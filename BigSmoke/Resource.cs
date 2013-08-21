using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSmoke
{
    class Resource
    {
        public enum TypeEnum
        {
            TOBACCO,
            PAPER,
            MATCHES
        };

        public TypeEnum Type { get; private set; }

        public Resource(Resource.TypeEnum type)
        {
            this.Type = type;
        }
    }
}
