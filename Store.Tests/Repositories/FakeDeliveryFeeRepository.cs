using Store.Domain.Repositories;
using Store.Domain.Entities;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}