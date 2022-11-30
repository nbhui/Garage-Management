using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(Vehicle.eTypeOfVehicle i_TypeOfVehicle, Vehicle i_VehicleData)
        {
            Vehicle newVehicle = null;

            switch (i_TypeOfVehicle)
            {
                case Vehicle.eTypeOfVehicle.GasCar:
                    newVehicle = new GasolinePrivateCar(i_VehicleData as GasolinePrivateCar);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricCar:
                    newVehicle = new ElectricPrivateCar(i_VehicleData as ElectricPrivateCar);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_VehicleData as ElectricMotorcycle);
                    break;
                case Vehicle.eTypeOfVehicle.GasMotorcycle:
                    newVehicle = new GasolineMotorcycle(i_VehicleData as GasolineMotorcycle);
                    break;
                case Vehicle.eTypeOfVehicle.GasTruck:
                    newVehicle = new GasolineTruck(i_VehicleData as GasolineTruck);
                    break;
            }
            return newVehicle;
        }
    }
}
