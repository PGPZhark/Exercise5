using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public enum VehicleColor
    {
        None = 0,
        RED,
        BLUE,
        GREEN,
        YELLOW,
        PURPLE,
        WHITE,
        BLACK,
        BROWN,
        GREY,
        GOLD,
    }
    internal class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; } 
        public VehicleColor Color { get; set; }
        public int NrOfWheels { get; set; }
    }

    internal class Airplane : Vehicle
    {
        public int NrOfEngines;

        public Airplane(string RegistrationNumber, VehicleColor Color, int NrOfWheels, int NrOfEngines)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NrOfWheels = NrOfWheels;
            this.NrOfEngines = NrOfEngines;
        }
    }

    internal class Motorcycle : Vehicle
    {
        public float CylinderVolume;

        public Motorcycle(string RegistrationNumber, VehicleColor Color, int NrOfWheels, float CylinderVolume)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NrOfWheels = NrOfWheels;
            this.CylinderVolume = CylinderVolume;
        }
    }

    public enum CarFuelType
    {
        DIESEL,
        PETROL
    }
    internal class Car : Vehicle
    {
        

        public CarFuelType FuelType;

        public Car(string RegistrationNumber, VehicleColor Color, int NrOfWheels, CarFuelType FuelType)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NrOfWheels = NrOfWheels;
            this.FuelType = FuelType;
        }
    }

    internal class Bus : Vehicle
    {
        public int NrOfSeats;

        public Bus(string RegistrationNumber, VehicleColor Color, int NrOfWheels, int NrOfSeats)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NrOfWheels = NrOfWheels;
            this.NrOfSeats = NrOfSeats;
        }
    }

    internal class Boat : Vehicle
    {
        public float Length;

        public Boat(string RegistrationNumber, VehicleColor Color, int NrOfWheels, float Length)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NrOfWheels = NrOfWheels;
            this.Length = Length;
        }
    }
}
