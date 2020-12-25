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
            Matcher.ExcludeHeaders.Add("Content-Length");
            Matcher.ExcludeHeaders.Add("client-request-id");
            Matcher.ExcludeHeaders.Add("x-client-OS");
            Matcher.ExcludeHeaders.Add("x-client-SKU");
            Matcher.ExcludeHeaders.Add("x-client-CPU");
            Matcher.ExcludeHeaders.Add("x-client-Ver");

            Sanitizer = new IdentityRecordedTestSanitizer();
        }
    }
}
