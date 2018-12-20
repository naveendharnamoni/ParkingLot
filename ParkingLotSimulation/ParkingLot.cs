using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingLot
    {
        public List<ParkingSlot> ParkingSlots { get; set; }
        public List<ParkingTicket> ParkingTickets { get; set; }

        public ParkingLot()
        {
            ParkingSlots = new List<ParkingSlot>();
            ParkingTickets = new List<ParkingTicket>();
        }

        public bool IsVehicleNumberExist(int vehicleNumber)
        {
            return ParkingSlots.Exists(slot => slot.ParkingTicket != null && slot.ParkingTicket.VehicleNumber == vehicleNumber);
        }
        public bool IsVehicleAndTicketExist(int vehicleNumber)
        {
            return ParkingSlots.Exists(slot => slot.ParkingTicket != null && slot.ParkingTicket.VehicleNumber == vehicleNumber && !slot.ParkingTicket.IsExpired);
        }
        public ParkingSlot GetAvailableSlot(VehicleType vehicleType)
        {
            return ParkingSlots.FirstOrDefault(slot => slot.isAvailable == true && slot.VehicleType == vehicleType);
        }

        public ParkingSlot GetParkingSlotOfVehicleNumber(int vehicleNumber)
        {
           return ParkingSlots.Find(slot => slot.ParkingTicket != null && slot.ParkingTicket.VehicleNumber == vehicleNumber);
        }

        public ParkingTicket IssueTicket(int vehicleNumber, VehicleType vehicleType, int slotNumber)
        {
            ParkingTicket parkingTicket = new ParkingTicket { VehicleNumber = vehicleNumber, VehicleType = vehicleType, SlotNumber = slotNumber };
            ParkingTickets.Add(parkingTicket);
            return parkingTicket;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            ParkingSlot parkingSlot = GetAvailableSlot(vehicle.Type);
            int slotNumber = parkingSlot.ParkAVehicle(vehicle);
            parkingSlot.ParkingTicket = IssueTicket(vehicle.VehicleNumber, vehicle.Type , slotNumber);
        }

        public void ChangeTicketStatus(ParkingTicket parkingTicket)
        {
            ParkingTickets.Find(ticket => ticket.Equals(parkingTicket)).ChangeExpiryStatus(true);
        }

        public void AddParkingSlot(ParkingSlot parkingSlot)
        {
            ParkingSlots.Add(parkingSlot);
        }
    }
}
