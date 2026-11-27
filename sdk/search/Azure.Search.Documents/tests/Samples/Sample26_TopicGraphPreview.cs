// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using OpenAI.Embeddings;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task TopicGraphSetupSearchAndRetrieve()
        {
            string embeddingDeployment = RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_DEPLOYMENT");
            string embeddingModel = RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_MODEL");
            Assert.That(embeddingModel, Is.AnyOf("text-embedding-3-small", "text-embedding-3-large"));
            int dimensions = embeddingModel == "text-embedding-3-small" ? 1536 : 3072;
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();
            string sidecarName = indexName + "-topicgraph";
            string sourceName = indexName + "-source";
            string baseName = indexName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;

            #region Snippet:Azure_Search_Documents_Sample26_TopicGraph_Indexes
            SearchIndex corpus = PreviewHotelIndex(indexName);
            corpus.Fields.Add(new SimpleField("topic", SearchFieldDataType.String) { IsFilterable = true, IsFacetable = true });
            corpus.Fields.Add(new SearchField("content_vector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
            {
                IsSearchable = true,
                IsHidden = true,
                IsStored = true,
                VectorSearchDimensions = dimensions,
                VectorSearchProfileName = "vectors"
            });
            corpus.VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
            {
                Algorithms = { new HnswAlgorithmConfiguration("cosine") { Parameters = new HnswParameters { Metric = VectorSearchAlgorithmMetric.Cosine } } },
                Profiles = { new VectorSearchProfile("vectors", "cosine") { VectorizerName = "embeddings" } },
                Vectorizers =
                {
                    new AzureOpenAIVectorizer("embeddings")
                    {
                        Parameters = new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(openAIEndpoint),
                            ApiKey = openAIKey,
                            DeploymentName = embeddingDeployment,
                            ModelName = embeddingModel
                        }
                    }
                }
            };
            SearchIndex sidecar = new SearchIndex(sidecarName)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
                    new SimpleField("subject_id", SearchFieldDataType.String),
                    new SearchField("object_vector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
                    {
                        IsSearchable = true,
                        IsStored = true,
                        VectorSearchDimensions = dimensions,
                        VectorSearchProfileName = "centroids"
                    }
                },
                VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
                {
                    Algorithms = { new HnswAlgorithmConfiguration("cosine") { Parameters = new HnswParameters { Metric = VectorSearchAlgorithmMetric.Cosine } } },
                    Profiles = { new VectorSearchProfile("centroids", "cosine") }
                }
            };
            await indexClient.CreateIndexAsync(sidecar);
#if !SNIPPET
            resources.TrackIndex(sidecarName);
#endif
            await indexClient.CreateIndexAsync(corpus);
#if !SNIPPET
            resources.TrackIndex(indexName);
#endif
            corpus = await indexClient.GetIndexAsync(indexName);
            corpus.VectorSearch.TopicGraphProfiles.Add(
                new VectorSearchTopicGraphProfile("hotel-topics", sidecarName, VectorSearchTopicGraphKind.Balanced)
                {
                    DefaultMinDiversityPoolSize = 1000
                });
            corpus.Fields.Single(field => field.Name == "content_vector").TopicGraphProfile = "hotel-topics";
            await indexClient.CreateOrUpdateIndexAsync(corpus, onlyIfUnchanged: true);
            #endregion
            Assert.That((await indexClient.GetIndexAsync(indexName)).Value.VectorSearch.TopicGraphProfiles.Single().IndexName,
                Is.EqualTo(sidecarName));

            #region Snippet:Azure_Search_Documents_Sample26_TopicGraph_Data
            string[] topics = { "wellness", "dining", "adventure" };
            string[] descriptions =
            {
                "Relax in the hotel spa with a heated pool, a sauna and quiet gardens.",
                "Enjoy regional hotel dining, rooftop restaurants, local wine and cooking classes.",
                "Explore mountain trails, guided kayaking, rafting and outdoor adventures near the hotel."
            };
            SearchDocument[] documents = Enumerable.Range(0, 9).Select(number => new SearchDocument
            {
                ["id"] = "hotel-" + number.ToString(CultureInfo.InvariantCulture),
                ["title"] = topics[number / 3] + " hotel " + number.ToString(CultureInfo.InvariantCulture),
                ["content"] = descriptions[number / 3] + " Guest room " + number.ToString(CultureInfo.InvariantCulture) + ".",
                ["topic"] = topics[number / 3],
                ["country"] = "Canada",
                ["rating"] = 4
            }).ToArray();
            string query = "Which hotels offer relaxation, interesting dining, and outdoor adventures?";
            EmbeddingClient embeddingClient = new AzureOpenAIClient(new Uri(openAIEndpoint), new AzureKeyCredential(openAIKey))
                .GetEmbeddingClient(embeddingDeployment);
            var embeddings = (await embeddingClient.GenerateEmbeddingsAsync(
                documents.Select(document => (string)document["content"]).Concat(new[] { query }),
                new EmbeddingGenerationOptions { Dimensions = dimensions })).Value;
            float[][] vectors = embeddings.OrderBy(embedding => embedding.Index)
                .Select(embedding => embedding.ToFloats().ToArray()).ToArray();
            for (int number = 0; number < documents.Length; number++)
            {
                documents[number]["content_vector"] = vectors[number];
            }
            // These sampled document vectors are toy representatives, not production topic discovery or computed centroids.
            SearchDocument[] representatives = new[] { 0, 3, 6 }.Select(number => new SearchDocument
            {
                ["id"] = "topic-" + topics[number / 3],
                ["subject_id"] = topics[number / 3],
                ["object_vector"] = vectors[number]
            }).ToArray();
            SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
            SearchClient sidecarClient = new SearchClient(endpoint, sidecarName, credential);
