// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
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

        [TestCase("J")]
        [TestCase("W")]
        public void DeserializesFromJson(string format)
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
  ""markdownParsingSubmode"": ""oneToMany"",
  ""markdownHeaderDepth"": ""h3"",
  ""documentRoot"": ""$.values"",
  ""dataToExtract"": ""allMetadata"",
  ""imageAction"": ""generateNormalizedImages"",
  ""allowSkillsetToReadFileData"": true,
  ""pdfTextRotationAlgorithm"": ""detectAngles"",
  ""executionEnvironment"": ""standard"",
  ""refreshAllAcls"": true,
  ""queryTimeout"": ""12:34:56"",
  ""customTestProperty"": ""custom""
}";

            using JsonDocument doc = JsonDocument.Parse(json);
            IndexingParametersConfiguration configuration = IndexingParametersConfiguration.DeserializeIndexingParametersConfiguration(doc.RootElement, new ModelReaderWriterOptions(format));

            Assert.AreEqual(BlobIndexerParsingMode.Json, configuration.ParsingMode);
            Assert.AreEqual(".png", configuration.ExcludedFileNameExtensions);
            Assert.AreEqual(".json,.jsonc", configuration.IndexedFileNameExtensions);
            Assert.IsFalse(configuration.FailOnUnsupportedContentType);
            Assert.IsFalse(configuration.FailOnUnprocessableDocument);
            Assert.IsTrue(configuration.IndexStorageMetadataOnlyForOversizedDocuments);
            Assert.AreEqual("A,B", configuration.DelimitedTextHeaders);
            Assert.AreEqual("|", configuration.DelimitedTextDelimiter);
            Assert.IsTrue(configuration.FirstLineContainsHeaders);
            Assert.AreEqual(new MarkdownParsingSubmode("oneToMany"), configuration.MarkdownParsingSubmode);
            Assert.AreEqual(new MarkdownHeaderDepth("h3"), configuration.MarkdownHeaderDepth);
            Assert.AreEqual("$.values", configuration.DocumentRoot);
            Assert.AreEqual(BlobIndexerDataToExtract.AllMetadata, configuration.DataToExtract);
            Assert.AreEqual(BlobIndexerImageAction.GenerateNormalizedImages, configuration.ImageAction);
            Assert.IsTrue(configuration.AllowSkillsetToReadFileData);
            Assert.AreEqual(BlobIndexerPdfTextRotationAlgorithm.DetectAngles, configuration.PdfTextRotationAlgorithm);
            Assert.AreEqual(IndexerExecutionEnvironment.Standard, configuration.ExecutionEnvironment);
            Assert.IsTrue(configuration.RefreshAllAcls);
            Assert.AreEqual(TimeSpan.Parse("12:34:56"), configuration.QueryTimeout);

            Assert.AreEqual(1, configuration.Count());
            Assert.AreEqual("custom", configuration["customTestProperty"]);
        }

        [TestCase("{}", null)]
        [TestCase(@"{""refreshAllAcls"":null}", null)]
        [TestCase(@"{""refreshAllAcls"":false}", false)]
        [TestCase(@"{""refreshAllAcls"":true}", true)]
        public void DeserializesRefreshAllAcls(string json, bool? expected)
        {
            foreach (string format in new[] { "J", "W" })
            {
                IndexingParametersConfiguration configuration = ModelReaderWriter.Read<IndexingParametersConfiguration>(
                    BinaryData.FromString(json), new ModelReaderWriterOptions(format));

                Assert.AreEqual(expected, configuration.RefreshAllAcls);
                Assert.IsFalse(configuration.ContainsKey("refreshAllAcls"));
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DictionaryPropertiesSurviveSerialization(string format)
        {
            IndexingParametersConfiguration configuration = new IndexingParametersConfiguration
            {
                ParsingMode = BlobIndexerParsingMode.Json,
                QueryTimeout = TimeSpan.FromMinutes(10),
                RefreshAllAcls = false,
                ["customString"] = "custom",
                ["customNumber"] = 7,
                ["customBoolean"] = true,
                ["customNull"] = null,
            };
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(configuration, options);

            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement root = document.RootElement;
            Assert.AreEqual("json", root.GetProperty("parsingMode").GetString());
            Assert.AreEqual("00:10:00", root.GetProperty("queryTimeout").GetString());
            Assert.IsFalse(root.GetProperty("refreshAllAcls").GetBoolean());
            Assert.AreEqual("custom", root.GetProperty("customString").GetString());
            Assert.AreEqual(7, root.GetProperty("customNumber").GetInt32());
            Assert.IsTrue(root.GetProperty("customBoolean").GetBoolean());
            Assert.AreEqual(JsonValueKind.Null, root.GetProperty("customNull").ValueKind);

            IndexingParametersConfiguration roundtripped = ModelReaderWriter.Read<IndexingParametersConfiguration>(data, options);
            Assert.AreEqual(configuration.ParsingMode, roundtripped.ParsingMode);
            Assert.AreEqual(configuration.QueryTimeout, roundtripped.QueryTimeout);
            Assert.AreEqual(configuration.RefreshAllAcls, roundtripped.RefreshAllAcls);
            CollectionAssert.AreEquivalent(configuration, roundtripped);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DictionaryMutationsAreSerialized(string format)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            IndexingParametersConfiguration configuration = ModelReaderWriter.Read<IndexingParametersConfiguration>(
                BinaryData.FromString(@"{""customTestProperty"":""original"",""removed"":true}"), options);
            IDictionary<string, object> properties = configuration;
            properties["customTestProperty"] = "updated";
            properties.Remove("removed");
            properties.Add("added", false);

            using (JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(configuration, options)))
            {
                Assert.AreEqual("updated", document.RootElement.GetProperty("customTestProperty").GetString());
                Assert.IsFalse(document.RootElement.TryGetProperty("removed", out _));
                Assert.IsFalse(document.RootElement.GetProperty("added").GetBoolean());
            }

            properties.Clear();
            using JsonDocument cleared = JsonDocument.Parse(ModelReaderWriter.Write(configuration, options));
            Assert.IsFalse(cleared.RootElement.TryGetProperty("customTestProperty", out _));
            Assert.IsFalse(cleared.RootElement.TryGetProperty("added", out _));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void FactoryAdditionalPropertiesAreAvailableToDictionary(string format)
        {
            IndexingParametersConfiguration configuration = SearchModelFactory.IndexingParametersConfiguration(
                additionalProperties: new Dictionary<string, BinaryData>
                {
                    ["customTestProperty"] = BinaryData.FromString(@"""custom"""),
                    ["customNull"] = null,
                });

            Assert.AreEqual("custom", configuration["customTestProperty"]);
            Assert.IsNull(configuration["customNull"]);
            configuration["customTestProperty"] = "updated";

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(configuration, new ModelReaderWriterOptions(format)));
            Assert.AreEqual("updated", document.RootElement.GetProperty("customTestProperty").GetString());
            Assert.AreEqual(JsonValueKind.Null, document.RootElement.GetProperty("customNull").ValueKind);
        }

        [Test]
        public void InvalidFactoryPropertyDoesNotLeavePartialDictionary()
        {
            IndexingParametersConfiguration configuration = SearchModelFactory.IndexingParametersConfiguration(
                additionalProperties: new Dictionary<string, BinaryData>
                {
                    ["valid"] = BinaryData.FromString("true"),
                    ["invalid"] = BinaryData.FromString("not-json"),
                });

            Assert.Catch<JsonException>(() => configuration.ContainsKey("valid"));
            Assert.Catch<JsonException>(() => configuration.ContainsKey("valid"));
        }

        private static IEnumerable<PropertyInfo> DeclaredProperties => typeof(IndexingParametersConfiguration)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0);
    }
}
