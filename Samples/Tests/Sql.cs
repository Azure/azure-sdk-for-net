// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Sql
    {
        public Sql(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
            Microsoft.Azure.Management.Samples.Common.Utilities.PauseMethod = TestHelper.ReadLine;
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabaseTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabase.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabaseInElasticPoolTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabaseInElasticPool.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabasesAcrossDifferentDataCentersTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabasesAcrossDifferentDataCenters.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "Sql")]
        public void ManageSqlFirewallRulesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlFirewallRules.Program.RunSample(rollUpClient);
            }
        }
    }
}
