// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceConnector.Tests;

public class BasicLiveResourceConnectorTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateAppliance()
    {
        await using Trycep test = BasicResourceConnectorTests.CreateApplianceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
