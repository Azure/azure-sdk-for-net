// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceFabricManagedClusters.Tests;

public class BasicLiveServiceFabricManagedClustersTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.servicefabric/2026-02-01/managedclusters/applicationtypes")]
    [LiveOnly]
    public async Task CreateApplicationType()
    {
        await using Trycep test = BasicServiceFabricManagedClustersTests.CreateApplicationTypeTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
