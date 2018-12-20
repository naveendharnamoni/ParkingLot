using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingSlot
    {
        public ParkingTicket ParkingTicket { get; set; }
        public bool isAvailable { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleType VehicleType { get; set; }
        public int SlotNumber { get; set; }
        static int count = 0;

        public ParkingSlot(VehicleType vehicleType)
        {
            isAvailable = true;
            this.VehicleType = vehicleType;
            SlotNumber = ++count;
        }

        public int ParkAVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            ChangeSlotStatus(false);
            return SlotNumber;
        }

        public void ChangeSlotStatus(bool status)
        {
            isAvailable = status;
        }

        public void UnParkVehicle()
        {
            Vehicle = null;
            ChangeSlotStatus(true);
            ParkingTicket.ChangeExpiryStatus(true);
        }
       
    }
}
