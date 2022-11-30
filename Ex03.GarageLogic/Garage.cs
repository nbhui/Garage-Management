using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum eVehicleStateInGarage
{
    WorkInProgress,
    WorkComplete,
    Paid
}

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> garageVehicles;

        public Garage()
        {
            garageVehicles = new Dictionary<string, GarageVehicle>();
        }

        public bool AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNum)
        {
            if (i_Vehicle == null)
            {
                throw new ArgumentNullException();
            }
            bool vehicleExistsInGarage = garageVehicles.ContainsKey(i_Vehicle.VehicleData.LicensePlate);

            GarageVehicle vehicleInGarage;

            if (vehicleExistsInGarage)
            {
                ChangeExistingVehicleState(i_Vehicle.VehicleData.LicensePlate, eVehicleStateInGarage.WorkInProgress);
            }
            else
            {
                vehicleInGarage = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhoneNum);
                garageVehicles.Add(i_Vehicle.VehicleData.LicensePlate, vehicleInGarage);
            }

            return vehicleExistsInGarage;
        }
        public void ChangeExistingVehicleState(string i_LicenseNum, eVehicleStateInGarage i_NewVehicleState)
        {
            GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            vehicleInGarage.VehicleStateInGarage = i_NewVehicleState;
        }
        public void InflateVehicleWheelsToMax(string i_LicenseNum)
        {
            GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            foreach (Tire tire in vehicleInGarage.Vehicle.VehicleData.MyVehicleWheels)
            {
                tire.InflateTireToMax();
            }
        }

        public void AddGasToVehicle(string i_LicenseNum, GasolinePowerSource.eGasType i_GasType, float i_GasAmountToAdd)
        {
            GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            if (!(vehicleInGarage.Vehicle.VehicleData.EnergySource is GasolinePowerSource))
            {
                throw new IncompatibleEnergyType();
            }

            (vehicleInGarage.Vehicle.VehicleData.EnergySource as GasolinePowerSource).AddFuelToTank(i_GasAmountToAdd, i_GasType);
        }

        public void ChargeElectricVehicle(string i_LicenseNum, float i_ChargeAmount)
        {
            GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            if (!(vehicleInGarage.Vehicle.VehicleData.EnergySource is ElectricPowerSource))
            {
                throw new IncompatibleEnergyType();
            }

            (vehicleInGarage.Vehicle.VehicleData.EnergySource as ElectricPowerSource).ChargeBattery(i_ChargeAmount);
        }

        public string GetVehicleData(string i_LicenseNum)
        {
            GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            return vehicleInGarage.ToString();
        }

        private GarageVehicle getVehicleFromDictionary(string i_LicenseNum)
        {
            GarageVehicle garageVehicle;
            bool vehicleExists = garageVehicles.TryGetValue(i_LicenseNum, out garageVehicle);
            if (!vehicleExists)
            {
                garageVehicle = null;
            }

            return garageVehicle;
        }
        public List<string> GetLicenseNumbers()
        {
            List<string> licenseNums = new List<string>();
            foreach (string licenseNum in garageVehicles.Keys)
            {
                licenseNums.Add(licenseNum);
            }

            return licenseNums;
        }
        public List<string> GetLicenseNumbers(eVehicleStateInGarage i_StateInGarage)
        {
            List<string> licenseNumbers = new List<string>();
            foreach (GarageVehicle vehicleInGarage in garageVehicles.Values)
            {
                if (vehicleInGarage.VehicleStateInGarage == i_StateInGarage)
                {
                    licenseNumbers.Add(vehicleInGarage.Vehicle.VehicleData.LicensePlate);
                }
            }

            return licenseNumbers;
        }

        private class GarageVehicle
        {
            private string m_OwnerName;
            private string m_OwnerPhoneNumber;
            private eVehicleStateInGarage m_VehicleStateInGarage;
            private Vehicle m_Vehicle;

            public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerPhoneNumber = i_OwnerPhoneNumber;
                m_Vehicle = i_Vehicle;
                m_VehicleStateInGarage = eVehicleStateInGarage.WorkInProgress;
            }

            public eVehicleStateInGarage VehicleStateInGarage
            {
                get { return m_VehicleStateInGarage; }
                set { m_VehicleStateInGarage = value; }
            }

            public Vehicle Vehicle
            {
                get { return m_Vehicle; }
            }

            public string OwnerName
            {
                get { return m_OwnerName; }
            }

            public string OwnerPhoneNumber
            {
                get { return m_OwnerPhoneNumber; }
            }

            public override string ToString()
            {
                string vehicleDetails = String.Format(
                    "Owner Name: {1}{0}Owner Phone: {2}{0}Status in garage: {3}{0}",
                    Environment.NewLine,
                    OwnerName,
                    OwnerPhoneNumber,
                    VehicleStateInGarage);

                return Vehicle.ToString() + vehicleDetails;
            }
        }
    }
}
