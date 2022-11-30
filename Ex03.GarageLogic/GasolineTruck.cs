using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class GasolineTruck : Vehicle
    {
        private bool m_IsTransporingHazardMaterials;
        private const float k_ContentMaxWeight = 1000.5f;
        private const int k_NumOfWheels = 16;
        private const float k_MaxTirePressure = 42;
        private const float k_MaxLiterInTank = 86f;
        private GasolinePowerSource m_PowerSource;
        private const GasolinePowerSource.eGasType k_GasType = GasolinePowerSource.eGasType.Octan96;
        private readonly float r_Volume;

      
        public GasolineTruck(
            string i_ModelName,
            string i_LicenseNum,
            EnergySource i_EnergyType,
            int i_NumOfWheels,
            string i_WheelsManufacturer,
            float i_WheelsMaxAirPressure,
            Vehicle.eTypeOfVehicle i_TypeOfVehicle,
            float i_Volume,
            bool i_IsTransportingHazardMaterials)
            : base(i_ModelName, i_LicenseNum, i_EnergyType, i_WheelsManufacturer, i_WheelsMaxAirPressure, i_NumOfWheels, i_TypeOfVehicle)
        {
            r_Volume = i_Volume;
            m_IsTransporingHazardMaterials = i_IsTransportingHazardMaterials;
        }

        public GasolineTruck(Vehicle i_VehicleData) : base(i_VehicleData)
        {
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = Vehicle.GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(float), "Maximum volume"));
            parameters.Add(new VehicleParameter(typeof(bool), "vehicle carrying hazard materials"));

            return parameters;
        }

        public override string ToString()
        {
            string GasTank = string.Format(
                               "{0}Max volume allowed: {1}{0}" +
                               "Is transporing hazardous materials: {2}{0}",
                               Environment.NewLine,
                               r_Volume,
                               m_IsTransporingHazardMaterials);

            return base.ToString() + GasTank;
        }
    }
}
