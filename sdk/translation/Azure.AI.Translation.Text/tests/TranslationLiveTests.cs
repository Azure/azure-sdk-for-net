// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Tests
{
    public partial class TranslationLiveTests : TextTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TranslationLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TranslateBasic()
        {
            string fromLanguage = "es";
            string targetLanguages = "cs";
            string inputText = "Hola mundo";
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, sourceLanguage: fromLanguage).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Value.Count);
            Assert.AreEqual(1, response.Value.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual("cs", response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithAutoDetect()
        {
            string targetLanguage = "cs";
            string inputText = "This is a test.";
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Value.Count);
            Assert.AreEqual("en", response.Value.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual("cs", response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithMultipleInputTexts()
        {
            string targetLanguage = "cs";
            IEnumerable<string> inputText = new[]
            {
                "This is a test.",
                "Esto es una prueba.",
                "Dies ist ein Test."
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(3, response.Value.Value.Count);

            Assert.AreEqual("en", response.Value.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.AreEqual("es", response.Value.Value[1].DetectedLanguage.Language);
            Assert.AreEqual("de", response.Value.Value[2].DetectedLanguage.Language);

            Assert.AreEqual(1, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.LessOrEqual(0.5, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.LessOrEqual(0.5, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);

            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.Value[1].Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.Value[2].Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateMultipleTargetLanguages()
        {
            IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
            IEnumerable<string> inputText = new[] { "This is a test." };
            TextTranslationClient client = GetClient();
            TranslateInputItem input = new TranslateInputItem("This is a test.", targetLanguages.Select(lang => new TranslateTarget(lang)));
            var response = await client.TranslateAsync([input]).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Value.Count);
            Assert.AreEqual(3, response.Value.Value.FirstOrDefault().Translations.Count);

            Assert.AreEqual("en", response.Value.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);

            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations[1].Text);
            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations[2].Text);
        }

        [RecordedTest]
        public async Task TranslateWithCustomEndpoint()
        {
            string targetLanguage = "cs";
            string inputText = "It is a beautiful morning";
            TextTranslationClient client = GetClient(endpoint: new Uri(TestEnvironment.CustomEndpoint));
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Value.Count);
            Assert.AreEqual("en", response.Value.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.Value.FirstOrDefault().Translations.Count);
            Assert.NotNull(response.Value.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithToken()
        {
            string accessToken;
            if (Mode == RecordedTestMode.Playback)
            {
                accessToken = string.Empty;
            }
            else
            {
                accessToken = await GetAzureAuthorizationTokenAsync();
            }

            TokenCredential token = new StaticAccessTokenCredential(new AccessToken(accessToken, DateTimeOffset.Now.AddDays(1)));

            TextTranslationClient client = GetClient(token: token);
            IEnumerable<string> inputText = new[] { "This is a test." };
            var translate = await client.TranslateAsync("cs" , inputText).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Value.Count);
        }

        [RecordedTest]
        [PlaybackOnly("Live tests involving secrets will be temporarily disabled.")]
        public async Task TranslateWithAADAuth()
        {
            TextTranslationClient client = GetClient(useAADAuth: true);
            var translate = await client.TranslateAsync("cs", "This is a test.").ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Value.Count);
        }
    }
}
