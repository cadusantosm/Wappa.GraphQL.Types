using GraphQL.Types;
using Wappa.GraphQL.Types.Model;

namespace Wappa.GraphQL.Types
{
    public class MoneyGraphType : ObjectGraphType<Money>
    {
        public MoneyGraphType()
        {
            Name = "Money";
            Description = "The `money` scalar represents monetary value";

            Field(x => x.Amount, type: typeof(NonNullGraphType<FloatGraphType>))
                .Description("The amount in currency");

            Field(x => x.Currency, type: typeof(NonNullGraphType<ISO3166A2GraphType>))
                .Description("The code of currency");

            Field(x => x.Formatted, type: typeof(StringGraphType))
                .Description("The amount formatted with country currency symbol");

            Field(x => x.Symbol, type: typeof(StringGraphType))
                .Description("The country currency symbol");
        }
    }
}
