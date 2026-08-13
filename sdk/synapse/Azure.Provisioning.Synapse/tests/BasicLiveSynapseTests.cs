// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Synapse.Tests;

public class BasicLiveSynapseTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateSynapseWorkspace()
    {
        await using Trycep test = BasicSynapseTests.CreateSynapseWorkspaceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
