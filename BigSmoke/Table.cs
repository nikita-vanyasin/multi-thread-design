using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSmoke
{
    class Table
    {
        private List<Resource> resources = new List<Resource>();

        public void putResource(Resource resource)
        {
            View.message("Resource [" + resource.Type + "] has been added to table");
            resources.Add(resource);
        }

        public bool empty()
        {
            return resources.Count() == 0;
        }

        public List<Resource> getResources()
        {
            return this.resources;
        }

        public List<Resource> pullResources()
        {
            var result = new List<Resource>(this.resources);
            this.resources.Clear();

            View.message("All resources has been pulled from table.");

            return result;
        }
    }
}
