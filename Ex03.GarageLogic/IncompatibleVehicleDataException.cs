using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class IncompatibleVehicleDataException : Exception
    {
        private string m_ExpectedVehicleData;

        public IncompatibleVehicleDataException(string i_ExpectedVehicleData)
        {
            m_ExpectedVehicleData = i_ExpectedVehicleData;
        }

        public string VehicleType
        {
            get { return m_ExpectedVehicleData; }
        }
    }
}
