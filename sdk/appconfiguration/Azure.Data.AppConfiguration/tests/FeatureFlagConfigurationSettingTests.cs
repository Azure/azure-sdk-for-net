// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration
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

        private const string MinimalFeatureValueWithFormatting = "{  \"id\"    :     \"my feature\"   ,   \"enabled\":false,\"conditions\":{}}";

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
        [TestCase(MinimalFeatureValueWithFormatting)]
        [TestCase("")]
        public void CanRountripValue(string value)
        {
            var featureFlag = new FeatureFlagConfigurationSetting();
            featureFlag.Value = value;

            Assert.AreEqual(value, featureFlag.Value);
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

            Assert.AreEqual(FullFeatureValue, feature.Value);
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
        public void ReadingPropertiedDoesNotChangeValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            _ = feature.Description;
            _ = feature.ClientFilters;
            _ = feature.DisplayName;
            _ = feature.FeatureId;
            _ = feature.IsEnabled;

            Assert.AreEqual(MinimalFeatureValueWithFormatting, feature.Value);
        }

        [Test]
        public void SettingDescriptionChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.Description = "new description";

            Assert.AreEqual("{\"id\":\"my feature\",\"description\":\"new description\",\"enabled\":false,\"conditions\":{}}", feature.Value);
        }

        [Test]
        public void SettingEnabledChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.IsEnabled = true;

            Assert.AreEqual("{\"id\":\"my feature\",\"enabled\":true,\"conditions\":{}}", feature.Value);
        }

        [Test]
        public void SettingFeatureIdChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.FeatureId = "my old feature";

            Assert.AreEqual("{\"id\":\"my old feature\",\"enabled\":false,\"conditions\":{}}", feature.Value);
        }

        [Test]
        public void SettingDisplayNameChangesValue()
        {
            var feature = new FeatureFlagConfigurationSetting();
            feature.Value = MinimalFeatureValueWithFormatting;
            feature.DisplayName = "Very nice feature indeed";

            Assert.AreEqual("{\"id\":\"my feature\",\"display_name\":\"Very nice feature indeed\",\"enabled\":false,\"conditions\":{}}", feature.Value);
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

            Assert.AreEqual("{\"id\":\"my feature\",\"enabled\":false,\"conditions\":{\"client_filters\":[{\"name\":\"file\",\"parameters\":{\"p1\":1}}]}}", feature.Value);
        }
    }
}