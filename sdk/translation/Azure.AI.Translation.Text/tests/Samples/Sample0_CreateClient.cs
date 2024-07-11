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
        [Test]
        public TextTranslationClient CreateTextTranslationClient()
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

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithKey()
        {
            #region Snippet:CreateTextTranslationClientWithKey

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;

#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey));
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithRegion()
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

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithEndpoint()
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

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithToken()
        {
            #region Snippet:CreateTextTranslationClientWithToken

            string token = "<Cognitive Services Token>";
            TokenCredential credential = new StaticAccessTokenCredential(new AccessToken(token, DateTimeOffset.Now.AddMinutes(1)));
            TextTranslationClient client = new(credential);

            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithAad()
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

            return client;
        }

        [Test]
        public void HandleBadRequest()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        public async void HandleBadRequestAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
