// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ModelQueryTests
    {
        private readonly string _modelTemplate = @"{{
            {0}
            ""@type"": ""Interface"",
            ""displayName"": ""Phone"",
            {1}
            {2}
            ""@context"": ""dtmi:dtdl:context;2""
        }}";

        [TestCase("\"@id\": \"dtmi:com:example:thermostat;1\",", "dtmi:com:example:thermostat;1")]
        [TestCase("\"@id\": \"\",", "")]
        [TestCase("", "")]
        public void GetId(string formatId, string expectedId)
        {
            string modelContent = string.Format(_modelTemplate, formatId, "", "");
            ModelQuery query = new ModelQuery(modelContent);
            Assert.AreEqual(query.ParseModel().Id, expectedId);
        }

        [TestCase(
            @"
            ""contents"":
            [{
                ""@type"": ""Property"",
                ""name"": ""capacity"",
                ""schema"": ""integer""
            },
            {
                ""@type"": ""Component"",
                ""name"": ""frontCamera"",
                ""schema"": ""dtmi:com:example:Camera;3""
            },
            {
                ""@type"": ""Component"",
                ""name"": ""backCamera"",
                ""schema"": ""dtmi:com:example:Camera;3""
            },
            {
                ""@type"": ""Component"",
                ""name"": ""deviceInfo"",
                ""schema"": ""dtmi:azure:DeviceManagement:DeviceInformation;1""
            }],",
            "dtmi:com:example:Camera;3,dtmi:com:example:Camera;3,dtmi:azure:DeviceManagement:DeviceInformation;1"
        )]
        [TestCase(
            @"
            ""contents"":
            [{
              ""@type"": ""Property"",
              ""name"": ""capacity"",
              ""schema"": ""integer""
            }],", ""
        )]
        [TestCase(@"""contents"":[],", "")]
        [TestCase("", "")]
        public void GetComponentSchema(string contents, string expected)
        {
            string[] expectedDtmis = expected.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
            string modelContent = string.Format(_modelTemplate, "", "", contents);
            ModelQuery query = new ModelQuery(modelContent);
            IList<string> componentSchemas = query.ParseModel().ComponentSchemas;
            Assert.AreEqual(componentSchemas.Count, expectedDtmis.Length);

            foreach (string schema in componentSchemas)
            {
                Assert.Contains(schema, expectedDtmis);
            }
        }

        [TestCase(
            "\"extends\": [\"dtmi:com:example:Camera;3\",\"dtmi:azure:DeviceManagement:DeviceInformation;1\"],",
            "dtmi:com:example:Camera;3,dtmi:azure:DeviceManagement:DeviceInformation;1"
        )]
        [TestCase("\"extends\": [],", "")]
        [TestCase("\"extends\": \"dtmi:com:example:Camera;3\",", "dtmi:com:example:Camera;3")]
        [TestCase("", "")]
        public void GetExtends(string extends, string expected)
        {
            string[] expectedDtmis = expected.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
            string modelContent = string.Format(_modelTemplate, "", extends, "");
            ModelQuery query = new ModelQuery(modelContent);
            IList<string> extendsDtmis = query.ParseModel().Extends;
            Assert.AreEqual(extendsDtmis.Count, expectedDtmis.Length);

            foreach (string dtmi in extendsDtmis)
            {
                Assert.Contains(dtmi, expectedDtmis);
            }
        }

        [TestCase(
            "\"@id\": \"dtmi:com:example:thermostat;1\",",
            "\"extends\": [\"dtmi:com:example:Camera;3\",\"dtmi:azure:DeviceManagement:DeviceInformation;1\"],",
            @"""contents"":
            [{
              ""@type"": ""Property"",
              ""name"": ""capacity"",
              ""schema"": ""integer""
            },
            {
                ""@type"": ""Component"",
                ""name"": ""frontCamera"",
                ""schema"": ""dtmi:com:example:Camera;3""
            },
            {
                ""@type"": ""Component"",
                ""name"": ""backCamera"",
                ""schema"": ""dtmi:com:example:Camera;3""
            }],",
            "dtmi:com:example:Camera;3,dtmi:azure:DeviceManagement:DeviceInformation;1"
        ),
        TestCase(
            "\"@id\": \"dtmi:example:Interface1;1\",",
            @"""extends"": [""dtmi:example:Interface2;1"", {
              ""@id"": ""dtmi:example:Interface3;1"",
              ""@type"": ""Interface"",
              ""contents"": [{
                  ""@type"": ""Component"",
                  ""name"": ""comp1"",
                  ""schema"": [""dtmi:example:Interface4;1""]
                },
                {
                  ""@type"": ""Component"",
                  ""name"": ""comp2"",
                  ""schema"": {
                    ""@id"": ""dtmi:example:Interface5;1"",
                    ""@type"": ""Interface"",
                    ""extends"": ""dtmi:example:Interface6;1""
                  }
                }
              ]
            }],",
            "",
            "dtmi:example:Interface2;1,dtmi:example:Interface4;1,dtmi:example:Interface6;1"
        )]
        public void GetModelDependencies(string id, string extends, string contents, string expected)
        {
            string[] expectedDtmis = expected.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
            string modelContent = string.Format(_modelTemplate, id, extends, contents);
            ModelMetadata metadata = new ModelQuery(modelContent).ParseModel();

            IList<string> dependencies = metadata.Dependencies;

            Assert.AreEqual(dependencies.Count, expectedDtmis.Length);

            foreach (string dtmi in dependencies)
            {
                Assert.Contains(dtmi, expectedDtmis);
            }
        }

        [Test]
        public void ListToDict()
        {
            string testRepoPath = TestHelpers.TestLocalModelRepository;
            string expandedContent = File.ReadAllText(
                $"{testRepoPath}/dtmi/com/example/temperaturecontroller-1.expanded.json", Encoding.UTF8);
            ModelQuery query = new ModelQuery(expandedContent);
            Dictionary<string, string> transformResult = query.ListToDict();

            // Assert KPI's for TemperatureController;1.
            // Ensure transform of expanded content to dictionary is what we'd expect.
            string[] expectedIds = new string[] {
                "dtmi:azure:DeviceManagement:DeviceInformation;1",
                "dtmi:com:example:Thermostat;1",
                "dtmi:com:example:TemperatureController;1" };

            Assert.True(transformResult.Keys.Count == expectedIds.Length);

            foreach (string id in expectedIds)
            {
                Assert.True(transformResult.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(transformResult[id]).Equals(id, System.StringComparison.Ordinal));
            }
        }
    }
}
