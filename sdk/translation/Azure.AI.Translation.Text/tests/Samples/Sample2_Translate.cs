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
        public void GetTextTranslationBySource()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationBySource
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText, sourceLanguage);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
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
        public void GetTextTranslationLlm()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationLlm
            try
            {
                string targetLanguage = "cs";
                string llmModelname = "gpt-4o-mini";
                string inputText = "This is a test.";

                TranslationTarget target = new TranslationTarget(targetLanguage, deploymentName: llmModelname);
                TranslateInputItem input = new TranslateInputItem(inputText, target);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;

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
        public void GetMultipleTextTranslations()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetMultipleTextTranslations
            try
            {
                string targetLanguage = "cs";
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputTextElements);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

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
        public void GetTextTranslationMatrix()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationMatrix
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
                string inputText = "This is a test.";

                TranslateInputItem input = new TranslateInputItem(inputText, targetLanguages.Select(lang => new TranslationTarget(lang)));
                Response<TranslatedTextItem> response = client.Translate(input);
                IReadOnlyList<TranslationText> translations = response.Value.Translations;

                foreach (TranslationText translation in translations)
                {
                    Console.WriteLine($"Text was translated to: '{translation?.Language}' and the result is: '{translation?.Text}'.");
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
                string targetLanguage = "cs";
                string inputText = "<html><body>This <b>is</b> a test.</body></html>";

                TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), textType: TextType.Html);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
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
                string sourceLanguage = "en";
                string targetLanguage = "cs";
                string inputText = "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>";

                TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), language: sourceLanguage, textType: TextType.Html);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
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
                string sourceLanguage = "en";
                string targetLanguage = "cs";
                string inputText = "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry.";

                TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), language: sourceLanguage, textType: TextType.Html);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
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

                string targetLanguage = "cs";
                string inputText = "This is ***.";

                TranslationTarget target = new TranslationTarget(targetLanguage, profanityAction: profanityAction, profanityMarker: profanityMarkers);
                TranslateInputItem input = new TranslateInputItem(inputText, target);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
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
                string toLanguage = "zh-Hans";
                string inputText = "hudha akhtabar.";

                TranslationTarget target = new TranslationTarget(toLanguage, script: toScript);
                TranslateInputItem inputItem = new TranslateInputItem(inputText, target, language: fromLanguage, script: fromScript);

                Response<TranslatedTextItem> response = client.Translate(inputItem);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Translation: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Transliterated text ({translated.Language}): {translated.Text}");
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
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                TranslationTarget target = new TranslationTarget(targetLanguage, deploymentName: category, allowFallback: true);
                TranslateInputItem input = new TranslateInputItem(inputText, target);

                Response<TranslatedTextItem> response = client.Translate(input);
                TranslatedTextItem translation = response.Value;
                TranslationText translated = translation.Translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
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
