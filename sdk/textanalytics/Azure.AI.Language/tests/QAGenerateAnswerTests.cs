// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Models;
using NUnit.Framework;

namespace Azure.AI.Language.Tests
{
    public class QAGenerateAnswerTests : TextAnalyticsClientLiveTestBase
    {
        public QAGenerateAnswerTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task QAGenerateAnswerTest()
        {
            TextAnalyticsClient client = GetQAClient();
            var query = new Query
            {
                Question = "hi",
                IsTest = true
            };

            QnASearchResultList answers = await client.GenerateAnswerAsync("ef31dd53-6d00-4769-b353-63335503a8b3", query, default).ConfigureAwait(false);
            Assert.AreEqual("hello", answers.Answers[0].Answer);
        }
    }
}
