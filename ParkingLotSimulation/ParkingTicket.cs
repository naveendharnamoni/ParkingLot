using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingTicket
    {
        public int VehicleNumber { get; set; }
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool IsExpired { get; set; }

        public ParkingTicket()
        {
            InTime = DateTime.Now;
            OutTime = InTime.Add(new TimeSpan(0, 30, 0));
            IsExpired = false;
        }
        public void ChangeExpiryStatus(bool status)
        {
            IsExpired = status;
        }
    }
}
