// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.TextAnalytics.Tests
{
    public class TextAnalyticsClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("TextAnalytics_ENDPOINT");

        // Add other client paramters here as above.
    }
}
