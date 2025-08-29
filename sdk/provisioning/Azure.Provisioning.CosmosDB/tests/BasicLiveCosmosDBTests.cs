// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CosmosDB.Tests;

public class BasicLiveCosmosDBTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.documentdb/cosmosdb-free/main.bicep")]
    public async Task CreateCosmosSqlDB()
    {
        await using Trycep test = BasicCosmosDBTests.CreateCosmosSqlDBTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }
}
