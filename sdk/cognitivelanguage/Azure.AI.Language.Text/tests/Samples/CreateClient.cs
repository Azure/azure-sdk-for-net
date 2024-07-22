// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Text_Identity_Namespace
using Azure.Identity;
#endregion

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class CreateClient : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        public void CreateTextAnalysisClientForSpecificApiVersion()
        {
            #region Snippet:CreateTextAnalysisClientForSpecificApiVersion
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            AzureKeyCredential credential = new("your apikey");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
            var client = new TextAnalysisClient(endpoint, credential, options);
            #endregion
        }

        [Test]
        public void CreateTextClient()
        {
            #region Snippet:CreateTextClient
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            AzureKeyCredential credential = new("your apikey");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
            #endregion
        }

        [Test]
        public void TextAnalysisClient_CreateWithDefaultAzureCredential()
        {
            #region Snippet:TextAnalysisClient_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
            #endregion
        }
    }
}
