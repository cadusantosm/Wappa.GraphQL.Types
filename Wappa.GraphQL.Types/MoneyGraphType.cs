using GraphQL.Types;
using Wappa.GraphQL.Types.Model;

namespace Wappa.GraphQL.Types
{
    public class MoneyGraphType : ObjectGraphType<Money>
    {
        public MoneyGraphType()
        {
            Name = "Money";
            Description = "The `Money` object type represents a monetary value.";

            Field(x => x.Amount, type: typeof(NonNullGraphType<FloatGraphType>))
                .Name("amount")
                .Description("The decimal amount.");

            Field(x => x.Currency, type: typeof(NonNullGraphType<ISO4217GraphType>))
                .Name("currency")
                .Description("The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) currency code for this monetary value.");

            Field(x => x.Formatted, type: typeof(StringGraphType))
                .Name("formatted")
                .Description("The formatted value to be displayed to users.");

            Field(x => x.Symbol, type: typeof(StringGraphType))
                .Name("symbol")
                .Description("The currency symbol.");
        }
    }
}
