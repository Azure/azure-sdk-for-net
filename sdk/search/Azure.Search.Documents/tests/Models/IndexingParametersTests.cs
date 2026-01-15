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
            Assert.That(parameters.Configuration.Count, Is.EqualTo(0));

            parameters.Configuration["customTestProperty"] = "custom";
            Assert.IsNotNull(parameters.IndexingParametersConfiguration);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));
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

            Assert.That(parameters.Configuration.Count, Is.EqualTo(2));
            Assert.That(parameters.Configuration["parsingMode"], Is.EqualTo(BlobIndexerParsingMode.Json));
            Assert.That(parameters.Configuration["customTestProperty"], Is.EqualTo("custom"));

            Assert.That(parameters.IndexingParametersConfiguration.Count(), Is.EqualTo(1));
            Assert.That(parameters.IndexingParametersConfiguration["customTestProperty"], Is.EqualTo("custom"));

            Assert.That(parameters.IndexingParametersConfiguration.ParsingMode, Is.EqualTo(BlobIndexerParsingMode.Json));
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

            Assert.That(configuration.ParsingMode, Is.EqualTo(BlobIndexerParsingMode.Json));
            Assert.That(configuration.ExcludedFileNameExtensions, Is.EqualTo(".png"));
            Assert.That(configuration.IndexedFileNameExtensions, Is.EqualTo(".json,.jsonc"));
            Assert.That(configuration.FailOnUnsupportedContentType, Is.False);
            Assert.That(configuration.FailOnUnprocessableDocument, Is.False);
            Assert.That(configuration.IndexStorageMetadataOnlyForOversizedDocuments, Is.True);
            Assert.That(configuration.DelimitedTextHeaders, Is.EqualTo("A,B"));
            Assert.That(configuration.DelimitedTextDelimiter, Is.EqualTo("|"));
            Assert.That(configuration.FirstLineContainsHeaders, Is.True);
            Assert.That(configuration.DocumentRoot, Is.EqualTo("$.values"));
            Assert.That(configuration.DataToExtract, Is.EqualTo(BlobIndexerDataToExtract.AllMetadata));
            Assert.That(configuration.ImageAction, Is.EqualTo(BlobIndexerImageAction.GenerateNormalizedImages));
            Assert.That(configuration.AllowSkillsetToReadFileData, Is.True);
            Assert.That(configuration.PdfTextRotationAlgorithm, Is.EqualTo(BlobIndexerPdfTextRotationAlgorithm.DetectAngles));
            Assert.That(configuration.ExecutionEnvironment, Is.EqualTo(IndexerExecutionEnvironment.Standard));
            Assert.That(configuration.QueryTimeout, Is.EqualTo(TimeSpan.Parse("12:34:56")));

            Assert.That(configuration.Count(), Is.EqualTo(1));
            Assert.That(configuration["customTestProperty"], Is.EqualTo("custom"));
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

            Assert.That(configuration.Count(), Is.EqualTo(1));
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

            Assert.That(keys.Count, Is.EqualTo(0));

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
                ["customTestProperty"] = "custom",
            };

            Assert.That(keys.Count, Is.EqualTo(2));
            CollectionAssert.Contains(keys, "parsingMode");
            CollectionAssert.Contains(keys, "customTestProperty");

            parameters.Configuration.Clear();

            Assert.That(keys.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConfigurationValuesGrowAndShrink()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<object> values = parameters.Configuration.Values;

            Assert.That(values.Count, Is.EqualTo(0));

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
                ["customTestProperty"] = "custom",
            };

            Assert.That(values.Count, Is.EqualTo(2));
            CollectionAssert.Contains(values, BlobIndexerParsingMode.Json);
            CollectionAssert.Contains(values, "custom");

            parameters.Configuration.Clear();

            Assert.That(values.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConfigurationKeysAreReadOnly()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<string> keys = parameters.Configuration.Keys;

            Assert.That(keys.IsReadOnly, Is.True);
            Assert.Throws<NotSupportedException>(() => keys.Add("customTestProperty"));
            Assert.Throws<NotSupportedException>(() => keys.Remove("customTestProperty"));
            Assert.Throws<NotSupportedException>(() => keys.Clear());
        }

        [Test]
        public void ConfigurationValuesAreReadOnly()
        {
            IndexingParameters parameters = new IndexingParameters();
            ICollection<object> values = parameters.Configuration.Values;

            Assert.That(values.IsReadOnly, Is.True);
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
            Assert.That(keys, Is.EqualTo(new[] { "parsingMode", "customTestProperty" }));
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
            Assert.That(values, Is.EqualTo(new object[] { BlobIndexerParsingMode.Json, "custom" }));
        }

        [Test]
        public void ConfigurationIsReadWrite() =>
            Assert.That(new IndexingParameters().Configuration.IsReadOnly, Is.False);

        [Test]
        public void AddsToCorrectConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters();

            parameters.Configuration.Add("parsingMode", "json");
            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));
            Assert.That(parameters.Configuration.ContainsKey("parsingMode"), Is.True);
            Assert.That(parameters.Configuration.Contains(new KeyValuePair<string, object>("parsingMode", "json")), Is.False);
            Assert.That(parameters.Configuration.Contains(new KeyValuePair<string, object>("parsingMode", BlobIndexerParsingMode.Json)), Is.True);
            Assert.That(parameters.IndexingParametersConfiguration.Count(), Is.EqualTo(0));
            Assert.That(parameters.IndexingParametersConfiguration.ContainsKey("parsingMode"), Is.False);

            parameters.Configuration.Add("customTestProperty", "custom");
            Assert.That(parameters.Configuration.Count, Is.EqualTo(2));
            Assert.That(parameters.Configuration.ContainsKey("customTestProperty"), Is.True);
            Assert.That(parameters.IndexingParametersConfiguration.Count(), Is.EqualTo(1));
            Assert.That(parameters.IndexingParametersConfiguration.ContainsKey("customTestProperty"), Is.True);
            Assert.That(parameters.IndexingParametersConfiguration.Contains(new KeyValuePair<string, object>("customTestProperty", "custom")), Is.True);
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
            Assert.That(pairs[3].Key, Is.EqualTo("customTestProperty"));
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

            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));
            CollectionAssert.Contains(parameters.Configuration.Keys, "customTestProperty");

            parameters.IndexingParametersConfiguration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
            };

            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));
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

            Assert.That(parameters.Configuration.Count, Is.EqualTo(0));
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

            Assert.That(parameters.Configuration.Count, Is.EqualTo(0));
            Assert.That(parameters.IndexingParametersConfiguration.Count(), Is.EqualTo(0));
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

            Assert.That(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", "text")), Is.False);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));

            Assert.That(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", "json")), Is.False);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));

            Assert.That(parameters.Configuration.Remove(new KeyValuePair<string, object>("parsingMode", BlobIndexerParsingMode.Json)), Is.True);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(0));
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

            Assert.That(parameters.Configuration.Remove(new KeyValuePair<string, object>("customTestProperty", "other")), Is.False);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(1));

            Assert.That(parameters.Configuration.Remove(new KeyValuePair<string, object>("customTestProperty", "custom")), Is.True);
            Assert.That(parameters.Configuration.Count, Is.EqualTo(0));
        }
    }
}
