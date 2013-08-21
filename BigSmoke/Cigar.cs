using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSmoke
{
    class Cigar
    {
        
        public static List<Resource.TypeEnum> getIngridientsList()
        {
            return (new Resource.TypeEnum[] {
                Resource.TypeEnum.TOBACCO,
                Resource.TypeEnum.PAPER,
                Resource.TypeEnum.MATCHES
            }).ToList();
        }

        private const int MAX_USE_COUNT = 5;
        private int useCount = 0;

        public Cigar()
        {

        }

        public void use()
        {
            View.message("☻ ☺ ☻");
            ++useCount;
        }

        public bool isBurning()
        {
            return useCount <= MAX_USE_COUNT;
        }
    }
}
