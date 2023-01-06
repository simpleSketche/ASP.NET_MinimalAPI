using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalApi;
using Newtonsoft.Json;

namespace GraphData
{
    public class GraphDataHandler:IGraphDataHandler
    {
        private static GraphDataHandler instance = new GraphDataHandler();
        public static GraphDataHandler Instance { get { return instance; } }
        private GraphDataHandler()
        {
            Nodes = new List<INodeData>();
            Edges = new List<IEdgeData>();
        }

        public List<INodeData> Nodes { get; set; }
        public List<IEdgeData> Edges { get; set; }
        public IGraphData Graph { get; set; }

        public string TEST()
        {
            return "HELOO THERE!";
        }
        public string SerializeNodes()
        {
            CreateNodeData();
            string jsonStr = JsonConvert.SerializeObject(Nodes);
            return jsonStr;
        }
        public string SerializeEdges()
        {
            CreateEdgeData();
            string jsonStr = JsonConvert.SerializeObject(Edges);
            return jsonStr;
        }

        public string CreateGraphData()
        {
            CreateNodeData();
            CreateEdgeData();

            IGraphData graphData = new GraphDataSet();
            graphData.nodes = Nodes;
            graphData.edges = Edges;
            Graph = graphData;

            string jsonStr = JsonConvert.SerializeObject(Graph);
            return jsonStr;
        }

        private void CreateNodeData()
        {
            Nodes.Clear();

            int numNodes = 20;
            for(int i = 0; i < numNodes; i++)
            {
                NodeData curNode = new NodeData();
                curNode.name = i.ToString();
                curNode.id = i;
                Nodes.Add(curNode);
            }
        }

        private bool IsEdgeExisted(HashSet<int> edge1, List<HashSet<int>> edgeList)
        {
            foreach(HashSet<int> edge in edgeList)
            {
                if (edge1.SetEquals(edge))
                {
                    return true;
                }
                continue;
            }
            return false;
        }

        private void CreateEdgeData()
        {
            Edges.Clear();

            int numNodes = Nodes.Count;

            Random rand = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);

            List<HashSet<int>> addedSets = new List<HashSet<int>>();

            for(int i = 0; i < numNodes; i++)
            {
                int numNeighbors = rand.Next(numNodes / 2);

                for(int j = 0; j < numNeighbors; j++)
                {
                    EdgeData curEdge = new EdgeData();
                    curEdge.source = i;
                    curEdge.target = j;
                    curEdge.connection = new HashSet<int> { i, j };

                    bool isContained = IsEdgeExisted(curEdge.connection, addedSets);

                    if(!isContained && i != j)
                    {
                        Edges.Add(curEdge);
                        addedSets.Add(curEdge.connection);
                    }

                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
