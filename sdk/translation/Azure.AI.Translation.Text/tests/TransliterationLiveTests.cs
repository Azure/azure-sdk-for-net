// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public partial class TransliterationLiveTests : TextTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TransliterationLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task VerifyTransliterationTest()
        {
            TextTranslationClient client = GetClient();
            string inputText = "这里怎么一回事?";
            Response<IReadOnlyList<TransliteratedText>> response =
                await client.TransliterateAsync("zh-Hans", "Hans", "Latn", inputText).ConfigureAwait(false);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [RecordedTest]
        public async Task VerifyTransliterationTestOptions()
        {
            TextTranslationClient client = GetClient();
            TextTranslationTransliterateOptions options = new TextTranslationTransliterateOptions(
                language: "zh-Hans",
                fromScript: "Hans",
                toScript: "Latn",
                content: new[] { "这里怎么一回事?" }
            );
            Response<IReadOnlyList<TransliteratedText>> response =
                await client.TransliterateAsync(options).ConfigureAwait(false);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [RecordedTest]
        public async Task VerifyTransliterationWithMultipleTextArray()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "यहएककसौटीहैयहएककसौटीहै",
                "यहएककसौटीहै"
            };
            Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync("hi", "Deva", "Latn", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[0].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[1].Text));
        }

        [RecordedTest]
        public async Task VerifyTransliterationWithMultipleTextArrayOptions()
        {
            TextTranslationClient client = GetClient();
            TextTranslationTransliterateOptions options = new TextTranslationTransliterateOptions(
                language: "hi",
                fromScript: "Deva",
                toScript: "Latn",
                content: new[]
                {
                    "यहएककसौटीहैयहएककसौटीहै",
                    "यहएककसौटीहै"
                }
            );
            Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[0].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[1].Text));
        }

        [RecordedTest]
        public async Task VerifyTransliterationWithEditDistance()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "gujarat",
                "hadman",
                "hukkabar"
            };
            Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync("gu", "latn", "gujr", inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[0].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[1].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[2].Text));

            List<string> expectedText = new()
            { "ગુજરાત", "હદમાં", "હુક્કાબાર" };

            int editDistance = 0;
            for (int i = 0; i < expectedText.Count; i++)
            {
                editDistance = editDistance + TestHelper.EditDistance(expectedText[i], response.Value[i].Text);
            }
            Assert.IsTrue(editDistance < 6, $"Total string distance: {editDistance}");
        }

        [RecordedTest]
        public async Task VerifyTransliterationWithEditDistanceOptions()
        {
            TextTranslationClient client = GetClient();

            TextTranslationTransliterateOptions options = new TextTranslationTransliterateOptions(
                language: "gu",
                fromScript: "latn",
                toScript: "gujr",
                content: new[]
                {
                    "gujarat",
                    "hadman",
                    "hukkabar"
                }
            );
            Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync(options).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[0].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[1].Text));
            Assert.IsFalse(string.IsNullOrEmpty(response.Value[2].Text));

            List<string> expectedText = new()
            { "ગુજરાત", "હદમાં", "હુક્કાબાર" };

            int editDistance = 0;
            for (int i = 0; i < expectedText.Count; i++)
            {
                editDistance = editDistance + TestHelper.EditDistance(expectedText[i], response.Value[i].Text);
            }
            Assert.IsTrue(editDistance < 6, $"Total string distance: {editDistance}");
        }
    }
}
