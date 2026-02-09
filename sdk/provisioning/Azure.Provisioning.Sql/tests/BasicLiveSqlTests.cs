// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Sql.Tests;

public class BasicLiveSqlTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.sql/sql-database/main.bicep")]
    [LiveOnly]
    public async Task CreateSimpleSqlServerAndDatabase()
    {
        await using Trycep test = BasicSqlTests.CreateSimpleSqlServerAndDatabaseTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
