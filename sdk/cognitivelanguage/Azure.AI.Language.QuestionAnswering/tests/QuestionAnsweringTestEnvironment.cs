// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringTestEnvironment : TestEnvironment
    {
        public string ApiKey => GetRecordedVariable("QNAMAKER_API_KEY");

        public Uri Endpoint => new Uri(GetRecordedVariable("QNAMAKER_URI"), UriKind.Absolute);
    }
}
