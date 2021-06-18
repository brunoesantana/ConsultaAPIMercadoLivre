using System;

namespace TesteIderis.Data.DTO
{
    public class MlItemDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int OfficialStoreId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}