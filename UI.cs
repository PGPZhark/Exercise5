using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercise_5
{
    internal class UI : IUI
    {
        // Reference to the Garage Handler
        GarageHandler handler = new GarageHandler();
        public void ViewAllVehiclesInGarage(Garage<Vehicle> garage)
        {
            // For every vehicle in garage type out what type of vehicle it is and their descriptions
            foreach (var vehicle in garage.GetEnumerable())
            {
                if (vehicle != null)
                {
                    Console.WriteLine("Vehicle: " + vehicle.GetType().Name);
                    Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}  Color: {vehicle.Color}  Wheels: {vehicle.NrOfWheels}");
                }
                else
                {
                    Console.WriteLine("Empty");
                }
            }
;
        }

        public void ViewAllVehicleTypes(Garage<Vehicle> garage)
        {
            // Removes all the empty spots to get all the vehicles in one list
            var allVehicles = from vehicle in garage.GetEnumerable()
                    where vehicle != null
                    select vehicle;

            // Seperates all the different types into their own lists
            var boats = from vehicle in allVehicles
                        where vehicle.GetType() == typeof(Boat)
                    select vehicle;
            var cars = from vehicle in allVehicles
                       where vehicle.GetType() == typeof(Car)
                       select vehicle;
            var busses = from vehicle in allVehicles
                         where vehicle.GetType() == typeof(Bus)
                         select vehicle;
            var airplanes = from vehicle in allVehicles
                            where vehicle.GetType() == typeof(Airplane)
                            select vehicle;
            var motorcycles = from vehicle in allVehicles
                              where vehicle.GetType() == typeof(Motorcycle)
                              select vehicle;

            
            // Writes out the amount of each type if they are in the garage.
            if (cars.ToList().Count != 0)
            {
                Console.WriteLine($"Amount of Cars: {cars.ToList().Count}");
            }
            if (boats.ToList().Count != 0)
            {
                Console.WriteLine($"Amount of Boats: {boats.ToList().Count}");
            }
            if (busses.ToList().Count != 0)
            {
                Console.WriteLine($"Amount of Busses: {busses.ToList().Count}");
            }
            if (airplanes.ToList().Count != 0)
            {
                Console.WriteLine($"Amount of Airplanes: {airplanes.ToList().Count}");
            }
            if (motorcycles.ToList().Count != 0)
            {
                Console.WriteLine($"Amount of Motorcycles: {motorcycles.ToList().Count}");
            }

        }
        public void Menu()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Clear();
                Console.Write("Navigate through the menu by using number inputs:");
                Console.WriteLine("(1, 2, 3, 4, 5, 6, 0)");
                Console.WriteLine("1. List All Vehicles in Garage");
                Console.WriteLine("2. List All Vehicle Types in Garage");
                Console.WriteLine("3. Add Vehicle to Garage");
                Console.WriteLine("4. Remove Vehicle from Garage");
                Console.WriteLine("5. Search in Garage");
                Console.WriteLine("6. Add New Garage");
                Console.WriteLine("0. Quit Application");
                Console.Write("User Input: ");
                // Saves input as a char. Sets it to the first part of the read line. If its empty asks for valid input. 
                char input = ' ';  
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter valid input");
                }
                switch (input)
                {
                    case '1':
                        Clear();
                        // If there is a garage already, calls ViewAllVehiclesInGarage function to... view all vehicles in the garage.
                        if (handler.Garage != null)
                        {
                            ViewAllVehiclesInGarage(handler.Garage);
                        }
                        else
                        {
                            Console.WriteLine("You need to create a garage first!");
                            Console.WriteLine("Input '6' while in the main menu to go to the create a garage menu.");
                        }
                        Console.Read();
                        break;
                    case '2':
                        Clear();
                        // Here again checks if there is a garage already then calls ViewAllVehicleTypes.
                        if (handler.Garage != null)
                        {
                            ViewAllVehicleTypes(handler.Garage);
                        }
                        else
                        {
                            Console.WriteLine("You need to create a garage first!");
                            Console.WriteLine("Input '6' while in the main menu to go to the create a garage menu.");
                        }
                        Console.Read();
                        break;
                    case '3':
                        Clear();
                        AddVehicleMenu();
                        Console.Read();
                        break;
                    case '4':
                        Clear();
                        RemoveVehicleMenu();
                        Console.Read();
                        break;
                    case '5':
                        Clear();
                        SearchVehicleMenu();
                        Console.Read();
                        break;
                    case '6':
                        Clear();
                        CreateGarageMenu();
                        Console.Read();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input: (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
        public void QuitApplication()
        {
            Environment.Exit(0);
        }


        private void CreateGarageMenu()
        {
            bool runningMenu = true;

            while (runningMenu)
            {
                //Checks if there is a garage already, if not adds one. If one already exists you can choose to replace it with a new one or not.
                if (handler.Garage != null)
                {
                    Console.WriteLine("Garage already exists. Want to create a new one? Y/N?");
                    char input = ' ';
                    try
                    {
                        input = Console.ReadLine()![0];
                    }
                    catch
                    {
                        Console.WriteLine("Please enter Y for Yes or N for No");
                    }
                    switch (input)
                    {
                        case 'Y':
                            Console.WriteLine("Add a Garage");
                            Console.Write("Set Garage Capacity: ");
                            int capacity;
                            try
                            {
                                capacity = int.Parse(Console.ReadLine());
                                if (capacity <= 0)
                                {
                                    Console.WriteLine("Minimum Capacity is 1. Setting Capacity to 1...");
                                    capacity = 1;
                                }
                                handler.CreateGarage(capacity);
                                runningMenu = false;
                                Console.WriteLine("Garage added");

                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter some input!");
                            }
                            break;
                        case 'N':
                            runningMenu = false;
                            break;
                        default:
                            Console.WriteLine("Please enter valid input.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Add a Garage");
                    Console.Write("Set Garage Capacity: ");
                    int capacity;
                    try
                    {
                        capacity = int.Parse(Console.ReadLine());
                        handler.CreateGarage(capacity);
                        runningMenu = false;
                        Console.WriteLine("Garage added");
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter valid input.");
                    }
                }

            }
        }
        private void AddVehicleMenu()
        {
            if (handler.Garage != null)
            {
                if (handler.Garage.IsFull())
                {
                    Console.WriteLine("Garage is full.");
                }
                else
                {
                    bool runningTypeMenu = true;
                    bool runningRegNumMenu = true;
                    bool runningColorMenu = true;
                    bool runningWheelMenu = true;
                    Console.WriteLine("Add Vehicle Menu to Garage");
                    Type type = typeof(Vehicle);
                    string regNum = "ABC123";
                    VehicleColor color = VehicleColor.None;
                    int nrOfWheels = 0;


                    while (runningTypeMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("First of all select a type");
                        Console.WriteLine("Types are: Airplane, Motorcycle, Boat, Car, Bus");
                        Console.Write("Vehicle Type: ");
                        string input = "";
                        try
                        {
                            input = Console.ReadLine()!;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter some input!");
                        }
                        if (input.ToUpper() == "AIRPLANE")
                        {
                            type = typeof(Airplane);
                            runningTypeMenu = false;
                        }
                        else if (input.ToUpper() == "MOTORCYCLE")
                        {
                            type = typeof(Motorcycle);
                            runningTypeMenu = false;
                        }
                        else if (input.ToUpper() == "BOAT")
                        {
                            type = typeof(Boat);
                            runningTypeMenu = false;
                        }
                        else if (input.ToUpper() == "CAR")
                        {
                            type = typeof(Car);
                            runningTypeMenu = false;
                        }
                        else if (input.ToUpper() == "BUS")
                        {
                            type = typeof(Bus);
                            runningTypeMenu = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter correct input.");
                        }
                    }
                    while (runningRegNumMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Vehicle Type: " + type.Name);
                        Console.WriteLine("Secondly, set a registration number for the vehicle. Maximum of 6 characters");
                        Console.WriteLine("Example: ABC123");
                        Console.Write("Registration Number: ");
                        string input = "";
                        try
                        {
                            input = Console.ReadLine()!;
                            input = input.Substring(0, 6);
                            regNum = input.ToUpper();
                            runningRegNumMenu = false;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter some input!");
                        }
                    }
                    while (runningColorMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Vehicle Type: " + type.Name);
                        Console.WriteLine("Registration Number: " + regNum);
                        Console.WriteLine("Thirdly, set a color for the vehicle.");
                        Console.WriteLine("Example: Black, White, Blue, Red, Yellow, Grey etc...");
                        Console.Write("Color: ");
                        string input = "";
                        try
                        {
                            input = Console.ReadLine()!;
                            input = input.ToUpper();
                            try
                            {
                                color = (VehicleColor)Enum.Parse(typeof(VehicleColor), input);
                                runningColorMenu = false;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid color!");
                            }
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid color!");
                        }
                    }
                    while (runningWheelMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Vehicle so far: ");
                        Console.WriteLine("Vehicle Type: " + type.Name);
                        Console.WriteLine("Registration Number: " + regNum);
                        Console.WriteLine("Color: " + color);
                        Console.WriteLine("Almost done. Now set a number of wheels for the vehicle.");
                        Console.WriteLine("Example: 0, 2, 4 etc...");
                        Console.Write("Number of wheels: ");
                        string input = "";
                        try
                        {
                            input = Console.ReadLine()!;

                            nrOfWheels = int.Parse(input);
                            if (nrOfWheels < 0)
                            {
                                Console.WriteLine("Please enter valid input!");
                                nrOfWheels = 0;
                            }
                            else
                            {
                                runningWheelMenu = false;
                            }
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter valid input!");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Vehicle so far: ");
                    Console.WriteLine("Vehicle Type: " + type.Name);
                    Console.WriteLine("Registration Number: " + regNum);
                    Console.WriteLine("Color: " + color);
                    Console.WriteLine("Number of Wheels: " + nrOfWheels);

                    bool finalMenu = true;

                    switch (type.Name)
                    {
                        case "Airplane":
                            int nrOfEngines = 0;
                            while (finalMenu)
                            {
                                Console.WriteLine("Since the vehicle type is an Airplane, we need to set number of engines.");
                                Console.Write("Number of Engines: ");
                                string input = "";
                                try
                                {
                                    input = Console.ReadLine()!;
                                    nrOfEngines = int.Parse(input);
                                    if (nrOfEngines < 0)
                                    {
                                        Console.WriteLine("Please enter valid input!");
                                    }
                                    else
                                    {
                                        Airplane airplane = new Airplane(regNum, color, nrOfWheels, nrOfEngines);
                                        handler.AddVehicleToGarage(handler.Garage, airplane);
                                        finalMenu = false;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid number.");
                                }
                            }
                            Console.WriteLine("Vehicle added!");
                            break;
                        case "Car":
                            CarFuelType fuelType = CarFuelType.PETROL;
                            while (finalMenu)
                            {
                                Console.WriteLine("Since the vehicle type is a Car, we need to set the cars Fuel Type (Diesel/Petrol).");
                                Console.Write("Fuel Type (Diesel/Petrol): ");
                                string input = "";
                                try
                                {
                                    input = Console.ReadLine()!;

                                    if (input.ToUpper() == "DIESEL")
                                    {
                                        fuelType = CarFuelType.DIESEL;
                                        Car car = new Car(regNum, color, nrOfWheels, fuelType);
                                        handler.AddVehicleToGarage(handler.Garage, car);
                                        finalMenu = false;
                                    }
                                    else if (input.ToUpper() == "PETROL")
                                    {
                                        fuelType = CarFuelType.PETROL;
                                        Car car = new Car(regNum, color, nrOfWheels, fuelType);
                                        handler.AddVehicleToGarage(handler.Garage, car);
                                        finalMenu = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter valid input!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid input.");
                                }
                            }
                            Console.WriteLine("Vehicle added!");
                            break;
                        case "Boat":
                            float length;
                            while (finalMenu)
                            {
                                Console.WriteLine("Since the vehicle type is a Boat, we need to set the boats length (in meters).");
                                Console.Write("Length (in meters): ");
                                string input = "";
                                try
                                {
                                    input = Console.ReadLine()!;
                                    length = int.Parse(input);
                                    if (length <= 1)
                                    {
                                        Console.WriteLine("Please enter valid input! The boat has to be at least 1 meter long.");
                                    }
                                    else
                                    {
                                        Boat boat = new Boat(regNum, color, nrOfWheels, length);
                                        handler.AddVehicleToGarage(handler.Garage, boat);
                                        finalMenu = false;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid input.");
                                }
                            }
                            Console.WriteLine("Vehicle added!");
                            break;
                        case "Bus":
                            int nrOfSeats;
                            while (finalMenu)
                            {
                                Console.WriteLine("Since the vehicle type is a Bus, we need to set the number of seats in the bus.");
                                Console.Write("Number of seats: ");
                                string input = "";
                                try
                                {
                                    input = Console.ReadLine()!;
                                    nrOfSeats = int.Parse(input);
                                    if (nrOfSeats <= 0)
                                    {
                                        Console.WriteLine("Please enter valid input!");
                                    }
                                    else
                                    {
                                        Bus bus = new Bus(regNum, color, nrOfWheels, nrOfSeats);
                                        handler.AddVehicleToGarage(handler.Garage, bus);
                                        finalMenu = false;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid input.");
                                }
                            }
                            Console.WriteLine("Vehicle added!");
                            break;
                        case "Motorcycle":
                            float cylinderVolume;
                            while (finalMenu)
                            {
                                Console.WriteLine("Since the vehicle type is a Motorcycle, we need to set the cylinder volume for the Motorcycle.");
                                Console.Write("Cylinder Volume: ");
                                string input = "";
                                try
                                {
                                    input = Console.ReadLine()!;
                                    cylinderVolume = float.Parse(input);
                                    if (cylinderVolume <= 0)
                                    {
                                        Console.WriteLine("Please enter valid input!");
                                    }
                                    else
                                    {
                                        Motorcycle motorcycle = new Motorcycle(regNum, color, nrOfWheels, cylinderVolume);
                                        handler.AddVehicleToGarage(handler.Garage, motorcycle);
                                        finalMenu = false;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid input.");
                                }
                            }
                            Console.WriteLine("Vehicle added!");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need to create a garage first!");
                Console.WriteLine("Input '6' while in the main menu to go to the create a garage menu.");
            }
        }

        private void RemoveVehicleMenu()
        {
            if (handler.Garage != null)
            {
                bool runningMenu = true;
                
                while(runningMenu)
                {
                    Console.WriteLine("Remove a Vehicle from Garage.");
                    Console.Write("Type their Registration Number to remove them: ");
                    string input = "";

                    input = Console.ReadLine();
                    if (input.Length != 6)
                    {
                        Console.WriteLine("Please enter valid input!");
                    }
                    else
                    {
                        input = input.ToUpper();
                        handler.RemoveVehicleFromGarage(handler.Garage, input);
                        runningMenu = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need to create a garage first!");
                Console.WriteLine("Input '6' while in the main menu to go to the create a garage menu.");
            }
        }
        
        private void SearchVehicleMenu()
        {
            if (handler.Garage != null)
            {
                bool runningMenu = true;
                bool searchByType = false;
                bool searchByColor = false;
                bool searchByNrOfWheels = false;
                while (runningMenu)
                {
                    Console.Clear();
                    Console.WriteLine("Search for Vehicle");
                    Console.WriteLine("Enter 1, 2 or 3 to add/remove from search: ");
                    Console.WriteLine($"1. Search by Vehicle Type ({searchByType})");
                    Console.WriteLine($"2. Search by Color ({searchByColor})");
                    Console.WriteLine($"3. Search by Number of Wheels ({searchByNrOfWheels})");
                    Console.WriteLine("0. Continue Search");
                    Console.Write("User Input: ");
                    char input = ' ';
                    try
                    {
                        input = Console.ReadLine()![0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter valid input");
                    }
                    switch (input)
                    {
                        case '1':
                            if (searchByType)
                            {
                                searchByType = false;
                            }
                            else
                            {
                                searchByType = true;
                            }
                            break;
                        case '2':
                            if (searchByColor)
                            {
                                searchByColor = false;
                            }
                            else
                            {
                                searchByColor = true;
                            }
                            break;
                        case '3':
                            if (searchByNrOfWheels)
                            {
                                searchByNrOfWheels = false;
                            }
                            else
                            {
                                searchByNrOfWheels = true;
                            }
                            break;
                        case '0':
                            if (searchByType && searchByNrOfWheels && searchByColor)
                            {
                                bool runningEnterType = true;
                                bool runningEnterColor = true;
                                bool runningEnterWheels = true;
                                Type type = typeof(Vehicle);
                                VehicleColor color = VehicleColor.None;
                                int nrOfWheels = 0;
                                while (runningEnterType)
                                {
                                    Clear();
                                    Console.Write("Enter Type: ");
                                    string typeInput = "";
                                    try
                                    {
                                        typeInput = Console.ReadLine()!;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                    if (typeInput.ToUpper() == "AIRPLANE")
                                    {
                                        type = typeof(Airplane);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "MOTORCYCLE")
                                    {
                                        type = typeof(Motorcycle);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BOAT")
                                    {
                                        type = typeof(Boat);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "CAR")
                                    {
                                        type = typeof(Car);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BUS")
                                    {
                                        type = typeof(Bus);
                                        runningEnterType = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter correct input.");
                                    }
                                }

                                while (runningEnterColor)
                                {
                                    Clear();
                                    Console.Write("Enter Color: ");
                                    string colorInput = "";
                                    try
                                    {
                                        colorInput = Console.ReadLine()!;
                                        colorInput = colorInput.ToUpper();
                                        try
                                        {
                                            color = (VehicleColor)Enum.Parse(typeof(VehicleColor), colorInput);
                                            runningEnterColor = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid color!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }
                                
                                while (runningEnterWheels)
                                {
                                    Clear();
                                    Console.Write("Enter Number of Wheels: ");
                                    string wheelInput = "";
                                    try
                                    {
                                        wheelInput = Console.ReadLine()!;
                                        try
                                        {
                                            nrOfWheels = int.Parse(wheelInput);
                                            if (nrOfWheels < 0)
                                            {
                                                Console.WriteLine("Please enter valid input!");
                                                nrOfWheels = 0;
                                            }
                                            else
                                            {
                                                runningEnterWheels = false;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid input!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.GetType() == type && vehicle.Color == color && vehicle.NrOfWheels == nrOfWheels
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (searchByType && searchByNrOfWheels && !searchByColor)
                            {
                                bool runningEnterType = true;
                                bool runningEnterWheels = true;
                                Type type = typeof(Vehicle);
                                int nrOfWheels = 0;
                                while (runningEnterType)
                                {
                                    Clear();
                                    Console.Write("Enter Type: ");
                                    string typeInput = "";
                                    try
                                    {
                                        typeInput = Console.ReadLine()!;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                    if (typeInput.ToUpper() == "AIRPLANE")
                                    {
                                        type = typeof(Airplane);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "MOTORCYCLE")
                                    {
                                        type = typeof(Motorcycle);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BOAT")
                                    {
                                        type = typeof(Boat);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "CAR")
                                    {
                                        type = typeof(Car);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BUS")
                                    {
                                        type = typeof(Bus);
                                        runningEnterType = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter correct input.");
                                    }
                                }

                                while (runningEnterWheels)
                                {
                                    Clear();
                                    Console.Write("Enter Number of Wheels: ");
                                    string wheelInput = "";
                                    try
                                    {
                                        wheelInput = Console.ReadLine()!;
                                        try
                                        {
                                            nrOfWheels = int.Parse(wheelInput);
                                            if (nrOfWheels < 0)
                                            {
                                                Console.WriteLine("Please enter valid input!");
                                                nrOfWheels = 0;
                                            }
                                            else
                                            {
                                                runningEnterWheels = false;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid input!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.GetType() == type && vehicle.NrOfWheels == nrOfWheels
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (searchByType && !searchByNrOfWheels && searchByColor)
                            {
                                bool runningEnterType = true;
                                bool runningEnterColor = true;
                                Type type = typeof(Vehicle);
                                VehicleColor color = VehicleColor.None;
                                while (runningEnterType)
                                {
                                    Clear();
                                    Console.Write("Enter Type: ");
                                    string typeInput = "";
                                    try
                                    {
                                        typeInput = Console.ReadLine()!;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                    if (typeInput.ToUpper() == "AIRPLANE")
                                    {
                                        type = typeof(Airplane);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "MOTORCYCLE")
                                    {
                                        type = typeof(Motorcycle);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BOAT")
                                    {
                                        type = typeof(Boat);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "CAR")
                                    {
                                        type = typeof(Car);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BUS")
                                    {
                                        type = typeof(Bus);
                                        runningEnterType = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter correct input.");
                                    }
                                }

                                while (runningEnterColor)
                                {
                                    Clear();
                                    Console.Write("Enter Color: ");
                                    string colorInput = "";
                                    try
                                    {
                                        colorInput = Console.ReadLine()!;
                                        colorInput = colorInput.ToUpper();
                                        try
                                        {
                                            color = (VehicleColor)Enum.Parse(typeof(VehicleColor), colorInput);
                                            runningEnterColor = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid color!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.GetType() == type && vehicle.Color == color
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (searchByType && !searchByNrOfWheels && !searchByColor)
                            {
                                bool runningEnterType = true;
                                Type type = typeof(Vehicle);
                                while (runningEnterType)
                                {
                                    Clear();
                                    Console.Write("Enter Type: ");
                                    string typeInput = "";
                                    try
                                    {
                                        typeInput = Console.ReadLine()!;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                    if (typeInput.ToUpper() == "AIRPLANE")
                                    {
                                        type = typeof(Airplane);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "MOTORCYCLE")
                                    {
                                        type = typeof(Motorcycle);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BOAT")
                                    {
                                        type = typeof(Boat);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "CAR")
                                    {
                                        type = typeof(Car);
                                        runningEnterType = false;
                                    }
                                    else if (typeInput.ToUpper() == "BUS")
                                    {
                                        type = typeof(Bus);
                                        runningEnterType = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter correct input.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.GetType() == type
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (!searchByType && searchByNrOfWheels && searchByColor)
                            {
                                bool runningEnterColor = true;
                                bool runningEnterWheels = true;
                                VehicleColor color = VehicleColor.None;
                                int nrOfWheels = 0;
                                
                                while (runningEnterColor)
                                {
                                    Clear();
                                    Console.Write("Enter Color: ");
                                    string colorInput = "";
                                    try
                                    {
                                        colorInput = Console.ReadLine()!;
                                        colorInput = colorInput.ToUpper();
                                        try
                                        {
                                            color = (VehicleColor)Enum.Parse(typeof(VehicleColor), colorInput);
                                            runningEnterColor = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid color!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                while (runningEnterWheels)
                                {
                                    Clear();
                                    Console.Write("Enter Number of Wheels: ");
                                    string wheelInput = "";
                                    try
                                    {
                                        wheelInput = Console.ReadLine()!;
                                        try
                                        {
                                            nrOfWheels = int.Parse(wheelInput);
                                            if (nrOfWheels < 0)
                                            {
                                                Console.WriteLine("Please enter valid input!");
                                                nrOfWheels = 0;
                                            }
                                            else
                                            {
                                                runningEnterWheels = false;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid input!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.Color == color && vehicle.NrOfWheels == nrOfWheels
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (!searchByType && searchByNrOfWheels && !searchByColor)
                            {
                                
                                bool runningEnterWheels = true;
                                int nrOfWheels = 0;

                                while (runningEnterWheels)
                                {
                                    Clear();
                                    Console.Write("Enter Number of Wheels: ");
                                    string wheelInput = "";
                                    try
                                    {
                                        wheelInput = Console.ReadLine()!;
                                        try
                                        {
                                            nrOfWheels = int.Parse(wheelInput);
                                            if (nrOfWheels < 0)
                                            {
                                                Console.WriteLine("Please enter valid input!");
                                                nrOfWheels = 0;
                                            }
                                            else
                                            {
                                                runningEnterWheels = false;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid input!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }

                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.NrOfWheels == nrOfWheels
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else if (!searchByType && !searchByNrOfWheels && searchByColor)
                            {
                                bool runningEnterColor = true;
                                VehicleColor color = VehicleColor.None;

                                while (runningEnterColor)
                                {
                                    Clear();
                                    Console.Write("Enter Color: ");
                                    string colorInput = "";
                                    try
                                    {
                                        colorInput = Console.ReadLine()!;
                                        colorInput = colorInput.ToUpper();
                                        try
                                        {
                                            color = (VehicleColor)Enum.Parse(typeof(VehicleColor), colorInput);
                                            runningEnterColor = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter a valid color!");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter valid type.");
                                    }
                                }
                                try
                                {
                                    var search = from vehicle in handler.Garage.GetEnumerable()
                                                 where vehicle != null && vehicle.Color == color
                                                 select vehicle;
                                    TypeOutSearch(search);
                                }
                                catch
                                {
                                    Console.WriteLine("Nothing found in search");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cannot continue without search parameters.");
                            }
                            runningMenu = false;
                            break;
                        default:
                            Console.WriteLine("Please enter some valid input: (1, 2, 3, 0)");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need to create a garage first!");
                Console.WriteLine("Input '6' while in the main menu to go to the create a garage menu.");
            }
        }

        private void TypeOutSearch(IEnumerable<Vehicle>? search)
        {
            Clear();
            Console.WriteLine($"Vehicles found in search: {search!.ToList().Count}");
            foreach (var vehicle in search!)
            {
                Console.WriteLine("Vehicle: " + vehicle.GetType().Name);
                Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}  Color: {vehicle.Color}  Wheels: {vehicle.NrOfWheels}");
            }
        }
    }
}
