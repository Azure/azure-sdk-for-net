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
            string targetLanguage = "cs";
            string inputText = "Hola mundo";
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguage, inputText, fromLanguage).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual(targetLanguage, response.Value.FirstOrDefault().Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithAutoDetect()
        {
            string targetLanguage = "cs";
            string inputText = "This is a test.";
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(targetLanguage, response.Value.FirstOrDefault().Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
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
            Assert.AreEqual(3, response.Value.Count);

            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.AreEqual("es", response.Value[1].DetectedLanguage.Language);
            Assert.AreEqual("de", response.Value[2].DetectedLanguage.Language);

            Assert.AreEqual(1, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);

            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value[1].Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value[2].Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateMultipleTargetLanguages()
        {
            IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
            IEnumerable<string> inputText = new[] { "This is a test." };
            TextTranslationClient client = GetClient();
            TranslateInputItem input = new TranslateInputItem("This is a test.", targetLanguages.Select(lang => new TranslationTarget(lang)));
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual(3, response.Value.Translations.Count);

            Assert.AreEqual("en", response.Value.DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.DetectedLanguage.Score);

            Assert.NotNull(response.Value.Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.Translations[1].Text);
            Assert.NotNull(response.Value.Translations[2].Text);
        }

        [RecordedTest]
        public async Task TranslateWithLlmModel()
        {
            string targetLanguage = "es";
            string inputText = "This is a test.";
            string llmModel = "gpt-4o-mini";
            TranslationTarget target = new TranslationTarget(targetLanguage, deploymentName: llmModel);
            TranslateInputItem input = new TranslateInputItem(inputText, [target]);
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual(1, response.Value.Translations.Count);
            Assert.AreEqual(targetLanguage, response.Value.Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateDifferentTextTypes()
        {
            string inputText = "<html><body>This <b>is</b> a test.</body></html>";
            string targetLanguage = "cs";
            TextType type = TextType.Html;
            TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), textType: type);
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual(1, response.Value.Translations.Count);

            Assert.AreEqual("en", response.Value.DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.DetectedLanguage.Score);
        }

        [RecordedTest]
        public async Task TranslateWithProfanity()
        {
            ProfanityAction profanityAction = ProfanityAction.Marked;
            ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;
            string targetLanguage = "zh-cn";
            string inputText = "shit this is fucking crazy";
            TranslateInputItem input = new TranslateInputItem(
                inputText,
                new TranslationTarget(targetLanguage, profanityAction: profanityAction, profanityMarker: profanityMarkers)
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual("en", response.Value.DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.Translations.Count);
            Assert.IsTrue(response.Value.Translations.FirstOrDefault().Text.Contains("***"));
        }

        [RecordedTest]
        public async Task TranslateWithNoTranslateTag()
        {
            string fromLanguage = "zh-chs";
            string targetLanguage = "en";
            string inputText = "<span class=notranslate>今天是怎么回事是</span>非常可怕的";
            TranslateInputItem input = new TranslateInputItem(
                inputText,
                new TranslationTarget(targetLanguage),
                language: fromLanguage,
                textType: TextType.Html
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual(1, response.Value.Translations.Count);
            Assert.IsTrue(response.Value.Translations.First().Text.Contains("今天是怎么回事是"));
        }

        [RecordedTest]
        public async Task TranslateWithDictionaryTag()
        {
            string fromLanguage = "en";
            string targetLanguage = "es";
            string inputText = "The word < mstrans:dictionary translation =\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry.";
            TranslateInputItem input = new TranslateInputItem(
                inputText,
                new TranslationTarget(targetLanguage),
                language: fromLanguage,
                textType: TextType.Html
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.AreEqual(1, response.Value.Translations.Count);
            Assert.AreEqual("es", response.Value.Translations.FirstOrDefault().Language);
            Assert.IsTrue(response.Value.Translations.FirstOrDefault().Text.Contains("wordomatic"));
        }

        [RecordedTest]
        public async Task TranslateWithTransliteration()
        {
            string fromLanguage = "ar";
            string targetLanguage = "zh-Hans";
            string script = "Latn";
            string inputText = "hudha akhtabar.";
            TranslateInputItem input = new TranslateInputItem(
                inputText,
                new TranslationTarget(targetLanguage, script: script),
                language: fromLanguage,
                script: script
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            Assert.AreEqual("zh-Hans", response.Value.Translations.FirstOrDefault().Language);
            Assert.NotNull(response.Value.Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateMultipleInputsAndTargets()
        {
            IEnumerable<TranslateInputItem> inputs = new[]
            {
                new TranslateInputItem("This is a test.", new[] { new TranslationTarget("es"), new TranslationTarget("de", deploymentName: "gpt-4o-mini") }),
                new TranslateInputItem("Hola mundo", new[] { new TranslationTarget("en"), new TranslationTarget("zh-Hans", script: "Latn") }),
                new TranslateInputItem("<html><body>This <b>is</b> a test.</body></html>", new TranslationTarget("zh-Hant"), textType: TextType.Html)
            };

            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(inputs).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(3, response.Value.Count);
            Assert.AreEqual(2, response.Value[0].Translations.Count);
            Assert.AreEqual("es", response.Value[0].Translations[0].Language);
            Assert.NotNull(response.Value[0].Translations[0].Text);
            Assert.AreEqual("de", response.Value[0].Translations[1].Language);
            Assert.NotNull(response.Value[0].Translations[1].Text);
            Assert.AreEqual(2, response.Value[1].Translations.Count);
            Assert.AreEqual("en", response.Value[1].Translations[0].Language);
            Assert.NotNull(response.Value[1].Translations[0].Text);
            Assert.AreEqual("zh-Hans", response.Value[1].Translations[1].Language);
            Assert.NotNull(response.Value[1].Translations[1].Text);
            Assert.AreEqual(1, response.Value[2].Translations.Count);
            Assert.AreEqual("zh-Hant", response.Value[2].Translations[0].Language);
            Assert.IsTrue(response.Value[2].Translations[0].Text.Contains("html"));
        }

        [RecordedTest]
        public async Task TranslateWithCustomEndpoint()
        {
            string targetLanguage = "cs";
            string inputText = "It is a beautiful morning";
            TextTranslationClient client = GetClient(endpoint: new Uri(TestEnvironment.CustomEndpoint));
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
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
            var translate = await client.TranslateAsync("cs", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }
    }
}
