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
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..location") { Value = TestEnvironment.FakeStorageLocation });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..nextLink") { Value = TestEnvironment.FakeNextLink });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"net-sdk-job-\d+-[0-9_]+") { Value = TestEnvironment.FakeJobName });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"net-sdk-job-\d+-[0-9_]+") { Value = TestEnvironment.FakeJobName });
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
