using System;
using System.Collections.Generic;
using System.Data.Linq;
using EdhLogViewer.Entities;

namespace DataAccess
{
    public interface IEdhLogDataContext : IDisposable
    {

        Table<ProcessLog> ProcessLog { get; }

        Table<SchedulerComponentParameter> SchedulerComponentParameter { get; }

        List<ProcessLog> LastOneHundred();

        List<ProcessLog> TimeQuery(DateTime fromDt, DateTime toDt);

        List<ProcessLog> NameStartsWithQuery(string processName);

        List<ProcessLog> ParamsQuery(QueryParams queryParams);
    }
}
