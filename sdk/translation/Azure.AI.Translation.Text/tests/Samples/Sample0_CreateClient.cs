// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Text.Tests;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Sample0_CreateClient : SamplesBase<TextTranslationTestEnvironment>
    {
        public TextTranslationClient CreateClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;

            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
            return client;
        }

        [Test]
        public void CreateTextTranslationClient()
        {
            #region Snippet:CreateTextTranslationClient

#if SNIPPET
            string endpoint = "<Text Translator Resource Endpoint>";
            string apiKey = "<Text Translator Resource API Key>";
            string region = "<Text Translator Azure Region>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
            #endregion
        }

        [Test]
        public void CreateTextTranslationClientWithKey()
        {
            #region Snippet:CreateTextTranslationClientWithKey

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;

#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey));
            #endregion

        }

        [Test]
        public void CreateTextTranslationClientWithRegion()
        {
            #region Snippet:CreateTextTranslationClientWithRegion

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
            string region = "<Text Translator Azure Region>";
#else
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), region);
            #endregion

        }

        [Test]
        public void CreateTextTranslationClientWithEndpoint()
        {
            #region Snippet:CreateTextTranslationClientWithEndpoint

#if SNIPPET
            string endpoint = "<Text Translator Resource Endpoint>";
            string apiKey = "<Text Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint));
            #endregion

        }

        [Test]
        public void CreateTextTranslationClientWithToken()
        {
            #region Snippet:CreateTextTranslationClientWithToken

            string token = "<Cognitive Services Token>";
            TokenCredential credential = new StaticAccessTokenCredential(new AccessToken(token, DateTimeOffset.Now.AddMinutes(1)));
            TextTranslationClient client = new(credential);

            #endregion

        }

        [Test]
        public void CreateTextTranslationClientWithAad()
        {
            #region Snippet:CreateTextTranslationClientWithAad

#if SNIPPET
            string endpoint = "<Text Translator Custom Endpoint>";
#else
            string endpoint = TestEnvironment.CustomEndpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextTranslationClient client = new TextTranslationClient(credential, new Uri(endpoint));

            #endregion

        }

        [Test]
        public void HandleBadRequest()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:HandleBadRequest
            try
            {
                var translation = client.Translate(Array.Empty<string>(), new[] { "This is a Test" });
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        public async Task HandleBadRequestAsync()
        {
            TextTranslationClient client = CreateClient();

            try
            {
                var translation = await client.TranslateAsync(Array.Empty<string>(), new[] { "This is a Test" }).ConfigureAwait(false);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [Test]
        public void CreateLoggingMonitor()
        {
            #region Snippet:CreateLoggingMonitor

            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();

            #endregion
        }
    }
}
