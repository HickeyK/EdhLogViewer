using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataAccess.Tests
{
    public class DatabaseFixture
    {
        public EdhLogDataContext EdhLogDataContext { get; set; }


        public DatabaseFixture()
        {
            var databaseConfigFileName = "EdhLogViewer.database.config";
            var installationDirectory = @"c:\Dev\EdhLogViewer\DataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            EdhLogDataContext = new EdhLogDataContext("Data Source=EDHDBSIT01,65000;Initial Catalog=ODS_SIT01;Integrated Security=True", mappingSource, false, 30);

        }

        public void Dispose()
        {
            EdhLogDataContext.Dispose();
        }

    }
}
