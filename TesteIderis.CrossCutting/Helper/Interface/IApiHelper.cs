using RestSharp;
using System.Collections.Generic;

namespace TesteIderis.CrossCutting.Helper.Interface
{
    public interface IApiHelper<T> where T : class
    {
        IRestResponse<List<T>> SendRequest(string url, Method method);
    }
}