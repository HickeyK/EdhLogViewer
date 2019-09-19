using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class QueryParamsViewModel
    {

        private string processName;

        string strFromDateTime;
        DateTime? fromDateTime;
        string strToDateTime;
        DateTime? toDateTime;

        string maxRows;
        string runId;

        public string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        public string StrFromDateTime
        {
            get { return strFromDateTime; }
            set
            {
                DateTime newValue;
                if (DateTime.TryParse(value, out newValue))
                {
                    FromDateTime = newValue;
                    strFromDateTime = value;
                }
            }
        }
        public DateTime? FromDateTime
        {
            get { return FromDateTime; }
            set
            {
                FromDateTime = value;
                strFromDateTime = value.ToString();
            }
        }

        public string StrToDateTime
        {
            get { return strToDateTime; }
            set
            {
                DateTime newValue;
                if (DateTime.TryParse(value, out newValue))
                {
                    ToDateTime = newValue;
                    strToDateTime = value.ToString();
                }
            }
        }

        public DateTime? ToDateTime
        {
            get { return ToDateTime; }
            set
            {
                ToDateTime = value;
                strToDateTime = value.ToString();
            }
        }


        public string MaxRows
        {
            get { return maxRows; }
            set { maxRows = value; }
        }

        public string RunId
        {
            get { return runId; }
            set { runId = value; }
        }


        public QueryParamsViewModel AllParams
        {
            get { return this; }
        }


    }
}
