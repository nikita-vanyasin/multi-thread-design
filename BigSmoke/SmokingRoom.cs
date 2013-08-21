using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSmoke
{
    class SmokingRoom
    {
        private Table table;
        private Servant servant;
        private Smoker[] smokers;

        public SmokingRoom(Table table, Servant servant, Smoker[] smokers)
        {
            this.table = table;
            this.servant = servant;
            this.smokers = smokers;
        }

        public void startSmoking()
        {
            foreach (Smoker smoker in smokers)
            {
                smoker.startWaitingForCigarIngridients(table);
            }

            servant.setTable(table);
            servant.startService(smokers);
        }
    }
}
