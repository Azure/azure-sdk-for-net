// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SearchModelFactoryTests
    {
        [TestCase(typeof(VectorizableImageBinaryQuery), "imageBinary", "base64Image", "aW1hZ2U=")]
        [TestCase(typeof(VectorizableImageUrlQuery), "imageUrl", "url", "https://example.com/image.png")]
        public void NovemberImageQueriesDeserializeThroughVectorQuery(Type expectedType, string kind, string propertyName, string value)
        {
            var data = BinaryData.FromObjectAsJson(new Dictionary<string, object>
            {
                ["kind"] = kind,
                [propertyName] = value
            });
            VectorQuery query = ModelReaderWriter.Read<VectorQuery>(data);

            Assert.That(query, Is.TypeOf(expectedType));
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(query));
            Assert.AreEqual(value, document.RootElement.GetProperty(propertyName).GetString());
        }

        [Test]
        public void NovemberAmlVectorizerDeserializesThroughVectorizer()
        {
            VectorSearchVectorizer vectorizer = ModelReaderWriter.Read<VectorSearchVectorizer>(
                BinaryData.FromString("{\"name\":\"aml\",\"kind\":\"aml\",\"amlParameters\":{\"uri\":\"https://example.com/score\",\"modelName\":\"Cohere-embed-v3-english\"}}"));

            Assert.IsInstanceOf<AzureMachineLearningVectorizer>(vectorizer);
            Assert.AreEqual(AIFoundryModelCatalogName.CohereEmbedV3English,
                ((AzureMachineLearningVectorizer)vectorizer).AMLParameters.ModelName);
        }

        [Test]
        public void NovemberActivityRetainsBothReasoningEfforts()
        {
            KnowledgeBaseActivityRecord activity = ModelReaderWriter.Read<KnowledgeBaseActivityRecord>(
                BinaryData.FromString("{\"id\":1,\"type\":\"agenticReasoning\",\"retrievalReasoningEffort\":{\"kind\":\"low\"},\"logicalReasoningEffort\":{\"kind\":\"medium\"}}"));

            Assert.IsInstanceOf<KnowledgeBaseAgenticReasoningActivityRecord>(activity);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(activity));
            Assert.AreEqual("low", document.RootElement.GetProperty("retrievalReasoningEffort").GetProperty("kind").GetString());
            Assert.AreEqual("medium", document.RootElement.GetProperty("logicalReasoningEffort").GetProperty("kind").GetString());
        }

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
