// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Authoring.Tests
{
    public class AuthoringClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("AZURE_TEXT_AUTHORING_ENDPOINT");
        public string ApiKey => GetRecordedVariable("AZURE_TEXT_AUTHORING_KEY", options => options.IsSecret());
    }
}
