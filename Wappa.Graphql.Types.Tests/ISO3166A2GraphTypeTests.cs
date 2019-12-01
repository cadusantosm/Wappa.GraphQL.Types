using System;
using Shouldly;
using Wappa.GraphQL.Types;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class ISO3166A2GraphTypeTests
    {
        ISO3166A2GraphType _iso3166A2GraphType = new ISO3166A2GraphType();

        [Fact]
        public void ParseValue_ParseCountryCodeWithTwoLetters_ReturnValidCurrencyCode() =>
            _iso3166A2GraphType.ParseValue("BR").ShouldBe("BR");

        [Fact]
        public void ParseValue_ParseCountryCodeNull_ReturnNull() =>
            _iso3166A2GraphType.ParseValue(null).ShouldBe(null);

        [Fact]
        public void ParseValue_ParseCountryCodeWithOneLetters_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso3166A2GraphType.ParseValue("A"));

        [Fact]
        public void ParseValue_ParseCountryCodeWithThreeLetters_ArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso3166A2GraphType.ParseValue("ABC"));

        [Fact]
        public void ParseValue_ParseCountryCodeWithNumber_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso3166A2GraphType.ParseValue(12));

        [Fact]
        public void ParseValue_ParseCountryCodeWithNumberInString_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso3166A2GraphType.ParseValue("13"));
    }
}