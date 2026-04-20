// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CostManagement.Tests;

public class BasicLiveCostManagementTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.costmanagement/exports")]
    [LiveOnly]
    public async Task CreateCostManagementExport()
    {
        await using Trycep test = BasicCostManagementTests.CreateCostManagementExportTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
