using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSmoke
{
    class Smoker
    {
        private Resource.TypeEnum productType;
        private Table table;
        private Thread smokerThread;
        private bool isSmoking = false;

        public Smoker(Resource.TypeEnum productType)
        {
            this.productType = productType;
        }

        public Resource getResource()
        {
            return new Resource(productType);
        }

        public void startWaitingForCigarIngridients(Table table)
        {
            this.table = table;

            smokerThread = new Thread(this.smokerThreadRoutine);
            smokerThread.Name = "Smoker [" + productType + "]";
            smokerThread.Start();
            View.message("Smoker [" + productType + "] started to wait for service...");
        }

        private void smokerThreadRoutine()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (!isSmoking && hasRequiredIngridientsToMakeACigar())
                {
                    View.message(" is ready to make a cigar");
                    table.pullResources(); //TODO: use retrieved resources to build new cigar
                    Cigar cigar = new Cigar();
                    startSmoking(cigar);
                }
            }
        }

        private bool hasRequiredIngridientsToMakeACigar()
        {
            List<Resource.TypeEnum> requiredIngridients = Cigar.getIngridientsList();
            List<Resource.TypeEnum> availableResources = getAvailableResources();

            foreach (Resource.TypeEnum ingridient in availableResources)
            {
                if ( requiredIngridients.Contains(ingridient) )
                {
                    requiredIngridients.RemoveAll((Resource.TypeEnum elem) => (elem == ingridient));
                }

                if ( requiredIngridients.Count == 0 )
                {
                    return true;
                }
            }

            return false;
        }

        private List<Resource.TypeEnum> getAvailableResources()
        {
            lock (table)
            {
                List<Resource> ingridientsOnTable = table.getResources();
                var ingridientTypesOnTable = from ingridient in ingridientsOnTable
                                             select ingridient.Type;
                List<Resource.TypeEnum> result = ingridientTypesOnTable.ToList<Resource.TypeEnum>();
                result.Add(productType);

                return result;
            }
        }

        private void startSmoking(Cigar cigar)
        {
            isSmoking = true;
            View.message(" has been started to smoke.");
            while (cigar.isBurning())
            {
                Thread.Sleep(800);
                cigar.use();
            }
            isSmoking = false;
            View.message(" has been finished the smoking.");
        }
    }
}