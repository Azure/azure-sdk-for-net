// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DesktopVirtualization.Tests;

public class BasicLiveDesktopVirtualizationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.desktopvirtualization/workspaces")]
    [LiveOnly]
    public async Task CreateVirtualWorkspace()
    {
        await using Trycep test = BasicDesktopVirtualizationTests.CreateVirtualWorkspaceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
