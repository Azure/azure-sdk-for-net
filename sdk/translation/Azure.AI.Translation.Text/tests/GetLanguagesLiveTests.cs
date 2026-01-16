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

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Translation.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Transliteration.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Models.Count, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTranslationScope()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "translation", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Translation.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Translation.TryGetValue("af", out TranslationLanguage translationLanguage), Is.True);
            Assert.That(translationLanguage.Directionality, Is.Not.Null);
            Assert.That(translationLanguage.Name, Is.Not.Null);
            Assert.That(translationLanguage.NativeName, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTransliterationScope()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Transliteration.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Transliteration.TryGetValue("be", out TransliterationLanguage transliterationLanguage), Is.True);
            Assert.That(transliterationLanguage.Name, Is.Not.Null);
            Assert.That(transliterationLanguage.NativeName, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts, Is.Not.Null);

            Assert.That(transliterationLanguage.Scripts.Count, Is.GreaterThan(0));
            Assert.That(transliterationLanguage.Scripts[0].Code, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].Directionality, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].Name, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].NativeName, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].ToScripts, Is.Not.Null);

            Assert.That(transliterationLanguage.Scripts[0].ToScripts.Count, Is.GreaterThan(0));
            Assert.That(transliterationLanguage.Scripts[0].ToScripts[0].Code, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].ToScripts[0].Directionality, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].ToScripts[0].Name, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts[0].ToScripts[0].NativeName, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesTransliterationScopeMultipleScripts()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(scope: "transliteration", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Transliteration.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Transliteration.TryGetValue("zh-Hant", out TransliterationLanguage transliterationLanguage), Is.True);
            Assert.That(transliterationLanguage.Name, Is.Not.Null);
            Assert.That(transliterationLanguage.NativeName, Is.Not.Null);
            Assert.That(transliterationLanguage.Scripts, Is.Not.Null);

            Assert.That(transliterationLanguage.Scripts.Count, Is.GreaterThan(1));
            Assert.That(transliterationLanguage.Scripts[0].ToScripts.Count, Is.GreaterThan(1));
            Assert.That(transliterationLanguage.Scripts[1].ToScripts.Count, Is.GreaterThan(1));
        }

        [RecordedTest]
        public async Task GetSupportedLanguagesWithCulture()
        {
            TextTranslationClient client = GetClient();
            Response<GetSupportedLanguagesResult> response =
                await client.GetSupportedLanguagesAsync(acceptLanguage: "es", cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Translation.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Transliteration.Count, Is.GreaterThan(0));
            Assert.That(response.Value.Translation.TryGetValue("en", out TranslationLanguage language), Is.True);
            Assert.That(language.Directionality, Is.Not.Null);
            Assert.That(language.Name, Is.Not.Null);
            Assert.That(language.NativeName, Is.Not.Null);
        }
    }
}
