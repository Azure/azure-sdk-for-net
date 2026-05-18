// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
#endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2026_04_01), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class KnowledgeBaseOperations : SearchTestBase
    {
        public KnowledgeBaseOperations(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateKnowledgeBase()
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
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // First, create a knowledge source referencing a search index
                string knowledgeSourceName = "my-hotels-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
                    knowledgeSourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName));
                await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);

                // Create a knowledge base that references the knowledge source
                string knowledgeBaseName = "my-hotels-knowledge-base";
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
                    Description = "Knowledge base for hotel information"
                };

                // Add an Azure OpenAI model for query planning
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
                                DeploymentName = "gpt-5-mini",
                                ModelName = AzureOpenAIModelName.Gpt5Mini
                            }));
#if !SNIPPET
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with {createdBase.KnowledgeSources.Count} source(s)");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Create

                Assert.AreEqual(testBaseName, createdBase.Name);
                Assert.AreEqual(1, createdBase.KnowledgeSources.Count);
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
        public async Task GetKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Get
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get a specific knowledge base by name
            KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
            Console.WriteLine($"Knowledge base '{knowledgeBase.Name}'");
            Console.WriteLine($"  Description: {knowledgeBase.Description}");
            Console.WriteLine($"  Knowledge sources: {knowledgeBase.KnowledgeSources.Count}");
            foreach (KnowledgeSourceReference sourceRef in knowledgeBase.KnowledgeSources)
            {
                Console.WriteLine($"    - {sourceRef.Name}");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Get

            Assert.AreEqual(resources.KnowledgeBaseName, knowledgeBase.Name);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task ListKnowledgeBases()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_List
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // List all knowledge bases
            await foreach (KnowledgeBase kb in indexClient.GetKnowledgeBasesAsync())
            {
                Console.WriteLine($"Knowledge base: {kb.Name} (sources: {kb.KnowledgeSources.Count})");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_List
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task UpdateKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Update
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

            // Update its description
            knowledgeBase.Description = "Updated description for hotel knowledge base";

            KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
            Console.WriteLine($"Updated knowledge base '{updatedBase.Name}': {updatedBase.Description}");
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Update

            Assert.AreEqual("Updated description for hotel knowledge base", updatedBase.Description);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task DeleteKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create source and knowledge base to delete
            SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
                testSourceName,
                new SearchIndexKnowledgeSourceParameters(resources.IndexName));
            await testClient.CreateKnowledgeSourceAsync(source);
            await DelayAsync(TimeSpan.FromSeconds(2));

            string deploymentName = "gpt-5-mini";
            KnowledgeBase kb = new KnowledgeBase(
                testBaseName,
                knowledgeSources: new[] { new KnowledgeSourceReference(testSourceName) })
            {
                Description = "Temporary knowledge base"
            };
            kb.Models.Add(
                new KnowledgeBaseAzureOpenAIModel(
                    new AzureOpenAIVectorizerParameters
                    {
                        ResourceUri = new Uri(TestEnvironment.OpenAIEndpoint),
                        ApiKey = TestEnvironment.OpenAIKey,
                        DeploymentName = deploymentName,
                        ModelName = AzureOpenAIModelName.Gpt5Mini
                    }));
            await testClient.CreateKnowledgeBaseAsync(kb);
            await DelayAsync(TimeSpan.FromSeconds(2));

            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", testBaseName);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Delete
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // Delete a knowledge base by name
                await indexClient.DeleteKnowledgeBaseAsync(knowledgeBaseName);
                Console.WriteLine($"Deleted knowledge base '{knowledgeBaseName}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Delete

                // Verify it was deleted
                var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await testClient.GetKnowledgeBaseAsync(testBaseName);
                });
                Assert.AreEqual(404, ex.Status);
            }
            finally
            {
                try
                { await testClient.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }
    }
}
