// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeSourceFabricOntologyPreview : SearchTestBase
    {
        public KnowledgeSourceFabricOntologyPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateAndUseFabricOntologyKnowledgeSource()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);
            Environment.SetEnvironmentVariable("FABRIC_WORKSPACE_ID", TestEnvironment.FabricWorkspaceId);
            Environment.SetEnvironmentVariable("FABRIC_ONTOLOGY_ID", TestEnvironment.FabricOntologyId);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create a Fabric Ontology knowledge source.
                // This connects the knowledge base to a Microsoft Fabric ontology,
                // enabling retrieval over structured business data models.
                string knowledgeSourceName = "my-fabric-ontology-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif

                // Provide the Fabric workspace ID and ontology ID
                string fabricWorkspaceId = Environment.GetEnvironmentVariable("FABRIC_WORKSPACE_ID");
                string fabricOntologyId = Environment.GetEnvironmentVariable("FABRIC_ONTOLOGY_ID");

                FabricOntologyKnowledgeSource fabricOntologySource = new FabricOntologyKnowledgeSource(
                    knowledgeSourceName,
                    new FabricOntologyKnowledgeSourceParameters(
                        workspaceId: fabricWorkspaceId,
                        ontologyId: fabricOntologyId))
                {
                    Description = "Fabric Ontology knowledge source for business data models"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(fabricOntologySource);
                Console.WriteLine($"Created Fabric Ontology knowledge source '{createdSource.Name}'");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is FabricOntologyKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_GetAndList
                // Get the Fabric Ontology knowledge source back
                KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

                if (retrievedSource is FabricOntologyKnowledgeSource retrievedOntology)
                {
                    Console.WriteLine($"  Kind: Fabric Ontology");
                    Console.WriteLine($"  Workspace ID: {retrievedOntology.FabricOntologyParameters.WorkspaceId}");
                    Console.WriteLine($"  Ontology ID: {retrievedOntology.FabricOntologyParameters.OntologyId}");
                }

                // List all knowledge sources
                await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
                {
                    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_AttachToKB
                // Create a knowledge base that uses the Fabric Ontology source
                string knowledgeBaseName = "my-fabric-ontology-kb";
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
                    Description = "Knowledge base with Fabric Ontology data",
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
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Fabric Ontology source");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Retrieve
                // Retrieve from the knowledge base — queries the Fabric ontology
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
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the key business entities?"));

                // Add per-source runtime parameters with references enabled
                request.KnowledgeSourceParams.Add(
                    new FabricOntologyKnowledgeSourceParams(knowledgeSourceName)
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

                // Fabric Ontology references include workspace and ontology identifiers
                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");

                    if (reference is KnowledgeBaseFabricOntologyReference ontologyRef)
                    {
                        Console.WriteLine($"  Workspace ID: {ontologyRef.WorkspaceId}");
                        Console.WriteLine($"  Ontology ID: {ontologyRef.OntologyId}");
                    }
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Retrieve

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
