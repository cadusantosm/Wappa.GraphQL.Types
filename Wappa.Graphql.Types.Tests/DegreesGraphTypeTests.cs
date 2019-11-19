using Shouldly;
using System;
using System.Collections.Generic;
using System.Globalization;
using Wappa.GraphQL.Types;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class DegreesGraphTypeTests
    {
        private readonly DegreesGraphType _degreesGraphType = new DegreesGraphType();

        [Fact]
        public void Coerces_Null_To_Null()
        {
            _degreesGraphType.ParseValue(null).ShouldBe(null);
        }

        [Fact]
        public void Coerces_Invalid_String_To_Exception()
        {
            Should.Throw<FormatException>(() => _degreesGraphType.ParseValue("abcd"));
        }

        [Fact]
        public void Coerces_Double_To_Value_Using_Cultures()
        {
            CultureTestHelper.UseCultures(Coerces_Null_To_Null);
        }

        [Fact]
        public void Coerces_Double_To_Value()
        {
            _degreesGraphType
                .ParseValue(1.79769313486231e308)
                .ShouldBe(1.79769313486231e308);
        }
    }

    internal static class CultureTestHelper
    {
        public static IEnumerable<CultureInfo> Cultures => new[]
        {
            new CultureInfo("en-US"),
            CultureInfo.InvariantCulture,
            new CultureInfo(CultureInfo.CurrentUICulture.Name),
            new CultureInfo(CultureInfo.CurrentCulture.Name)
        };

        public static void UseCultures(Action scope)
        {
            foreach (var culture in Cultures)
            {
                UseCulture(culture, scope);
            }
        }

        public static void UseCulture(CultureInfo culture, Action scope)
        {
            var before = CultureInfo.CurrentCulture;
            var beforeUi = CultureInfo.CurrentUICulture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            try
            {
                scope();
            }
            finally
            {
                CultureInfo.DefaultThreadCurrentCulture = before;
                CultureInfo.DefaultThreadCurrentUICulture = beforeUi;
            }
        }
    }
}
