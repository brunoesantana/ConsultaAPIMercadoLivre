using System;
using System.Linq;
using TesteIderis.CrossCutting.Helper;
using TesteIderis.CrossCutting.Helper.Interface;
using TesteIderis.CrossCutting.Mock;
using TesteIderis.CrossCutting.Mock.Interface;
using TesteIderis.CrossCutting.Util;
using TesteIderis.Data.DTO;
using TesteIderis.Service;
using TesteIderis.Service.Interface;

/// <summary>
///
/// O Código deve retornar
///     Problema resolvido
///
/// Não deve ser adicionado nenhum RETURN a mais
///
/// </summary>

public class Program
{
    //Nao mexer aqui

    #region Nao mexer aqui

    private static void Main(string[] args)
    {
        Console.WriteLine(Problema());
        Console.ReadLine();
    }

    #endregion Nao mexer aqui

    //
    public static string Problema()
    {
        try
        {
            IApiHelper<MlItemDTO> apiHelper = new ApiHelper<MlItemDTO>();
            IDataMock dataMock = new DataMock();
            IMlItemService mlItemService = new MlItemService(apiHelper, dataMock);

            var dados = mlItemService.BuscarInformacoesML();

            if (dados != null && dados.Count() == ContantUtil.EXPECTED_RESULT)
                return ContantUtil.SUCCESS_MESSAGE;
            else
                return ContantUtil.ERROR_MESSAGE;
        }
        catch (Exception ex)
        {
            return $"{ContantUtil.ERROR_MESSAGE} - {ex.Message}";
        }
    }

    /// <summary>
    ///
    ///     Usando RestSharp e Newtonsoft.Json, implemente um método que consulte a api do mercado livre e retorne em um array de "MlItem"
    ///     corrigindo qualquer erro que possa ocorrer
    ///
    ///     ex https://api.mercadolibre.com/items/MLB832035381
    ///
    ///     o metodo deverá retornar os seguintes items:
    ///
    ///     MLB832035381
    ///     MLB938457671
    ///     MLB691669454
    ///     MLB837523349
    ///
    /// </summary>
    /// <returns></returns>
}