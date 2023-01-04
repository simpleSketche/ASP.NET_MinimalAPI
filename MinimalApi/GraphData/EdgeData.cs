using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public class EdgeData : IEdgeData
    {
        public int Source { get; set; }
        public int Target { get; set; }
        public HashSet<int> connection { get; set; }
    }
}
