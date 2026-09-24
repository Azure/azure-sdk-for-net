// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppNetwork.Tests;

public class BasicLiveAppNetworkTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateAppLink()
    {
        await using Trycep test = BasicAppNetworkTests.CreateAppLinkTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
