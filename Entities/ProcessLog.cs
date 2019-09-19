using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdhLogViewer.Entities
{
    public class ProcessLog
    {
        public int LogId { get; set; }
        public int RunId { get; set; }
        public DateTime LogTime { get; set; }
        public string LogMessage { get; set; }
        public short MessageType { get; set; }
        public string ProcessType { get; set; }
        public string ProcessName { get; set; }
    }
}



