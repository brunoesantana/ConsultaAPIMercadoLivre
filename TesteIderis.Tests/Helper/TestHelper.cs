using System;
using System.Collections.Generic;
using System.Linq;
using TesteIderis.CrossCutting.Mock;
using TesteIderis.Data.DTO;

namespace TesteIderis.Tests.Helper
{
    public static class TestHelper
    {
        public static IList<MlItemDTO> GetListMl()
        {
            var result = new List<MlItemDTO>();
            var items = new DataMock().GetItemsParameters().ToList();

            items.ForEach(i =>
            {
                result.Add(GetItemMl(i));
            });

            return result;
        }

        public static MlItemDTO GetItemMl(string id)
        {
            return new MlItemDTO
            {
                Id = id,
                Price = 10,
                LastUpdated = DateTime.Now,
                OfficialStoreId = 1,
                Title = $"Item {id}"
            };
        }
    }
}