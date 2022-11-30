using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Tire(string i_Manufacturer, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_MaxAirPressure; //New Wheel Gets Max Air Pressure
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }
        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }   
        public void InflateTire(float i_AirAmountToInflate)
        {
            if(CurrentAirPressure + i_AirAmountToInflate > MaxAirPressure || i_AirAmountToInflate<=0)
            {
                throw new ValueOutOfRangeException(MaxAirPressure - CurrentAirPressure, 0); 
            }
            m_CurrentAirPressure = i_AirAmountToInflate;
        }
        public void InflateTireToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public override string ToString()
        {
            string wheelData = string.Format(
                               "Manufacturer Name: {1}{0}Current Air Pressure: {2}{0}Max Air Pressure: {3}{0}",
                               Environment.NewLine,
                               m_Manufacturer,
                               m_CurrentAirPressure,
                               r_MaxAirPressure);
            return wheelData;
        }

    }
}
