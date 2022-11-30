using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle:Motorcycle
    {
        private const float k_MaxBatteryTime = 2.2f;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.ElectricMotorcycle;
        private ElectricMotorcycle electricMotorcycle;

        public ElectricMotorcycle(ElectricMotorcycle i_ElectricMotorCycleData)
         : base(i_ElectricMotorCycleData)
        {
            if (i_ElectricMotorCycleData == null)
            {
                throw new IncompatibleVehicleDataException("electric motorcycle");
            }
        }

        public ElectricMotorcycle(
                                     string i_ModelName,
                                     string i_LicenseNum,
                                     string i_WheelsManufacturer,
                                     Motorcycle.eMotorCycleLicenseType i_LicenseType,
                                     int i_EngineCapacity)
                                    : base(
                                    i_ModelName,
                                    i_LicenseNum,
                                    new ElectricPowerSource(k_MaxBatteryTime),
                                    i_WheelsManufacturer,
                                    k_TypeOfVehicle,
                                    i_LicenseType,
                                    i_EngineCapacity)
        {
        }
        public float MaxBatteryTime
        {
            get { return k_MaxBatteryTime; }
        }
        public void ChargeBattery(float i_HoursToAdd)
        {
            (VehicleData.EnergySource as ElectricPowerSource).ChargeBattery(i_HoursToAdd);

        }

    }
}
