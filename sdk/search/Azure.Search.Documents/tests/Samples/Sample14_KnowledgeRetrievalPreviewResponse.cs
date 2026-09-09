// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_08_01_Preview)]
    public partial class KnowledgeRetrievalPreviewResponse : SearchTestBase
    {
        public KnowledgeRetrievalPreviewResponse(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task RetrieveWithPreviewResponseFeatures()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_WithActivity
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            // Create a KnowledgeBaseRetrievalClient
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential);
#if !SNIPPET
            retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

            // Build a retrieval request with preview features:
            // - maxOutputDocuments to limit the number of documents returned
            // - includeActivity to get detailed activity records with model names
            // - outputMode to control the response format
            KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
            {
                MaxOutputDocuments = 5,
                IncludeActivity = true,
                OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis
            };
            request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

            // Retrieve relevant content from the knowledge base
            Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
            KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

            // Display the synthesized response
            foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
            {
                foreach (KnowledgeBaseMessageContent content in message.Content)
                {
                    if (content is KnowledgeBaseMessageTextContent textContent)
                    {
                        Console.WriteLine($"Response: {textContent.Text}");
                    }
                }
            }

            // Display activity records with model names (available when includeActivity = true)
            foreach (KnowledgeBaseActivityRecord activity in retrievalResponse.Activity)
            {
                Console.WriteLine($"Activity ID: {activity.Id}, Elapsed: {activity.ElapsedMs}ms");

                if (activity is KnowledgeBaseModelQueryPlanningActivityRecord queryPlanning)
                {
                    Console.WriteLine($"  Query Planning - Model: {queryPlanning.Model?.ModelName}");
                    Console.WriteLine($"  Input tokens: {queryPlanning.InputTokens}, Output tokens: {queryPlanning.OutputTokens}");
                }
                else if (activity is KnowledgeBaseModelAnswerSynthesisActivityRecord answerSynthesis)
                {
                    Console.WriteLine($"  Answer Synthesis - Model: {answerSynthesis.Model?.ModelName}");
                    Console.WriteLine($"  Input tokens: {answerSynthesis.InputTokens}, Output tokens: {answerSynthesis.OutputTokens}");
                }
            }

            // Display references with Purview sensitivity label metadata when available
            foreach (KnowledgeBaseReference reference in retrievalResponse.References)
            {
                Console.WriteLine($"Reference ID: {reference.Id}, Score: {reference.RerankerScore}");

                if (reference is KnowledgeBaseSearchIndexReference searchIndexRef)
                {
                    Console.WriteLine($"  Document key: {searchIndexRef.DocKey}");

                    // Purview sensitivity label metadata is available on search index references
                    if (searchIndexRef.SearchSensitivityLabelInfo != null)
                    {
                        PurviewSensitivityLabelInfo label = searchIndexRef.SearchSensitivityLabelInfo;
                        Console.WriteLine($"  Sensitivity label: {label.DisplayName} (ID: {label.SensitivityLabelId})");
                        Console.WriteLine($"  Priority: {label.Priority}, Encrypted: {label.IsEncrypted}");
                    }
                }
            }

            // Check for overall response sensitivity label info
            if (retrievalResponse.ResponseSensitivityLabelInfo != null)
            {
                PurviewSensitivityLabelInfo responseLabel = retrievalResponse.ResponseSensitivityLabelInfo;
                Console.WriteLine($"Response sensitivity label: {responseLabel.DisplayName}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_WithActivity

            Assert.IsNotNull(retrievalResponse);
            Assert.IsNotNull(retrievalResponse.Response);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task RetrieveWithExtractiveDataMode()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_ExtractiveData
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential);
#if !SNIPPET
            retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

            // Use ExtractiveData mode to return raw data without LLM synthesis
            KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
            {
                MaxOutputDocuments = 3,
                IncludeActivity = true,
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
            };
            request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find budget hotels"));

            Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
            KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

            // In ExtractiveData mode, the response contains raw extracted content
            foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
            {
                foreach (KnowledgeBaseMessageContent content in message.Content)
                {
                    if (content is KnowledgeBaseMessageTextContent textContent)
                    {
                        Console.WriteLine($"Extracted content: {textContent.Text}");
                    }
                }
            }

            // References are still available with source data
            foreach (KnowledgeBaseReference reference in retrievalResponse.References)
            {
                Console.WriteLine($"Reference ID: {reference.Id}");
                foreach (var kvp in reference.SourceData)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_ExtractiveData

            Assert.IsNotNull(retrievalResponse);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task OverridePerSourceRetrievalBehavior()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);
            Environment.SetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME", resources.KnowledgeSourceName);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            string testSecondarySourceName = Recording.Random.GetName();
            SearchIndexClient testIndexClient = null;
            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_SourceOverrides
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");
                string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testIndexClient = indexClient;
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                // Add a second source so each request can exclude one source while
                // leaving another source queryable.
                string secondarySourceName = "my-secondary-hotels-source";
#if !SNIPPET
                secondarySourceName = testSecondarySourceName;
#endif
                SearchIndexKnowledgeSource secondarySource = new SearchIndexKnowledgeSource(
                    secondarySourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName))
                {
                    ResultsProcessing = KnowledgeSourceResultsProcessing.Rerank
                };
                KnowledgeSource createdSecondarySource = await indexClient.CreateKnowledgeSourceAsync(secondarySource);
                secondarySourceName = createdSecondarySource.Name;
#if !SNIPPET
                testSecondarySourceName = secondarySourceName;
#endif

                KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
                knowledgeBase.KnowledgeSources.Add(new KnowledgeSourceReference(secondarySourceName));
                await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
#if !SNIPPET
                await DelayAsync(TimeSpan.FromSeconds(2));
#endif

                // Store reranking as the primary source default.
                KnowledgeSource primarySource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                primarySource.ResultsProcessing = KnowledgeSourceResultsProcessing.Rerank;
                await indexClient.CreateOrUpdateKnowledgeSourceAsync(primarySource);

                // Query only the primary source and override its stored reranking
                // setting for this request.
                KnowledgeBaseRetrievalRequest primaryRequest = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true,
                    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
                };
                primaryRequest.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find luxury hotels"));
                primaryRequest.KnowledgeSourceParams.Add(
                    new SearchIndexKnowledgeSourceParams(knowledgeSourceName)
                    {
                        AlwaysQuerySource = true,
                        IncludeReferences = true,
                        ResultsProcessing = KnowledgeSourceResultsProcessing.None
                    });
                primaryRequest.KnowledgeSourceParams.Add(
                    new SearchIndexKnowledgeSourceParams(secondarySourceName)
                    {
                        NeverQuerySource = true
                    });

                KnowledgeBaseRetrievalResponse primaryResponse =
                    await retrievalClient.RetrieveAsync(primaryRequest);

                // Reverse the per-source controls for another request. The primary
                // source is excluded while the secondary source remains queryable.
                KnowledgeBaseRetrievalRequest secondaryRequest = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true,
                    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
                };
                secondaryRequest.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find luxury hotels"));
                secondaryRequest.KnowledgeSourceParams.Add(
                    new SearchIndexKnowledgeSourceParams(knowledgeSourceName)
                    {
                        NeverQuerySource = true
                    });
                secondaryRequest.KnowledgeSourceParams.Add(
                    new SearchIndexKnowledgeSourceParams(secondarySourceName)
                    {
                        AlwaysQuerySource = true,
                        IncludeReferences = true
                    });

                KnowledgeBaseRetrievalResponse secondaryResponse =
                    await retrievalClient.RetrieveAsync(secondaryRequest);

                KnowledgeSource persistedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                KnowledgeBase persistedBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
                Console.WriteLine($"Stored processing remains: {persistedSource.ResultsProcessing}");
                Console.WriteLine($"Knowledge-base source count remains: {persistedBase.KnowledgeSources.Count}");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_SourceOverrides

                List<KnowledgeBaseSearchIndexActivityRecord> primaryActivities = primaryResponse.Activity
                    .OfType<KnowledgeBaseSearchIndexActivityRecord>()
                    .ToList();
                List<KnowledgeBaseSearchIndexActivityRecord> secondaryActivities = secondaryResponse.Activity
                    .OfType<KnowledgeBaseSearchIndexActivityRecord>()
                    .ToList();
                Assert.IsTrue(primaryResponse.References.All(reference => reference.RerankerScore is null));
                Assert.IsNotEmpty(primaryActivities);
                Assert.IsTrue(
                    primaryActivities.All(activity => activity.KnowledgeSourceName == knowledgeSourceName),
                    $"Expected only '{knowledgeSourceName}', but recorded: {string.Join(", ", primaryActivities.Select(activity => activity.KnowledgeSourceName))}");
                Assert.IsNotEmpty(secondaryActivities);
                Assert.IsTrue(
                    secondaryActivities.All(activity => activity.KnowledgeSourceName != knowledgeSourceName),
                    $"The excluded primary source '{knowledgeSourceName}' appeared in secondary activity.");
                Assert.AreEqual(
                    1,
                    secondaryActivities.Select(activity => activity.KnowledgeSourceName).Distinct().Count(),
                    "Expected activity from only the one remaining queryable source.");
                Assert.AreEqual(KnowledgeSourceResultsProcessing.Rerank, persistedSource.ResultsProcessing);
                Assert.IsTrue(persistedBase.KnowledgeSources.Any(reference => reference.Name == knowledgeSourceName));
                Assert.IsTrue(persistedBase.KnowledgeSources.Any(reference => reference.Name == secondarySourceName));
            }
            finally
            {
                if (testIndexClient != null)
                {
                    try
                    {
                        KnowledgeBase knowledgeBase = await testIndexClient.GetKnowledgeBaseAsync(resources.KnowledgeBaseName);
                        KnowledgeSourceReference secondaryReference = knowledgeBase.KnowledgeSources
                            .FirstOrDefault(reference => reference.Name == testSecondarySourceName);
                        if (secondaryReference != null)
                        {
                            knowledgeBase.KnowledgeSources.Remove(secondaryReference);
                            await testIndexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
                        }
                    }
                    catch { }
                    try
                    { await testIndexClient.DeleteKnowledgeSourceAsync(testSecondarySourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }

        [Test]
        public async Task ReadSearchOwnedCitationUrls()
        {
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", "https://fake-search.search.windows.net");
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", "fake-api-key");
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", "fake-knowledge-base");

            #region Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_CitationUrls
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential);
#if !SNIPPET
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent("""
                {
                  "response": [],
                  "activity": [],
                  "references": [
                    {"type":"searchIndex","id":"search-1","activitySource":1,"docKey":"hotel-1","citationUrl":"https://fake-search.search.windows.net/citations/search-1"},
                    {"type":"azureBlob","id":"blob-1","activitySource":2,"blobUrl":"https://storage.example.com/docs/blob-1","citationUrl":"https://fake-search.search.windows.net/citations/blob-1"},
                    {"type":"indexedSharePoint","id":"sharepoint-1","activitySource":3,"docUrl":"https://sharepoint.example.com/docs/1","citationUrl":"https://fake-search.search.windows.net/citations/sharepoint-1"},
                    {"type":"indexedOneLake","id":"onelake-1","activitySource":4,"docUrl":"https://onelake.example.com/docs/1","citationUrl":"https://fake-search.search.windows.net/citations/onelake-1"},
                    {"type":"file","id":"file-1","activitySource":5,"docName":"guides/overview.txt","citationUrl":"https://fake-search.search.windows.net/citations/file-1"},
                    {"type":"indexedSql","id":"sql-1","activitySource":6,"docUrl":"sql://documents/1","citationUrl":"https://fake-search.search.windows.net/citations/sql-1"}
                  ]
                }
                """);
            SearchClientOptions options = new SearchClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };
            retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, knowledgeBaseName, credential, options);
#endif

            KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
            request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find relevant documents"));

            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
            foreach (KnowledgeBaseReference reference in response.References)
            {
                Uri citationUrl = reference switch
                {
                    KnowledgeBaseSearchIndexReference searchIndex => searchIndex.CitationUrl,
                    KnowledgeBaseAzureBlobReference azureBlob => azureBlob.CitationUrl,
                    KnowledgeBaseIndexedSharePointReference sharePoint => sharePoint.CitationUrl,
                    KnowledgeBaseIndexedOneLakeReference oneLake => oneLake.CitationUrl,
                    KnowledgeBaseFileReference file => file.CitationUrl,
                    KnowledgeBaseIndexedSqlReference sql => sql.CitationUrl,
                    _ => null
                };

                if (citationUrl is null)
                {
                    // Work IQ, Fabric, web, remote SharePoint, and MCP references
                    // are not positive citation-URL cases for this release.
                    continue;
                }

                if (!citationUrl.IsAbsoluteUri || citationUrl.Host != endpoint.Host)
                {
                    throw new InvalidDataException("Expected an absolute Search-owned citation URL.");
                }

                Console.WriteLine($"{reference.GetType().Name}: {citationUrl}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_CitationUrls

            Assert.AreEqual(6, response.References.Count);
        }
    }
}
