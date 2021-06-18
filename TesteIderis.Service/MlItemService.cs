using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TesteIderis.CrossCutting.Exceptions;
using TesteIderis.CrossCutting.Helper.Interface;
using TesteIderis.CrossCutting.Mock.Interface;
using TesteIderis.CrossCutting.Util;
using TesteIderis.Data.DTO;
using TesteIderis.Service.Interface;

namespace TesteIderis.Service
{
    public class MlItemService : IMlItemService
    {
        private readonly IApiHelper<MlItemDTO> _apiHelper;
        private readonly IDataMock _dataMock;

        public MlItemService(IApiHelper<MlItemDTO> apiHelper, IDataMock dataMock)
        {
            _apiHelper = apiHelper;
            _dataMock = dataMock;
        }

        public IList<MlItemDTO> BuscarInformacoesML()
        {
            try
            {
                var result = new List<MlItemDTO>();
                var parameters = _dataMock.GetItemsParameters();

                foreach (var item in parameters)
                {
                    result.Add(BuscarItemMl(item));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MlItemDTO BuscarItemMl(string id)
        {
            try
            {
                var url = $"{ContantUtil.URL_MERCADO_LIVRE}{id}";
                var result = _apiHelper.SendRequest(url, Method.GET);

                return ProcessItemMl(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MlItemDTO ProcessItemMl(IRestResponse<List<MlItemDTO>> response)
        {
            if (string.IsNullOrWhiteSpace(response.Content) || response.StatusCode != HttpStatusCode.OK || response.Data == null || !response.Data.Any())
                throw new ClientServiceException(ContantUtil.RESTSHARP_ERROR_MESSAGE);

            return response.Data.FirstOrDefault();
        }
    }
}