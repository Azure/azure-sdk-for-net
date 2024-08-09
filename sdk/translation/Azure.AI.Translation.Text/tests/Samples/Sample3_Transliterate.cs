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
    public partial class Sample3_Transliterate : Sample0_CreateClient
    {
        [Test]
        public void GetTransliteratedText()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTransliteratedText
            try
            {
                string language = "zh-Hans";
                string fromScript = "Hans";
                string toScript = "Latn";

                string inputText = "这是个测试。";

                Response<IReadOnlyList<TransliteratedText>> response = client.Transliterate(language, fromScript, toScript, inputText);
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
        public void GetTransliteratedTextOptions()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTransliteratedTextOptions
            try
            {
                TextTranslationTransliterateOptions options = new TextTranslationTransliterateOptions(
                    language: "zh-Hans",
                    fromScript: "Hans",
                    toScript: "Latn",
                    content: "这是个测试。"
                );

                Response<IReadOnlyList<TransliteratedText>> response = client.Transliterate(options);
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
    }
}
