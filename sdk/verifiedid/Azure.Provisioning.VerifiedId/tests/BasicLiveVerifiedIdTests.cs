// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.VerifiedId.Tests;

public class BasicLiveVerifiedIdTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateVerifiedIdAuthority()
    {
        await using Trycep test = BasicVerifiedIdTests.CreateVerifiedIdAuthorityTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
