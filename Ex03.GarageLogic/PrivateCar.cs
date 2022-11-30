using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class PrivateCar : Vehicle
    {
        private const int k_CarWheelsMaxAirPressure = 28;
        private const int k_CarNumberOfWheels = 4;
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;
        public enum eCarColor
        {
            Red = 1,
            Yellow = 2,
            Black = 3,
            Silver = 4,
        }

        public enum eNumOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

      
        public PrivateCar(string i_ModelName,
                       string i_LicenseNum,
                       EnergySource i_EnergySource,
                       string i_WheelsManufacturer,
                       Vehicle.eTypeOfVehicle i_TypeOfVehicle,
                       eCarColor i_CarColor,
                       eNumOfDoors i_NumOfDoors)
                       : base(
                       i_ModelName,
                       i_LicenseNum,
                       i_EnergySource,
                       i_WheelsManufacturer,
                       k_CarWheelsMaxAirPressure,
                       k_CarNumberOfWheels,
                       i_TypeOfVehicle)
        {
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
        }

        public PrivateCar(Vehicle i_VehicleData) : base(i_VehicleData)
        {
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(eCarColor), "color of car"));
            parameters.Add(new VehicleParameter(typeof(eNumOfDoors), "number of doors"));

            return parameters;
        }

        public override string ToString()
        {
            string carData = string.Format("{0}Car Color: {1}{0}Number Of Doors: {2}{0}", Environment.NewLine, m_CarColor, m_NumOfDoors);

            return base.ToString() + carData;
        }
    }
}
