// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeSourceFabricDataAgentPreview : SearchTestBase
    {
        public KnowledgeSourceFabricDataAgentPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateAndUseFabricDataAgentKnowledgeSource()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);
            Environment.SetEnvironmentVariable("FABRIC_WORKSPACE_ID", TestEnvironment.FabricWorkspaceId);
            Environment.SetEnvironmentVariable("FABRIC_DATA_AGENT_ID", TestEnvironment.FabricDataAgentId);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create a Fabric Data Agent knowledge source.
                // This connects the knowledge base to a Microsoft Fabric Data Agent,
                // enabling retrieval from Fabric data pipelines and analytics.
                string knowledgeSourceName = "my-fabric-data-agent-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif

                // Provide the Fabric workspace ID and data agent ID
                string fabricWorkspaceId = Environment.GetEnvironmentVariable("FABRIC_WORKSPACE_ID");
                string fabricDataAgentId = Environment.GetEnvironmentVariable("FABRIC_DATA_AGENT_ID");

                FabricDataAgentKnowledgeSource fabricDataAgentSource = new FabricDataAgentKnowledgeSource(
                    knowledgeSourceName,
                    new FabricDataAgentKnowledgeSourceParameters(
                        workspaceId: fabricWorkspaceId,
                        dataAgentId: fabricDataAgentId))
                {
                    Description = "Fabric Data Agent knowledge source for analytics data"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(fabricDataAgentSource);
                Console.WriteLine($"Created Fabric Data Agent knowledge source '{createdSource.Name}'");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is FabricDataAgentKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_GetAndList
                // Get the Fabric Data Agent knowledge source back
                KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

                if (retrievedSource is FabricDataAgentKnowledgeSource retrievedAgent)
                {
                    Console.WriteLine($"  Kind: Fabric Data Agent");
                    Console.WriteLine($"  Workspace ID: {retrievedAgent.FabricDataAgentParameters.WorkspaceId}");
                    Console.WriteLine($"  Data Agent ID: {retrievedAgent.FabricDataAgentParameters.DataAgentId}");
                }

                // List all knowledge sources
                await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
                {
                    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_AttachToKB
                // Create a knowledge base that uses the Fabric Data Agent source
                string knowledgeBaseName = "my-fabric-agent-kb";
#if !SNIPPET
                knowledgeBaseName = testBaseName;
#endif
                KnowledgeBase knowledgeBase = new KnowledgeBase(
                    knowledgeBaseName,
                    knowledgeSources: new[]
                    {
                        new KnowledgeSourceReference(knowledgeSourceName)
                    })
                {
                    Description = "Knowledge base with Fabric Data Agent",
                    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
                };

                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
                string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");
#if !SNIPPET
                if (!string.IsNullOrEmpty(openAIEndpoint))
                {
#endif
                    knowledgeBase.Models.Add(
                        new KnowledgeBaseAzureOpenAIModel(
                            new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint),
                                ApiKey = openAIKey,
                                DeploymentName = "gpt-5.4-mini",
                                ModelName = AzureOpenAIModelName.Gpt54Mini
                            }));
#if !SNIPPET
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Fabric Data Agent source");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Retrieve
                // Retrieve from the knowledge base — the Fabric Data Agent handles data queries
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true
                };
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the latest sales trends?"));

                // Add per-source runtime parameters with references enabled
                request.KnowledgeSourceParams.Add(
                    new FabricDataAgentKnowledgeSourceParams(knowledgeSourceName)
                    {
                        IncludeReferences = true,
                        IncludeReferenceSourceData = true
                    });

                // Fabric sources require a query source authorization token.
                // Obtain an access token scoped to the search service:
                // az account get-access-token --resource https://search.azure.com
                string querySourceAuthorization = Environment.GetEnvironmentVariable("SEARCH_QUERY_SOURCE_AUTH");
#if !SNIPPET
                AccessToken token = await TestEnvironment.Credential.GetTokenAsync(
                    new TokenRequestContext(new[] { "https://search.azure.com/.default" }), CancellationToken.None);
                querySourceAuthorization = token.Token;
#endif

                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(
                    request, querySourceAuthorization);
                KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

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

                // Fabric Data Agent references include workspace and agent identifiers
                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");

                    if (reference is KnowledgeBaseFabricDataAgentReference dataAgentRef)
                    {
                        Console.WriteLine($"  Workspace ID: {dataAgentRef.WorkspaceId}");
                        Console.WriteLine($"  Data Agent ID: {dataAgentRef.DataAgentId}");
                    }
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Retrieve

                Assert.IsNotNull(retrievalResponse);
            }
            finally
            {
                if (testClient != null)
                {
                    try
                    { await testClient.DeleteKnowledgeBaseAsync(testBaseName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testClient.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }
    }
}
