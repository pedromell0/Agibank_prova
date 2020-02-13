using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Salesman
    {
        public string CPF { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public Salesman(string[] aLine)
        {
            CPF = aLine[1];
            Name = aLine[2];
            Salary = double.Parse(aLine[3]);
        }
    }
}
