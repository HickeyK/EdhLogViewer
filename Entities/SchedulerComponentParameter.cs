using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdhLogViewer.Entities
{
    public class SchedulerComponentParameter
    {
        public string SchedulerProcessName { get; set; }
        public string ParamName { get; set; }
        public string ParamType { get; set; }
        public string ParamValue { get; set; }
        public DateTime CadisInserted { get; set; }
        public DateTime CadisUpdated { get; set; }
        public string CadisChangedBy { get; set; }
    }
}

