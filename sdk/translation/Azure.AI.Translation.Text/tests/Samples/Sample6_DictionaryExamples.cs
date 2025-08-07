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
    public partial class Sample6_DictionaryExamples : Sample0_CreateClient
    {
        [Test]
        public void GetGrammaticalStructure()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetGrammaticalStructure
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                IEnumerable<InputTextWithTranslation> inputTextElements = new[]
                {
                    new InputTextWithTranslation("fly", "volar")
                };

                Response<IReadOnlyList<DictionaryExampleItem>> response = client.LookupDictionaryExamples(sourceLanguage, targetLanguage, inputTextElements);
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
    }
}
