using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace Wappa.GraphQL.Types
{
    public class MetersPerSecondGraphType : FloatGraphType
    {
        public MetersPerSecondGraphType()
        {
            Name = "MetersPerSecond";
            Description = "The `MetersPerSecond` scalar type represents speeds measured in m/s.";
        }
    }
}
