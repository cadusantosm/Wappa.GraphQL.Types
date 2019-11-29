using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Wappa.GraphQL.Types;
using Wappa.Graphql.Types.Tests.Util;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class MetersGraphTypeTests
    {
        private readonly MetersGraphType _metersGraphType = new MetersGraphType();

        [Fact]
        public void Coerces_Null_To_Null()
        {
            _metersGraphType.ParseValue(null).ShouldBe(null);
        }

        [Fact]
        public void Coerces_Invalid_String_To_Exception()
        {
            Should.Throw<FormatException>(() => _metersGraphType.ParseValue("abcd"));
        }

        [Fact]
        public void Coerces_Double_To_Value_Using_Cultures()
        {
            CultureTestHelper.UseCultures(Coerces_Null_To_Null);
        }

        [Fact]
        public void Coerces_Double_To_Value()
        {
            _metersGraphType
                .ParseValue(1.79769313486231e308)
                .ShouldBe(1.79769313486231e308);
        }
    }
}
