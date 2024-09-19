using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class HabitTemplate
    {
        public string Type { get; set; }
        public string Hive { get; set; }
        public string Key { get; set; }
        public string ValueName { get; set; }
        public object GoodValue { get; set; }
        public object BadValue { get; set; }
        public string AppName { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
    }

}