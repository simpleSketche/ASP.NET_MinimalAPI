using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public class EdgeData : IEdgeData
    {
        public int source { get; set; }
        public int target { get; set; }
        public HashSet<int> connection { get; set; }
    }
}
