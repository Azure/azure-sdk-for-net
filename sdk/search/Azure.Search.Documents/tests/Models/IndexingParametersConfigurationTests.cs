// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class IndexingParametersConfigurationTests
    {
        // Most of the cover can be found in IndexingParametersTests since we're more
        // interested in testing how well Configuration and IndexingParametersConfiguration are synchronized.

        [Test]
        public void DeclaredPropertiesAreHandled()
        {
            // Check that each declared public property has an associated constant defined,
            // which works as an analogue to make sure no properties were generated of which we weren't aware.
            ILookup<string, FieldInfo> constants = typeof(IndexingParametersConfiguration)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.IsPrivate && f.IsLiteral && f.FieldType == typeof(string) && f.Name.EndsWith("Key"))
                .ToLookup(f => f.Name);

            foreach (PropertyInfo property in DeclaredProperties)
            {
                Assert.IsTrue(constants.Contains($"{property.Name}Key"), $"No key name found for property '{property.Name}'");
            }
        }

        [Test]
        public void NullsByDefault()
        {
            IndexingParametersConfiguration configuration = new IndexingParametersConfiguration();
            foreach (PropertyInfo property in DeclaredProperties)
            {
                Assert.IsNull(property.GetValue(configuration), $"Property '{property.Name}' is not null by default");
            }
        }

        [Test]
        public void DeserializesFromJson()
        {
            const string json = @"{
  ""parsingMode"": ""json"",
  ""excludedFileNameExtensions"": "".png"",
  ""indexedFileNameExtensions"": "".json,.jsonc"",
  ""failOnUnsupportedContentType"": false,
  ""failOnUnprocessableDocument"": false,
  ""indexStorageMetadataOnlyForOversizedDocuments"": true,
  ""delimitedTextHeaders"": ""A,B"",
  ""delimitedTextDelimiter"": ""|"",
  ""firstLineContainsHeaders"": true,
  ""documentRoot"": ""$.values"",
  ""dataToExtract"": ""allMetadata"",
  ""imageAction"": ""generateNormalizedImages"",
  ""allowSkillsetToReadFileData"": true,
  ""pdfTextRotationAlgorithm"": ""detectAngles"",
  ""executionEnvironment"": ""standard"",
  ""queryTimeout"": ""12:34:56"",
  ""customTestProperty"": ""custom""
}";

            JsonDocument doc = JsonDocument.Parse(json);
            IndexingParametersConfiguration configuration = IndexingParametersConfiguration.DeserializeIndexingParametersConfiguration(doc.RootElement);

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
            Assert.AreEqual("12:34:56", configuration.QueryTimeout);

            Assert.AreEqual(1, configuration.Count());
            Assert.AreEqual("custom", configuration["customTestProperty"]);
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
            Assert.AreEqual("12:34:56", configuration.QueryTimeout);

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
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["failOnUnsupportedContentType"] = "meh",
                },
            };

            IndexingParametersConfiguration configuration = parameters.IndexingParametersConfiguration;
            Assert.Throws<InvalidCastException>(() => { _ = configuration.FailOnUnsupportedContentType; });
        }

        [Test]
        public void UnexpectedValueTypeForEnum()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["parsingMode"] = false,
                },
            };

            IndexingParametersConfiguration configuration = parameters.IndexingParametersConfiguration;
            Assert.Throws<InvalidCastException>(() => { _ = configuration.ParsingMode; });
        }

        [Test]
        public void UnexpectedValueTypeForString()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                Configuration =
                {
                    ["excludedFileNameExtensions"] = false,
                },
            };

            IndexingParametersConfiguration configuration = parameters.IndexingParametersConfiguration;
            Assert.Throws<InvalidCastException>(() => { _ = configuration.ExcludedFileNameExtensions; });
        }

        private static IEnumerable<PropertyInfo> DeclaredProperties => typeof(IndexingParametersConfiguration)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters() == null);
    }
}
