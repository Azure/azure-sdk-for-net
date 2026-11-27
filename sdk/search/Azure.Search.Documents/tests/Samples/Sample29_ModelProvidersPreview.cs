// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task NativeGpt6RetrievesSeededEvidence()
        {
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            #region Snippet:Azure_Search_Documents_Sample29_NativeGpt6
            // Use an existing deployment and its exact supported model profile, not a Chat Completions URL.
            KnowledgeBaseAzureOpenAIModel model = new KnowledgeBaseAzureOpenAIModel(new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                ApiKey = openAIKey,
                DeploymentName = RequiredPreviewSetting("SEARCH_GPT6_DEPLOYMENT_NAME"),
                ModelName = RequiredPreviewSetting("SEARCH_GPT6_MODEL_NAME")
            });
            string profile = model.AzureOpenAIParameters.ModelName.ToString();
            if (!new[] { "gpt-6-astra", "gpt-6-sol", "gpt-6-luna", "gpt-6.1-sol" }.Contains(profile))
            {
                throw new InvalidOperationException("Select the supported GPT-6 profile matching the deployment.");
            }
            #endregion
            await RetrievePreviewWithModelAsync(model);
        }

        [Test]
        [LiveOnly]
        public async Task CompatibleChatRetrievesSeededEvidence()
        {
            await RetrievePreviewWithModelAsync(PreviewCompatibleChatModel());
        }

        private KnowledgeBaseOpenAICompatibleModel PreviewCompatibleChatModel()
        {
            #region Snippet:Azure_Search_Documents_Sample29_CompatibleChat
            KnowledgeBaseOpenAICompatibleParameters parameters = new KnowledgeBaseOpenAICompatibleParameters(
                new Uri(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_CHAT_URI")),
                RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_CHAT_MODEL"));
            string audience = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_CHAT_MI_AUDIENCE");
            string headers = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_CHAT_HEADERS_JSON");
            if (!string.IsNullOrWhiteSpace(audience) == !string.IsNullOrWhiteSpace(headers))
            {
                throw new InvalidOperationException("Configure exactly one compatible-provider authentication method.");
            }
            if (!string.IsNullOrWhiteSpace(audience))
            {
                parameters.ManagedIdentityAudience = audience;
            }
            else
            {
                foreach (KeyValuePair<string, string> header in JsonSerializer.Deserialize<Dictionary<string, string>>(headers))
                {
                    parameters.Headers.Add(header.Key, header.Value);
                }
            }
            KnowledgeBaseOpenAICompatibleModel model = new KnowledgeBaseOpenAICompatibleModel(parameters);
            #endregion
            return model;
        }

        private async Task RetrievePreviewWithModelAsync(KnowledgeBaseModel model)
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();
            string sourceName = indexName + "-source";
            string baseName = indexName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            await indexClient.CreateIndexAsync(PreviewHotelIndex(indexName));
            resources.TrackIndex(indexName);
            await UploadPreviewDocumentsAsync(CreatePreviewSearchClient(resources, indexName), PreviewHotels());

            #region Snippet:Azure_Search_Documents_Sample29_ModelRetrieval
            await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(sourceName,
                new SearchIndexKnowledgeSourceParameters(indexName)
                {
                    SemanticConfigurationName = "hotels",
                    SourceDataFields = { new SearchIndexFieldReference("id"), new SearchIndexFieldReference("content") }
                }));
#if !SNIPPET
            resources.TrackSource(sourceName);
#endif
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
                new[] { new KnowledgeSourceReference(sourceName) })
            {
                Models = { model },
                RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(
                new KnowledgeBaseRetrievalRequest
                {
                    Messages =
                    {
                        new KnowledgeBaseMessage(new[]
                        {
                            new KnowledgeBaseMessageTextContent("What hotel guest benefits are available?")
                        }) { Role = "user" }
                    },
                    IncludeActivity = true,
                    KnowledgeSourceParams =
                    {
                        new SearchIndexKnowledgeSourceParams(sourceName)
                        {
                            IncludeReferences = true,
                            IncludeReferenceSourceData = true
                        }
                    }
                });
            foreach (KnowledgeBaseSearchIndexReference reference in response.References.OfType<KnowledgeBaseSearchIndexReference>())
            {
                Console.WriteLine($"Retrieved seeded hotel: {reference.DocKey}");
            }
            #endregion
            AssertPreviewReferences(response, "hotel-ca-1", "hotel-ca-2", "hotel-us-1");
            var expected = PreviewHotels().ToDictionary(document => (string)document["id"]);
            foreach (KnowledgeBaseSearchIndexReference reference in response.References)
            {
                Assert.That(reference.SourceData["content"].ToObjectFromJson<string>(),
                    Is.EqualTo(expected[reference.DocKey]["content"]));
            }
            if (model is KnowledgeBaseOpenAICompatibleModel)
            {
                KnowledgeBase stored = await indexClient.GetKnowledgeBaseAsync(baseName);
                var compatible = (KnowledgeBaseOpenAICompatibleModel)stored.Models.Single();
                Assert.That(compatible.OpenAICompatibleParameters.Headers.Count, Is.Zero,
                    "Stored authentication header names and values must not be returned.");
            }
        }
    }
}
