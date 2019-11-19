using GeoLibrary.Model;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Wappa.GraphQL.Types
{
    public class GeoPointGraphType : ScalarGraphType
    {
        public GeoPointGraphType()
        {
            Name = "GeoPoint";
            Description = "The `GeoPoint` scalar type represents point in 2D space.";
        }

        public override object ParseLiteral(IValue value)
        {
            double? lat;
            double? lon;

            if (value is StringValue stringValue)
            {
                var obj = JsonConvert.DeserializeObject<JArray>(stringValue.Value);

                lon = double.Parse(obj.Root[0].GetValue().ToString());
                lat = double.Parse(obj.Root[1].GetValue().ToString());

                return new Point
                {
                    Latitude = lat.Value,
                    Longitude = lon.Value
                };
            }

            if (!(value is ListValue listValue))
            {
                return null;
            }

            var children = listValue.Children.ToArray();
            if (children.Length != 2)
            {
                return null;
            }

            lon = (children[0] as FloatValue)?.Value ?? (children[0] as IntValue)?.Value;
            lat = (children[1] as FloatValue)?.Value ?? (children[1] as IntValue)?.Value;

            if (!lat.HasValue || !lon.HasValue)
            {
                return null;
            }

            return new Point
            {
                Latitude = lat.Value,
                Longitude = lon.Value
            };
        }

        public override object ParseValue(object value)
        {
            if (value != null && value is List<object> lstValue)
            {

                double.TryParse(lstValue[0].ToString(), out var lat);
                double.TryParse(lstValue[1].ToString(), out var lon);

                return new Point(lon, lat);
            }

            return null;
        }

        public override object Serialize(object value)
        {
            if (value is Point point)
            {
                return new double[] { point.Longitude, point.Latitude };
            }

            if (value != null && value is List<object> lstValue)
            {

                double.TryParse(lstValue[0].ToString(), out var lat);
                double.TryParse(lstValue[1].ToString(), out var lon);

                var result = new[] { lat, lon };

                return JsonConvert.SerializeObject(result);
            }
            return null;
        }
    }

}