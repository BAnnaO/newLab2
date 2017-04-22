using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    interface InameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();        
    }
}
