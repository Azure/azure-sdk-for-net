// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    /// <summary>
    /// Tests corresponding to all swagger-style operation examples, which include all implemented operations
    /// The unimplemented MonitoringIndexes_List and MonitoringIndexes_Get operations will be removed soon
    /// These tests contain workarounds for some service defects/inconsistencies, as noted by specific Issue comments
    /// </summary>
    public class ExamplesUnitTest : BaseUnitTest
    {
        //[Fact]
        public void CaptureExamples()
        {
            // Uncomment the [Fact] above and run this method with your favorite locations for secrets and outputs to recapture examples.  It takes about 1 minutes.
            ExampleCapture exampleCapture = new ExampleCapture(@"D:\secretsProd.json", @"D:\capture", @"D:\captureworkaround");
            exampleCapture.CaptureAllExamples();
        }

        [Fact]
        public void GatewayExtended_List()
        {
            RunTest("GatewayExtended_List", (example, client, responseCode) =>
            {
                IEnumerable<GatewayExtended> resource = client.GatewaysExtended.List(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (IEnumerable<GatewayExtended>)resource);                
            });
        }

        [Fact]
        public void GatewayExtended_Get()
        {
            RunTest("GatewayExtended_Get", (example, client, responseCode) =>
            {
                GatewayExtended resource = client.GatewaysExtended.Get(RGN(example), FN(example), GN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void GatewayExtended_Update()
        {
            RunTest("GatewayExtended_Update", (example, client, responseCode) =>
            {
                GatewayExtended resource = client.GatewaysExtended.Update(RGN(example), FN(example), GN(example), GWR(example, client, "parameters"));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void GatewayExtended_ForceSyncCredential()
        {
            RunTest("GatewayExtended_ForceSyncCredential", (example, client, responseCode) =>
            {
                client.GatewaysExtended.ForceSyncCredential(RGN(example), FN(example), GN(example));
            });
        }

        [Fact]
        public void GatewayExtended_UpdateNode()
        {
            RunTest("GatewayExtended_UpdateNode", (example, client, responseCode) =>
            {
                var param = new GatewayExtendedUpdateNodeParameters(Constants.DefaultNodeName, 15);
                client.GatewaysExtended.UpdateNode(RGN(example), FN(example), GN(example), param);
            });
        }

        [Fact]
        public void GatewayExtended_DeleteNode()
        {
            RunTest("GatewayExtended_DeleteNode", (example, client, responseCode) =>
            {
                var param = new GatewayExtendedDeleteNodeParameters(Constants.DefaultNodeName);
                client.GatewaysExtended.DeleteNode(RGN(example), FN(example), GN(example), param);
            });
        }

        private List<HttpResponseMessage> GetResponses(Example example)
        {
            List<HttpResponseMessage> messages = new List<HttpResponseMessage>();
            foreach (var kvp in example.Responses)
            {
                HttpResponseMessage message = new HttpResponseMessage((HttpStatusCode)int.Parse(kvp.Key));
                foreach (var header in kvp.Value.Headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }
                string body = SafeJsonConvert.SerializeObject(kvp.Value.Body);
                message.Content = new StringContent(body);
                messages.Add(message);
            }
            return messages;
        }

        private Example ReadExample(string exampleName)
        {
            var json = File.ReadAllText(Path.Combine("TestData", exampleName + ".json"));
            Example example = SafeJsonConvert.DeserializeObject<Example>(json);
            example.Name = exampleName;
            return example;
        }

        private IDataFactoryManagementExtendedClient GetClient(Example example)
        {
            var handler = new RecordedDelegatingHandler();
            handler.Responses = GetResponses(example);
            var client = CreateWorkflowClient(handler);
            client.SubscriptionId = (string)example.Parameters["subscriptionId"];
            return client;
        }

        private void RunTest(string exampleName, Action<Example, IDataFactoryManagementExtendedClient, int> test)
        {
            Example example = ReadExample(exampleName);
            var client = GetClient(example);
            foreach (var kvp in example.Responses)
            {
                test(example, client, int.Parse(kvp.Key));
            }
        }

        private void RunAyncApiTest(string exampleName, Action<Example, IDataFactoryManagementExtendedClient, int> test)
        {
            Example example = ReadExample(exampleName);
            var client = GetClient(example);
            test(example, client, 202);
        }

        private void RemovePropertyIfPresent(JToken jToken, string propertyName, bool onlyIfNull)
        {
            if (jToken.Type == JTokenType.Object)
            {
                JObject jObject = (JObject)jToken;
                JProperty jProperty = jObject.Property(propertyName);
                if (jProperty != null)
                {
                    if (!onlyIfNull || jProperty.Value.Type == JTokenType.Null)
                    {
                        jObject.Remove(propertyName);
                    }
                }
            }
        }

        private void RenamePropertyIfPresent(JToken jToken, string oldPropertyName, string newPropertyName)
        {
            if (jToken.Type == JTokenType.Object)
            {
                JObject jObject = (JObject)jToken;
                JProperty jProperty = jObject.Property(oldPropertyName);
                if (jProperty != null)
                {
                    jObject.Add(newPropertyName, jProperty.Value);
                    jObject.Remove(oldPropertyName);
                }
                else
                {
                    throw new ArgumentException("Property is not found.");
                }
            }
        }

        private void CheckResponseBody<T>(Example example, IDataFactoryManagementExtendedClient client, int responseCode, T response)
        {
            // Compares original raw json captured "expected" response against strongly typed "actual" response from SDK method
            // Issues with workarounds noted inline
            Assert.NotNull(response);
            object expectedObject = example.Responses[responseCode.ToString()].Body;
            string expectedJson = SafeJsonConvert.SerializeObject(expectedObject);
            JToken expectedJToken = JToken.Parse(expectedJson);

            string actualJson = SafeJsonConvert.SerializeObject(response, GetFullSerializerSettings(client));
            JToken actualJToken = JToken.Parse(actualJson);

            Assert.True(JToken.DeepEquals(expectedJToken, actualJToken), 
                string.Format(CultureInfo.InvariantCulture, "CheckResponseBody failed for example {0} response code {1}", example.Name, responseCode));
        }

        private string RGN(Example example)
        {
            return (string)example.Parameters["resourceGroupName"];
        }
        private string FN(Example example)
        {
            return (string)example.Parameters["dataFactoryName"];
        }
        private string GN(Example example)
        {
            return (string)example.Parameters["gatewayName"];
        }

        private T GetTypedObject<T>(IDataFactoryManagementExtendedClient client, object objectRaw)
        {
            string jsonRaw = SafeJsonConvert.SerializeObject(objectRaw);
            T objectTyped = SafeJsonConvert.DeserializeObject<T>(jsonRaw, GetFullSerializerSettings(client));
            return objectTyped;
        }
        private T GetTypedParameter<T>(Example example, IDataFactoryManagementExtendedClient client, string paramName)
        {
            object objectRaw = example.Parameters[paramName];
            Type parameterType = typeof(T);

            if (parameterType == typeof(DateTime))
            {
                objectRaw = objectRaw.ToString().Replace("%3A", ":");
            }

            return GetTypedObject<T>(client, objectRaw);
        }

        private GatewayExtended GWR(Example example, IDataFactoryManagementExtendedClient client, string paramName)
        {
            return GetTypedParameter<GatewayExtended>(example, client, paramName);
        }
    }
}
