// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class IndexingParametersTests
    {
        [Test]
        public void ConfigurationInitializesIndexingParametersConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters();
            Assert.IsNull(parameters.IndexingParametersConfiguration);

            // Setting Configuration should initialize IndexingParametersConfiguration
            Assert.IsNotNull(parameters.Configuration);
            Assert.AreEqual(0, parameters.Configuration.Count);

            parameters.Configuration["customTestProperty"] = "custom";
            Assert.IsNotNull(parameters.IndexingParametersConfiguration);
            Assert.AreEqual(1, parameters.Configuration.Count);
        }

        [Test]
        public void SetIndexingParametersConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                    ["customTestProperty"] = "custom",
                },
            };

            Assert.AreEqual(2, parameters.Configuration.Count);
            Assert.AreEqual(BlobIndexerParsingMode.Json, parameters.Configuration["parsingMode"]);
            Assert.AreEqual("custom", parameters.Configuration["customTestProperty"]);

            Assert.AreEqual(1, parameters.IndexingParametersConfiguration.Count());
            Assert.AreEqual("custom", parameters.IndexingParametersConfiguration["customTestProperty"]);

            Assert.AreEqual(BlobIndexerParsingMode.Json, parameters.IndexingParametersConfiguration.ParsingMode);
        }

        [Test]
        public void RoundtripsFromConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["parsingMode"] = "json",
                    ["excludedFileNameExtensions"] = ".png",
                    ["indexedFileNameExtensions"] = ".json,.jsonc",
                    ["failOnUnsupportedContentType"] = false,
                    ["failOnUnprocessableDocument"] = false,
                    ["indexStorageMetadataOnlyForOversizedDocuments"] = true,
                    ["delimitedTextHeaders"] = "A,B",
                    ["delimitedTextDelimiter"] = "|",
                    ["firstLineContainsHeaders"] = true,
                    ["documentRoot"] = "$.values",
                    ["dataToExtract"] = "allMetadata",
                    ["imageAction"] = "generateNormalizedImages",
                    ["allowSkillsetToReadFileData"] = true,
                    ["pdfTextRotationAlgorithm"] = "detectAngles",
                    ["executionEnvironment"] = "standard",
                    ["queryTimeout"] = "12:34:56",
                    ["customTestProperty"] = "custom",
                },
            };

            IndexingParametersConfiguration configuration = parameters.IndexingParametersConfiguration;

            Assert.AreEqual(BlobIndexerParsingMode.Json, configuration.ParsingMode);
            Assert.AreEqual(".png", configuration.ExcludedFileNameExtensions);
            Assert.AreEqual(".json,.jsonc", configuration.IndexedFileNameExtensions);
            Assert.IsFalse(configuration.FailOnUnsupportedContentType);
            Assert.IsFalse(configuration.FailOnUnprocessableDocument);
            Assert.IsTrue(configuration.IndexStorageMetadataOnlyForOversizedDocuments);
            Assert.AreEqual("A,B", configuration.DelimitedTextHeaders);
            Assert.AreEqual("|", configuration.DelimitedTextDelimiter);
            Assert.IsTrue(configuration.FirstLineContainsHeaders);
            Assert.AreEqual("$.values", configuration.DocumentRoot);
            Assert.AreEqual(BlobIndexerDataToExtract.AllMetadata, configuration.DataToExtract);
            Assert.AreEqual(BlobIndexerImageAction.GenerateNormalizedImages, configuration.ImageAction);
            Assert.IsTrue(configuration.AllowSkillsetToReadFileData);
            Assert.AreEqual(BlobIndexerPdfTextRotationAlgorithm.DetectAngles, configuration.PdfTextRotationAlgorithm);
            Assert.AreEqual(IndexerExecutionEnvironment.Standard, configuration.ExecutionEnvironment);
            Assert.AreEqual(TimeSpan.Parse("12:34:56"), configuration.QueryTimeout);

            Assert.AreEqual(1, configuration.Count());
            Assert.AreEqual("custom", configuration["customTestProperty"]);
        }

        [Test]
        public void RoundtripsFromConfigurationWithExplicitNulls()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["parsingMode"] = null,
                    ["excludedFileNameExtensions"] = null,
                    ["indexedFileNameExtensions"] = null,
                    ["failOnUnsupportedContentType"] = null,
                    ["failOnUnprocessableDocument"] = null,
                    ["indexStorageMetadataOnlyForOversizedDocuments"] = null,
                    ["delimitedTextHeaders"] = null,
                    ["delimitedTextDelimiter"] = null,
                    ["firstLineContainsHeaders"] = null,
                    ["documentRoot"] = null,
                    ["dataToExtract"] = null,
                    ["imageAction"] = null,
                    ["allowSkillsetToReadFileData"] = null,
                    ["pdfTextRotationAlgorithm"] = null,
                    ["executionEnvironment"] = null,
                    ["queryTimeout"] = null,
                    ["customTestProperty"] = null,
                },
            };

            IndexingParametersConfiguration configuration = parameters.IndexingParametersConfiguration;

            Assert.IsNull(configuration.ParsingMode);
            Assert.IsNull(configuration.ExcludedFileNameExtensions);
            Assert.IsNull(configuration.IndexedFileNameExtensions);
            Assert.IsNull(configuration.FailOnUnsupportedContentType);
            Assert.IsNull(configuration.FailOnUnprocessableDocument);
            Assert.IsNull(configuration.IndexStorageMetadataOnlyForOversizedDocuments);
            Assert.IsNull(configuration.DelimitedTextHeaders);
            Assert.IsNull(configuration.DelimitedTextDelimiter);
            Assert.IsNull(configuration.FirstLineContainsHeaders);
            Assert.IsNull(configuration.DocumentRoot);
            Assert.IsNull(configuration.DataToExtract);
            Assert.IsNull(configuration.ImageAction);
            Assert.IsNull(configuration.AllowSkillsetToReadFileData);
            Assert.IsNull(configuration.PdfTextRotationAlgorithm);
            Assert.IsNull(configuration.ExecutionEnvironment);
            Assert.IsNull(configuration.QueryTimeout);

            Assert.AreEqual(1, configuration.Count());
            Assert.IsNull(configuration["customTestProperty"]);
        }

        [Test]
        public void UnexpectedValueTypeForBool()
        {
            IndexingParameters parameters = new IndexingParameters();
            Assert.Throws<InvalidCastException>(() => parameters.Configuration["failOnUnsupportedContentType"] = "meh");
        }

        [Test]
        public void UnexpectedValueTypeForEnum()
        {
            IndexingParameters parameters = new IndexingParameters();
            Assert.Throws<InvalidCastException>(() => parameters.Configuration["parsingMode"] = false);
        }

        [Test]
        public void UnexpectedValueTypeForString()
        {
            IndexingParameters parameters = new IndexingParameters();
            Assert.Throws<InvalidCastException>(() => parameters.Configuration["excludedFileNameExtensions"] = false);
        }

        [Test]
        public void ConfigurationKeysGrowAndShrink()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<string> keys = parameters.Configuration.Keys;

            Assert.AreEqual(0, keys.Count);

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
                ["customTestProperty"] = "custom",
            };

            Assert.AreEqual(2, keys.Count);
            CollectionAssert.Contains(keys, "parsingMode");
            CollectionAssert.Contains(keys, "customTestProperty");

            parameters.Configuration.Clear();

            Assert.AreEqual(0, keys.Count);
        }

        [Test]
        public void ConfigurationValuesGrowAndShrink()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<object> values = parameters.Configuration.Values;

            Assert.AreEqual(0, values.Count);

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
                ["customTestProperty"] = "custom",
            };

            Assert.AreEqual(2, values.Count);
            CollectionAssert.Contains(values, BlobIndexerParsingMode.Json);
            CollectionAssert.Contains(values, "custom");

            parameters.Configuration.Clear();

            Assert.AreEqual(0, values.Count);
        }

        [Test]
        public void ConfigurationKeysAreReadOnly()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<string> keys = parameters.Configuration.Keys;

            Assert.IsTrue(keys.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => keys.Add("customTestProperty"));
            Assert.Throws<NotSupportedException>(() => keys.Remove("customTestProperty"));
            Assert.Throws<NotSupportedException>(() => keys.Clear());
        }

        [Test]
        public void ConfigurationValuesAreReadOnly()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<object> values = parameters.Configuration.Values;

            Assert.IsTrue(values.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => values.Add("custom"));
            Assert.Throws<NotSupportedException>(() => values.Remove("custom"));
            Assert.Throws<NotSupportedException>(() => values.Clear());
        }

        [Test]
        public void CopiesConfigurationKeys()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                    ["customTestProperty"] = "custom",
                },
            };

            string[] keys = new string[parameters.Configuration.Count];
            parameters.Configuration.Keys.CopyTo(keys, 0);
            Assert.AreEqual(new[] { "parsingMode", "customTestProperty" }, keys);
        }

        [Test]
        public void CopiesConfigurationValues()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                    ["customTestProperty"] = "custom",
                },
            };

            object[] values = new object[parameters.Configuration.Count];
            parameters.Configuration.Values.CopyTo(values, 0);
            Assert.AreEqual(new object[] { BlobIndexerParsingMode.Json, "custom" }, values);
        }

        [Test]
        public void ConfigurationIsReadWrite() =>
            Assert.IsFalse(new IndexingParameters().Configuration.IsReadOnly);

        [Test]
        public void AddsToCorrectConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters();

            parameters.Configuration.Add("parsingMode", "json");
            Assert.AreEqual(1, parameters.Configuration.Count);
            Assert.IsTrue(parameters.Configuration.ContainsKey("parsingMode"));
            Assert.IsFalse(parameters.Configuration.Contains(new KeyValuePair<string, object>("parsingMode", "json")));
            Assert.IsTrue(parameters.Configuration.Contains(new KeyValuePair<string, object>("parsingMode", BlobIndexerParsingMode.Json)));
            Assert.AreEqual(0, parameters.IndexingParametersConfiguration.Count());
            Assert.IsFalse(parameters.IndexingParametersConfiguration.ContainsKey("parsingMode"));

            parameters.Configuration.Add("customTestProperty", "custom");
            Assert.AreEqual(2, parameters.Configuration.Count);
            Assert.IsTrue(parameters.Configuration.ContainsKey("customTestProperty"));
            Assert.AreEqual(1, parameters.IndexingParametersConfiguration.Count());
            Assert.IsTrue(parameters.IndexingParametersConfiguration.ContainsKey("customTestProperty"));
            Assert.IsTrue(parameters.IndexingParametersConfiguration.Contains(new KeyValuePair<string, object>("customTestProperty", "custom")));
        }

        [Test]
        public void AddExistingConfigurationThrows()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                },
            };

            //Assert.Throws<ArgumentException>(() => parameters.Configuration.Add("parsingMode", "json"));
            Assert.Throws<ArgumentException>(() => parameters.Configuration.Add(new KeyValuePair<string, object>("parsingMode", "json")));
        }

        [Test]
        public void CopyToNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new IndexingParameters().Configuration.CopyTo(null, 0));

        [Test]
        public void CopyToNegativeStartIndexThrows() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new IndexingParameters().Configuration.CopyTo(Array.Empty<KeyValuePair<string, object>>(), -1));

        [Test]
        public void CopiesConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                    IndexedFileNameExtensions = ".json",
                    ["customTestProperty"] = "custom",
                },
            };

            KeyValuePair<string, object>[] pairs = new KeyValuePair<string, object>[parameters.Configuration.Count + 1];
            parameters.Configuration.CopyTo(pairs, 1);

            Assert.IsNull(pairs[0].Key);

            // Dictionary order is guaranteed, so check the last one which should be from AdditionalProperties.
            Assert.AreEqual("customTestProperty", pairs[3].Key);
        }

        [Test]
        public void SettingIndexingParametersConfigurationOverwritesConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["customTestProperty"] = "custom",
                },
            };

            Assert.AreEqual(1, parameters.Configuration.Count);
            CollectionAssert.Contains(parameters.Configuration.Keys, "customTestProperty");

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
            };

            Assert.AreEqual(1, parameters.Configuration.Count);
            CollectionAssert.Contains(parameters.Configuration.Keys, "parsingMode");
        }

        [Test]
        public void RemoveWellKnownConfigurationNullsValue()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                },
            };

            parameters.Configuration.Remove("parsingMode");

            Assert.AreEqual(0, parameters.Configuration.Count);
            Assert.IsNull(parameters.IndexingParametersConfiguration.ParsingMode);
        }

        [Test]
        public void RemovesCustomConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ["customTestProperty"] = "custom",
                },
            };

            parameters.Configuration.Remove("customTestProperty");

            Assert.AreEqual(0, parameters.Configuration.Count);
            Assert.AreEqual(0, parameters.IndexingParametersConfiguration.Count());
        }

        [Test]
        public void RemovePairChecksWellKnownPropertyValue()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                },
            };

            Assert.IsFalse(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", "text")));
            Assert.AreEqual(1, parameters.Configuration.Count);

            Assert.IsFalse(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", "json")));
            Assert.AreEqual(1, parameters.Configuration.Count);

            Assert.IsTrue(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", BlobIndexerParsingMode.Json)));
            Assert.AreEqual(0, parameters.Configuration.Count);
        }

        [Test]
        public void RemovePairChecksCustomPropertyValue()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ["customTestProperty"] = "custom",
                },
            };

            Assert.IsFalse(parameters.Configuration.Remove(new KeyValuePair<string, object>("customTestProperty", "other")));
            Assert.AreEqual(1, parameters.Configuration.Count);

            Assert.IsTrue(parameters.Configuration.Remove(new KeyValuePair<string, object>("customTestProperty", "custom")));
            Assert.AreEqual(0, parameters.Configuration.Count);
        }
    }
}
