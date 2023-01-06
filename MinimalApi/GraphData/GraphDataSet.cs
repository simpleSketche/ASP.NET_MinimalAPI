using GraphData;

namespace MinimalApi
{
    public class GraphDataSet : IGraphData
    {
        public List<INodeData> nodes { get; set; }
        public List<IEdgeData> edges { get; set; }
    }
}
