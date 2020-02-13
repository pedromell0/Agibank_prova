using System;

namespace Domain.Entities
{
    public class Client
    {
        public string CNPJ { get; set; }

        public string Name { get; set; }

        public string BusinessArea { get; set; }

        public Client(string[] aLine)
        {
            CNPJ = aLine[1];
            Name = aLine[2];
            BusinessArea = aLine[3];
        }

    }
}
