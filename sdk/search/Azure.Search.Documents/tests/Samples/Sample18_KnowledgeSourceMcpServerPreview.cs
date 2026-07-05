// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeSourceMcpServerPreview : SearchTestBase
    {
        public KnowledgeSourceMcpServerPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateAndUseMcpServerKnowledgeSource()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create an MCP Server knowledge source.
                // This connects the knowledge base to an external MCP (Model Context Protocol) server
                // that exposes tools for data retrieval.
                string knowledgeSourceName = "my-mcp-server-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif

                // Define the tools available on the MCP server
                McpServerTool searchTool = new McpServerTool
                {
                    Name = "microsoft_docs_search",
                    OutputParsing = new McpServerAutoOutputParsing()
                };

                // Configure the MCP server parameters
                McpServerKnowledgeSourceParameters mcpParams = new McpServerKnowledgeSourceParameters(
                    serverURL: "https://learn.microsoft.com/api/mcp",
                    tools: new[] { searchTool });

                McpServerKnowledgeSource mcpSource = new McpServerKnowledgeSource(
                    knowledgeSourceName, mcpParams)
                {
                    Description = "MCP server knowledge source for Microsoft documentation"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(mcpSource);
                Console.WriteLine($"Created MCP server knowledge source '{createdSource.Name}'");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is McpServerKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_GetAndList
                // Get the MCP server knowledge source back
                KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

                if (retrievedSource is McpServerKnowledgeSource retrievedMcp)
                {
                    Console.WriteLine($"  Server URL: {retrievedMcp.McpServerParameters.ServerURL}");
                    Console.WriteLine($"  Tools: {retrievedMcp.McpServerParameters.Tools.Count}");
                    foreach (McpServerTool tool in retrievedMcp.McpServerParameters.Tools)
                    {
                        Console.WriteLine($"    - {tool.Name} (inclusion: {tool.InclusionMode})");
                    }
                }

                // List all knowledge sources
                await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
                {
                    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_AttachToKB
                // Create a knowledge base that uses the MCP server source
                string knowledgeBaseName = "my-mcp-kb";
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
                    Description = "Knowledge base backed by MCP server tools",
                    OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis,
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
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with MCP server source");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Retrieve
                // Retrieve from the knowledge base — the MCP server tools are invoked as needed
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true,
                    MaxRuntimeInSeconds = 120
                };
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What products are in stock?"));

                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
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

                // Activity records show which MCP tools were invoked
                foreach (KnowledgeBaseActivityRecord activity in retrievalResponse.Activity)
                {
                    Console.WriteLine($"Activity ID: {activity.Id}, Elapsed: {activity.ElapsedMs}ms");
                }

                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Retrieve

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
