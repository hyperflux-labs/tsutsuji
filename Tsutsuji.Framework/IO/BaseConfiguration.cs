using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsutsuji.Framework.IO
{
    public class BaseConfiguration : Configuration
    {
        public Dictionary<string, List<KeyValuePair<string, dynamic>>> configValues = new Dictionary<string, List<KeyValuePair<string, dynamic>>>();
       
        public BaseConfiguration(Dictionary<string, List<KeyValuePair<string, dynamic>>> config)
        {
            configValues = config;
            return;
        }
    }
}
