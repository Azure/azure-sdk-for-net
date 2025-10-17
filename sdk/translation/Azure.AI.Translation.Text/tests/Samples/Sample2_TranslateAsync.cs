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
    public partial class Sample2_TranslateAsync : Sample0_CreateClient
    {
        [Test]
        public async Task GetTextTranslationBySourceAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationBySourceAsync
            try
            {
                string from = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<TranslationResult> response = await client.TranslateAsync(targetLanguage, inputText, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationAutoDetectAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationAutoDetectAsync
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<TranslationResult> response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationLlmAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationLlmAsync
            try
            {
                string targetLanguage = "cs";
                string llmModelname = "gpt-4o-mini";
                string inputText = "This is a test.";

                TranslateTarget target = new TranslateTarget(targetLanguage);
                target.DeploymentName = llmModelname;
                TranslateInputItem input = new TranslateInputItem(inputText, [target]);

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationMatrixAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMatrixAsync
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
                string inputText = "This is a test.";

                TranslateInputItem input = new TranslateInputItem(inputText, targetLanguages.Select(lang => new TranslateTarget(lang)));

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationFormatAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFormatAsync
            try
            {
                string targetLanguage = "cs";
                string inputText = "<html><body>This <b>is</b> a test.</body></html>";

                TranslateInputItem input = new TranslateInputItem(inputText, [new TranslateTarget(targetLanguage)]);
                input.TextType = TextType.Html;

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationFilterAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFilterAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "cs";
                string inputText = "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>";

                TranslateInputItem input = new TranslateInputItem(inputText, [new TranslateTarget(targetLanguage)]);
                input.Language = sourceLanguage;
                input.TextType = TextType.Html;

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationMarkupAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMarkupAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "cs";
                string inputText = "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry.";

                TranslateInputItem input = new TranslateInputItem(inputText, [new TranslateTarget(targetLanguage)]);
                input.Language = sourceLanguage;
                input.TextType = TextType.Html;

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationProfanityAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationProfanityAsync
            try
            {
                ProfanityAction profanityAction = ProfanityAction.Marked;
                ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

                string targetLanguage = "cs";
                string inputText = "This is ***.";

                TranslateTarget target = new TranslateTarget(targetLanguage)
                {
                    ProfanityAction = profanityAction,
                    ProfanityMarker = profanityMarkers
                };
                TranslateInputItem input = new TranslateInputItem(inputText, [target]);

                Response<TranslationResult> response = await client.TranslateAsync([input]).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }
    }
}
