// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class QAGenerateAnswerTests : TextAnalyticsClientLiveTestBase
    {
        public QAGenerateAnswerTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task QAGenerateAnswerTest()
        {
            TextAnalyticsClient client = GetQAClient();
            var query = new QueryDTO
            {
                Question = "hi",
                IsTest = true
            };

            QnASearchResultList answers = await client.GenerateAnswerAsync(query, default).ConfigureAwait(false);
            Assert.AreEqual("hello", answers.Answers[0].Answer);
        }
    }
}
