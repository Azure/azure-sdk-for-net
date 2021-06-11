// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringClientLiveTests: RecordedTestBase<QuestionAnsweringTestEnvironment>
    {
        public QuestionAnsweringClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task Placeholder()
        {
            await Task.Yield();
        }
    }
}
