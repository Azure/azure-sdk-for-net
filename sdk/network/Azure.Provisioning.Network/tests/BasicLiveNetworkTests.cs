// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class BasicLiveNetworkTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/vnet-two-subnets/main.bicep")]
    [LiveOnly]
    public async Task VNetTwoSubnets()
    {
        await using Trycep test = BasicNetworkTests.CreateVNetTwoSubnetsTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/nat-gateway-vnet/main.bicep")]
    [LiveOnly]
    public async Task NatGatewayVNet()
    {
        await using Trycep test = BasicNetworkTests.CreateNatGatewayVNetTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/networkwatcher-flowLogs-create/main.bicep")]
    [LiveOnly]
    public async Task NetworkWatcherFlowLogsCreate()
    {
        await using Trycep test = BasicNetworkTests.CreateNetworkWatcherFlowLogsCreateTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/security-group-create/azuredeploy.json#L42")]
    [LiveOnly]
    public async Task SecurityGroupCreate()
    {
        await using Trycep test = BasicNetworkTests.CreateSecurityGroupCreateTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
