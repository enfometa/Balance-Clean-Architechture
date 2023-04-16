using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Core.Entities
{
    public class RequestLog : EntityBase
    {
        public string Route { get; set; }
        public string UserAgent { get; set; }
        public string Host { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
