﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Tests
{
    public partial class DictionaryLookupLiveTests : TextTranslationLiveTestBase
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
            TextTranslationClient client = GetClient();
            string inputText = "fly";
            var response = await client.LookupDictionaryEntriesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("fly", response.Value[0].NormalizedSource);
            Assert.AreEqual("fly", response.Value[0].DisplaySource);
        }

        [RecordedTest]
        public async Task DictionaryLookupMultipleInputElements()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "fly",
                "fox"
            };
            var response = await client.LookupDictionaryEntriesAsync("en", "es", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Count);
        }
    }
}
