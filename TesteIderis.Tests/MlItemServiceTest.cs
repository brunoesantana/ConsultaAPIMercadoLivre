using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RestSharp;
using System.Collections.Generic;
using TesteIderis.Data.DTO;
using TesteIderis.Service.Interface;
using TesteIderis.Tests.Helper;

namespace TesteIderis.Tests
{
    [TestClass]
    public class MlItemServiceTest
    {
        private readonly IMlItemService _mockService;
        private readonly IRestResponse<List<MlItemDTO>> _mockResponse;

        public const string ID_ITEM_1 = "MLB832035381";
        public const string ID_ITEM_2 = "MLB938457671";

        public const int EXPECTED_RESULT = 4;

        public MlItemServiceTest()
        {
            _mockResponse = new RestResponse<List<MlItemDTO>>();
            _mockService = Substitute.For<IMlItemService>();

            _mockService.BuscarInformacoesML().Returns(TestHelper.GetListMl());
            _mockService.BuscarItemMl(Arg.Any<string>()).Returns(TestHelper.GetItemMl(ID_ITEM_1));
            _mockService.ProcessItemMl(_mockResponse).Returns(TestHelper.GetItemMl(ID_ITEM_2));
        }

        [TestMethod]
        public void Deve_buscar_informacoes_corretamente()
        {
            var response = _mockService.BuscarInformacoesML();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Count, EXPECTED_RESULT);
        }

        [TestMethod]
        public void Deve_buscar_item_corretamente()
        {
            var response = _mockService.BuscarItemMl("");

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, ID_ITEM_1);
        }

        [TestMethod]
        public void Deve_processar_retorno_corretamente()
        {
            var response = _mockService.ProcessItemMl(_mockResponse);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, ID_ITEM_2);
        }
    }
}