#if !SNIPPET
            searchClient = CreatePreviewSearchClient(resources, indexName);
            sidecarClient = CreatePreviewSearchClient(resources, sidecarName);
#endif
            await UploadPreviewDocumentsAsync(searchClient, documents);
            await UploadPreviewDocumentsAsync(sidecarClient, representatives);
            #endregion
            Assert.That(vectors.Length, Is.EqualTo(10));
            Assert.That(vectors.All(vector => vector.Length == dimensions), Is.True);

            #region Snippet:Azure_Search_Documents_Sample26_TopicGraph_Search
            VectorQueryTopicGraph[] modes =
            {
                new NoneVectorQueryTopicGraph(),
                new DiverseVectorQueryTopicGraph { DiversityFactor = 0.2f, MinDiversityPoolSize = 1000 },
                new BalancedVectorQueryTopicGraph { MinDiversityPoolSize = 1000 }
            };
            foreach (VectorQueryTopicGraph mode in modes)
            {
                SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>(new SearchOptions
                {
                    VectorSearch = new VectorSearchOptions
                    {
                        Queries = { new VectorizedQuery(vectors[9]) { Fields = { "content_vector" }, KNearestNeighborsCount = 6, TopicGraph = mode } }
                    },
                    Select = { "id", "title", "topic" },
                    Size = 6
                });
                var hits = await ReadPreviewResultsAsync(response);
                Console.WriteLine($"{mode.GetType().Name}: {string.Join(", ", hits.Select(hit => hit.Document["topic"]))}");
#if !SNIPPET
                Assert.That(hits.Select(hit => hit.Document["id"]).Distinct().Count(), Is.EqualTo(6));
#endif
            }
            // Omitting TopicGraph inherits the field's balanced profile.
            SearchResults<SearchDocument> inherited = await searchClient.SearchAsync<SearchDocument>(new SearchOptions
            {
                VectorSearch = new VectorSearchOptions
                {
                    Queries = { new VectorizableTextQuery(query) { Fields = { "content_vector" }, KNearestNeighborsCount = 6 } }
                },
                Size = 6
            });
            #endregion
            Assert.That((await ReadPreviewResultsAsync(inherited)).Count, Is.EqualTo(6));

            #region Snippet:Azure_Search_Documents_Sample26_TopicGraph_Retrieve
            await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(
                sourceName, new SearchIndexKnowledgeSourceParameters(indexName)
                {
                    SemanticConfigurationName = "hotels",
                    SearchFields = { new SearchIndexFieldReference("title"), new SearchIndexFieldReference("content"), new SearchIndexFieldReference("content_vector") },
                    SourceDataFields = { new SearchIndexFieldReference("id"), new SearchIndexFieldReference("title"), new SearchIndexFieldReference("topic") },
                    TopicGraph = new DiverseVectorQueryTopicGraph { DiversityFactor = 0.2f, MinDiversityPoolSize = 1000 }
                }));
#if !SNIPPET
            resources.TrackSource(sourceName);
#endif
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
            {
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            foreach (VectorQueryTopicGraph mode in new VectorQueryTopicGraph[] { null }.Concat(modes))
            {
                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    Intents = { new KnowledgeRetrievalSemanticIntent(query) },
                    IncludeActivity = true,
                    MaxOutputDocuments = 6,
                    KnowledgeSourceParams =
                    {
                        new SearchIndexKnowledgeSourceParams(sourceName)
                        {
                            AlwaysQuerySource = true,
                            FailOnError = true,
                            IncludeReferences = true,
                            IncludeReferenceSourceData = true,
                            TopicGraph = mode
                        }
                    }
                };
                KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
                Console.WriteLine($"{mode?.GetType().Name ?? "stored diverse"}: {response.References.Count} references");
#if !SNIPPET
                Assert.That(response.References, Is.Not.Empty);
                Assert.That(response.Activity, Is.Not.Empty);
                Assert.That(response.Activity.All(activity => activity.Error == null), Is.True);
                Assert.That(response.References.OfType<KnowledgeBaseSearchIndexReference>().Select(reference => reference.DocKey),
                    Is.SubsetOf(documents.Select(document => (string)document["id"])));
#endif
            }
            #endregion
        }
    }
}
