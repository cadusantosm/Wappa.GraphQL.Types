using System;
using Shouldly;
using Wappa.GraphQL.Types;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class ISO4217GraphTypeTests
    {
        private readonly ISO4217GraphType _iso4217GraphType = new ISO4217GraphType();

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithThreeLetters_ReturnValidCurrencyCode() =>
            _iso4217GraphType.ParseValue("USD").ShouldBe("USD");

        [Fact]
        public void ParseValue_ParseCurrencyCodeNull_ReturnNull() =>
            _iso4217GraphType.ParseValue(null).ShouldBe(null);

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithOneLetters_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso4217GraphType.ParseValue("A"));

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithTwoLetters_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso4217GraphType.ParseValue("AB"));

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithFourLetters_ArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso4217GraphType.ParseValue("ABCD"));

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithNumber_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso4217GraphType.ParseValue(123));

        [Fact]
        public void ParseValue_ParseCurrencyCodeWithNumberInString_ThrowArgumentException() =>
            Should.Throw<ArgumentException>(() => _iso4217GraphType.ParseValue("123"));
    }
}
