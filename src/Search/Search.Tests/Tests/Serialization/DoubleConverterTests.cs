// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Azure.Search.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public sealed class DoubleConverterTests
    {
        private readonly JsonSerializerSettings _serializerSettings =
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new DoubleConverter() } };

        private readonly JsonSerializerSettings _deserializerSettings =
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new DoubleConverter() } };

        private readonly Tuple<double, string>[] _writeTestCases =
            new[]
            {
                Tuple.Create(3.14d, "3.14"),
                Tuple.Create(123d, "123.0"),
                Tuple.Create(0d, "0.0"),
                Tuple.Create(0.0d, "0.0"),
                Tuple.Create(1.0d, "1.0"),
                Tuple.Create(Double.NegativeInfinity, @"""-INF"""),
                Tuple.Create(Double.PositiveInfinity, @"""INF"""),
                Tuple.Create(Double.NaN, @"""NaN"""),
                Tuple.Create(Double.MinValue, "-1.7976931348623157E+308"),
                Tuple.Create(Double.MaxValue, "1.7976931348623157E+308")
            };

        private readonly Tuple<double, string>[] _readTestCases =
            new[]
            {
                Tuple.Create(3.14d, "3.14"),
                Tuple.Create(123d, "123"),
                Tuple.Create(0d, "0"),
                Tuple.Create(0.0d, "0"),
                Tuple.Create(1.0d, "1"),
                Tuple.Create(Double.NegativeInfinity, @"""-INF"""),
                Tuple.Create(Double.PositiveInfinity, @"""INF"""),
                Tuple.Create(Double.NaN, @"""NaN"""),
                Tuple.Create(Double.MinValue, "-1.7976931348623157E+308"),
                Tuple.Create(Double.MaxValue, "1.7976931348623157E+308")
            };

        [Fact]
        public void CanWriteDoubleValues()
        {
            foreach (var testCase in _writeTestCases)
            {
                double doubleValue = testCase.Item1;
                string expectedJson = testCase.Item2;

                string json = JsonConvert.SerializeObject(doubleValue, _serializerSettings);
                Assert.Equal(expectedJson, json);
            }
        }

        [Fact]
        public void CanWriteNullableDouble()
        {
            double? nullableDouble = 3.14159;
            
            // Due to some JSON.NET weirdness, we need to wrap it in an object to trigger the double? detection path.
            object obj = new { PI = nullableDouble };
            string json = JsonConvert.SerializeObject(obj, _serializerSettings);
            Assert.Equal(@"{""PI"":3.14159}", json);
        }

        [Fact]
        public void CanReadDoubleValues()
        {
            foreach (var testCase in _readTestCases)
            {
                double expectedDoubleValue = testCase.Item1;
                string json = testCase.Item2;

                double actualDoubleValue = JsonConvert.DeserializeObject<double>(json, _deserializerSettings);
                Assert.Equal(expectedDoubleValue, actualDoubleValue);
            }
        }

        [Fact]
        public void CanReadNullableDouble()
        {
            double? expectedDouble = 3.14159;
            double? actualDouble = JsonConvert.DeserializeObject<double?>("3.14159", _deserializerSettings);
            Assert.Equal(expectedDouble, actualDouble);
        }

        [Fact]
        public void CanReadNullDouble()
        {
            double? nullDouble = null;
            double? actualDouble = JsonConvert.DeserializeObject<double?>("null", _deserializerSettings);
            Assert.Equal(nullDouble, actualDouble);
        }

        [Fact]
        public void CanReadPreParsedDouble()
        {
            const string Json = @"{""Price"":""3.50""}";
            using (JsonReader reader = new JsonTextReader(new StringReader(Json)))
            {
                JsonSerializer serializer = JsonSerializer.Create(_deserializerSettings);
                JObject propertyBag = serializer.Deserialize<JObject>(reader);
                Model model = serializer.Deserialize<Model>(new JTokenReader(propertyBag));
                Assert.Equal(3.5, model.Price);
            }
        }

        private class Model
        {
            public double Price { get; set; }
        }
    }
}
