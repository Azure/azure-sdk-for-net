// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Tests.Samples;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public sealed class IndexingParametersExtensionsTests
    {
        private const string ExpectedParsingModeKey = "parsingMode";

        [Test]
        public void ParseJsonSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetParseJson();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "json");
        }

        [Test]
        public void ParseJsonLinesSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetParseJsonLines();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonLines");
        }

        [Test]
        public void IncludeFileNameExtensionsSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetIndexedFileNameExtensions(".pdf", "docx");
            AssertHasConfigItem(parameters, "indexedFileNameExtensions", ".pdf,.docx");
        }

        [Test]
        public void IndexFileNameExtensionsAreValidated()
        {
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetIndexedFileNameExtensions(new string[] { null }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetIndexedFileNameExtensions(new string[] { string.Empty }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetIndexedFileNameExtensions(new string[] { "*.log" }));
        }

        [Test]
        public void IncludeFileNameExtensionsNotSetWhenNoExtensionsGiven()
        {
            IndexingParameters parameters = new IndexingParameters().SetIndexedFileNameExtensions();
            Assert.IsEmpty(parameters.Configuration);
        }

        [Test]
        public void ExcludeFileNameExtensionsSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetExcludeFileNameExtensions(".pdf", "docx");
            AssertHasConfigItem(parameters, "excludedFileNameExtensions", ".pdf,.docx");
        }

        [Test]
        public void ExcludeFileNameExtensionsAreValidated()
        {
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetExcludeFileNameExtensions(new string[] { null }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetExcludeFileNameExtensions(new string[] { string.Empty }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().SetExcludeFileNameExtensions(new string[] { "*.log" }));
        }

        [Test]
        public void ExcludeFileNameExtensionsNotSetWhenNoExtensionsGiven()
        {
            IndexingParameters parameters = new IndexingParameters().SetExcludeFileNameExtensions();
            Assert.IsEmpty(parameters.Configuration);
        }

        [Test]
        public void BlobExtractionModeSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetBlobExtractionMode(BlobExtractionMode.AllMetadata);

            AssertHasConfigItem(parameters, "dataToExtract", BlobExtractionMode.AllMetadata.ToString());
        }

        [Test]
        public void ParseJsonArraysWithNullDocumentRootSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetParseJsonArrays();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray");
        }

        [Test]
        public void ParseJsonArraysWithEmptyDocumentRootSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetParseJsonArrays(string.Empty);
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray");
        }

        [Test]
        public void ParseJsonArraysWithDocumentRootSetCorrectly()
        {
            const int ExpectedCount = 2;

            IndexingParameters parameters = new IndexingParameters().SetParseJsonArrays("/my/path");
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray", ExpectedCount);
            AssertHasConfigItem(parameters, "documentRoot", "/my/path", ExpectedCount);
        }

        [Test]
        public void ParseDelimitedTextFilesWithInlineHeadersSetCorrectly()
        {
            const int ExpectedCount = 3;

            IndexingParameters parameters = new IndexingParameters().SetParseDelimitedTextFiles();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextDelimiter", ",", ExpectedCount);
            AssertHasConfigItem(parameters, "firstLineContainsHeaders", true, ExpectedCount);
        }

        [Test]
        public void ParseDelimitedTextFilesWithGivenHeadersSetCorrectly()
        {
            const int ExpectedCount = 3;

            IndexingParameters parameters = new IndexingParameters().SetParseDelimitedTextFiles("id", "name", "address");
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextDelimiter", ",", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextHeaders", "id,name,address", ExpectedCount);
        }

        [Test]
        public void ParseTabDelimitedTextFilesWithInlineHeadersSetCorrectly()
        {
            const int ExpectedCount = 3;

            IndexingParameters parameters = new IndexingParameters().SetParseDelimitedTextFiles('\t', null);
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextDelimiter", "\t", ExpectedCount);
            AssertHasConfigItem(parameters, "firstLineContainsHeaders", true, ExpectedCount);
        }

        [Test]
        public void ParseTabDelimitedTextFilesWithGivenHeadersSetCorrectly()
        {
            const int ExpectedCount = 3;

            IndexingParameters parameters = new IndexingParameters().SetParseDelimitedTextFiles('\t', new[] { "id", "name", "address" });
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextDelimiter", "\t", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextHeaders", "id,name,address", ExpectedCount);
        }

        [Test]
        public void ParseTextSetCorrectly()
        {
            const int ExpectedCount = 2;

            IndexingParameters parameters = new IndexingParameters().SetParseText();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "text", ExpectedCount);
            AssertHasConfigItem(parameters, "encoding", "utf-8", ExpectedCount);
        }

        [Test]
        public void ParseTextWithEncodingSetCorrectly()
        {
            const int ExpectedCount = 2;

            IndexingParameters parameters = new IndexingParameters().SetParseText(Encoding.ASCII);
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "text", ExpectedCount);
            AssertHasConfigItem(parameters, "encoding", "us-ascii", ExpectedCount);
        }

        [Test]
        public void EmptyConfigurationSerializesWithoutConfiguration()
        {
            IUtf8JsonSerializable parameters = new IndexingParameters()
                .SetIndexedFileNameExtensions()
                .SetExcludeFileNameExtensions();

            using MemoryStream ms = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(ms))
            {
                parameters.Write(writer);
            }

            string jsonContent = Encoding.UTF8.GetString(ms.ToArray());
            StringAssert.DoesNotContain(@"""configuration""", jsonContent);
        }

        [Test]
        public void FailOnUnsupportedContentTypeSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetFailOnUnsupportedContentType();
            AssertHasConfigItem(parameters, "failOnUnsupportedContentType", true);
        }

        [Test]
        public void FailOnUnprocessableDocumentSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetFailOnUnprocessableDocument();
            AssertHasConfigItem(parameters, "failOnUnprocessableDocument", true);
        }

        [Test]
        public void AllowSkillsetToReadFileDataSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetAllowSkillsetToReadFileData();
            AssertHasConfigItem(parameters, "allowSkillsetToReadFileData", true);
        }

        [Test]
        public void ImageActionSetCorrectly([EnumValues] ImageAction imageAction)
        {
            IndexingParameters parameters = new IndexingParameters().SetImageAction(imageAction);
            AssertHasConfigItem(parameters, "imageAction", imageAction.ToString());
        }

        [Test]
        public void PdfTextRotationAlgorithmSetCorrectly([EnumValues] PdfTextRotationAlgorithm pdfTextRotationAlgorithm)
        {
            IndexingParameters parameters = new IndexingParameters().SetPdfTextRotationAlgorithm(pdfTextRotationAlgorithm);
            AssertHasConfigItem(parameters, "pdfTextRotationAlgorithm", pdfTextRotationAlgorithm.ToString());
        }

        [Test]
        public void QueryTimeoutSetCorrectly()
        {
            IndexingParameters parameters = new IndexingParameters().SetQueryTimeout(TimeSpan.FromMinutes(10));
            AssertHasConfigItem(parameters, "queryTimeout", "00:10:00");
        }

        [Test]
        public void IndexOnlyJsonDocuments()
        {
            #region Snippet:IndexingParametersExtensions_IndexOnlyJsonDocuments
            SearchIndexer indexer = new SearchIndexer("hotelsIndexer", "hotelsDataSource", "hotelsIndex")
            {
                Parameters = new IndexingParameters()
                    .SetIndexedFileNameExtensions(".json")
                    .SetParseJson()
            };
            #endregion Snippet:IndexingParametersExtensions_IndexOnlyJsonDocuments

            const int ExpectedCount = 2;

            AssertHasConfigItem(indexer.Parameters, "indexedFileNameExtensions", ".json", ExpectedCount);
            AssertHasConfigItem(indexer.Parameters, ExpectedParsingModeKey, "json", ExpectedCount);
        }

        private static void AssertHasConfigItem(
            IndexingParameters parameters,
            string expectedKey,
            object expectedValue,
            int expectedCount = 1)
        {
            IDictionary<string, object> config = parameters.Configuration;

            Assert.NotNull(config);
            Assert.True(config.ContainsKey(expectedKey));
            Assert.AreEqual(expectedValue, config[expectedKey]);
            Assert.AreEqual(expectedCount, config.Count);
        }
    }
}
