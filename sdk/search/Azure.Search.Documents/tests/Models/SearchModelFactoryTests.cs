// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SearchModelFactoryTests
    {
        [Test]
        public void StatisticsFactoriesPreserveGaOptionalArguments()
        {
            var counter = SearchModelFactory.SearchResourceCounter(7, 10);
            var counters = SearchModelFactory.SearchServiceCounters(aliasCounter: counter);
            var limits = SearchModelFactory.SearchServiceLimits(maxCumulativeIndexerRuntimeSeconds: 120);

            using JsonDocument counterDocument = JsonDocument.Parse(ModelReaderWriter.Write(counters));
            using JsonDocument limitDocument = JsonDocument.Parse(ModelReaderWriter.Write(limits));
            Assert.AreEqual(7, counterDocument.RootElement.GetProperty("aliasesCount").GetProperty("usage").GetInt64());
            Assert.AreEqual(120, limitDocument.RootElement.GetProperty("maxCumulativeIndexerRuntimeSeconds").GetInt64());
        }

        [Test]
        public void IndexerFactoryAcceptsGaEnumerableMappings()
        {
            IEnumerable<FieldMapping> mappings = new[] { new FieldMapping("source") }.Where(_ => true);
            var indexer = SearchModelFactory.SearchIndexer(fieldMappings: mappings);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(indexer));
            Assert.AreEqual("source", document.RootElement.GetProperty("fieldMappings")[0].GetProperty("sourceFieldName").GetString());
        }

        [Test]
        public void ScoringFunctionPreservesGaFieldsAndOptionalParameters()
        {
            var function = SearchModelFactory.ScoringFunction(fieldName: "rating", boost: 2, type: "future");

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(function));
            Assert.AreEqual("rating", document.RootElement.GetProperty("fieldName").GetString());
            Assert.AreEqual(2, document.RootElement.GetProperty("boost").GetDouble());
            Assert.AreEqual("future", document.RootElement.GetProperty("type").GetString());
        }

        [Test]
        public void ReferenceFactoryPreservesGaDefaultsAndCitation()
        {
            var citation = new Uri("https://example.com/document");
            var reference = SearchModelFactory.KnowledgeBaseSearchIndexReference(id: "reference-1", citationUrl: citation);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(reference));
            Assert.AreEqual("reference-1", document.RootElement.GetProperty("id").GetString());
            Assert.AreEqual(citation.ToString(), document.RootElement.GetProperty("citationUrl").GetString());
        }
    }
}
