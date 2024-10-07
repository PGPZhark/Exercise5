using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    internal interface IHandler
    {
        void AddVehicleToGarage(Garage<Vehicle> garage, Vehicle vehicle);
        void RemoveVehicleFromGarage(Garage<Vehicle> garage, string RegistrationNumber);
        void CreateGarage(int Capacity);
    }
}
