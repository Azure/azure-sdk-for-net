// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    public sealed class IndexingParametersTests
    {
        private const string ExpectedParsingModeKey = "parsingMode";

        [Fact]
        public void IndexStorageMetadataOnlySetCorrectly()
        {
            var parameters = new IndexingParameters().IndexStorageMetadataOnly();
            AssertHasConfigItem(parameters, "indexStorageMetadataOnly", true);
        }

        [Fact]
        public void SkipContentSetCorrectly()
        {
            var parameters = new IndexingParameters().SkipContent();
            AssertHasConfigItem(parameters, "skipContent", true);
        }

        [Fact]
        public void ParseJsonSetCorrectly()
        {
            var parameters = new IndexingParameters().ParseJson();
            AssertHasConfigItem(parameters, ExpectedParsingModeKey, "json");
        }

        [Fact]
        public void IndexFileNameExtensionsSetCorrectly()
        {
            var parameters = new IndexingParameters().IndexFileNameExtensions(".pdf", ".docx");
            AssertHasConfigItem(parameters, "indexedFileNameExtensions", ".pdf,.docx");
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
            var parameters = new IndexingParameters().ExcludeFileNameExtensions(".pdf", ".docx");
            AssertHasConfigItem(parameters, "excludedFileNameExtensions", ".pdf,.docx");
        }

        [Fact]
        public void ExcludeFileNameExtensionsNotSetWhenNoExtensionsGiven()
        {
            var parameters = new IndexingParameters().ExcludeFileNameExtensions();
            Assert.Null(parameters.Configuration);
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
