// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class AppService
    {
        public AppService(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppBasicTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppBasic.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSourceControlTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppSourceControl.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSlotsTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppSlots.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSqlConnectionTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppSqlConnection.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppStorageAccountConnectionTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppStorageAccountConnection.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppWithDomainSslTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppWithDomainSsl.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: convert to recorded tests")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppWithTrafficManagerTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageWebAppWithTrafficManager.Program.RunSample(rollUpClient);
            }
        }
    }
}
