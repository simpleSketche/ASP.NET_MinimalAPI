namespace GraphData
{
    public interface IGraphData
    {
        public List<INodeData> nodes { get; set; }

        public List<IEdgeData> edges { get; set; }
    }
}
