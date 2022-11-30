using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricPowerSource : EnergySource
    {
        private float m_TimeLeftInBattery;
        private readonly float r_BatteryMaxUseTime;

        public ElectricPowerSource(float i_capacity) : base(i_capacity)
        {
        }

        public void ChargeBattery(float i_TimeToCharge)
        {
            AddEnergy(i_TimeToCharge);
        }

        public override string ToString()
        {
            return "Energy type: Gas" + base.ToString();
        }
    }
}
