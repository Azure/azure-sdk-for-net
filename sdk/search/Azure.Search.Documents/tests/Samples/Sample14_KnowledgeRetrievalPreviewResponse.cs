// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
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
                    Console.WriteLine($"  Query Planning - Model: {queryPlanning.ModelName}");
                    Console.WriteLine($"  Input tokens: {queryPlanning.InputTokens}, Output tokens: {queryPlanning.OutputTokens}");
                }
                else if (activity is KnowledgeBaseModelAnswerSynthesisActivityRecord answerSynthesis)
                {
                    Console.WriteLine($"  Answer Synthesis - Model: {answerSynthesis.ModelName}");
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
    }
}
