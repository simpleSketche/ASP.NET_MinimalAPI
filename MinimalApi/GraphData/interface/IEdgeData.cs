using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public interface IEdgeData
    {
        int source { get; set; }

        int target { get; set; }

        HashSet<int> connection { get; set; }
    }
}
