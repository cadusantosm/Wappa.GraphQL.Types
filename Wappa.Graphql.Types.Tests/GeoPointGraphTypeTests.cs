using GeoLibrary.Model;
using GraphQL.Language.AST;
using Shouldly;
using System.Collections.Generic;
using Wappa.GraphQL.Types;
using Xunit;

namespace Wappa.Graphql.Types.Tests
{
    public class GeoPointGraphTypeTests
    {
        private readonly Point _point = new Point(-46.654251, -23.563210);
        private readonly GeoPointGraphType _geoPointGraphType = new GeoPointGraphType();

        [Fact]
        public void ParseValue_WhenLatLonNull_ReturnNull()
        {
            _geoPointGraphType
                .ParseValue(null)
                .ShouldBe(null);
        }

        [Fact]
        public void ParseValue_Object_To_Point()
        {
            _geoPointGraphType
                .ParseValue(new List<object>()
                {
                    -23.563210,
                    -46.654251})
                .ShouldBe(_point);
        }

        [Fact]
        public void Serialize_Object_To_String()
        {
            _geoPointGraphType
                .Serialize(new List<object>()
                {
                    -23.563210,
                    -46.654251})
                .ShouldBe("[-23.56321,-46.654251]");
        }

        [Fact]
        public void Serialize_Point_To_String()
        {
            _geoPointGraphType
                .Serialize(_point)
                .ShouldBe(new double[] { _point.Longitude, _point.Latitude });
        }

        [Fact]
        public void ParseLiteral_StringValue_To_Point()
        {
            _geoPointGraphType
                .ParseLiteral(new StringValue("[-46.654251,-23.56321]"))
                .ShouldBe(_point);
        }

        [Fact]
        public void ParseLiteral_WhenIncompletePoint_ReturnNull()
        {
            var value = new ListValue(new List<IValue>()
            {
                new FloatValue(-46.654251)
            });

            _geoPointGraphType
                .ParseLiteral(value)
                .ShouldBe(null);
        }

        [Fact]
        public void ParseLiteral_Null_To_Point()
        {
            _geoPointGraphType.ParseLiteral(null)
                .ShouldBe(null);
        }

        [Fact]
        public void ParseLiteral_FloatValue_To_Point()
        {
            var value = new ListValue(new List<IValue>()
            {
                new FloatValue(-46.654251),
                new FloatValue(-23.56321)
            });

            _geoPointGraphType.ParseLiteral(value)
                .ShouldBe(_point);
        }

        [Fact]
        public void ParseLiteral_WhenLongitudeEmpty_ReturnNull()
        {
            var value = new ListValue(new List<IValue>()
            {
                null,
                new FloatValue(-23.56321)
            });

            _geoPointGraphType.ParseLiteral(value)
                .ShouldBe(null);
        }

        [Fact]
        public void ParseLiteral_WhenLatitudeEmpty_ReturnNull()
        {
            var value = new ListValue(new List<IValue>()
            {
                new FloatValue(-46.654251),
                null
            });

            _geoPointGraphType.ParseLiteral(value)
                .ShouldBe(null);
        }

        [Fact]
        public void ParseLiteral__ReturnNull()
        {
            var value = new ListValue(null);

            _geoPointGraphType.Serialize(value)
                .ShouldBe(null);
        }
    }
}
