// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.ContentSafety.Tests
{
    public class ContentSafetyClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ContentSafety_ENDPOINT");

        // Add other client paramters here as above.
    }
}
