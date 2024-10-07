using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    internal interface IVehicle
    {
        string RegistrationNumber { get; set; }
        VehicleColor Color { get; set; }
        int NrOfWheels { get; set; }
    }
}
