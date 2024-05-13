// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestBase : RecordedTestBase<DeidentificationTestEnvironment>
    {
        public DeidentificationTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        protected DeidentificationClient GetDeidClient()
        {
            return InstrumentClient(
                new DeidentificationClient(
                    new Uri(TestEnvironment.Endpoint),
                    new DefaultAzureCredential(),
                    InstrumentClientOptions(new DeidentificationClientOptions())
                )
            );
        }
    }
}
