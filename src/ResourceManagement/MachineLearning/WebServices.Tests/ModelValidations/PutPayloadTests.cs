// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;

namespace WebServices.Tests
{

    public class WebServiceTests : TestBase
    {
        private readonly MachineLearningWebServicesManagementClientAPIs client;

        public WebServiceTests()
        {
            this.client = new MachineLearningWebServicesManagementClientAPIs(new TokenCredentials("foo"));
        }

        [Fact]
        public void WebServiceSerializationGraph()
        {
            var payload = WebServiceTests.CreateWebServiceGraph();

            string output = JsonConvert.SerializeObject(payload, client.SerializationSettings);
            ValidateJson(output, "TestData\\WebServiceGraph.json");
        }

        [Fact]
        public void WebServiceSerializationCode()
        {
            var payload = WebServiceTests.CreateWebServiceCode();

            string output = JsonConvert.SerializeObject(payload, client.SerializationSettings);
            ValidateJson(output, "TestData\\WebServiceCode.json");
        }

        [Fact]
        public void WebServiceDeserializationGraph()
        {
            string input = File.ReadAllText("TestData\\WebServiceGraph.json");
            var inputObj = JsonConvert.DeserializeObject<WebService>(input, client.DeserializationSettings);

            var expectedPayload = CreateWebServiceGraph();

            //TODO: Validate two objects are the same.
        }

        [Fact]
        public void WebServiceDeserializationCode()
        {
            string input = File.ReadAllText("TestData\\WebServiceCode.json");
            var inputObj = JsonConvert.DeserializeObject<WebService>(input, client.DeserializationSettings);

            var expectedPayload = CreateWebServiceCode();

            //TODO: Validate two objects are the same.
        }

        private static WebService CreateWebServiceGraph()
        {
            var payload = new WebService
            {
                Location = "foo_Web_US",
                Tags = new Dictionary<string, string>()
                {
                    { "tag1", "https://foo-graph.com" }
                }
            };

            var payloadProperties = new WebServicePropertiesForGraph();
            UpdateWebServiceCommonProperties(payloadProperties);

            var graphPackage = new WebServicePropertiesForGraphPackage();
            {
                var node1Parameters = new Dictionary<string, string>
                {
                    { "key1", "value1"},
                    { "key2", "value2"}
                };
                var node2Parameters = new Dictionary<string, string>
                {
                    { "key3", "value3"},
                    { "key4", "value4"}
                };
                var nodes = new Dictionary<string, GraphNode>
                {
                    { "node1", new GraphNode("assetA", null, null, node1Parameters) },
                    { "node2", new GraphNode("assetB", null, null, node2Parameters) }
                };
                graphPackage.Nodes = nodes;

                var edge1 = new GraphEdge("E3", null, "1", "p1");
                var edge2 = new GraphEdge("E1", "p7", "1", null);
                graphPackage.Edges = new List<GraphEdge> { edge1, edge2 };

                var param1 = new GraphParameter("Param1 description", ParameterType.Int);
                var link1 = new GraphParameterLink("2", "paramId1");
                var link2 = new GraphParameterLink("4", "paramId3");
                param1.Links = new List<GraphParameterLink> { link1, link2 };
                var param2 = new GraphParameter("Param2 description", ParameterType.Script);
                var link3 = new GraphParameterLink("7", "paramId5");
                var link4 = new GraphParameterLink("9", "paramId11");
                param2.Links = new List<GraphParameterLink> { link3, link4 };
                graphPackage.GraphParameters = new Dictionary<string, GraphParameter>
                {
                    { "id1", param1 },
                    { "id2", param2 }
                };
            }

            payloadProperties.Package = graphPackage;
            payload.Properties = payloadProperties;

            return payload;
        }

        private static WebService CreateWebServiceCode()
        {
            var payload = new WebService
            {
                Location = "foo_Web_US",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "https://foo-code.com" }
                }
            };

            var payloadProperties = new WebServicePropertiesForCode();
            UpdateWebServiceCommonProperties(payloadProperties);
            payloadProperties.Package = new WebServicePropertiesForCodePackage("R-3.1", "fake code here", "2");
            payload.Properties = payloadProperties;

