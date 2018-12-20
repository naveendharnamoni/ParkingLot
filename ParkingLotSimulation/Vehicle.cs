using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class Vehicle
    {
        public int VehicleNumber { get; set; }
        public VehicleType Type { get; protected set; }
    }

    public enum VehicleType
    {
        TwoWheeler,
        FourWheeler,
        HeavyVehicle
    };
}
