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
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual("cs", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateBasicOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(targetLanguage: "cs", content: "Hola mundo")
            {
                SourceLanguage = "es",
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(
                options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual("cs", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithAutoDetect()
        {
            IEnumerable<string> targetLanguages = new[] { "cs" };
            IEnumerable<string> inputText = new[] { "This is a test." };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual("cs", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithAutoDetectOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(targetLanguage: "cs", content: "This is a test.");
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual("cs", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithNoTranslateTag()
        {
            string fromLanguage = "zh-chs";
            IEnumerable<string> targetLanguages = new[] { "en" };
            IEnumerable<string> inputText = new[] { "<span class=notranslate>今天是怎么回事是</span>非常可怕的" };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, sourceLanguage: fromLanguage, textType: TextType.Html).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.First().Text.Contains("今天是怎么回事是"));
        }

        [RecordedTest]
        public async Task TranslateWithNoTranslateTagOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(targetLanguage: "en", content: "<span class=notranslate>今天是怎么回事是</span>非常可怕的")
            {
                SourceLanguage = "zh-chs",
                TextType = TextType.Html
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.First().Text.Contains("今天是怎么回事是"));
        }

        [RecordedTest]
        public async Task TranslateWithDictionaryTag()
        {
            string fromLanguage = "en";
            IEnumerable<string> targetLanguages = new[] { "es" };
            IEnumerable<string> inputText = new[] { "The word < mstrans:dictionary translation =\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry." };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, sourceLanguage: fromLanguage).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual("es", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text.Contains("wordomatic"));
        }

        [RecordedTest]
        public async Task TranslateWithDictionaryTagOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(targetLanguage: "es", content: "The word < mstrans:dictionary translation =\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry.")
            {
                SourceLanguage = "en"
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual("es", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text.Contains("wordomatic"));
        }

        [RecordedTest]
        public async Task TranslateWithTransliteration()
        {
            IEnumerable<string> targetLanguages = new[] { "zh-Hans" };
            IEnumerable<string> inputText = new[] { "hudha akhtabar." };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, sourceLanguage: "ar", fromScript: "Latn", toScript: "Latn").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);

            Assert.NotNull(response.Value.FirstOrDefault().SourceText.Text);
            Assert.AreEqual("zh-Hans", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithTransliterationOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(targetLanguage: "zh-Hans", content: "hudha akhtabar.")
            {
                SourceLanguage = "ar",
                FromScript = "Latn",
                ToScript = "Latn"
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);

            Assert.NotNull(response.Value.FirstOrDefault().SourceText.Text);
            Assert.AreEqual("zh-Hans", response.Value.FirstOrDefault().Translations.FirstOrDefault().To);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateFromLatinToLatinScript()
        {
            IEnumerable<string> targetLanguages = new[] { "ta" };
            IEnumerable<string> inputText = new[] { "ap kaise ho" };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, sourceLanguage: "hi", fromScript: "Latn", toScript: "Latn").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Transliteration);
            Assert.AreEqual("eppadi irukkiraai?", response.Value.FirstOrDefault().Translations.FirstOrDefault().Transliteration.Text);
        }

        [RecordedTest]
        public async Task TranslateFromLatinToLatinScriptOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "ta",
                content: "ap kaise ho")
            {
                SourceLanguage = "hi",
                FromScript = "Latn",
                ToScript = "Latn",
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Transliteration);
            Assert.AreEqual("eppadi irukkiraai?", response.Value.FirstOrDefault().Translations.FirstOrDefault().Transliteration.Text);
        }

        [RecordedTest]
        public async Task TranslateWithMultipleInputTexts()
        {
            IEnumerable<string> targetLanguages = new[] { "cs" };
            IEnumerable<string> inputText = new[]
            {
                "This is a test.",
                "Esto es una prueba.",
                "Dies ist ein Test."
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText).ConfigureAwait(false);

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
        public async Task TranslateWithMultipleInputTextsOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguages: new[] { "cs" },
                content: new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                }
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

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
            var response = await client.TranslateAsync(targetLanguages, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.Count);

            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);

            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.FirstOrDefault().Translations[1].Text);
            Assert.NotNull(response.Value.FirstOrDefault().Translations[2].Text);
        }

        [RecordedTest]
        public async Task TranslateMultipleTargetLanguagesOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguages: new[] { "cs", "es", "de" },
                content: new[] { "This is a test." }
            );
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.Count);

            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);

            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
            Assert.NotNull(response.Value.FirstOrDefault().Translations[1].Text);
            Assert.NotNull(response.Value.FirstOrDefault().Translations[2].Text);
        }

        [RecordedTest]
        public async Task TranslateDifferentTextTypes()
        {
            IEnumerable<string> targetLanguages = new[] { "cs" };
            IEnumerable<string> inputText = new[] { "<html><body>This <b>is</b> a test.</body></html>" };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, textType: TextType.Html).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);

            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
        }

        [RecordedTest]
        public async Task TranslateDifferentTextTypesOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguages: new[] { "cs" },
                content: new[] { "<html><body>This <b>is</b> a test.</body></html>" })
            {
                TextType = TextType.Html
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);

            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
        }

        [RecordedTest]
        public async Task TranslateWithProfanity()
        {
            ProfanityAction profanityAction = ProfanityAction.Marked;
            ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;
            IEnumerable<string> targetLanguages = new[] { "zh-cn" };
            IEnumerable<string> inputText = new[] { "shit this is fucking crazy" };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, profanityAction: profanityAction, profanityMarker: profanityMarkers).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text.Contains("***"));
        }

        [RecordedTest]
        public async Task TranslateWithProfanityOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "zh-cn",
                content: "shit this is fucking crazy")
            {
                ProfanityAction = ProfanityAction.Marked,
                ProfanityMarker = ProfanityMarker.Asterisk,
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.IsTrue(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text.Contains("***"));
        }

        [RecordedTest]
        public async Task TranslateWithAlignment()
        {
            bool includeAlignment = true;
            IEnumerable<string> targetLanguages = new[] { "cs" };
            IEnumerable<string> inputText = new[] { "It is a beautiful morning" };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, includeAlignment: includeAlignment).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Alignment.Proj);
        }

        public async Task TranslateWithAlignmentOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "cs",
                content: "It is a beautiful morning")
            {
                IncludeAlignment = true,
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Alignment.Proj);
        }

        [RecordedTest]
        public async Task TranslateWithIncludeSentenceLength()
        {
            bool includeSentenceLength = true;
            IEnumerable<string> targetLanguages = new[] { "fr" };
            IEnumerable<string> inputText = new[] { "La réponse se trouve dans la traduction automatique. La meilleure technologie de traduction automatique ne peut pas toujours fournir des traductions adaptées à un site ou des utilisateurs comme un être humain. Il suffit de copier et coller un extrait de code n'importe où." };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguages, inputText, includeSentenceLength: includeSentenceLength).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("fr", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.FirstOrDefault().SentLen.SrcSentLen.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.FirstOrDefault().SentLen.TransSentLen.Count);
        }

        [RecordedTest]
        public async Task TranslateWithIncludeSentenceLengthOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "fr",
                content: "La réponse se trouve dans la traduction automatique. La meilleure technologie de traduction automatique ne peut pas toujours fournir des traductions adaptées à un site ou des utilisateurs comme un être humain. Il suffit de copier et coller un extrait de code n'importe où.")
            {
                IncludeSentenceLength = true
            };
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("fr", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.FirstOrDefault().SentLen.SrcSentLen.Count);
            Assert.AreEqual(3, response.Value.FirstOrDefault().Translations.FirstOrDefault().SentLen.TransSentLen.Count);
        }

        [RecordedTest]
        public async Task TranslateWithCustomEndpoint()
        {
            IEnumerable<string> targetLanguages = new[] { "cs" };
            IEnumerable<string> inputText = new[] { "It is a beautiful morning" };
            TextTranslationClient client = GetClient(endpoint: new Uri(TestEnvironment.CustomEndpoint));
            var response = await client.TranslateAsync(targetLanguages, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("en", response.Value.FirstOrDefault().DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Score);
            Assert.AreEqual(1, response.Value.FirstOrDefault().Translations.Count);
            Assert.NotNull(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text);
        }

        [RecordedTest]
        public async Task TranslateWithCustomEndpointOptions()
        {
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "cs",
                content: "It is a beautiful morning"
            );
            TextTranslationClient client = GetClient(endpoint: new Uri(TestEnvironment.CustomEndpoint));
            var response = await client.TranslateAsync(options).ConfigureAwait(false);

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
            var translate = await client.TranslateAsync(new[] { "cs" }, inputText).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }

        [RecordedTest]
        public async Task TranslateWithTokenOptions()
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
            TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                targetLanguage: "cs",
                content: "This is a test."
            );
            var translate = await client.TranslateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }
    }
}
