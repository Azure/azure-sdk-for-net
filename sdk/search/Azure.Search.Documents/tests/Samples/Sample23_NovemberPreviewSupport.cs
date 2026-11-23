// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [NonParallelizable]
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_11_01_Preview)]
    public partial class NovemberPreviewSamples : SearchTestBase
    {
        public NovemberPreviewSamples(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion)
        {
            CompareBodies = true;
        }

        private PreviewResources CreatePreviewResources()
        {
            Uri endpoint = new Uri($"https://{TestEnvironment.SearchServiceName}.{TestEnvironment.SearchEndpointSuffix}");
            string expectedEndpoint = Environment.GetEnvironmentVariable("SEARCH_PREVIEW_EXPECTED_ENDPOINT");
            if (Mode != RecordedTestMode.Playback && expectedEndpoint != null && !endpoint.Equals(new Uri(expectedEndpoint)))
            {
                throw new InvalidOperationException("The effective test configuration does not target SEARCH_PREVIEW_EXPECTED_ENDPOINT.");
            }
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.SearchAdminKey);
            return new PreviewResources(
                InstrumentClient(new SearchIndexClient(endpoint, credential, GetPreviewClientOptions())),
                endpoint, credential);
        }

        private SearchClient CreatePreviewSearchClient(PreviewResources resources, string indexName) =>
            InstrumentClient(new SearchClient(resources.Endpoint, indexName, resources.Credential, GetPreviewClientOptions()));

        private KnowledgeBaseRetrievalClient CreatePreviewRetrievalClient(PreviewResources resources, string baseName) =>
            InstrumentClient(new KnowledgeBaseRetrievalClient(
                resources.Endpoint, baseName, resources.Credential, GetPreviewClientOptions()));

        private SearchIndexerClient CreatePreviewIndexerClient(PreviewResources resources) =>
            InstrumentClient(new SearchIndexerClient(resources.Endpoint, resources.Credential, GetPreviewClientOptions()));

        private SearchClientOptions GetPreviewClientOptions()
        {
            SearchClientOptions options = GetSearchClientOptions();
            options.Retry.MaxRetries = 2;
            options.Retry.MaxDelay = TimeSpan.FromSeconds(5);
            options.Retry.NetworkTimeout = TimeSpan.FromMinutes(2);
            return options;
        }

        private string PreviewName() => "dp11-net-" + Recording.Random.GetName();

        #region Snippet:Azure_Search_Documents_Sample23_RequiredSetting
        private static string RequiredPreviewSetting(string name) =>
            Environment.GetEnvironmentVariable(name) is string value && !string.IsNullOrWhiteSpace(value)
                ? value : throw new InvalidOperationException($"Set {name} before running this live sample.");
        #endregion

        private KnowledgeBaseAzureOpenAIModel PreviewChatModel(string deploymentVariable = "SEARCH_OPENAI_DEPLOYMENT_NAME",
            string modelVariable = "SEARCH_OPENAI_MODEL_NAME") =>
            new KnowledgeBaseAzureOpenAIModel(new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(TestEnvironment.OpenAIEndpoint),
                ApiKey = TestEnvironment.OpenAIKey,
                DeploymentName = RequiredPreviewSetting(deploymentVariable),
                ModelName = RequiredPreviewSetting(modelVariable)
            });

        #region Snippet:Azure_Search_Documents_Sample23_HotelFixture
        private static SearchIndex PreviewHotelIndex(string indexName) => new SearchIndex(indexName)
        {
            Fields =
            {
                new SimpleField("id", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                new SearchableField("title"),
                new SearchableField("content"),
                new SimpleField("country", SearchFieldDataType.String) { IsFilterable = true, IsFacetable = true },
                new SimpleField("rating", SearchFieldDataType.Int32) { IsFilterable = true }
            },
            SemanticSearch = new Azure.Search.Documents.Indexes.Models.SemanticSearch
            {
                DefaultConfigurationName = "hotels",
                Configurations =
                {
                    new SemanticConfiguration("hotels", new SemanticPrioritizedFields
                    {
                        TitleField = new SemanticField("title"),
                        ContentFields = { new SemanticField("content") }
                    })
                }
            }
        };

        private static SearchDocument[] PreviewHotels() => new[]
        {
            new SearchDocument { ["id"] = "hotel-ca-1", ["title"] = "Harbor Hotel", ["country"] = "Canada",
                ["content"] = "Hotel guest benefits include complimentary wireless internet and breakfast.", ["rating"] = 5 },
            new SearchDocument { ["id"] = "hotel-ca-2", ["title"] = "Mountain Inn", ["country"] = "Canada",
                ["content"] = "Hotel guest benefits include complimentary wireless internet, breakfast and parking.", ["rating"] = 4 },
            new SearchDocument { ["id"] = "hotel-us-1", ["title"] = "Garden Hotel", ["country"] = "United States",
                ["content"] = "Hotel guest benefits include complimentary wireless internet and breakfast.", ["rating"] = 3 }
        };
        #endregion

        #region Snippet:Azure_Search_Documents_Sample23_UploadDocuments
        private static async Task UploadPreviewDocumentsAsync(SearchClient client, IEnumerable<SearchDocument> documents)
        {
            SearchDocument[] batch = documents.ToArray();
            IndexDocumentsResult uploaded = await client.UploadDocumentsAsync(batch);
            if (uploaded.Results.Any(result => !result.Succeeded))
            {
                throw new InvalidOperationException("Some sample documents could not be uploaded.");
            }
            await WaitForPreviewDocumentCountAsync(client, batch.Length);
        }

        private static async Task WaitForPreviewDocumentCountAsync(SearchClient client, int expectedCount)
        {
            for (int attempt = 0; attempt < 30; attempt++)
            {
                if ((await client.GetDocumentCountAsync()).Value == expectedCount)
                {
                    return;
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
            throw new TimeoutException("Uploaded sample documents did not become searchable within 60 seconds.");
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Sample23_SemanticIntent
        private static KnowledgeBaseRetrievalRequest PreviewIntent(string search) => new KnowledgeBaseRetrievalRequest
        {
            Intents = { new KnowledgeRetrievalSemanticIntent(search) },
            IncludeActivity = true,
            MaxRuntimeInSeconds = 60,
            MaxOutputDocuments = 10
        };
        #endregion

        private static void AssertPreviewReferences(KnowledgeBaseRetrievalResponse response, params string[] expectedKeys)
        {
            Assert.That(response.Activity, Is.Not.Empty);
            Assert.That(response.References, Is.Not.Empty);
            Assert.That(response.References.All(reference => reference is KnowledgeBaseSearchIndexReference), Is.True);
            Assert.That(response.References.OfType<KnowledgeBaseSearchIndexReference>().Select(reference => reference.DocKey),
                Is.EquivalentTo(expectedKeys));
            Assert.That(response.Activity.All(activity => activity.Error == null), Is.True);
        }

        private sealed class PreviewResources : IAsyncDisposable
        {
            private readonly Stack<Func<Task>> _cleanup = new Stack<Func<Task>>();
            public SearchIndexClient Indexes { get; }
            public Uri Endpoint { get; }
            public AzureKeyCredential Credential { get; }

            public PreviewResources(SearchIndexClient indexes, Uri endpoint, AzureKeyCredential credential)
            {
                Indexes = indexes;
                Endpoint = endpoint;
                Credential = credential;
            }

            public void TrackIndex(string name) =>
                _cleanup.Push(() => Indexes.DeleteIndexAsync(name, cancellationToken: CancellationToken.None));

            public void TrackSource(string name) =>
                _cleanup.Push(() => Indexes.DeleteKnowledgeSourceAsync(name, cancellationToken: CancellationToken.None));

            public void TrackBase(string name) =>
                _cleanup.Push(() => Indexes.DeleteKnowledgeBaseAsync(name, cancellationToken: CancellationToken.None));

            public void TrackCleanup(Func<Task> cleanup) => _cleanup.Push(cleanup);

            public async ValueTask DisposeAsync()
            {
                List<Exception> failures = new List<Exception>();
                while (_cleanup.Count > 0)
                {
                    try
                    {
                        await _cleanup.Pop()();
                    }
                    catch (RequestFailedException exception) when (exception.Status == 404)
                    {
                    }
                    catch (Exception exception)
                    {
                        failures.Add(exception);
                    }
                }
                if (failures.Count > 0)
                {
                    throw new AggregateException("Could not clean up all run-owned sample resources.", failures);
                }
            }
        }
    }
}
