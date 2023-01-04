using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public interface IGraphDataHandler
    {
        List<INodeData> Nodes { get; set; }

        List<IEdgeData> Edges { get; set; }

        string SerializeNodes();

        string SerializeEdges();

        string TEST();
    }
}
