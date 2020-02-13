using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain.Test.TestData
{
    class WontHandleLinePathClassData : IEnumerable<object[]>
    {

        private readonly string tstData = @"001ç1234567891234çPedroç52g0|001ç3245678865434çPauloç40000.99|002ç2345675434544345çJose da SilvaçRural|002ç2345675433444345çEduardo PereiraçRural|003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro|003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çCarol";
        private readonly string tstData2 = @"001ç1234567891234çPedroç50000|001ç3245678865434çPauloç40000.99|022ç2345675434544345çJose da SilvaçRural|002ç2345675433444345çEduardo PereiraçRural|003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro|003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çCarol";
        private readonly string tstData3 = @"001ç1234567891234çPedroç50000|001ç3245678865434çPauloç40000.99|002ç2345675434544345çJose da SilvaçRural|002ç2345675433444345çEduardo PereiraçRural|003ç10ç[1-1ye-100,2-30-2.50,3-40-3.10]çPedro|003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çCarol";

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { tstData };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
