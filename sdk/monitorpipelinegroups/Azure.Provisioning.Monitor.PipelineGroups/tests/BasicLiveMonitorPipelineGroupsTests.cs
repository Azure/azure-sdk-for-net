// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Monitor.PipelineGroups.Tests;

public class BasicLiveMonitorPipelineGroupsTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.monitor")]
    [LiveOnly]
    public async Task CreatePipelineGroup()
    {
        await using Trycep test = BasicMonitorPipelineGroupsTests.CreatePipelineGroupTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
