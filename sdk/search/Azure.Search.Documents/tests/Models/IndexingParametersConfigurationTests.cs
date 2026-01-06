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
                Assert.That(
                    IndexingParametersConfiguration.WellKnownProperties.Keys.Contains(property.Name, StringComparer.OrdinalIgnoreCase),
                    Is.True,
                    $"Property '{property.Name}' was not found in {nameof(IndexingParametersConfiguration.WellKnownProperties)}");
            }
        }

        [Test]
        public void NullsByDefault()
        {
            IndexingParametersConfiguration configuration = new IndexingParametersConfiguration();
            foreach (PropertyInfo property in DeclaredProperties)
            {
                Assert.That(property.GetValue(configuration), Is.Null, $"Property '{property.Name}' is not null by default");
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

            Assert.Multiple(() =>
            {
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
            });
        }

        private static IEnumerable<PropertyInfo> DeclaredProperties => typeof(IndexingParametersConfiguration)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters() is null);
    }
}
