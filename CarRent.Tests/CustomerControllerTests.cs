using CarRent.API.Controllers;
using FluentAssertions;

namespace CarRent.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void Create_WhenNoRepository_ThenThrow()
        {
            Action act = () => new CustomerController(null);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
