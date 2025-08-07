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
    public partial class Sample2_Translate : Sample0_CreateClient
    {
        [Test]
        public void GetTextTranslation()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslation
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText);
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
        public void GetTextTranslationOptions()
        {
            TextTranslationClient client = CreateClient();

            try
            {
                TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                    targetLanguage: "cs",
                    content: "This is a test."
                );

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(options);
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
        }

        [Test]
        public void GetTextTranslationBySource()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationBySource
            try
            {
                string from = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText, sourceLanguage: from);
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
        public void GetTextTranslationAutoDetect()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationAutoDetect
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText);
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
        public void GetMultipleTextTranslations()
        {
            TextTranslationClient client = CreateClient();

            try
            {
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements);
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
        }

        [Test]
        public void GetMultipleTextTranslationsOptions()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetMultipleTextTranslationsOptions
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

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(options);
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
        public void GetTextTranslationMatrix()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMatrix
            try
            {
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs", "es", "de" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements);
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
        public void GetTextTranslationMatrixOptions()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMatrixOptions
            try
            {
                TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                    targetLanguages: new[] { "cs", "es", "de" },
                    content: new[] { "This is a test." }
                );

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(options);
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
        public void GetTextTranslationFormat()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFormat
            try
            {
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<html><body>This <b>is</b> a test.</body></html>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, textType: TextType.Html);
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
        public void GetTextTranslationFilter()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFilter
            try
            {
                string from = "en";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, textType: TextType.Html, sourceLanguage: from);
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
        public void GetTextTranslationMarkup()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMarkup
            try
            {
                string from = "en";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry."
            };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, sourceLanguage: from);
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
        public void GetTextTranslationProfanity()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationProfanity
            try
            {
                ProfanityAction profanityAction = ProfanityAction.Marked;
                ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is ***."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, profanityAction: profanityAction, profanityMarker: profanityMarkers);
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
        public void GetTextTranslationAlignment()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationAlignment
            try
            {
                bool includeAlignment = true;

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, includeAlignment: includeAlignment);
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
        public void GetTextTranslationSentences()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationSentences
            try
            {
                bool includeSentenceLength = true;

                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation. This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, includeSentenceLength: includeSentenceLength);
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
        public void GetTextTranslationFallback()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationFallback
            try
            {
                string category = "<<Category ID>>";
                IEnumerable<string> tarGetSupportedLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, category: category);
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
        public void GetTranslationTextTransliterated()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTranslationTextTransliterated
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

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(tarGetSupportedLanguages, inputTextElements, sourceLanguage: fromLanguage, fromScript: fromScript, toScript: toScript);
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
        public void GetTranslationTextTransliteratedOptions()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTranslationTextTransliteratedOptions
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

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(options);
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
