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
    public partial class Sample4_BreakSentenceAsync : Sample0_CreateClient
    {
        [Test]
        public async Task GetTextTranslationSentencesSourceAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationSentencesSourceAsync
            try
            {
                string sourceLanguage = "zh-Hans";
                string sourceScript = "Latn";
                IEnumerable<string> inputTextElements = new[]
                {
                    "zhè shì gè cè shì。"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements, language: sourceLanguage, script: sourceScript).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentencesLengths)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async Task GetTextTranslationSentencesAutoAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationSentencesAutoAsync
            try
            {
                IEnumerable<string> inputTextElements = new[]
                {
                    "How are you? I am fine. What did you do today?"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Confidence}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentencesLengths)}'.");
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
