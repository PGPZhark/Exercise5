using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    internal interface IUI
    {
        public void ViewAllVehiclesInGarage(Garage<Vehicle> garage);
        public void ViewAllVehicleTypes(Garage<Vehicle> garage);
        public void Menu();
        public void Clear();
        public void QuitApplication();
    }
}
