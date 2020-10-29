// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class ManagedHsmLiveTests : KeyClientLiveTests
    {
        public ManagedHsmLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        public override Uri Uri => new Uri(TestEnvironment.ManagedHsmUrl);
    }
}
