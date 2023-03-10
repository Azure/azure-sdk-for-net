// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextTranslator.Tests
{
    public partial class DictionaryExamplesLiveTests : TextTranslatorLiveTestBase
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
            TranslatorClient client = GetClient();
            IEnumerable<InputTextWithTranslation> inputText = new[]
            {
                new InputTextWithTranslation { Text = "fly", Translation = "volar" }
            };
            Response<IReadOnlyList<Models.DictionaryExampleElement>> response =
                await client.DictionaryExamplesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("fly", response.Value[0].NormalizedSource);
            Assert.AreEqual("volar", response.Value[0].NormalizedTarget);
        }

        [RecordedTest]
        public async Task DictionaryExamplesMultipleInputElements()
        {
            TranslatorClient client = GetClient();
            IEnumerable<InputTextWithTranslation> inputText = new[]
            {
                new InputTextWithTranslation { Text = "fly", Translation = "volar" },
                new InputTextWithTranslation { Text = "beef", Translation = "came" }
            };
            Response<IReadOnlyList<Models.DictionaryExampleElement>> response =
                await client.DictionaryExamplesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Count);
        }
    }
}
