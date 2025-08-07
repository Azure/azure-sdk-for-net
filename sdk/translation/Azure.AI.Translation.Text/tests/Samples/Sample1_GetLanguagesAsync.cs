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
    public partial class Sample1_GetLanguagesAsync : Sample0_CreateClient
    {
        [Test]
        public async Task GetTextTranslationLanguagesMetadataAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationLanguagesMetadataAsync
            try
            {
                Response<GetSupportedLanguagesResult> response = await client.GetSupportedLanguagesAsync().ConfigureAwait(false);
                GetSupportedLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operation: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for transliterate operation: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for dictionary operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
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
        public async Task GetTextTranslationLanguagesByScopeAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationLanguagesByScopeAsync
            try
            {
                string scope = "translation";
                Response<GetSupportedLanguagesResult> response = await client.GetSupportedLanguagesAsync(scope: scope).ConfigureAwait(false);
                GetSupportedLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
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
        public async Task GetTextTranslationLanguagesByCultureAsync()
        {
            TextTranslationClient client = CreateClient();

            #region Snippet:GetTextTranslationLanguagesByCultureAsync
            try
            {
                string acceptLanguage = "es";
                Response<GetSupportedLanguagesResult> response = await client.GetSupportedLanguagesAsync(acceptLanguage: acceptLanguage).ConfigureAwait(false);
                GetSupportedLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
                }
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
