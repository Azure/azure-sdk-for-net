// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextTranslator.Tests
{
    public partial class DictionaryLookupLiveTests : TextTranslatorLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DictionaryLookupLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DictionaryLookupSingleInputElement()
        {
            TranslatorClient client = GetClient();
            IEnumerable<InputText> inputText = new[]
            {
                new InputText { Text = "fly" }
            };
            Response<IReadOnlyList<Models.DictionaryLookupElement>> response =
                await client.DictionaryLookupAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("fly", response.Value[0].NormalizedSource);
            Assert.AreEqual("fly", response.Value[0].DisplaySource);
        }

        [RecordedTest]
        public async Task DictionaryLookupMultipleInputElements()
        {
            TranslatorClient client = GetClient();
            IEnumerable<InputText> inputText = new[]
            {
                new InputText { Text = "fly" },
                new InputText { Text = "fox" }
            };
            Response<IReadOnlyList<Models.DictionaryLookupElement>> response =
                await client.DictionaryLookupAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Count);
        }
    }
}
