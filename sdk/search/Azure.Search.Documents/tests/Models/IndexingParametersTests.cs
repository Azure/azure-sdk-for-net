// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    }
}
