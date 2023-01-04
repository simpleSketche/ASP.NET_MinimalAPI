using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public interface IEdgeData
    {
        int Source { get; set; }

        int Target { get; set; }

        HashSet<int> connection { get; set; }
    }
}
