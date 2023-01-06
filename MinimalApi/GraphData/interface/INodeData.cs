using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public interface INodeData
    {
        int id { get; set; }

        string name { get; set; }
    }
}
