﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData
{
    public interface INodeData
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
