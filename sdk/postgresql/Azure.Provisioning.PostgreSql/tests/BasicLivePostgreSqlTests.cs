// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PostgreSql.Tests;

public class BasicLivePostgreSqlTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.dbforpostgresql/flexible-postgresql-with-aad/main.bicep")]
    [LiveOnly]
    public async Task CreateFlexibleServer()
    {
        await using Trycep test = BasicPostgreSqlTests.CreateFlexibleServerTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
