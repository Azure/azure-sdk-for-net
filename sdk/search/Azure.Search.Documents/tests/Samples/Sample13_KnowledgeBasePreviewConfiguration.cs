// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeBasePreviewConfiguration : SearchTestBase
    {
        public KnowledgeBasePreviewConfiguration(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateKnowledgeBaseWithPreviewConfiguration()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
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

                // Create a knowledge base with preview configuration options
                string knowledgeBaseName = "my-preview-knowledge-base";
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
                    Description = "Knowledge base with preview configuration",

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

                    // Set reasoning effort level
                    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
                };

                // Add an Azure OpenAI model using a GPT-5.4 deployment
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
                                DeploymentName = "gpt-54-mini",
                                ModelName = AzureOpenAIModelName.Gpt54Mini
                            }));
#if !SNIPPET
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
                Console.WriteLine($"  CORS allowed origins: {string.Join(", ", createdBase.CorsOptions?.AllowedOrigins ?? Array.Empty<string>())}");
                Console.WriteLine($"  Output mode: {createdBase.OutputMode}");
                Console.WriteLine($"  Retrieval instructions: {createdBase.RetrievalInstructions}");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Create

                Assert.AreEqual(testBaseName, createdBase.Name);
                Assert.IsNotNull(createdBase.CorsOptions);
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
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task UpdateKnowledgeBasePreviewConfiguration()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Update
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get the existing knowledge base
            KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

            // Update preview configuration: add CORS options and change output mode
            knowledgeBase.CorsOptions = new CorsOptions(new[] { "*" })
            {
                MaxAgeInSeconds = 600
            };
            knowledgeBase.OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData;
            knowledgeBase.RetrievalInstructions = "Return raw data without summarization.";

            KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
            Console.WriteLine($"Updated knowledge base '{updatedBase.Name}'");
            Console.WriteLine($"  Output mode: {updatedBase.OutputMode}");
            #endregion Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Update

            Assert.AreEqual(KnowledgeRetrievalOutputMode.ExtractiveData, updatedBase.OutputMode);
        }
    }
}
