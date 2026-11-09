// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Subscription.Tests;

public class BasicLiveSubscriptionTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateSubscriptionAlias()
    {
        await using Trycep test = BasicSubscriptionTests.CreateSubscriptionAliasTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
