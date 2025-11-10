// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests
{
    public class AuthoringClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Authoring_ENDPOINT");

        // Add other client paramters here as above.
    }
}
