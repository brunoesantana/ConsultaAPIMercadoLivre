using System.Collections.Generic;
using TesteIderis.CrossCutting.Mock.Interface;
using TesteIderis.CrossCutting.Util;

namespace TesteIderis.CrossCutting.Mock
{
    public class DataMock : IDataMock
    {
        public DataMock()
        {
        }

        public IList<string> GetItemsParameters()
        {
            return new List<string>
            {
                ContantUtil.ID_ITEM_1,
                ContantUtil.ID_ITEM_2,
                ContantUtil.ID_ITEM_3,
                ContantUtil.ID_ITEM_4
            };
        }
    }
}