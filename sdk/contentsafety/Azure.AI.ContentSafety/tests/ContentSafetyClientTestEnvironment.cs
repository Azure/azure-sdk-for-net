// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.ContentSafety.Tests
{
    public class ContentSafetyClientTestEnvironment
        : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTENT_SAFETY_ENDPOINT");

        public string Key => GetRecordedVariable("CONTENT_SAFETY_KEY", options => options.IsSecret());
    }
}
