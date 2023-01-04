using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CreateGraphData();
        }

        public List<INodeData> Nodes { get; set; }
        public List<IEdgeData> Edges { get; set; }

        public string TEST()
        {
            return "HELOO THERE!";
        }
        public string SerializeNodes()
        {
            string jsonStr = JsonConvert.SerializeObject(Nodes);
            return jsonStr;
        }
        public string SerializeEdges()
        {
            string jsonStr = JsonConvert.SerializeObject(Edges);
            return jsonStr;
        }

        private void CreateGraphData()
        {
            CreateNodeData();
            CreateEdgeData();
        }

        private void CreateNodeData()
        {
            int numNodes = 20;
            for(int i = 0; i < numNodes; i++)
            {
                NodeData curNode = new NodeData();
                curNode.Name = i.ToString();
                curNode.Id = i;
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
            int numNodes = Nodes.Count;

            Random rand = new Random();

            List<HashSet<int>> addedSets = new List<HashSet<int>>();

            for(int i = 0; i < numNodes; i++)
            {
                int numNeighbors = rand.Next(numNodes / 2);

                for(int j = 0; j < numNeighbors; j++)
                {
                    EdgeData curEdge = new EdgeData();
                    curEdge.Source = i;
                    curEdge.Target = j;
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
