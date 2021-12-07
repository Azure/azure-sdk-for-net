// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    public abstract class IdentityRecordedTestBase : RecordedTestBase<IdentityTestEnvironment>
    {
        protected IdentityRecordedTestBase(bool isAsync, bool useLegacyTransport = false) : base(isAsync, useLegacyTransport: useLegacyTransport)
        {
            InitialzeRecordingSettings();
        }

        protected IdentityRecordedTestBase(bool isAsync, RecordedTestMode mode, bool useLegacyTransport = false) : base(isAsync, mode, useLegacyTransport: useLegacyTransport)
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
            // x-ms-PKeyAuth is only added on MAC and Linux so recordings made on windows will fail on these platforms and vice-versa
            // ignoring this header as CI must run on all platforms
            Matcher.LegacyExcludedHeaders.Add("x-ms-PKeyAuth");
            Sanitizer = new IdentityRecordedTestSanitizer();
        }
    }
}
