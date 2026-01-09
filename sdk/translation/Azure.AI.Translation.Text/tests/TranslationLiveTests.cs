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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.FirstOrDefault().Translations.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Language, Is.EqualTo(targetLanguage));
                Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text, Is.Not.Null);
            });
        }

        [RecordedTest]
        public async Task TranslateWithAutoDetect()
        {
            string targetLanguage = "cs";
            string inputText = "This is a test.";
            TextTranslationClient client = GetClient();
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.FirstOrDefault().DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.FirstOrDefault().DetectedLanguage.Score));
                Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Language, Is.EqualTo(targetLanguage));
                Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Count, Is.EqualTo(3));
            });

            Assert.Multiple(() =>
            {
                Assert.That(response.Value.FirstOrDefault().DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(response.Value[1].DetectedLanguage.Language, Is.EqualTo("es"));
                Assert.That(response.Value[2].DetectedLanguage.Language, Is.EqualTo("de"));

                Assert.That(response.Value.FirstOrDefault().DetectedLanguage.Score, Is.EqualTo(1));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.FirstOrDefault().DetectedLanguage.Score));
            });
            Assert.Multiple(() =>
            {
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.FirstOrDefault().DetectedLanguage.Score));

                Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text, Is.Not.Null);
                Assert.That(response.Value[1].Translations.FirstOrDefault().Text, Is.Not.Null);
                Assert.That(response.Value[2].Translations.FirstOrDefault().Text, Is.Not.Null);
            });
        }

        [RecordedTest]
        public async Task TranslateMultipleTargetLanguages()
        {
            IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
            IEnumerable<string> inputText = new[] { "This is a test." };
            TextTranslationClient client = GetClient();
            TranslateInputItem input = new TranslateInputItem("This is a test.", targetLanguages.Select(lang => new TranslationTarget(lang)));
            var response = await client.TranslateAsync(input).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Translations.Count, Is.EqualTo(3));

                Assert.That(response.Value.DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.DetectedLanguage.Score));

                Assert.That(response.Value.Translations.FirstOrDefault().Text, Is.Not.Null);
                Assert.That(response.Value.Translations[1].Text, Is.Not.Null);
                Assert.That(response.Value.Translations[2].Text, Is.Not.Null);
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.That(response.Value.Translations.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Translations.FirstOrDefault().Language, Is.EqualTo(targetLanguage));
                Assert.That(response.Value.Translations.FirstOrDefault().Text, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Translations.Count, Is.EqualTo(1));

                Assert.That(response.Value.DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.DetectedLanguage.Score));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.DetectedLanguage.Score));
                Assert.That(response.Value.Translations.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.Translations.FirstOrDefault().Text, Does.Contain("***"));
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.That(response.Value.Translations.Count, Is.EqualTo(1));
            Assert.That(response.Value.Translations.First().Text, Does.Contain("今天是怎么回事是"));
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });
            Assert.That(response.Value.Translations.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Translations.FirstOrDefault().Language, Is.EqualTo("es"));
                Assert.That(response.Value.Translations.FirstOrDefault().Text, Does.Contain("wordomatic"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Translations.FirstOrDefault().Language, Is.EqualTo("zh-Hans"));
                Assert.That(response.Value.Translations.FirstOrDefault().Text, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Count, Is.EqualTo(3));
            });
            Assert.That(response.Value[0].Translations.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0].Translations[0].Language, Is.EqualTo("es"));
                Assert.That(response.Value[0].Translations[0].Text, Is.Not.Null);
                Assert.That(response.Value[0].Translations[1].Language, Is.EqualTo("de"));
                Assert.That(response.Value[0].Translations[1].Text, Is.Not.Null);
                Assert.That(response.Value[1].Translations.Count, Is.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[1].Translations[0].Language, Is.EqualTo("en"));
                Assert.That(response.Value[1].Translations[0].Text, Is.Not.Null);
                Assert.That(response.Value[1].Translations[1].Language, Is.EqualTo("zh-Hans"));
                Assert.That(response.Value[1].Translations[1].Text, Is.Not.Null);
                Assert.That(response.Value[2].Translations.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[2].Translations[0].Language, Is.EqualTo("zh-Hant"));
                Assert.That(response.Value[2].Translations[0].Text, Does.Contain("html"));
            });
        }

        [RecordedTest]
        public async Task TranslateWithCustomEndpoint()
        {
            string targetLanguage = "cs";
            string inputText = "It is a beautiful morning";
            TextTranslationClient client = GetClient(endpoint: new Uri(TestEnvironment.CustomEndpoint));
            var response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.FirstOrDefault().DetectedLanguage.Language, Is.EqualTo("en"));
                Assert.That(0.5, Is.LessThanOrEqualTo(response.Value.FirstOrDefault().DetectedLanguage.Score));
                Assert.That(response.Value.FirstOrDefault().Translations.Count, Is.EqualTo(1));
            });
            Assert.That(response.Value.FirstOrDefault().Translations.FirstOrDefault().Text, Is.Not.Null);
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

            Assert.Multiple(() =>
            {
                Assert.That(translate.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(translate.Value.Count, Is.EqualTo(1));
            });
        }
    }
}
