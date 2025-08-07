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
    public partial class Sample5_DictionaryLookup : Sample0_CreateClient
    {
        [Test]
        public void LookupDictionaryEntries()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:LookupDictionaryEntries
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                string inputText = "fly";

                Response<IReadOnlyList<DictionaryLookupItem>> response = client.LookupDictionaryEntries(sourceLanguage, targetLanguage, inputText);
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
    }
}
