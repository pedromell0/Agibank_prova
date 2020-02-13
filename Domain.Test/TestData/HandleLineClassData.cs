using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Test.TestData
{
    public class HandleLineClassData : IEnumerable<object[]>
    {

        private readonly string tstData = @"001ç1234567891234çPedroç50000|001ç3245678865434çPauloç40000.99|002ç2345675434544345çJose da SilvaçRural|002ç2345675433444345çEduardo PereiraçRural|003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro|003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çCarol";

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { tstData, 2, 2, 10, "Carol" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
