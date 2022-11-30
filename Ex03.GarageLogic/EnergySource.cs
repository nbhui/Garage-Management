using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private readonly float r_MaxEnergy;
        private float m_RemainingEnergy;

        public EnergySource(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_RemainingEnergy = r_MaxEnergy;
        }
        public float MaxEnergy
        {
            get { return r_MaxEnergy; }
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
        }

        public float RemainingEnergyPercent
        {
            get { return r_MaxEnergy / m_RemainingEnergy * 100; }
        }

        protected void AddEnergy(float i_AddedEnergyAmount)
        {
            if (i_AddedEnergyAmount <= 0 || m_RemainingEnergy + i_AddedEnergyAmount > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy - m_RemainingEnergy, 0);
            }

            m_RemainingEnergy += i_AddedEnergyAmount;
        }

        public override string ToString()
        {
            string EnergySourceData = string.Format(
                                      "Max energy: {1}{0}" +
                                      "Remaining energy percent: {2}%{0}",
                                       Environment.NewLine,
                                       r_MaxEnergy,
                                       RemainingEnergyPercent);
            return EnergySourceData;
        }

    }
}
