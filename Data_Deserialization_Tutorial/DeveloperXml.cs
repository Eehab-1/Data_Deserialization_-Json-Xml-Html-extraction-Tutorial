using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Deserialization_Tutorial
{


    [Serializable]
   public  class DeveloperXml
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public Decimal Salary { get; set; }

    }



}
