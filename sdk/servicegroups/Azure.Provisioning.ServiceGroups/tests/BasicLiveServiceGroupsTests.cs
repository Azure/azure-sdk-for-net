// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceGroups.Tests;

public class BasicLiveServiceGroupsTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateServiceGroup()
    {
        await using Trycep test = BasicServiceGroupsTests.CreateServiceGroupTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
