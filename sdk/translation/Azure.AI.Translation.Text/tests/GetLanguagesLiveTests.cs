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
    public partial class GetSupportedLanguagesLiveTests : TextTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public GetSupportedLanguagesLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesAllScopes()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync().ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.Greater(response.Value.Models.Count, 0);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTranslationScope()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "translation", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.IsTrue(response.Value.Translation.TryGetValue("af", out TranslationLanguage translationLanguage));
            Assert.NotNull(translationLanguage.Directionality);
            Assert.NotNull(translationLanguage.Name);
            Assert.NotNull(translationLanguage.NativeName);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTransliterationScope()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.IsTrue(response.Value.Transliteration.TryGetValue("be", out TransliterationLanguage transliterationLanguage));
            Assert.NotNull(transliterationLanguage.Name);
            Assert.NotNull(transliterationLanguage.NativeName);
            Assert.NotNull(transliterationLanguage.Scripts);

            Assert.Greater(transliterationLanguage.Scripts.Count, 0);
            Assert.NotNull(transliterationLanguage.Scripts[0].Code);
            Assert.NotNull(transliterationLanguage.Scripts[0].Directionality);
            Assert.NotNull(transliterationLanguage.Scripts[0].Name);
            Assert.NotNull(transliterationLanguage.Scripts[0].NativeName);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts);

            Assert.Greater(transliterationLanguage.Scripts[0].ToScripts.Count, 0);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Code);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Directionality);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].Name);
            Assert.NotNull(transliterationLanguage.Scripts[0].ToScripts[0].NativeName);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTransliterationScopeMultipleScripts()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.IsTrue(response.Value.Transliteration.TryGetValue("zh-Hant", out TransliterationLanguage transliterationLanguage));
            Assert.NotNull(transliterationLanguage.Name);
            Assert.NotNull(transliterationLanguage.NativeName);
            Assert.NotNull(transliterationLanguage.Scripts);

            Assert.Greater(transliterationLanguage.Scripts.Count, 1);
            Assert.Greater(transliterationLanguage.Scripts[0].ToScripts.Count, 1);
            Assert.Greater(transliterationLanguage.Scripts[1].ToScripts.Count, 1);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesWithCulture()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(acceptLanguage: "es", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.Greater(response.Value.Translation.Count, 0);
            Assert.Greater(response.Value.Transliteration.Count, 0);
            Assert.IsTrue(response.Value.Translation.TryGetValue("en", out TranslationLanguage language));
            Assert.NotNull(language.Directionality);
            Assert.NotNull(language.Name);
            Assert.NotNull(language.NativeName);
        }
    }
}
