﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Tests
{
    public partial class DictionaryExamplesLiveTests : TextTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DictionaryExamplesLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DictionaryExamplesSingleInputElement()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<InputTextWithTranslation> inputText = new[]
            {
                new InputTextWithTranslation("fly", "volar")
            };
            var response = await client.LookupDictionaryExamplesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("fly", response.Value[0].NormalizedSource);
            Assert.AreEqual("volar", response.Value[0].NormalizedTarget);
        }

        [RecordedTest]
        public async Task DictionaryExamplesMultipleInputElements()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<InputTextWithTranslation> inputText = new[]
            {
                new InputTextWithTranslation("fly", "volar"),
                new InputTextWithTranslation("beef", "came")
            };
            var response = await client.LookupDictionaryExamplesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Count);
        }
    }
}
