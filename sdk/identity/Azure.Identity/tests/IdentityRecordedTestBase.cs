// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    public abstract class IdentityRecordedTestBase : RecordedTestBase<IdentityTestEnvironment>
    {
        protected IdentityRecordedTestBase(bool isAsync) : base(isAsync)
        {
            InitialzeRecordingSettings();
        }

        protected IdentityRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            InitialzeRecordingSettings();
        }

        private void InitialzeRecordingSettings()
        {
            // the following headers are added by MSAL and need to be excluded from matching for recordings
            Matcher.LegacyExcludedHeaders.Add("Content-Length");
            Matcher.LegacyExcludedHeaders.Add("client-request-id");
            Matcher.LegacyExcludedHeaders.Add("x-client-OS");
            Matcher.LegacyExcludedHeaders.Add("x-client-SKU");
            Matcher.LegacyExcludedHeaders.Add("x-client-CPU");
            Matcher.LegacyExcludedHeaders.Add("x-client-Ver");
            Matcher.LegacyExcludedHeaders.Add("Date");
            Matcher.LegacyExcludedHeaders.Add("x-ms-date");
            Matcher.LegacyExcludedHeaders.Add("x-ms-client-request-id");
            Matcher.LegacyExcludedHeaders.Add("User-Agent");
            Matcher.LegacyExcludedHeaders.Add("Request-Id");
            Matcher.LegacyExcludedHeaders.Add("traceparent");
            Sanitizer = new IdentityRecordedTestSanitizer();
        }
    }
}
