using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoValidoEleDeveGerarUmNumeroComOitoCaracteres()
        {
            var customer = new Customer("André Baltieri", "andre@balta.io");
            var order = new Order(customer, 0, null);
            Assert.AreEqual(8, order.Number.Lenght);
        }
    }
}