            return payload;
        }

        private static void UpdateWebServiceCommonProperties(WebServiceProperties payloadProperties)
        {
            payloadProperties.Description = "test data";
            payloadProperties.Keys = new WebServiceKeys("primary key here", "secondary key here");
            payloadProperties.RealtimeConfiguration = new RealtimeConfiguration(100);
            payloadProperties.ReadOnlyProperty = true;
            var dateTime = new DateTime(2007, 2, 4, 2, 20, 15, DateTimeKind.Local);
            payloadProperties.Diagnostics = new DiagnosticsConfiguration(DiagnosticsLevel.Error, dateTime);
            payloadProperties.StorageAccount = new StorageAccount("storage account id");
            payloadProperties.MachineLearningWorkspace = new MachineLearningWorkspace("workspace ID");
            payloadProperties.CommitmentPlan = new CommitmentPlan("commitmentPlanId");

            var longColumn = new ColumnSpecification("integer", "Uint64");
            var stringColumn = new ColumnSpecification("string", null);
            var doubleColumn = new ColumnSpecification("number", "double");
            var categoryColumn = new ColumnSpecification("string", null, new List<object>() {"AA", "BB", "YY"});
            var input1ColumnSpecifications = new Dictionary<string, ColumnSpecification>
            {
                { "the long column", longColumn },
                { "the string column", stringColumn }
            };
            var input2ColumnSpecifications = new Dictionary<string, ColumnSpecification>
            {
                { "the string column", stringColumn },
                { "the double column", doubleColumn }
            };
            var outputColumnSpecifications = new Dictionary<string, ColumnSpecification>
            {
                { "the string column", stringColumn },
                { "the category column", categoryColumn },
                { "another long column", longColumn }
            };
            var input1Schema = new TableSpecification("input1 schema", "some description", "object", input1ColumnSpecifications);
            var input2Schema = new TableSpecification("input2 schema", "more description here", "object", input2ColumnSpecifications);
            var outputSchema = new TableSpecification("output schema", "output description here", "object", outputColumnSpecifications);
            payloadProperties.Input = new ServiceInputOutputSpecification
            {
                Title = "Input title",
                Description = "Input Description",
                Type = "object",
                Properties = new Dictionary<string, TableSpecification>
                {
                   { "input1", input1Schema },
                   { "input2", input2Schema }
                }
            };

            payloadProperties.Output = new ServiceInputOutputSpecification
            {
                Title = "Output title",
                Description = "Output Description",
                Type = "object",
                Properties = new Dictionary<string, TableSpecification>
                {
                    { "output", outputSchema }
                }
            };

            payloadProperties.Assets = new Dictionary<string, AssetItem>
            {
                ["asset1"] = new AssetItem
                {
                    Name = "Asset 1",
                    Type = "module",
                    Location = new AssetLocation("idv://blah.com/blahblah", null),
                    InputPorts = new Dictionary<string, InputPort>
                    {
                        { "p1", new InputPort("dataset") },
                        { "p2", new InputPort("zip") }
                    },
                    OutputPorts = new Dictionary<string, OutputPort>
                    {
                        { "p1", new OutputPort("dataset") },
                        { "p2", new OutputPort("zip") }
                    }
                },
                ["asset2"] = new AssetItem
                {
                    Name = "Asset 2",
                    Type = "module",
                    Location = new AssetLocation("idv://blahblah.com/blah", null),
                    InputPorts = new Dictionary<string, InputPort>
                    {
                        { "p1", new InputPort("dataset") },
                        { "p2", new InputPort("zip") }
                    },
                    OutputPorts = new Dictionary<string, OutputPort>
                    {
                        { "p1", new OutputPort("dataset") },
                        { "p2", new OutputPort("zip") }
                    }
                }
            };

            payloadProperties.Parameters = new Dictionary<string, string>
            {
                {"param1", "value1"},
                {"param2", "value2"}
            };
        }

        private static void ValidateJson(string actualJson, string expectedJsonFilePath)
        {
            string expectedJson = File.ReadAllText(expectedJsonFilePath);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}