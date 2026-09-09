// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Kusto.Tests;

public class BasicLiveKustoTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/d56737b22db0280fc1967a59d7c01a6762ccbedd/quickstarts/microsoft.kusto/kusto-cluster-database/azuredeploy.json")]
    [LiveOnly]
    public async Task KustoClusterDatabase()
    {
        await using Trycep test = BasicKustoTests.CreateKustoClusterDatabaseTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
