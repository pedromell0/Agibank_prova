using Domain.Entities;
using Domain.Test.TestData;
using System;
using Xunit;

namespace Domain.Test
{
    public class SaleLotTest
    {
        [Theory]
        [ClassData(typeof(HandleLineClassData))]
        public void HandleLinePath(string arr, int clientsQuant, int salesmanQuant, int idMostExpensive, string wrstSalesman)
        {
            SaleLot saleLot = new SaleLot("tst", "tst");

            foreach (var item in arr.Split('|'))
            {
                saleLot.HandleFileLine(item);
            }

            Assert.Equal(saleLot.Clients.Count, clientsQuant);
            Assert.Equal(saleLot.Salesmans.Count, salesmanQuant);
            Assert.Equal(saleLot.GetMostExpensiveSaleId(), idMostExpensive);
            Assert.Equal(saleLot.GetWhorstSalesman(), wrstSalesman);
        }

        [Theory]
        [ClassData(typeof(WontHandleLinePathClassData))]
        public void WontHandleLinePath(string arr)
        {
            SaleLot saleLot = new SaleLot("tst", "tst");

            foreach (var item in arr.Split('|'))
            {
                saleLot.HandleFileLine(item);
            }

            Assert.NotEmpty(saleLot.Errors);

        }

    }
}
