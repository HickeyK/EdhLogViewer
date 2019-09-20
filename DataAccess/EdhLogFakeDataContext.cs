using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdhLogViewer.Entities;

namespace DataAccess
{
    public class EdhLogFakeDataContext : IEdhLogDataContext
    {
        //private DataTable ProcessLog;
        private List<ProcessLog> ProcessLog;

        public EdhLogFakeDataContext()
        {
            ProcessLog = this.ConvertCSVtoDataTable(@"D:\Code\SampleDB\SAMPLE_LOG_DATA.txt")
                        .AsEnumerable()
                        .Select(r => new ProcessLog(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString(), r[5].ToString(), r[6].ToString()))
                        .ToList();

            ;
        }


        public Table<SchedulerComponentParameter> SchedulerComponentParameter => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<ProcessLog> LastOneHundred()
        {
            return this.ProcessLog
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
                .ToList(); ;
        }



        public List<ProcessLog> TimeQuery(DateTime fromDt, DateTime toDt)
        {
            return this.ProcessLog
               .Select(r => r)
               .Where(r => r.LogTime >= fromDt && r.LogTime <= toDt)
               .Take(100)
               .ToList();
        }


        public List<ProcessLog> ParamsQuery(QueryParams queryParams)
        {

            var query = this.ProcessLog.AsQueryable();
            if (!string.IsNullOrEmpty(queryParams.ProcessName))
            {
                query = query.Where(r => r.ProcessName == queryParams.ProcessName);
            }
            if (queryParams.StartDate.HasValue)
            {
                query = query.Where(r => r.LogTime >= queryParams.StartDate);
            }
            if (queryParams.EndDate.HasValue)
            {
                query = query.Where(r => r.LogTime <= queryParams.EndDate);
            }

            return query
                .Select(r => r)
                .OrderByDescending(r => r.RunId)
                .Take(100)
                .ToList();


                       //&& r.LogTime >= queryParams.StartDate
                       //&& r.LogTime >= queryParams.EndDate

        }



        private DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split('\t');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), "\t");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
