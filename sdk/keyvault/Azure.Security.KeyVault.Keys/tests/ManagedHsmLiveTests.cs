// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    // BUGBUG: run manually until we can resolve https://github.com/Azure/azure-sdk-for-net/issues/16531
    [RunFrequency(RunTestFrequency.Manually)]
    public class ManagedHsmLiveTests : KeyClientLiveTests
    {
        public ManagedHsmLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        public override Uri Uri => new Uri(TestEnvironment.ManagedHsmUrl);
    }
}
