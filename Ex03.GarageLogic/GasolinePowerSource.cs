using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolinePowerSource : EnergySource
    {

        private eGasType m_GasType;
       
        public GasolinePowerSource(float i_GasTankCapacity, eGasType i_GasType)
            : base(i_GasTankCapacity)
        {
            m_GasType = i_GasType;
        }
        public eGasType GasType
        {
            get { return m_GasType; }
        }
        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }
        public void AddFuelToTank(float i_LiterAddToTank, eGasType i_GasType)
        {
            if (m_GasType != i_GasType)
            {
                throw new ArgumentException();
            }

            AddEnergy(i_LiterAddToTank);
        }
        public override string ToString()
        {
            string gasTankData = string.Format(
                                    "Energy type: Gas{0}" +
                                    "Gas type: {1}",
                                    Environment.NewLine,
                                    m_GasType);

            return base.ToString() + gasTankData;
        }

    }
}
