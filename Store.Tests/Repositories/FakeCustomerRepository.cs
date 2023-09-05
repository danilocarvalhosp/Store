namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public FakeCustomerRepository Get(string document)
        {
            if (document == "12345678911")
                return new FakeCustomerRepository("Bruce Wayne", "batman@balta.io");

            return null;
        }
    }
}