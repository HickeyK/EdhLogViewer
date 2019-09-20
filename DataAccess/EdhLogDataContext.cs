using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using EdhLogViewer.Entities;

namespace DataAccess
{
    public class EdhLogDataContext : DataContext, IEdhLogDataContext
    {
        public EdhLogDataContext(
            string connectionString,
            MappingSource mappingSource,
            Boolean objectTrackingEnabled,
            int commandTimeout) : base(connectionString, mappingSource)
        {
            base.ObjectTrackingEnabled = ObjectTrackingEnabled;
            base.CommandTimeout = commandTimeout;
        }

        #region Linq Tables

        Table<ProcessLog> ProcessLog
        {
            get { return GetTable<ProcessLog>(); }
        }

        public Table<SchedulerComponentParameter> SchedulerComponentParameter
        {
            get { return GetTable<SchedulerComponentParameter>(); }
        }

        #endregion

        public List<ProcessLog> LastOneHundred()
        {
            return this.ProcessLog.Select(r => r).Take(100).ToList();
        }


        public List<ProcessLog> TimeQuery(DateTime fromDt, DateTime toDt)
        {
            return this.ProcessLog
                .Select(r => r)
                .Where(r => r.LogTime >= fromDt && r.LogTime <= toDt)
                .Take(100)
                .ToList();
        }


        public List<ProcessLog> NameStartsWithQuery(string processName)
        {
            return this.ProcessLog
                .Select(r => r)
                .Where(r => r.ProcessName.StartsWith(processName))
                .OrderByDescending(r => r.RunId)
                .Take(100)
                .ToList();
        }

        public List<ProcessLog> ParamsQuery(QueryParams queryParams)
        {
            return this.ProcessLog
                .Select(r => r)
                .Where(r => r.ProcessName.StartsWith(queryParams.ProcessName) &&
                            r.LogTime >= queryParams.StartDate &&
                            r.LogTime >= queryParams.EndDate)
                .OrderByDescending(r => r.RunId)
                .Take(100)
                .ToList();
        }




    }
}
