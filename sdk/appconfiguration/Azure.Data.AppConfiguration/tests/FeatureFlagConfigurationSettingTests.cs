// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class FeatureFlagConfigurationSettingTests
    {
        private const string MinimalFeatureValue = "{\"id\":\"my feature\",\"enabled\":false,\"conditions\":{}}";
        private const string FullFeatureValue = "{" +
                                                    "\"id\":\"Feature Id\"," +
                                                    "\"description\":\"Description\"," +
                                                    "\"display_name\":\"Display name\"," +
                                                    "\"enabled\":true," +
                                                    "\"conditions\":{" +
                                                        "\"client_filters\":[" +
                                                            "{\"name\":\"Flag1\",\"parameters\":{}}," +
                                                            "{\"name\":\"Flag2\",\"parameters\":{" +
                                                                "\"p1\":\"s\"," +
                                                                "\"p2\":1," +
                                                                "\"p3\":true," +
                                                                "\"p4\":null," +
                                                                "\"p5\":[" +
                                                                    "\"s\"," +
                                                                    "1," +
                                                                    "true," +
                                                                    "null," +
                                                                    "[1]," +
                                                                    "{" +
                                                                        "\"p6\":\"s\"," +
                                                                        "\"p7\":1," +
                                                                        "\"p8\":true," +
                                                                        "\"p9\":null" +
                                                                    "}" +
                                                                "]" +
                                                            "}}" +
                                                        "]" +
                                                    "}" +
                                                "}";

        private const string UnknownAttributeFeatureValue = @"{
              ""id"": ""original-id"",
              ""description"":""original-description"",
              ""more_custom"" : [1, 2, 3, 4],
              ""display_name"":""original-display"",
              ""enabled"": false,
              ""custom_stuff"": { ""id"":""dummy"", ""description"":""dummy"", ""enabled"":false },
              ""conditions"": {
                ""custom_condition"": { ""id"":""custcond"", ""description"":""a thing"" },
                ""client_filters"": [
                  {
                    ""name"": ""Flag1"",
                    ""parameters"": {}
                  },
                  {
                    ""name"": ""Flag2"",
                    ""parameters"": {
                      ""p1"": ""s"",
                      ""p2"": 1,
                      ""p3"": true,
                      ""p4"": null,
                      ""p5"": [
                        ""s"",
                        1,
                        true,
                        null,
                        [
                          1
                        ],
                        {
                          ""p6"": ""s"",
                          ""p7"": 1,
                          ""p8"": true,
                          ""p9"": null
                        }
                      ]
                    }
                  }
                ],
                ""condition_val"":1
              }
            }";

        private const string UnknownAttributeMinimalFeatureValue = @"{
              ""id"": ""original-id"",
              ""enabled"": false,
              ""custom_stuff"": { ""id"":""dummy"", ""description"":""dummy"", ""enabled"":false },
              ""conditions"": {}
            }";

        private const string MinimalFeatureValueWithFormatting = "{  \"id\"    :     \"my feature\"   ,   \"enabled\":false,\"conditions\":{}}";
        private const string MinimalFeatureValueWithInvalidConditions = "{\"id\":\"my feature\",\"enabled\":false,\"conditions\": \"broken\"}";
        private readonly JsonElementEqualityComparer _jsonComparer = new();

        [Test]
        public void CreatingSetsContentTypeAndPrefix()
        {
            var feature = new FeatureFlagConfigurationSetting("my feature", false);

            Assert.AreEqual("application/vnd.microsoft.appconfig.ff+json;charset=utf-8", feature.ContentType);
            Assert.AreEqual(".appconfig.featureflag/my feature" , feature.Key);
            Assert.AreEqual("my feature", feature.FeatureId);
            Assert.AreEqual(false, feature.IsEnabled);
        }

        [TestCase("INVALID")]
        [TestCase(MinimalFeatureValue)]
        [TestCase(MinimalFeatureValueWithInvalidConditions)]
        [TestCase("")]
        public void CanRountripValue(string value)
        {
            var featureFlag = new FeatureFlagConfigurationSetting();
            featureFlag.Value = value;

            try
            {
                using var expected = JsonDocument.Parse(value);
                using var actual = JsonDocument.Parse(featureFlag.Value);

                Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
            }
            catch (JsonException)
            {
                // For the cases that are not legal JSON, this exception will occur
                // and we just want to make sure that the string value is set correctly.
                Assert.AreEqual(value, featureFlag.Value);
            }
        }

        [Test]
        public void NewFeatureFlagSerialized()
        {
            var feature = new FeatureFlagConfigurationSetting("my feature", false);
            feature.IsEnabled = true;
            feature.Description = "Description";
            feature.DisplayName = "Display name";
            feature.FeatureId = "Feature Id";
            feature.ClientFilters.Add(new FeatureFlagFilter("Flag1"));
            feature.ClientFilters.Add(new FeatureFlagFilter("Flag2", new Dictionary<string, object>()
            {
                {"p1", "s"},
                {"p2", 1},
                {"p3", true},
                {"p4", null},
                {"p5", new object[]
                {
                    "s",
                    1,
                    true,
                    null,
                    new object[] { 1 },
                    new Dictionary<string, object>()
                    {
                        {"p6", "s"},
                        {"p7", 1},
                        {"p8", true},
                        {"p9", null},
                    }
                }}
            }));

            using var expected = JsonDocument.Parse(FullFeatureValue);
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void FeatureValueIsParsedOnAssignment()
        {
            var feature = new FeatureFlagConfigurationSetting("random feature", false);
            feature.Value = FullFeatureValue;
            Assert.AreEqual("Feature Id", feature.FeatureId);
            Assert.AreEqual("Description", feature.Description);
            Assert.AreEqual("Display name", feature.DisplayName);
            Assert.AreEqual(true, feature.IsEnabled);
            Assert.AreEqual(2, feature.ClientFilters.Count);

            Assert.AreEqual("Flag1", feature.ClientFilters[0].Name);
            Assert.AreEqual(0, feature.ClientFilters[0].Parameters.Count);

            Assert.AreEqual("Flag2", feature.ClientFilters[1].Name);
            Assert.AreEqual(new Dictionary<string, object>()
                {
                    {"p1", "s"},
                    {"p2", 1},
                    {"p3", true},
                    {"p4", null},
                    {"p5", new object[]
                    {
                        "s",
                        1,
                        true,
                        null,
                        new object[] { 1 },
                        new Dictionary<string, object>()
                        {
                            {"p6", "s"},
                            {"p7", 1},
                            {"p8", true},
                            {"p9", null},
                        }
                    }}}, feature.ClientFilters[1].Parameters);
        }

        [Test]
        public void SettingDescriptionChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.Description = "new description";

            using var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"description\":\"new description\",\"enabled\":false,\"conditions\":{}}");
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void SettingEnabledChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.IsEnabled = true;

            using var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"enabled\":true,\"conditions\":{}}");
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void SettingFeatureIdChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.FeatureId = "my old feature";

            using var expected = JsonDocument.Parse("{\"id\":\"my old feature\",\"enabled\":false,\"conditions\":{}}");
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void SettingDisplayNameChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.DisplayName = "Very nice feature indeed";

            using var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"display_name\":\"Very nice feature indeed\",\"enabled\":false,\"conditions\":{}}");
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void AddingConditionChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.ClientFilters.Add(new FeatureFlagFilter("file", new Dictionary<string, object>()
            {
                {"p1", 1}
            }));

            using var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"enabled\":false,\"conditions\":{\"client_filters\":[{\"name\":\"file\",\"parameters\":{\"p1\":1}}]}}");
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void ChangingParametersUpdatesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.ClientFilters.Add(new FeatureFlagFilter("file", new Dictionary<string, object>()
            {
                {"p1", 1}
            }));

            using (var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"enabled\":false,\"conditions\":{\"client_filters\":[{\"name\":\"file\",\"parameters\":{\"p1\":1}}]}}"))
            using (var actual = JsonDocument.Parse(feature.Value))
            {
                Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
            }

            feature.ClientFilters[0].Parameters["p1"] = 2;

            using (var expected = JsonDocument.Parse("{\"id\":\"my feature\",\"enabled\":false,\"conditions\":{\"client_filters\":[{\"name\":\"file\",\"parameters\":{\"p1\":2}}]}}"))
            using (var actual = JsonDocument.Parse(feature.Value))
            {
                Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
            }
        }

        [Test]
        public void UnknownAttributesArePreservedWhenReadingValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = UnknownAttributeFeatureValue;

            using var expected = JsonDocument.Parse(UnknownAttributeFeatureValue);

            // Since the value is generated on each read, read and compare multiple times to ensure
            // that the result is consistent.
            for (var index = 0; index < 3; ++index)
            {
                using var actual = JsonDocument.Parse(feature.Value);
                Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
            }
        }

        [Test]
        public void UnknownAttributesArePreservedChangingProperties()
        {
            var originalFeature = new FeatureFlagConfigurationSetting();
            originalFeature.Value = UnknownAttributeFeatureValue;

            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = UnknownAttributeFeatureValue;

            feature.FeatureId = "new-id";
            feature.Description = "new-description";
            feature.DisplayName = "new-display";

            var expectedJson = originalFeature.Value
                .Replace(originalFeature.FeatureId, feature.FeatureId)
                .Replace(originalFeature.Description, feature.Description)
                .Replace(originalFeature.DisplayName, feature.DisplayName);

            using var expected = JsonDocument.Parse(expectedJson);
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void UnknownAttributesArePreservedWhenAddingOptionalMembers()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = UnknownAttributeMinimalFeatureValue;
            feature.DisplayName = "new-display";
            feature.Description = "new-description";

            // Hack up the source JSON to inject the new members.  Order should not matter for equality,
            // so include them in the opposite order.
            var expectedJson =
                UnknownAttributeMinimalFeatureValue.Substring(0, UnknownAttributeMinimalFeatureValue.Length - 1) +
                $",\"description\":\"{feature.Description}\"" +
                $",\"display_name\":\"{feature.DisplayName}\"" +
                "}";

            using var expected = JsonDocument.Parse(expectedJson);
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void UnknownAttributesArePreservedAndNullOptionalMembersAreNotAdded()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = UnknownAttributeMinimalFeatureValue;
            feature.DisplayName = "new-display";
            feature.Description = "new-description";

            feature.DisplayName = null;
            feature.Description = null;

            using var expected = JsonDocument.Parse(UnknownAttributeMinimalFeatureValue);
            using var actual = JsonDocument.Parse(feature.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void InvalidConditionTypeIsTreatedAsInvalid()
        {
            var featureFlag = new FeatureFlagConfigurationSetting();
            featureFlag.Value = MinimalFeatureValueWithInvalidConditions;

            Assert.Throws<InvalidOperationException>(() =>
                featureFlag.ClientFilters.Add(new FeatureFlagFilter(
                    "file",
                    new Dictionary<string, object>()
                    {
                        {"p1", 1}
                    })));

            using var expected = JsonDocument.Parse(MinimalFeatureValueWithInvalidConditions);
            using var actual = JsonDocument.Parse(featureFlag.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }
    }
}
