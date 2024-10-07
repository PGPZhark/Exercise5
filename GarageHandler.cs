using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    internal class GarageHandler : IHandler
    {
        public Garage<Vehicle> Garage { get; set; }

        public void AddVehicleToGarage(Garage<Vehicle> garage, Vehicle vehicle)
        {
            garage.Add(vehicle);
        }
        public void RemoveVehicleFromGarage(Garage<Vehicle> garage, string RegistrationNumber)
        {
            garage.Remove(RegistrationNumber);
        }
        public void CreateGarage(int Capacity)
        {
            Garage = new Garage<Vehicle>(Capacity);
        }
        
        

    }
}
