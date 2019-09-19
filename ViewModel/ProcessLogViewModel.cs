using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EdhLogViewer.Entities;
using System.Runtime.CompilerServices;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ViewModel
{
    public class ProcessLogViewModel : INotifyPropertyChanged, IDisposable
    {

        //public IUnitOfWork AvDataContext { get; set; }
        public IEdhLogDataContext EdhLogDataContext { get; set; }

        public ObservableCollection<ProcessLog> LogMessages { get; set; }

        public DelegateCommand<string> RetrieveByProcessNameCommand { get; private set; }
        public DelegateCommand<QueryParamsViewModel> RetrieveByParamsCommand { get; private set; }

        // Temp constructor till I get IOC wired up
        public ProcessLogViewModel()
        {

            var databaseConfigFileName = "EdhLogViewer.database.config";
            var installationDirectory = @"c:\Dev\EdhLogViewer\DataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            EdhLogDataContext = new EdhLogDataContext("Data Source=EDHDBSIT01,65000;Initial Catalog=ODS_SIT01;Integrated Security=True", mappingSource, false, 60);


            RetrieveByProcessNameCommand = new DelegateCommand<string>(new Action<string>(i =>
            {
                LogMessages = new ObservableCollection<ProcessLog>(EdhLogDataContext.NameStartsWithQuery(i));
                OnPropertyChanged("LogMessages");
            }));

            RetrieveByParamsCommand = new DelegateCommand<QueryParamsViewModel>(new Action<QueryParamsViewModel>(i =>
            {
                var queryParams = new QueryParams();
                queryParams.ProcessName = i.ProcessName;

                queryParams.StartDate = i.FromDateTime;
                queryParams.EndDate = i.ToDateTime;

                LogMessages = new ObservableCollection<ProcessLog>(EdhLogDataContext.ParamsQuery(queryParams));
                OnPropertyChanged("LogMessages");
            }));

            QueryParamsViewModel = new QueryParamsViewModel();

            //LogMessages = new ObservableCollection<ProcessLog> (EdhLogDataContext.NameStartsWithQuery("1000"));
        }


        // Intending to use this one when IOC is wired up
        public ProcessLogViewModel(IEdhLogDataContext dc)
        {
            EdhLogDataContext = dc;

            RetrieveByProcessNameCommand = new DelegateCommand<string>(new Action<string>(i =>
            {
                LogMessages = new ObservableCollection<ProcessLog>(EdhLogDataContext.NameStartsWithQuery(i));
                OnPropertyChanged("LogMessages");
            }));
        }


        private void GetRequests()
        {

            //var param = new StoreYbAnalyticReq()
            //{
            //    //RunDate = SelectedRequestGroup.RunDate,
            //    //ValDate = SelectedRequestGroup.ValDate,
            //    //Slot = SelectedRequestGroup.Slot,
            //    PortfolioId = portfolio
            //};

            LogMessages = new ObservableCollection<ProcessLog>(EdhLogDataContext.NameStartsWithQuery("1000"));
            OnPropertyChanged("LogMessages");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public QueryParamsViewModel QueryParamsViewModel { get; set; }


        public void Dispose()
        {
            EdhLogDataContext.Dispose();
        }
    }
}
