using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle:Vehicle
    {
        private int m_EngineSize;
        private const int k_NumOfWheels = 2;
        private const int k_MaxTirePressure = 28;
        private eMotorCycleLicenseType m_LicenseType;


        public enum eMotorCycleLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }



        public Motorcycle(
                             string i_ModelName,
                             string i_LicenseNum,
                             EnergySource i_EnergySource,
                             string i_WheelsManufacturer,
                             Vehicle.eTypeOfVehicle i_TypeOfVehicle,
                             eMotorCycleLicenseType i_LicenseType,
                            int i_EngineCapacity)
                            : base(
                                  i_ModelName,
                                  i_LicenseNum,
                                  i_EnergySource,
                                  i_WheelsManufacturer,
                                  k_MaxTirePressure,
                                  k_NumOfWheels,
                                  i_TypeOfVehicle)
        {
            m_LicenseType = i_LicenseType;
            m_EngineSize = i_EngineCapacity;
        }

        public Motorcycle(Vehicle i_VehicleData) : base(i_VehicleData)
        {
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = Vehicle.GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(Vehicle.eTypeOfVehicle), "license Type"));
            parameters.Add(new VehicleParameter(typeof(int), "engine capacity"));

            return parameters;
        }

        public eMotorCycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }
        public int EngineCapacity
        {
            get { return m_EngineSize; }
        }
        public override string ToString()
        {
            string motorCycleData = string.Format(
                                    "{0}License type: {1}{0}Engine Volume: {2}{0}",
                                     Environment.NewLine,
                                     m_LicenseType,
                                     m_EngineSize);
            return base.ToString() + motorCycleData;
        }
    }
}
