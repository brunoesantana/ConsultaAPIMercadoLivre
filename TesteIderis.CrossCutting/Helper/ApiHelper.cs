using RestSharp;
using System;
using System.Collections.Generic;
using TesteIderis.CrossCutting.Exceptions;
using TesteIderis.CrossCutting.Helper.Interface;

namespace TesteIderis.CrossCutting.Helper
{
    public class ApiHelper<T> : IApiHelper<T> where T : class
    {
        public ApiHelper()
        {
        }

        public IRestResponse<List<T>> SendRequest(string url, Method method)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(method);

                return client.Execute<List<T>>(request);
            }
            catch (Exception e)
            {
                throw new ClientServiceException(e.Message);
            }
        }
    }
}