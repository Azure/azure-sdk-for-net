// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("QuestionAnswering_ENDPOINT");

        // Add other client paramters here as above.
    }
}
