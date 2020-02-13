using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class SaleLot
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public IList<Client> Clients { get; set; }

        public IList<Salesman> Salesmans { get; set; }

        public IList<Sale> Sales { get; set; }

        public IList<string> Errors { get; set; }


        public SaleLot(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;

            Sales = new List<Sale>();
            Salesmans = new List<Salesman>();
            Clients = new List<Client>();
            Errors = new List<string>();
        }

        public void HandleFileLine(string line)
        {
            var aLine = line.Split('ç');

            if (aLine.Length <= 0)
            {
                Errors.Add("Empty line");
            }

            string sDataType = aLine[0];

            if (!Enum.TryParse(sDataType, out DataType dataType))
            {
                Errors.Add($"Int32.TryParse could not parse '{sDataType}' to an int.");
            }

            try
            {
                switch (dataType)
                {
                    case DataType.Client:
                        HandleClientLine(aLine);
                        break;
                    case DataType.SalesMan:
                        HandleSalesManLine(aLine);
                        break;
                    case DataType.Sale:
                        HandleSaleLine(aLine);
                        break;
                }
            }
            catch (FormatException ex)
            {
                Errors.Add($"Erro de formatação: {ex.Message}");
            }
        }

        public int GetMostExpensiveSaleId() => (Sales.Count > 0) ? Sales.Aggregate((l, r) => l.GetSaleTotal() > r.GetSaleTotal() ? l : r).SaleId : 0;

        public string GetWhorstSalesman() => (Sales.Count > 0) ? Sales.Aggregate((l, r) => l.GetSaleTotal() < r.GetSaleTotal() ? l : r).SalesmanName : string.Empty;

        public string GetErrors() => Errors?.Aggregate((l, r) => l + '\n' + r);


        #region Privates

        private void HandleClientLine(string[] aLine)
        {
            Client client = new Client(aLine);
            Clients.Add(client);
        }

        private void HandleSalesManLine(string[] aLine)
        {
            Salesman salesman = new Salesman(aLine);
            Salesmans.Add(salesman);
        }

        private void HandleSaleLine(string[] aLine)
        {
            Sale sale = new Sale(aLine);
            Sales.Add(sale);
        }

        #endregion Privates
    }
}
