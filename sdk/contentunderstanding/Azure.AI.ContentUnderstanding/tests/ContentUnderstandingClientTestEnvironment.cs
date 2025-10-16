// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ContentUnderstandingClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ContentUnderstanding_ENDPOINT");

        // Add other client paramters here as above.
    }
}
