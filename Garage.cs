using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Exercise_5
{
    internal class Garage<T> where T : Vehicle
    {
        
        public readonly int capacity;
        private Vehicle[] vehicles;

        public int Count => vehicles.Length;

        
        // Checks if garages is full by checking if there is an element in vehicles that is null (open spot)
        public bool IsFull()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle! == null)
                {
                    return false;
                }
            }

            return true;

            /*
            if (vehicles[capacity - 1]! == null)
            {
                return false;
            }
            else
                return true;*/
        }

        public Garage(int capacity) 
        {
            this.capacity = capacity;
            vehicles = new Vehicle[capacity];
        }

        public bool Add(Vehicle vehicle)
        {
            // Adds vehicle to vehicles if it isnt null and if vehicles isnt already full
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));
            if (IsFull())
            {
                Console.WriteLine("Garage is full!");
                return false;
            }

            vehicles[FindFirstOpenIndex()] = vehicle;
            return true;
        }
        public void Remove(string RegistrationNumber)
        {
            // Removes vehicle from its spot by checking its registration number. (Removes the first item only)
            try
            {
                var index = Array.FindIndex(vehicles, vehicle => vehicle != null && vehicle.RegistrationNumber == RegistrationNumber);
                vehicles.SetValue(null, index);
                Console.WriteLine("Vehicle removed.");
            }
            catch
            {
                Console.WriteLine("Vehicle with that Registration Number not found. Please try another number.");
            }
        }

        public IEnumerable<T> GetEnumerable()
        {
            var res = new List<T>();

            foreach (var vehicle in vehicles)
            {
                res.Add((T)vehicle);
            }

            return res;
        }

        // Finds the first open spot in the garage
        private int FindFirstOpenIndex()
        {
            int firstEmpty = Array.IndexOf(vehicles, null);

            return firstEmpty;
        }

        internal object GetEnumerable<T>()
        {
            throw new NotImplementedException();
        }
    }
}
