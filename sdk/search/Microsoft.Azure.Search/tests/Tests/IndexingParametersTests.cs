// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    public sealed class IndexingParametersTests
    {
        private const string ExpectedParsingModeKey = "parsingMode";

        [Fact]
        public void ParseJsonSetCorrectly()
        {
            var parameters = new IndexingParameters().ParseJson();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "json");
        }

        [Fact]
        public void ParseJsonLinesSetCorrectly()
        {
            var parameters = new IndexingParameters().ParseJsonLines();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonLines");
        }

        [Fact]
        public void IndexFileNameExtensionsSetCorrectly()
        {
            var parameters = new IndexingParameters().IndexFileNameExtensions(".pdf", "docx"); // . should be prefixed automatically 
            AssertHasConfigItem(parameters, "indexedFileNameExtensions", ".pdf,.docx"); //
        }

        [Fact]
        public void IndexFileNameExtensionsAreValidated()
        {
            Assert.Throws<ArgumentException>(() => new IndexingParameters().IndexFileNameExtensions(new string[] { null }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().IndexFileNameExtensions(new string[] { String.Empty }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().IndexFileNameExtensions(new string[] { "*.log" }));
        }

        [Fact]
        public void IndexFileNameExtensionsNotSetWhenNoExtensionsGiven()
        {
            var parameters = new IndexingParameters().IndexFileNameExtensions();
            Assert.Null(parameters.Configuration);
        }

        [Fact]
        public void ExcludeFileNameExtensionsSetCorrectly()
        {
            var parameters = new IndexingParameters().ExcludeFileNameExtensions(".pdf", "docx"); // . should be prefixed automatically
            AssertHasConfigItem(parameters, "excludedFileNameExtensions", ".pdf,.docx");
        }

        [Fact]
        public void ExcludeFileNameExtensionsAreValidated()
        {
            Assert.Throws<ArgumentException>(() => new IndexingParameters().ExcludeFileNameExtensions(new string[] { null }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().ExcludeFileNameExtensions(new string[] { String.Empty }));
            Assert.Throws<ArgumentException>(() => new IndexingParameters().ExcludeFileNameExtensions(new string[] { "*.log" }));
        }

        [Fact]
        public void ExcludeFileNameExtensionsNotSetWhenNoExtensionsGiven()
        {
            var parameters = new IndexingParameters().ExcludeFileNameExtensions();
            Assert.Null(parameters.Configuration);
        }

        [Fact]
        public void BlobExtractionModeSetCorrectly()
        {
            var parameters = new IndexingParameters().SetBlobExtractionMode(BlobExtractionMode.AllMetadata);

            AssertHasConfigItem(parameters, "dataToExtract", (string)BlobExtractionMode.AllMetadata);
        }

        [Fact]
        public void ParseJsonArraysWithNullDocumentRootSetCorrectly()
        {
            var parameters = new IndexingParameters().ParseJsonArrays();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray");
        }

        [Fact]
        public void ParseJsonArraysWithEmptyDocumentRootSetCorrectly()
        {
            var parameters = new IndexingParameters().ParseJsonArrays(string.Empty);
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray");
        }

        [Fact]
        public void ParseJsonArraysWithDocumentRootSetCorrectly()
        {
            const int ExpectedCount = 2;

            var parameters = new IndexingParameters().ParseJsonArrays("/my/path");
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "jsonArray", ExpectedCount);
            AssertHasConfigItem(parameters, "documentRoot", "/my/path", ExpectedCount);
        }

        [Fact]
        public void ParseDelimitedTextFilesWithInlineHeadersSetCorrectly()
        {
            const int ExpectedCount = 2;

            var parameters = new IndexingParameters().ParseDelimitedTextFiles();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "firstLineContainsHeaders", true, ExpectedCount);
        }

        [Fact]
        public void ParseDelimitedTextFilesWithGivenHeadersSetCorrectly()
        {
            const int ExpectedCount = 2;

            var parameters = new IndexingParameters().ParseDelimitedTextFiles("id", "name", "address");
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "delimitedText", ExpectedCount);
            AssertHasConfigItem(parameters, "delimitedTextHeaders", "id,name,address", ExpectedCount);
        }

        [Fact]
        public void ParseTextSetCorrectly()
        {
            const int ExpectedCount = 2;

            var parameters = new IndexingParameters().ParseText();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "text", ExpectedCount);
            AssertHasConfigItem(parameters, "encoding", "utf-8", ExpectedCount);
        }

        [Fact]
        public void ParseTextWithEncodingSetCorrectly()
        {
            const int ExpectedCount = 2;

            var parameters = new IndexingParameters().ParseText(Encoding.ASCII);
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "text", ExpectedCount);
            AssertHasConfigItem(parameters, "encoding", "us-ascii", ExpectedCount);
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
            Assert.Equal(expectedValue, config[expectedKey]);
            Assert.Equal(expectedCount, config.Count);
        }
    }
}
