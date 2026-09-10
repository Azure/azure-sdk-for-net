// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_08_01_Preview)]
    public partial class KnowledgeSourceWorkIqPreview : SearchTestBase
    {
        public KnowledgeSourceWorkIqPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [Ignore("Work IQ knowledge requires entra app authentication which requires provisioning a live app. Skipping test for now")]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateAndUseWorkIqKnowledgeSource()
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
                #region Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create a Work IQ knowledge source.
                // Work IQ connects the knowledge base to Microsoft 365 work data,
                // enabling retrieval from emails, documents, and other M365 content.
                string knowledgeSourceName = "my-workiq-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif

                EntraAppAuthentication entraAuthentication = new EntraAppAuthentication(
                    applicationId: Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    federatedCredentialId: Guid.Parse("00000000-0000-0000-0000-000000000000"));

                // TenantId is optional when the app and Search service use the same
                // tenant. Set it explicitly for a cross-tenant app registration.
                string tenantId = Environment.GetEnvironmentVariable("WORK_IQ_TENANT_ID");
                if (!string.IsNullOrEmpty(tenantId))
                {
                    entraAuthentication.TenantId = Guid.Parse(tenantId);
                }

                WorkIQKnowledgeSourceParameters workIqParameters = new WorkIQKnowledgeSourceParameters(entraAuthentication);

                WorkIQKnowledgeSource workIqSource = new WorkIQKnowledgeSource(knowledgeSourceName, workIqParameters)
                {
                    Description = "Work IQ knowledge source for M365 content"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(workIqSource);
                Console.WriteLine($"Created Work IQ knowledge source '{createdSource.Name}'");
                Console.WriteLine($"  Tenant: {workIqParameters.EntraAppAuthentication.TenantId?.ToString() ?? "Search service tenant"}");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is WorkIQKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_GetAndList
                // Get the Work IQ knowledge source back
                KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

                if (retrievedSource is WorkIQKnowledgeSource)
                {
                    Console.WriteLine($"  Kind: WorkIQ");
                }

                // List all knowledge sources
                await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
                {
                    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_AttachToKB
                // Create a knowledge base that uses the Work IQ source
                string knowledgeBaseName = "my-workiq-kb";
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
                    Description = "Knowledge base with Work IQ data",
                    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
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
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Work IQ source");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Retrieve
                // Retrieve from the knowledge base — Work IQ queries M365 data.
                // Note: Work IQ may take 40-60 seconds, so set a generous maxRuntimeInSeconds.
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
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find recent project status updates"));

                // Add per-source runtime parameters with references enabled
                request.KnowledgeSourceParams.Add(
                    new WorkIQKnowledgeSourceParams(knowledgeSourceName)
                    {
                        IncludeReferences = true,
                        IncludeReferenceSourceData = true
                    });

                // Search query-source authorization enforces Search document access.
                // It is separate from the Work IQ user assertion.
                string querySourceAuthorization = Environment.GetEnvironmentVariable("SEARCH_QUERY_SOURCE_AUTH");

                // The Work IQ user assertion represents the user for on-behalf-of
                // authentication to Work IQ. Do not reuse a Search access token here.
                string queryWorkIQSourceAuthorization = Environment.GetEnvironmentVariable("WORK_IQ_USER_ASSERTION");

                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(
                    request,
                    querySourceAuthorization: querySourceAuthorization,
                    queryWorkIQSourceAuthorization: queryWorkIQSourceAuthorization);
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

                // Work IQ references point back to M365 content
                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");

                    if (reference is KnowledgeBaseWorkIQReference workIqRef)
                    {
                        Console.WriteLine($"  Work IQ reference data:");
                        foreach (var kvp in workIqRef.SourceData)
                        {
                            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                        }
                    }
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Retrieve

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
