using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class GasolinePrivateCar : PrivateCar
    {
        private const float k_GasTankCapacity = 55;
        private const GasolinePowerSource.eGasType k_GasType = GasolinePowerSource.eGasType.Octan98;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.GasCar;
        private GasolinePrivateCar gasolinePrivateCar;

        public GasolinePrivateCar(GasolinePrivateCar gasolinePrivateCar) : base(gasolinePrivateCar)
        {
            if (gasolinePrivateCar == null)
            {
                throw new IncompatibleVehicleDataException("gas car");
            }
        }

        public GasolinePrivateCar(
                          string i_ModelName,
                          string i_LicenseNum,
                          string i_WheelsManufacturer,
                          PrivateCar.eCarColor i_CarColor,
                          PrivateCar.eNumOfDoors i_NumOfDoors)
                         : base(
                         i_ModelName,
                         i_LicenseNum,
                         new GasolinePowerSource(k_GasTankCapacity, k_GasType),
                         i_WheelsManufacturer,
                         k_TypeOfVehicle,
                         i_CarColor,
                         i_NumOfDoors)
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
            (VehicleData.EnergySource as GasolinePowerSource).AddFuelToTank(i_FuelToAdd, i_GasType);
        }

    }

}
