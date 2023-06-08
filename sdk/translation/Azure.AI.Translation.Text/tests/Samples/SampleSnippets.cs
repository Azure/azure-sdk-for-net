// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.AI.Translation.Text.Tests;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class SampleSnippets : SamplesBase<TextTranslationTestEnvironment>
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
            var client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
            #endregion

            return client;
        }

        [Test]
        public async void GetTextTranslationLanguagesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();
            #region Snippet:GetTextTranslationLanguagesAsync
            try
            {
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAsync
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTransliteratedTextAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTransliteratedTextAsync
            try
            {
                string language = "zh-Hans";
                string fromScript = "Hans";
                string toScript = "Latn";

                string inputText = "这是个测试。";

                Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync(language, fromScript, toScript, inputText).ConfigureAwait(false);
                IReadOnlyList<TransliteratedText> transliterations = response.Value;
                TransliteratedText transliteration = transliterations.FirstOrDefault();

                Console.WriteLine($"Input text was transliterated to '{transliteration?.Script}' script. Transliterated text: '{transliteration?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void FindTextSentenceSentenceBoundariesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:FindTextSentenceBoundariesAsync
            try
            {
                string inputText = "How are you? I am fine. What did you do today?";

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputText).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void LookupDictionaryEntriesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:LookupDictionaryEntriesAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                string inputText = "fly";

                Response<IReadOnlyList<DictionaryLookupItem>> response = await client.LookupDictionaryEntriesAsync(sourceLanguage, targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<DictionaryLookupItem> dictionaryEntries = response.Value;
                DictionaryLookupItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

                Console.WriteLine($"For the given input {dictionaryEntry?.Translations?.Count} entries were found in the dictionary.");
                Console.WriteLine($"First entry: '{dictionaryEntry?.Translations?.FirstOrDefault()?.DisplayTarget}', confidence: {dictionaryEntry?.Translations?.FirstOrDefault()?.Confidence}.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetGrammaticalStructureAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetGrammaticalStructureAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                IEnumerable<InputTextWithTranslation> inputTextElements = new[]
                {
                    new InputTextWithTranslation("fly", "volar")
                };

                Response<IReadOnlyList<DictionaryExampleItem>> response = await client.LookupDictionaryExamplesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<DictionaryExampleItem> dictionaryEntries = response.Value;
                DictionaryExampleItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

                Console.WriteLine($"For the given input {dictionaryEntry?.Examples?.Count} examples were found in the dictionary.");
                DictionaryExample firstExample = dictionaryEntry?.Examples?.FirstOrDefault();
                Console.WriteLine($"Example: '{string.Concat(firstExample.TargetPrefix, firstExample.TargetTerm, firstExample.TargetSuffix)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void HandleBadRequestAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:HandleBadRequestAsync
            try
            {
                var translation = await client.TranslateAsync(Array.Empty<string>(), new[] { "This is a Test" }).ConfigureAwait(false);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
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
