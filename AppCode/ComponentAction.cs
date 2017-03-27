using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MsCrmTools.SolutionComponentManager.AppCode
{
    internal class ComponentAction
    {
        public Entity Solution { get; set; }
        public List<Entity> Components { get; set; }

    }
}
