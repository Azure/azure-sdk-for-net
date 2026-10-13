// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Enclave.Tests;

public class BasicLiveEnclaveTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateVirtualEnclave()
    {
        await using Trycep test = BasicEnclaveTests.CreateVirtualEnclaveTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
