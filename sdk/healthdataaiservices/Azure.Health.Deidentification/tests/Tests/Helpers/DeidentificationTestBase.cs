// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestBase : RecordedTestBase<DeidentificationTestEnvironment>
    {
        public DeidentificationTestBase(bool isAsync) : base(isAsync)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..sourceLocation.location") { Value = DeidentificationTestEnvironment.FakeStorageLocation });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..targetLocation.location") { Value = DeidentificationTestEnvironment.FakeStorageLocation });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..nextLink") { Value = DeidentificationTestEnvironment.FakeNextLink });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"net-sdk-job-\d+-[0-9_]+") { Value = DeidentificationTestEnvironment.FakeJobName });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"continuationToken=[A-Za-z0-9%._~-]+") { Value = DeidentificationTestEnvironment.FakeContinuationTokenSegment });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"net-sdk-job-\d+-[0-9_]+") { Value = DeidentificationTestEnvironment.FakeJobName });
        }

        protected DeidentificationClient GetDeidClient()
        {
            return InstrumentClient(
                new DeidentificationClient(
                    new Uri(TestEnvironment.Endpoint),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new DeidentificationClientOptions())
                )
            );
        }
    }
}
