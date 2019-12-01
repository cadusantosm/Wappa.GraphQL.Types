using Shouldly;
using Wappa.GraphQL.Types;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class MoneyGraphTypeTests
    {
        private readonly MoneyGraphType _moneyGraphType = new MoneyGraphType();

        [Fact]
        public void should_derive_name()
        {
            _moneyGraphType.Name.ShouldBe("Money");
        }

        [Fact]
        public void should_derive_description()
        {
            _moneyGraphType.Description.ShouldBe("The `money` scalar represents");
        }
    }
}
