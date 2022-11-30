using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
    {
        private readonly string m_ModelName;
        private readonly string m_LicenseNum;
        private readonly Vehicle.eTypeOfVehicle r_TypeOfVehicle;
        private List<Tire> m_Tires;
        private int m_NumOfWheels;
        private EnergySource m_EnergySource;

        public enum eTypeOfVehicle
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            GasTruck = 5
        }
        private Vehicle m_VehicleData;

        public Vehicle(Vehicle i_VehicleData)
        {
            m_VehicleData = i_VehicleData;
        }

        public Vehicle VehicleData
        {
            get { return m_VehicleData; }
        }


        public Vehicle(string i_ModelName,
            string i_LicensePlate,
            EnergySource i_EnergyType,
            string i_WheelsManufacturer,
            float i_MaxTirePressure,
            int i_NumOfWheels,
            eTypeOfVehicle i_TypeOfVehicle)
        {

            m_ModelName = i_ModelName;
            m_LicenseNum = i_LicensePlate;
            m_NumOfWheels = i_NumOfWheels;
            m_EnergySource = i_EnergyType;
            r_TypeOfVehicle = i_TypeOfVehicle;
            m_Tires = new List<Tire>();
            CreatVehicleTires(i_NumOfWheels, i_WheelsManufacturer, i_MaxTirePressure);
        }

        private void CreatVehicleTires(int i_NumOfWheels, string i_WheelsManufacturer, float i_WheelsMaxAirPressure)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Tires.Add(new Tire(i_WheelsManufacturer, i_WheelsMaxAirPressure));
            }
        }


        public string ModelName
        {
            get { return ModelName; }
        }

        public string LicensePlate
        {
            get { return LicensePlate; }
        }

        public EnergySource EnergySource
        {
            get { return m_EnergySource; }
        }

        public Vehicle.eTypeOfVehicle TypeOfVehicle
        {
            get { return r_TypeOfVehicle; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
        }

        public List<Tire> MyVehicleWheels
        {
            get { return m_Tires; }
        }

      

        public static List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = new List<VehicleParameter>();
            parameters.Add(new VehicleParameter(typeof(string), "model"));
            parameters.Add(new VehicleParameter(typeof(string), "license number"));
            parameters.Add(new VehicleParameter(typeof(string), "wheels manufacturer"));

            return parameters;
        }


        public override string ToString()
        {
            string vehicleData = string.Format(
                                 "Model name: {1}{0}License number: {2}{0}Number of wheels: {3}{0}",
                                 Environment.NewLine,
                                 m_ModelName,
                                 m_LicenseNum,
                                 m_NumOfWheels);

            return vehicleData + m_Tires[0].ToString() + EnergySource.ToString();
        }

    }
}
