using Store.Domain.Repositories;
using Store.Tests.Repositories;
using Store.Domain.Commands;
using Store.Domain.Handlers;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class OrderHanderTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;    

        public OrderHanderTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _orderRepository = new FakeOrderRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmClienteInexistenteOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = null;
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmCepInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = null;
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPromoCodeInexistenteOPedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = null;
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPedidoSemItensOMesmoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 0));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 0));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }    
        
        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoValidoOPedidoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository
            );

            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }        
    }
}