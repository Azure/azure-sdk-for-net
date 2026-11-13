// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_10_01)]
    public partial class KnowledgeBaseConfiguration : SearchTestBase
    {
        public KnowledgeBaseConfiguration(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task CreateKnowledgeBaseWithConfiguration()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                TokenCredential credential = new DefaultAzureCredential();
#if !SNIPPET
                credential = TestEnvironment.Credential;
#endif
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create a knowledge source referencing a search index
                string knowledgeSourceName = "my-hotels-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
                    knowledgeSourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName));
                await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);

                // Create a knowledge base with retrieval configuration options
                string knowledgeBaseName = "my-knowledge-base";
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
                    Description = "Knowledge base with retrieval configuration",

                    // Configure CORS options for cross-origin access
                    CorsOptions = new CorsOptions(new[] { "https://myapp.example.com", "https://dashboard.example.com" })
                    {
                        MaxAgeInSeconds = 300
                    },

                    // Set KB-level retrieval instructions and answer instructions
                    RetrievalInstructions = "Focus on luxury hotel amenities and pricing information.",
                    AnswerInstructions = "Provide concise answers with specific hotel details and ratings.",

                    // Set default output mode for all retrievals from this KB
                    OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis,

                    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
                };

                // The deployment must exist and allow the Search service's managed identity.
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
                knowledgeBase.Models.Add(
                    new KnowledgeBaseAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(openAIEndpoint),
                            DeploymentName = "gpt-5.4-mini",
                            ModelName = AzureOpenAIModelName.Gpt54Mini
                        }));

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
                Console.WriteLine($"  CORS allowed origins: {string.Join(", ", createdBase.CorsOptions?.AllowedOrigins ?? Array.Empty<string>())}");
                Console.WriteLine($"  Output mode: {createdBase.OutputMode}");
                Console.WriteLine($"  Reasoning effort: {createdBase.RetrievalReasoningEffort.GetType().Name}");
                Console.WriteLine($"  Retrieval instructions: {createdBase.RetrievalInstructions}");
                #endregion Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Create

                Assert.AreEqual(testBaseName, createdBase.Name);
                Assert.IsNotNull(createdBase.CorsOptions);
                Assert.AreEqual(knowledgeSourceName, createdBase.KnowledgeSources[0].Name);
                Assert.AreEqual(1, createdBase.Models.Count);
                Assert.AreEqual(knowledgeBase.RetrievalInstructions, createdBase.RetrievalInstructions);
                Assert.AreEqual(knowledgeBase.AnswerInstructions, createdBase.AnswerInstructions);
                Assert.IsInstanceOf<KnowledgeRetrievalLowReasoningEffort>(createdBase.RetrievalReasoningEffort);
                Assert.AreEqual(KnowledgeRetrievalOutputMode.AnswerSynthesis, createdBase.OutputMode);
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

        [Test]
        public async Task UpdateKnowledgeBaseConfiguration()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Update
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            TokenCredential credential = new DefaultAzureCredential();
#if !SNIPPET
            credential = TestEnvironment.Credential;
#endif
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get the existing knowledge base
            KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

            knowledgeBase.CorsOptions = new CorsOptions(new[] { "https://myapp.example.com" })
            {
                MaxAgeInSeconds = 600
            };
            // Update the default retrieval mode and query-planning instructions.
            knowledgeBase.OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData;
            knowledgeBase.RetrievalInstructions = "Prioritize hotels with lower nightly rates.";

            KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
            Console.WriteLine($"Updated knowledge base '{updatedBase.Name}'");
            Console.WriteLine($"  Output mode: {updatedBase.OutputMode}");
            #endregion Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Update

            Assert.AreEqual(KnowledgeRetrievalOutputMode.ExtractiveData, updatedBase.OutputMode);
            Assert.AreEqual(knowledgeBase.RetrievalInstructions, updatedBase.RetrievalInstructions);
            Assert.AreEqual(resources.KnowledgeBaseName, updatedBase.Name);
        }
    }
}
