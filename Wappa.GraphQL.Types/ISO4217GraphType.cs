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
            Description = "The `ISO4217` scalar type represents a three letter code that is used to identify a currency code according with the with the [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).";
        }

        public override object ParseValue(object value)
        {
            if (value == null) return null;

            if (value.ToString().Length < 3 || value.ToString().Length > 3)
                throw new ArgumentException(
                    "Currency code must be only three letter according with the with the [ISO 4217].");

            if (value.ToString().Any(x => !char.IsLetter(x)))
                throw new ArgumentException("Invalid currency code. To more information check following wiki: (https://en.wikipedia.org/wiki/ISO_4217)");

            return base.ParseValue(value);
        }
    }
}
