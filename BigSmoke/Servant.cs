using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSmoke
{
    class Servant
    {
        private Table table;
        private Smoker[] smokers;
        private Thread servantThread;
        private Random random = new Random();

        public void setTable(Table table)
        {
            this.table = table;
        }

        public void startService(Smoker[] smokers)
        {
            this.smokers = smokers;

            servantThread = new Thread(this.servantRoutineMain);
            servantThread.Name = "Servant";

            View.message("Servant starting ...");
            servantThread.Start();
        }

        private void servantRoutineMain()
        {
            while ( true )
            {
                Thread.Sleep(100);
                if (table.empty())
                {
                    View.message("Table is empty!");

                    int first = getRand();
                    int second = getRandExcept(first);

                    Resource firstResource = smokers[first].getResource();
                    Resource secondResource = smokers[second].getResource();

                    table.putResource(firstResource);
                    table.putResource(secondResource);
                }
            }
        }

        private int getRandExcept(int except)
        {
            int result;
            do
            {
                result = getRand();
            } while ( result == except );

            return result;
        }

        private int getRand()
        {
            return random.Next(this.smokers.Length);
        }
    }
}
