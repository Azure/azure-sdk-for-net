// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public abstract class IdentityRecordedTestBase : RecordedTestBase<IdentityTestEnvironment>
    {
        protected IdentityRecordedTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            // TODO: enable after new KeyValue is released (after Dec 2023)
            TestDiagnostics = false;
            InitializeRecordingSettings();
        }

        private void InitializeRecordingSettings()
        {
            // the following headers are added by MSAL and need to be excluded from matching for recordings
            LegacyExcludedHeaders.Add("Content-Length");
            LegacyExcludedHeaders.Add("client-request-id");
            LegacyExcludedHeaders.Add("x-client-OS");
            LegacyExcludedHeaders.Add("x-client-SKU");
            LegacyExcludedHeaders.Add("x-client-CPU");
            LegacyExcludedHeaders.Add("x-client-Ver");
            // x-ms-PKeyAuth is only added on MAC and Linux so recordings made on windows will fail on these platforms and vice-versa
            // ignoring this header as CI must run on all platforms
            LegacyExcludedHeaders.Add("x-ms-PKeyAuth");
            LegacyExcludedHeaders.Add("x-client-current-telemetry");
            LegacyExcludedHeaders.Add("x-client-last-telemetry");
            LegacyExcludedHeaders.Add("x-anchormailbox");
            // temporary until update to disable cookies in Core is shipped
            LegacyExcludedHeaders.Add("cookie");
            SanitizedHeaders.Add("secret");
            JsonPathSanitizers.Add("$..refresh_token");
            JsonPathSanitizers.Add("$..access_token");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"=[^&|}|""]+", "=" + SanitizeValue)
            {
                Condition = new Condition { UriRegex = ".*/token([?].*)?$" }
            });
            HeaderTransforms.Add(new HeaderTransform(
                "WWW-Authenticate",
                $"Basic realm={Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "mock-arc-mi-key.key")}")
            {
                Condition = new Condition
                {
                    ResponseHeader = new HeaderCondition
                    {
                        Key = "WWW-Authenticate",
                        ValueRegex = "Basic realm=.*"
                    }
                }
            });
        }
    }
}
