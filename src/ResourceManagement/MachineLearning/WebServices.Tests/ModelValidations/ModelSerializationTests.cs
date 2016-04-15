// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace WebServices.Tests
{
    public class ModelSerializationTests : TestBase
    {
        [Fact]
        public void GraphBasedWebServiceSerializationTest()
        {
            this.RunSerializationTest(@".\TestData\SerializedGraphWebService.json", ModelSerializationTests.CreateWebServiceGraph);
        }

        [Fact]
        public void CodeBasedWebServiceSerializationTest()
        {
            this.RunSerializationTest(@".\TestData\SerializedCodeWebService.json", ModelSerializationTests.CreateWebServiceCode);
        }

        private void RunSerializationTest(string testDataFile, Func<WebService> createWebserviceCall)
        {
            // Validate correct serialization
            var payload = createWebserviceCall();
            string output = ModelsSerializationUtil.GetAzureMLWebServiceDefinitionJsonFromObject(payload);
            ModelSerializationTests.ValidateJson(output, testDataFile);
        }

        private static WebService CreateWebServiceGraph()
        {
            var payload = new WebService
            {
                Location = "South Central US",
                Tags = new Dictionary<string, string>()
                {
                    { "tag1", "https://foo-graph.com" }
                },
                Name = "graphWebService",
                Id = "/subscriptions/7b373400-c82e-453b-a97b-c53e14325b8b/resourceGroups/rg/providers/Microsoft.MachineLearning/webServices/graphWebService",
                Type = "Microsoft.MachineLearning/webservices"
            };

            var payloadProperties = new WebServicePropertiesForGraph();
            ModelSerializationTests.UpdateWebServiceCommonProperties(payloadProperties);

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
                Location = "South Central US",
                Tags = new Dictionary<string, string>
                {
                    { "tag1", "https://foo-code.com" }
                },
                Name = "codeWebService",
                Id = "/subscriptions/7b373400-c82e-453b-a97b-c53e14325b8b/resourceGroups/rg/providers/Microsoft.MachineLearning/webServices/codehWebService",
                Type = "Microsoft.MachineLearning/webservices"
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
            var dateTime = new DateTime(2017, 2, 4, 2, 20, 15, DateTimeKind.Local);
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