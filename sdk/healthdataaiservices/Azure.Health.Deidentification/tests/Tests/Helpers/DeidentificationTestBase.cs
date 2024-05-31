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
        public DeidentificationTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
        {
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..location") { Value = DeidentificationTestEnvironment.FakeSASUri });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..nextLink") { Value = TestEnvironment.FakeNextLink });
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
