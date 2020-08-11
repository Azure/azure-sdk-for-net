// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Microsoft.Azure;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using CR.Azure.NetCore.Tests;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    public class ResourceJsonConverterTest
    {
        [Fact]
        public void TestResourceSerialization()
        {
            var sampleResource = new SampleResource()
            {
                Size = "3",
                Child = new SampleResourceChild1()
                {
                    ChildName1 = "name1"
                },
                Location = "EastUS",
                Plan = "testPlan",
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""plan"": ""testPlan"",
  ""properties"": {
    ""size"": ""3"",
    ""child"": {
      ""dType"": ""SampleResourceChild1"",
      ""properties"": {
        ""name1"": ""name1""
      }
    }
  }
}", json);
            
            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(json, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(json, jsonoverProcessed);
        }

        [Fact]
        public void TestResourceSerializationWithPolymorphism()
        {
            var sampleResource = new SampleResource()
            {
                Size = "3",
                Child = new SampleResourceChild1(),
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResource>("dType"));
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""dType"": ""SampleResource"",
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""size"": ""3"",
    ""child"": {
      ""dType"": ""SampleResourceChild1""
    }
  }
}", json);
        }

        [Fact]
        public void TestGenericResourceSerialization()
        {
            var sampleResource = new GenericResource()
            {
                Location = "EastUS",
                Properties = JObject.Parse("{ \"size\" : \"3\" }")
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""size"": ""3""
  }
}", json);

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<GenericResource>(json, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(json, jsonoverProcessed);
        }

        [Fact]
        public void TestGenericResourceWithNullPropertiesSerialization()
        {
            var sampleResource = new GenericResource()
            {
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  }
}", json);

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<GenericResource>(json, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(json, jsonoverProcessed);
        }
        
        [Fact]
        public void TestResourceWithNullPropertiesSerialization()
        {
            var sampleResource = new SampleResource()
            {
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new ResourceJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  }
}", json);

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(json, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(json, jsonoverProcessed);
        }
        
        [Fact]
        public void TestProvisioningStateDeserialization()
        {
            var expected = @"{
                              ""location"": ""EastUS"",
                              ""tags"": {
                                ""tag1"": ""value1""
                              },
                              ""properties"": {
                                ""size"": ""3"",
                                ""provisioningState"": ""some string"",
                                ""child"": {
                                  ""dType"": ""SampleResourceChild1"",
                                  ""name1"": ""name1"",
                                  ""id"": ""child""
                                }
                              }
                            }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(expected, deserializeSettings);

            Assert.Equal("some string", deserializedResource.ProvisioningState);
        }

        [Fact]
        public void TestDeserializationOfResourceWithConflictingProperties()
        {
            var expected = @"{
                ""id"": ""123"",
                ""location"": ""EastUS"",
                ""tags"": {
                ""tag1"": ""value1""
                },
                ""properties"": {
                   ""size"": ""3"",
                   ""provisioningState"": ""some string"",
                   ""location"": ""Special Location"",
                   ""id"": ""Special Id""
                }
            }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            var deserializedResource = JsonConvert.DeserializeObject<SampleResourceWithConflict>(expected, deserializeSettings);

            Assert.Equal("Special Location", deserializedResource.SampleResourceWithConflictLocation);
            Assert.Equal("Special Id", deserializedResource.SampleResourceWithConflictId);
            Assert.Equal("123", deserializedResource.Id);

            var expectedSerializedJson = @"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""location"": ""Special Location"",
    ""id"": ""Special Id""
  }
}";
            var newJson = JsonConvert.SerializeObject(deserializedResource, deserializeSettings);
            Assert.Equal(expectedSerializedJson, newJson);
        }

        [Fact]
        public void TestGenericResourceDeserialization()
        {
            var expected = @"{
                              ""location"": ""EastUS"",
                              ""tags"": {
                                ""tag1"": ""value1""
                              },
                              ""properties"": {
                                ""size"": ""3"",
                                ""provisioningState"": ""some string"",
                                ""child"": {
                                  ""dType"": ""SampleResourceChild1"",
                                  ""name1"": ""name1"",
                                  ""id"": ""child""
                                }
                              }
                            }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<GenericResource>(expected, deserializeSettings);

            Assert.Equal("some string", ((JObject)deserializedResource.Properties)["provisioningState"]);
            Assert.Equal("EastUS", deserializedResource.Location);
            Assert.Equal("value1", deserializedResource.Tags["tag1"]);
            Assert.Equal("3", ((JObject)deserializedResource.Properties)["size"]);
            Assert.Equal("some string", ((JObject)deserializedResource.Properties)["provisioningState"]);
            Assert.Equal("name1", ((JObject)deserializedResource.Properties)["child"]["name1"]);
        }

        [Fact]
        public void Failure()
        {
            var expected = @"{
  ""id"": ""/subscriptions/1234564654654654654/resourceGroups/csmrg6766/providers/Microsoft.Web/sites/csmr6039"",
  ""name"": ""csmr6039"",
  ""type"": ""Microsoft.Web/sites"",
  ""location"": ""South Central US"",
  ""tags"": {},
  ""properties"": {
    ""name"": ""csmr6039"",
    ""state"": ""Running"",
    ""hostNames"": [
      ""csmr6039.antares-int.windows-int.net""
    ],
    ""webSpace"": ""csmrg6766-SouthCentralUSwebspace"",
    ""selfLink"": ""https://azure.com/subscriptions/1234564654654654654/webspaces/csmrg6766-SouthCentralUSwebspace/sites/csmr6039"",
    ""repositorySiteName"": ""csmr6039"",
    ""owner"": null,
    ""usageState"": 0,
    ""enabled"": true,
    ""adminEnabled"": true,
    ""enabledHostNames"": [
      ""csmr6039.antares-int.windows-int.net"",
      ""csmr6039.scm.antares-int.windows-int.net""
    ],
    ""siteProperties"": {
      ""metadata"": null,
      ""properties"": [],
      ""appSettings"": null
    },
    ""availabilityState"": 0,
    ""sslCertificates"": null,
    ""csrs"": [],
    ""cers"": null,
    ""siteMode"": null,
    ""hostNameSslStates"": [
      {
        ""name"": ""csmr6039.antares-int.windows-int.net"",
        ""sslState"": 0,
        ""ipBasedSslResult"": null,
        ""virtualIP"": null,
        ""thumbprint"": null,
        ""toUpdate"": null,
        ""toUpdateIpBasedSsl"": null,
        ""ipBasedSslState"": 0
      },
      {
        ""name"": ""csmr6039.scm.antares-int.windows-int.net"",
        ""sslState"": 0,
        ""ipBasedSslResult"": null,
        ""virtualIP"": null,
        ""thumbprint"": null,
        ""toUpdate"": null,
        ""toUpdateIpBasedSsl"": null,
        ""ipBasedSslState"": 0
      }
    ],
    ""computeMode"": null,
    ""serverFarm"": ""Default1"",
    ""webHostingPlan"": ""Default1"",
    ""lastModifiedTimeUtc"": ""2014-06-24T22:04:45.16"",
    ""storageRecoveryDefaultState"": ""Running"",
    ""contentAvailabilityState"": 0,
    ""runtimeAvailabilityState"": 0,
    ""siteConfig"": null,
    ""deploymentId"": ""csmr6039"",
    ""trafficManagerHostNames"": null,
    ""sku"": ""Free""
  }
}";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new ResourceJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<GenericResource>(expected, deserializeSettings);

            Assert.Equal("South Central US", deserializedResource.Location);
            Assert.Equal("csmr6039", deserializedResource.Name);
        }

        [Fact]
        public void PolymorphismWithPage()
        {
            var expected = @"{
    ""jobId"": ""12ac4036-cb63-4244-a7dd-03a087062b43"",
    ""name"": ""azure sdk data lake analytics job"",
    ""type"": ""USql"",
    ""submitter"": ""admin@aad264.ccsctp.net"",
    ""account"": null,
    ""degreeOfParallelism"": 2,
    ""priority"": 0,
    ""submitTime"": ""Sat, 12 Dec 2015 00:04:50 GMT"",
    ""startTime"": null,
    ""endTime"": null,
    ""state"": ""Compiling"",
    ""result"": ""Succeeded"",
    ""errorMessage"": ""null"",
    ""storageAccounts"": null,
    ""stateAuditRecords"": [
        {
            ""newState"": ""New"",
            ""timeStamp"": ""Sat, 12 Dec 2015 00:04:50 GMT"",
            ""requestedByUser"": null,
            ""details"": ""userName:admin@aad264.ccsctp.net;submitMachine:N/A""
        }
    ],
    ""properties"": {
        ""owner"": ""admin@aad264.ccsctp.net"",
        ""runtimeVersion"": ""default"",
        ""rootProcessNodeId"": ""00000000-0000-0000-0000-000000000000"",
        ""algebraFilePath"": ""adl://azure.net/system/jobservice/jobs/Usql/2015/12/12/00/04/12ac4036-cb63-4244-a7dd-03a087062b43/algebra.xml"",
        ""compileMode"": ""Semantic"",
        ""errorSource"": ""Unknown"",
        ""totalCompilationTime"": ""00:00:00"",
        ""totalPausedTime"": ""00:00:00"",
        ""totalQueuedTime"": ""00:00:00"",
        ""totalRunningTime"": ""00:00:00"",
        ""type"": ""USql""
    }
}";

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
            deserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<JobProperties>("type"));
            deserializationSettings.Converters.Add(new ResourceJsonConverter());
            deserializationSettings.Converters.Add(new CloudErrorJsonConverter());
            var deserializedResource = JsonConvert.DeserializeObject<JobInformation>(expected, deserializationSettings);

            Assert.True(deserializedResource.Properties is USql);
        }
    }
}
