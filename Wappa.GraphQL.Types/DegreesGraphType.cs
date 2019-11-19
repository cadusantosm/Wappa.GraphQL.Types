using GraphQL.Types;

namespace Wappa.GraphQL.Types
{
    public class DegreesGraphType : FloatGraphType
    {
        public DegreesGraphType()
        {
            Name = "Degrees";
            Description = "The `Degrees` scalar type represents an angle in degrees.";
        }
    }
}
