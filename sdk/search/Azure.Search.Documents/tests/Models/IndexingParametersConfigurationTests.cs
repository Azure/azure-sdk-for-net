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
        public void DeclaredPropertiesAreWellKnownProperties()
        {
            foreach (PropertyInfo property in DeclaredProperties)
            {
                // Assumes property names match JSON property names sans case. This would still alert us if properties were added,
                // but any custom name overrides would break this check and require specific handling.
                Assert.IsTrue(
                    IndexingParametersConfiguration.WellKnownProperties.Keys.Contains(property.Name, StringComparer.OrdinalIgnoreCase),
                    $"Property '{property.Name}' was not found in {nameof(IndexingParametersConfiguration.WellKnownProperties)}");
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

            using JsonDocument doc = JsonDocument.Parse(json);
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
            Assert.AreEqual(TimeSpan.Parse("12:34:56"), configuration.QueryTimeout);

            Assert.AreEqual(1, configuration.Count());
            Assert.AreEqual("custom", configuration["customTestProperty"]);
        }

        private static IEnumerable<PropertyInfo> DeclaredProperties => typeof(IndexingParametersConfiguration)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters() is null);
    }
}
