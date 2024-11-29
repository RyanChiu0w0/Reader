using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderTest
{
    public class ReaderSettings : AutoCreator.ISettings
    {
        public string ListenIP { get; set; } /*= "169.254.124.170";*/
        public int ListenPort { get; set; } /*= 9004;*/
        public string ReaderIP { get; set; } /*= "169.254.0.1";*/
        public int ReaderPort { get; set; } /*= 9004;*/
        public int Timeout { get; set; } = 3000;
        
    }
}
