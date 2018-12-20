using System;
using System.Collections.Generic;
using ConsoleTables;

namespace ParkingLotSimulation
{
    class Program
    {
        //input and validate the string is number
        private static int GetUserInput()
        {
            int result = 0;
            bool isExit = false;
            while (!isExit)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("invalid input");
                    Console.WriteLine("please enter again");
                }
            }
            return result;
        }

        private static void Intialize(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter number of Two Wheeler Vehicles parking lot can contain");
            int numberOfTwoWheelerSlots = GetUserInput();
            for (int i = 0; i < numberOfTwoWheelerSlots; i++)
            {
                parkingLot.AddParkingSlot(new ParkingSlot(VehicleType.TwoWheeler));
            }

            Console.WriteLine("Enter number of Four Wheeler Vehicles parking lot can contain");
            int numberOfFourWheelerSlots = GetUserInput();
            for (int i = 0; i < numberOfFourWheelerSlots; i++)
            {
                parkingLot.AddParkingSlot(new ParkingSlot(VehicleType.FourWheeler));

            }

            Console.WriteLine("Enter number of Heavy Vehicles parking lot can contain");
            int numberofHeavyVehicleSlots = GetUserInput();
            for (int i = 0; i < numberofHeavyVehicleSlots; i++)
            {
                parkingLot.AddParkingSlot(new ParkingSlot(VehicleType.HeavyVehicle));
            }
        }

        private static void DisplayOccupancyDetails(ParkingLot parkingLot)
        {
            if (parkingLot.ParkingTickets.Count == 0)
            {
                Console.WriteLine("There are no vehicles parked!!");
            }
            else
            {
                var table = new ConsoleTable("Slot Number", "Vehicle Number", "Vehicle Type", "in-time", "out-time");
                foreach (var parkingTicket in parkingLot.ParkingTickets)
                {
                    if (!parkingTicket.IsExpired)
                    {
                        table.AddRow(parkingTicket.SlotNumber, parkingTicket.VehicleNumber, parkingTicket.VehicleType.ToString(), parkingTicket.InTime, parkingTicket.OutTime);
                    }
                }
                table.Write();
            }
            Console.WriteLine("press any key to continue..");
            Console.ReadKey();
        }

        /// <summary>
        /// park a vehicle based on their vehicle type
        /// </summary>
        /// <param name="parkingLot"></param>
        private static void ParkVehicle(VehicleType vehicleType , ParkingLot parkingLot)
        {
            ParkingSlot parkingSlot = parkingLot.GetAvailableSlot(vehicleType);
            if (parkingSlot != null)
            {
                Vehicle vehicle = GetVehicle(vehicleType);
                Console.WriteLine("enter vehicle number");
                int vehicleNumber = GetUserInput();
                if (!parkingLot.IsVehicleAndTicketExist(vehicleNumber))
                {
                    vehicle.VehicleNumber = vehicleNumber;
                    parkingLot.ParkVehicle(vehicle);
                    Console.WriteLine("your parking slot has been allocated");
                }
                else
                {
                    Console.WriteLine("vehicle number already exist");
                }
            }
            else
            {
                Console.WriteLine("Sorry,there are no slots available!!");
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        private static Vehicle GetVehicle(VehicleType vehicleType)
        {
            if (vehicleType.Equals(VehicleType.TwoWheeler))
            {
                return new Bike();
            }
            else if (vehicleType.Equals(VehicleType.FourWheeler))
            {
                return new Car();
            }
            else
            {
                return new Truck();
            }

        }
        private static void DisplayParkMenu(ParkingLot parkingLot)
        {
            Console.WriteLine("1. Two Wheeler");
            Console.WriteLine("2. Four Wheeler");
            Console.WriteLine("3. Heavy Vehicle");
            Console.WriteLine("select a vehicle type");
            int choice = GetUserInput();
            switch (choice)
            {
                case 1:
                    ParkVehicle(VehicleType.TwoWheeler, parkingLot);
                    break;

                case 2:
                    ParkVehicle(VehicleType.FourWheeler, parkingLot);
                    break;

                case 3:
                    ParkVehicle(VehicleType.HeavyVehicle , parkingLot);
                    break;

                default:
                    Console.WriteLine("option doesnt exist");
                    break;
            }
        }

        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();
            Intialize(parkingLot);

            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("1. Parking Lot Current Occupancy details");
                Console.WriteLine("2. Park a Vehicle");
                Console.WriteLine("3. UnPark a Vehicle");
                Console.WriteLine("0. Back");
                Console.WriteLine("please a select a menu option");
                int menuOption = GetUserInput();
                switch (menuOption)
                {
                    case 1:
                        DisplayOccupancyDetails(parkingLot);
                        break;

                    case 2:
                        DisplayParkMenu(parkingLot);
                        break;

                    case 3:
                        Console.WriteLine("PLease enter Vehicle Number");
                        int vehicleNumber = GetUserInput();
                        if ( parkingLot.IsVehicleNumberExist(vehicleNumber))
                        {
                            ParkingSlot parkingSlot = parkingLot.GetParkingSlotOfVehicleNumber(vehicleNumber);
                            parkingSlot.UnParkVehicle();
                            parkingLot.ChangeTicketStatus(parkingSlot.ParkingTicket);
                            Console.WriteLine("vehicle has been successfully Unparked");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Vehicle number doesnt exist");
                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                        }
                        break;

                    case 0:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("option doesnt exist");
                        break;
                }
            }
            
        }
    }
}
