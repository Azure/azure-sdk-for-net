// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    public class CloudErrorJsonConverterTest
    {  
        [Fact]
        public void TestCloudErrorDeserialization()
        {
            var expected = @"
                {
                    ""error"": {
                        ""code"": ""BadArgument"",
                        ""message"": ""The provided database ‘foo’ has an invalid username."",
                        ""target"": ""query"",
                        ""details"": [
                        {
                            ""code"": ""301"",
                            ""target"": ""$search"",
                            ""message"": ""$search query option not supported""
                        }
                        ]
                    }
                }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new CloudErrorJsonConverter());
            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializeSettings);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", cloudError.Message);
            Assert.Equal("BadArgument", cloudError.Code);
            Assert.Equal("query", cloudError.Target);
            Assert.Equal(1, cloudError.Details.Count);
            Assert.Equal("301", cloudError.Details[0].Code);
        }

        [Fact]
        public void TestCloudErrorWithDifferentCasing()
        {
            var expected = "{\"Error\":{\"Code\":\"CatalogObjectNotFound\",\"Message\":\"datainsights.blah doesn't exist.\"}} ";

            var deserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            deserializationSettings.Converters.Add(new ResourceJsonConverter());
            deserializationSettings.Converters.Add(new CloudErrorJsonConverter());

            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializationSettings);

            Assert.NotNull(cloudError);
            Assert.Equal("datainsights.blah doesn't exist.", cloudError.Message);
            Assert.Equal("CatalogObjectNotFound", cloudError.Code);
        }


        [Fact]
        public void TestEmptyCloudErrorDeserialization()
        {
            var expected = "{}";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new CloudErrorJsonConverter());
            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializeSettings);

            Assert.NotNull(cloudError);
            Assert.Null(cloudError.Code);
        }
    }
}
