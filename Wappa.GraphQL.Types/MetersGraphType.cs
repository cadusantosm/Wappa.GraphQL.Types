using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace Wappa.GraphQL.Types
{
    public class MetersGraphType : FloatGraphType
    {
        public MetersGraphType()
        {
            Name = "Meters";
            Description = "The `Meters` scalar type represents distances measured in meters.";
        }
    }
}
