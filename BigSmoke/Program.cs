using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSmoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            Servant servant = new Servant();
            Smoker[] smokers = {
                new Smoker(Resource.TypeEnum.MATCHES),
                new Smoker(Resource.TypeEnum.TOBACCO),
                new Smoker(Resource.TypeEnum.PAPER)
            };

            SmokingRoom room = new SmokingRoom(table, servant, smokers);
            room.startSmoking();
        }
    }
}
