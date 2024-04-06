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
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithKey()
        {
            #region Snippet:CreateTextTranslationClientWithKey

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;

#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey));
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithRegion()
        {
            #region Snippet:CreateTextTranslationClientWithRegion

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
            string region = "<Text Translator Azure Region>";
#else
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), region);
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithEndpoint()
        {
            #region Snippet:CreateTextTranslationClientWithEndpoint

#if SNIPPET
            string endpoint = "<Text Translator Resource Endpoint>";
            string apiKey = "<Text Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint));
            #endregion

            return client;
        }

        public class CustomTokenCredential : TokenCredential
        {
            public CustomTokenCredential(AzureKeyCredential azureKeyCredential): base()
            {
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithToken()
        {
            #region Snippet:CreateTextTranslationClientWithToken

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;
#endif
            TokenCredential credential = new CustomTokenCredential(new AzureKeyCredential(apiKey));
            TextTranslationClient client = new(credential);

            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithAad()
        {
            #region Snippet:CreateTextTranslationClientWithAad

#if SNIPPET
            string endpoint = "<Text Translator Custom Endpoint>";
#else
            string endpoint = TestEnvironment.CustomEndpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextTranslationClient client = new TextTranslationClient(credential, new Uri(endpoint));

            #endregion

            return client;
        }

        [Test]
        public void GetTextTranslationLanguages()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguages
            try
            {
                Response<GetLanguagesResult> response = client.GetLanguages(cancellationToken: CancellationToken.None);
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
        public async void GetTextTranslationLanguagesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void GetTextTranslationLanguagesMetadata()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesMetadata
            try
            {
                Response<GetLanguagesResult> response = client.GetLanguages();
                GetLanguagesResult languages = response.Value;

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
        public async void GetTextTranslationLanguagesMetadataAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync().ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

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
        }

        [Test]
        public void GetTextTranslationLanguagesByScope()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesByScope
            try
            {
                string scope = "translation";
                Response<GetLanguagesResult> response = client.GetLanguages(scope: scope);
                GetLanguagesResult languages = response.Value;

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
        public async void GetTextTranslationLanguagesByScopeAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string scope = "translation";
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(scope: scope).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

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
        }

        [Test]
        public void GetTextTranslationLanguagesByCulture()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesByCulture
            try
            {
                string acceptLanguage = "es";
                Response<GetLanguagesResult> response = client.GetLanguages(acceptLanguage: acceptLanguage);
                GetLanguagesResult languages = response.Value;

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
        public async void GetTextTranslationLanguagesByCultureAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string acceptLanguage = "es";
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(acceptLanguage: acceptLanguage).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

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
        }

        [Test]
        public void GetTextTranslation()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslation
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText);
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
        public void GetTextTranslationOptions()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                TextTranslationTranslateOptions options = new TextTranslationTranslateOptions(
                    targetLanguage: "cs",
                    content: "This is a test."
                );

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(options);
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
        }

        [Test]
        public async void GetTextTranslationAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void GetTextTranslationBySource()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationBySource
            try
            {
                string from = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText, sourceLanguage: from);
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
        public async void GetTextTranslationBySourceAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string from = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText, sourceLanguage: from).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationAutoDetect()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAutoDetect
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText);
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
        public async void GetTextTranslationAutoDetectAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void GetMultipleTextTranslations()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
            TextTranslationClient client = CreateTextTranslationClient();

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
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
        public async void GetMultipleTextTranslationsAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void GetTextTranslationMatrix()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationMatrix
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
            TextTranslationClient client = CreateTextTranslationClient();

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
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
        public async void GetTextTranslationMatrixAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void GetTextTranslationFormat()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFormat
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<html><body>This <b>is</b> a test.</body></html>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, textType: TextType.Html);
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
        public async void GetTextTranslationFormatAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<html><body>This <b>is</b> a test.</body></html>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, textType: TextType.Html).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationFilter()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFilter
            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response =client.Translate(targetLanguages, inputTextElements, textType: TextType.Html, sourceLanguage: from);
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
        public async void GetTextTranslationFilterAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, textType: TextType.Html, sourceLanguage: from).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationMarkup()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationMarkup
            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry."
            };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, sourceLanguage: from);
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
        public async void GetTextTranslationMarkupAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry."
            };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, sourceLanguage: from).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationProfanity()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationProfanity
            try
            {
                ProfanityAction profanityAction = ProfanityAction.Marked;
                ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is ***."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, profanityAction: profanityAction, profanityMarker: profanityMarkers);
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
        public async void GetTextTranslationProfanityAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                ProfanityAction profanityAction = ProfanityAction.Marked;
                ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is ***."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, profanityAction: profanityAction, profanityMarker: profanityMarkers).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationAlignment()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAlignment
            try
            {
                bool includeAlignment = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, includeAlignment: includeAlignment);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Alignments: {translation?.Translations?.FirstOrDefault()?.Alignment?.Proj}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationAlignmentAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                bool includeAlignment = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, includeAlignment: includeAlignment).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Alignments: {translation?.Translations?.FirstOrDefault()?.Alignment?.Proj}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void GetTextTranslationSentences()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentences
            try
            {
                bool includeSentenceLength = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation. This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, includeSentenceLength: includeSentenceLength);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Source Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.SrcSentLen)}");
                Console.WriteLine($"Translated Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.TransSentLen)}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationSentencesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                bool includeSentenceLength = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation. This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, includeSentenceLength: includeSentenceLength).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Source Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.SrcSentLen)}");
                Console.WriteLine($"Translated Sentence length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.TransSentLen)}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void GetTextTranslationFallback()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFallback
            try
            {
                string category = "<<Category ID>>";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, category: category);
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
        public async void GetTextTranslationFallbackAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string category = "<<Category ID>>";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, category: category).ConfigureAwait(false);
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
        }

        [Test]
        public void GetTextTranslationSentencesSource()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentencesSource
            try
            {
                string sourceLanguage = "zh-Hans";
                string sourceScript = "Latn";
                IEnumerable<string> inputTextElements = new[]
                {
                    "zhè shì gè cè shì。"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = client.FindSentenceBoundaries(inputTextElements, language: sourceLanguage, script: sourceScript);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationSentencesSourceAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        public void GetTextTranslationSentencesAuto()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentencesAuto
            try
            {
                IEnumerable<string> inputTextElements = new[]
                {
                    "How are you? I am fine. What did you do today?"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = client.FindSentenceBoundaries(inputTextElements);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        public async void GetTextTranslationSentencesAutoAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                IEnumerable<string> inputTextElements = new[]
                {
                    "How are you? I am fine. What did you do today?"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void GetTransliteratedText()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
            TextTranslationClient client = CreateTextTranslationClient();

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

        [Test]
        public async void GetTransliteratedTextAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void GetTranslationTextTransliterated()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTranslationTextTransliterated
            try
            {
                string fromScript = "Latn";
                string fromLanguage = "ar";
                string toScript = "Latn";
                IEnumerable<string> targetLanguages = new[] { "zh-Hans" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "hudha akhtabar."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguages, inputTextElements, sourceLanguage: fromLanguage, fromScript: fromScript, toScript: toScript);
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
            TextTranslationClient client = CreateTextTranslationClient();

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

        [Test]
        public async void GetTranslationTextTransliteratedAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                string fromScript = "Latn";
                string fromLanguage = "ar";
                string toScript = "Latn";
                IEnumerable<string> targetLanguages = new[] { "zh-Hans" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "hudha akhtabar."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, sourceLanguage: fromLanguage, fromScript: fromScript, toScript: toScript).ConfigureAwait(false);
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
        }

        [Test]
        public void FindTextSentenceSentenceBoundaries()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:FindTextSentenceBoundaries
            try
            {
                string inputText = "How are you? I am fine. What did you do today?";

                Response<IReadOnlyList<BreakSentenceItem>> response = client.FindSentenceBoundaries(inputText);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
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

            try
            {
                string inputText = "How are you? I am fine. What did you do today?";

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputText).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }

        [Test]
        public void LookupDictionaryEntries()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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

        [Test]
        public async void LookupDictionaryEntriesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void GetGrammaticalStructure()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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

        [Test]
        public async void GetGrammaticalStructureAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

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
        }

        [Test]
        public void HandleBadRequest()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:HandleBadRequest
            try
            {
                var translation = client.Translate(Array.Empty<string>(), new[] { "This is a Test" });
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        public async void HandleBadRequestAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            try
            {
                var translation = await client.TranslateAsync(Array.Empty<string>(), new[] { "This is a Test" }).ConfigureAwait(false);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
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
