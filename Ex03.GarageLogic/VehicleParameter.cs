using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleParameter
    {
        private Type m_Type;
        private string m_Description;

        public VehicleParameter(Type i_Type, string i_Description)
        {
            m_Type = i_Type;
            m_Description = i_Description;
        }

        public Type Type
        {
            get { return m_Type; }
        }

        public string Description
        {
            get { return m_Description; }
        }
    }
}

