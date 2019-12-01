using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphQL.Types;

namespace Wappa.GraphQL.Types
{
    public class ISO4217GraphType : StringGraphType
    {
        public ISO4217GraphType()
        {
            Name = "ISO4217";
            Description = "The `ISO4217` scalar type represents a three letter code that is used to identify a currency according with the [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).";
        }

        public override object ParseValue(object value)
        {
            if (value == null) return null;

            if (value.ToString().Length != 3)
                throw new ArgumentException(
                    "ISO 4217 codes must be exactly 3 characters long.");

            if (value.ToString().Any(x => !char.IsLetter(x)))
                throw new ArgumentException("ISO 4217 codes must be composed of only alpha characters.");

            return base.ParseValue(value);
        }
    }
}
