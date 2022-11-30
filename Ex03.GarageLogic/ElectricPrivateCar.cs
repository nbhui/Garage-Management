using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricPrivateCar : PrivateCar
    {
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.ElectricCar;
        private const float k_MaxBatteryTime = 2.5f;

        public ElectricPrivateCar(ElectricPrivateCar i_ElectricCarData)
            : base(i_ElectricCarData)
        {
            if (i_ElectricCarData == null)
            {
                throw new IncompatibleVehicleDataException("electric Car");
            }
        }

        public ElectricPrivateCar ( 
                             string i_ModelName,
                             string i_LicenseNum,
                             string i_WheelsManufacturer,
                             PrivateCar.eCarColor i_CarColor,
                             PrivateCar.eNumOfDoors i_NumOfDoors)
                             : base(
                             i_ModelName,
                             i_LicenseNum,
                             new ElectricPowerSource(k_MaxBatteryTime),
                             i_WheelsManufacturer,
                             k_TypeOfVehicle,
                             i_CarColor,
                             i_NumOfDoors)
        {
        }
        public float MaxBatteryTime
        {
            get { return k_MaxBatteryTime; }
        }

        public ElectricPrivateCar electricPrivateCar { get; }

        public void ChargeBattery(float i_HoursToAdd)
        {
            (VehicleData.EnergySource as ElectricPowerSource).ChargeBattery(i_HoursToAdd);
        }
    }
}
