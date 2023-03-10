// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Tests
{
    public partial class GetLanguagesLiveTests : TextTranslatorLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public GetLanguagesLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetLanguagesAllScopes()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.Greater(response.Value.Dictionary.Count, 0);
        }

        [RecordedTest]
        public async Task GetLanguagesTranslationScope()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(scope: "translation", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.IsTrue(response.Value.Translation.TryGetValue("af", out Models.TranslationLanguage translationLanguage));
            Assert.NotNull(translationLanguage.Dir);
            Assert.NotNull(translationLanguage.Name);
            Assert.NotNull(translationLanguage.NativeName);
        }

        [RecordedTest]
        public async Task GetLanguagesTransliterationScope()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.IsTrue(response.Value.Transliteration.TryGetValue("be", out Models.TransliterationLanguage transliterationLanguage));
            Assert.NotNull(transliterationLanguage.Name);
            Assert.NotNull(transliterationLanguage.NativeName);
            Assert.NotNull(transliterationLanguage.Scripts);

            Assert.Greater(transliterationLanguage.Scripts.Count, 0);
            Assert.NotNull(transliterationLanguage.Scripts[0].Code);
            Assert.NotNull(transliterationLanguage.Scripts[0].Dir);
            Assert.NotNull(transliterationLanguage.Scripts[0].Name);
            Assert.NotNull(transliterationLanguage.Scripts[0].NativeName);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts);

            Assert.Greater(transliterationLanguage.Scripts[0].ToScripts.Count, 0);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Code);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Dir);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Name);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].NativeName);
        }

        [RecordedTest]
        public async Task GetLanguagesTransliterationScopeMultipleScripts()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.IsTrue(response.Value.Transliteration.TryGetValue("zh-Hant", out Models.TransliterationLanguage transliterationLanguage));
            Assert.NotNull(transliterationLanguage.Name);
            Assert.NotNull(transliterationLanguage.NativeName);
            Assert.NotNull(transliterationLanguage.Scripts);

            Assert.Greater(transliterationLanguage.Scripts.Count, 1);
            Assert.Greater(transliterationLanguage.Scripts[0].ToScripts.Count, 1);
            Assert.Greater(transliterationLanguage.Scripts[1].ToScripts.Count, 1);
        }

        [RecordedTest]
        public async Task GetLanguagesDictionaryScope()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(scope: "dictionary", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Dictionary.Count, 0);
            Assert.IsTrue(response.Value.Dictionary.TryGetValue("de", out Models.SourceDictionaryLanguage dictionaryLanguage));
            Assert.NotNull(dictionaryLanguage.Dir);
            Assert.NotNull(dictionaryLanguage.Name);
            Assert.NotNull(dictionaryLanguage.NativeName);

            Assert.Greater(dictionaryLanguage.Translations.Count, 0);
            Assert.NotNull(dictionaryLanguage.Translations[0].Code);
            Assert.NotNull(dictionaryLanguage.Translations[0].Dir);
            Assert.NotNull(dictionaryLanguage.Translations[0].Name);
            Assert.NotNull(dictionaryLanguage.Translations[0].NativeName);
        }

        [RecordedTest]
        public async Task GetLanguagesDictionaryScopeMultipleTranslations()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(scope: "dictionary", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Dictionary.Count, 0);
            Assert.IsTrue(response.Value.Dictionary.TryGetValue("en", out Models.SourceDictionaryLanguage dictionaryLanguage));
            Assert.NotNull(dictionaryLanguage.Dir);
            Assert.NotNull(dictionaryLanguage.Name);
            Assert.NotNull(dictionaryLanguage.NativeName);
            Assert.Greater(dictionaryLanguage.Translations.Count, 1);
        }

        [RecordedTest]
        public async Task GetLanguagesWithCulture()
        {
            TextTranslationClient client = GetClient();
            Response<Models.GetLanguagesResult> response =
                await client.GetLanguagesAsync(acceptLanguage: "es", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.Greater(response.Value.Dictionary.Count, 0);
            Assert.IsTrue(response.Value.Translation.TryGetValue("en", out Models.TranslationLanguage language));
            Assert.NotNull(language.Dir);
            Assert.NotNull(language.Name);
            Assert.NotNull(language.NativeName);
        }
    }
}
