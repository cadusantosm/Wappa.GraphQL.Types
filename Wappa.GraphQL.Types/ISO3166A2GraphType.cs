using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphQL.Types;

namespace Wappa.GraphQL.Types
{
    public class ISO3166A2GraphType : StringGraphType
    {
        public ISO3166A2GraphType()
        {
            Name = "ISO3166A2";
            Description = "The `ISO3166A2` scalar type represents a two letter code that is used to identify a country according with the [ISO 3166-1 Alpha 2 standard](https://en.wikipedia.org/wiki/ISO_3166-1).";
        }

        public override object ParseValue(object value)
        {
            if (value == null) return null;

            if (value.ToString().Length != 2)
                throw new ArgumentException(
                    "ISO 3166-1 Alpha 2 standard codes must be exactly 2 characters long.");

            if (value.ToString().Any(x => !char.IsLetter(x)))
                throw new ArgumentException("ISO 3166-1 Alpha 2 standard codes must be composed of only alpha characters.");
            
            return base.ParseValue(value);
        }
    }
}
