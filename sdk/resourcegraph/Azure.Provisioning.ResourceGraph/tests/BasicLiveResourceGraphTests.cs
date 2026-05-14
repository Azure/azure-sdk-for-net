// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceGraph.Tests;

public class BasicLiveResourceGraphTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/demos/resourcegraph-sharedquery-countos")]
    [LiveOnly]
    public async Task CreateResourceGraphQuery()
    {
        await using Trycep test = BasicResourceGraphTests.CreateResourceGraphQueryTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
