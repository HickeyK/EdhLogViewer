using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdhLogViewer.Entities
{
    public class QueryParams
    {
        public string ProcessName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxRows { get; set; }
        public long RunId { get; set; }

    }
}
