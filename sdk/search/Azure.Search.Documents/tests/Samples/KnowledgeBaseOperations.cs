// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Namespaces
using Azure.Identity;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Newtonsoft.Json;

#endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class KnowledgeBaseOperations : SearchTestBase
    {
        public KnowledgeBaseOperations(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task CreateKnowledgeBase()
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
                #region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                DefaultAzureCredential credential = new DefaultAzureCredential();
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, TestEnvironment.Credential, GetSearchClientOptions()));
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
#if AZURE_SEARCH_PREVIEW
                knowledgeBase.Tags.Add("environment", "sample");
                knowledgeBase.Tags.Add("owner", "search-team");
#endif

                // Add an Azure OpenAI model for query planning
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
#if !SNIPPET
                if (!string.IsNullOrEmpty(openAIEndpoint))
                {
#endif
                    knowledgeBase.Models.Add(
                        new KnowledgeBaseAzureOpenAIModel(
                            new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint),
                                DeploymentName = "gpt-5.4-mini",
                                ModelName = AzureOpenAIModelName.Gpt54Mini
                            }));
#if !SNIPPET
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Create

                Assert.AreEqual(testBaseName, createdBase.Name);
                Assert.AreEqual(1, createdBase.KnowledgeSources.Count);
#if AZURE_SEARCH_PREVIEW
                Assert.IsTrue(string.Equals("sample", createdBase.Tags["environment"]));
                Assert.IsTrue(string.Equals("search-team", createdBase.Tags["owner"]));
#endif
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
        public async Task GetKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Get
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, TestEnvironment.Credential, GetSearchClientOptions()));
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
#if AZURE_SEARCH_PREVIEW
            foreach (KeyValuePair<string, string> tag in knowledgeBase.Tags)
            {
                Console.WriteLine($"  Tag: {tag.Key} = {tag.Value}");
            }
#endif
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Get

            Assert.AreEqual(resources.KnowledgeBaseName, knowledgeBase.Name);
        }

        [Test]
        public async Task ListKnowledgeBases()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());

            #region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_List
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            DefaultAzureCredential credential = new DefaultAzureCredential();

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, TestEnvironment.Credential, GetSearchClientOptions()));
#endif

            // List all knowledge bases
            await foreach (KnowledgeBase kb in indexClient.GetKnowledgeBasesAsync())
            {
                Console.WriteLine($"Knowledge base: {kb.Name} (sources: {kb.KnowledgeSources.Count})");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_List
        }

        [Test]
        public async Task UpdateKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Update
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, TestEnvironment.Credential, GetSearchClientOptions()));
#endif

            // Get the existing knowledge base
            KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

            // Update its description and application metadata.
            knowledgeBase.Description = "Updated description for hotel knowledge base";
#if AZURE_SEARCH_PREVIEW
            knowledgeBase.Tags.Add("lifecycle", "updated");
#endif

            KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
            Console.WriteLine($"Updated knowledge base '{updatedBase.Name}': {updatedBase.Description}");
#if AZURE_SEARCH_PREVIEW
            Console.WriteLine($"  Lifecycle tag: {updatedBase.Tags["lifecycle"]}");
#endif
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Update

            Assert.AreEqual("Updated description for hotel knowledge base", updatedBase.Description);
            KnowledgeBase persistedBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
#if AZURE_SEARCH_PREVIEW
            Assert.AreEqual("updated", persistedBase.Tags["lifecycle"]);
#endif
            Assert.AreEqual(updatedBase.Description, persistedBase.Description);
        }

        [Test]
        public async Task DeleteKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, TestEnvironment.Credential, GetSearchClientOptions()));

            // Create source and knowledge base to delete
            SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
                testSourceName,
                new SearchIndexKnowledgeSourceParameters(resources.IndexName));
            await testClient.CreateKnowledgeSourceAsync(source);
            await DelayAsync(TimeSpan.FromSeconds(2));

            string deploymentName = "gpt-5.4-mini";
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
                        DeploymentName = deploymentName,
                        ModelName = AzureOpenAIModelName.Gpt54Mini
                    }));
            await testClient.CreateKnowledgeBaseAsync(kb);
            await DelayAsync(TimeSpan.FromSeconds(2));

            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", testBaseName);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Delete
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                DefaultAzureCredential credential = new DefaultAzureCredential();
                string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // Delete a knowledge base by name
                await indexClient.DeleteKnowledgeBaseAsync(knowledgeBaseName);
                Console.WriteLine($"Deleted knowledge base '{knowledgeBaseName}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Delete

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
