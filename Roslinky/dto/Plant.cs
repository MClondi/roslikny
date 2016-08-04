using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roslinky.dto
{
    public class Plant
    {
        public string name { get; set; }
        public string notes { get; set; }
        public string photoPath { get; set; }
        public string hyperlink { get; set; }
        public List<string> types { get; set; }
    }
}
