using RestSharp;
using System.Collections.Generic;
using TesteIderis.Data.DTO;

namespace TesteIderis.Service.Interface
{
    public interface IMlItemService
    {
        IList<MlItemDTO> BuscarInformacoesML();

        MlItemDTO BuscarItemMl(string id);

        MlItemDTO ProcessItemMl(IRestResponse<List<MlItemDTO>> response);
    }
}