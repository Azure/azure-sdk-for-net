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

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetMultipleTextTranslationsOptionsAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetMultipleTextTranslationsOptionsAsync
            try
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

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(options).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
        public async Task GetTextTranslationMatrixAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMatrixAsync
            try
            {
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs", "es", "de" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<html><body>This <b>is</b> a test.</body></html>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, textType: TextType.Html).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
                string from = "en";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, textType: TextType.Html, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
                string from = "en";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry."
            };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is ***."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, profanityAction: profanityAction, profanityMarker: profanityMarkers).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationAlignmentAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationAlignmentAsync
            try
            {
                bool includeAlignment = true;

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, includeAlignment: includeAlignment).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Alignments: {translation?.Translations?.FirstOrDefault()?.Alignment?.Projections}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationSentencesAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationSentencesAsync
            try
            {
                bool includeSentenceLength = true;

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation. This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, includeSentenceLength: includeSentenceLength).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with confidence: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Source Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentenceBoundaries?.SourceSentencesLengths)}");
                Console.WriteLine($"Translated Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentenceBoundaries?.TranslatedSentencesLengths)}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationFallbackAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFallbackAsync
            try
            {
                string category = "<<Category ID>>";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, category: category).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().TargetLanguage}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTranslationTextTransliteratedAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTranslationTextTransliteratedAsync
            try
            {
                string fromScript = "Latn";
                string fromLanguage = "ar";
                string toScript = "Latn";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "zh-Hans" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "hudha akhtabar."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(tarGetSupportedLanguages, inputTextElements, sourceLanguage: fromLanguage, fromScript: fromScript, toScript: toScript).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Source Text: {translation.SourceText.Text}");
                Console.WriteLine($"Translation: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Transliterated text ({translation?.Translations?.FirstOrDefault()?.Transliteration?.Script}): {translation?.Translations?.FirstOrDefault()?.Transliteration?.Text}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTranslationTextTransliteratedOptionsAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTranslationTextTransliteratedOptionsAsync
            try
            {
                TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                    targetLanguage: "zh-Hans",
                    content: "hudha akhtabar.")
                {
                    FromScript = "Latn",
                    SourceLanguage = "ar",
                    ToScript = "Latn"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(options).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Source Text: {translation.SourceText.Text}");
                Console.WriteLine($"Translation: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Transliterated text ({translation?.Translations?.FirstOrDefault()?.Transliteration?.Script}): {translation?.Translations?.FirstOrDefault()?.Transliteration?.Text}");
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
