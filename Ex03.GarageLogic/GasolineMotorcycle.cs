using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolineMotorcycle:Motorcycle
    {
        private const float k_GasTankCapacity = 7;
        private const GasolinePowerSource.eGasType k_GasType = GasolinePowerSource.eGasType.Octan95;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.GasMotorcycle;
        private GasolineMotorcycle gasolineMotorcycle;

        public GasolineMotorcycle(GasolineMotorcycle i_GasMotorCycleData)
             : base(i_GasMotorCycleData)
        {
            if (i_GasMotorCycleData == null)
            {
                throw new IncompatibleVehicleDataException("gas motorcycle");
            }
        }

        public GasolineMotorcycle(
                                string i_ModelName,
                                string i_LicenseNum,
                                string i_WheelsManufacturer,
                                Motorcycle.eMotorCycleLicenseType i_LicenseType,
                                int i_EngineCapacity)
                                : base(
                                i_ModelName,
                                i_LicenseNum,
                                new GasolinePowerSource(k_GasTankCapacity, k_GasType),
                                i_WheelsManufacturer,
                                k_TypeOfVehicle,
                                i_LicenseType,
                                i_EngineCapacity)
        {
        }

        public float GasTankCapacity
        {
            get { return k_GasTankCapacity; }
        }

        public GasolinePowerSource.eGasType GasType
        {
            get { return k_GasType; }
        }

        public void AddFuel(float i_FuelToAdd, GasolinePowerSource.eGasType i_GasType)
        {
            (EnergySource as GasolinePowerSource).AddFuelToTank(i_FuelToAdd, i_GasType);
        }

    }    
}
