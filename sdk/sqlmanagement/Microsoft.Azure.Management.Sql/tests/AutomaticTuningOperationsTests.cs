// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sql.Tests
{
    public class AutomaticTuningOperationsTests
    {
        [Fact]
        public void TestSetServerAutotuningSettings()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Set server autotuning options Custom
                ServerAutomaticTuning parameters = new ServerAutomaticTuning() {
                    DesiredState = AutomaticTuningServerMode.Custom,
                    Options = new Dictionary<string, AutomaticTuningServerOptions>()
                    {
                        {"createIndex", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.On} },
                        {"dropIndex", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.Off} },
                        {"forceLastGoodPlan", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.On} }
                    }
                };

                var resultUpdate = sqlClient.ServerAutomaticTuning.UpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, parameters).GetAwaiter().GetResult();

                Assert.True(resultUpdate.Response.IsSuccessStatusCode);

                var resultGet = sqlClient.ServerAutomaticTuning.GetWithHttpMessagesAsync(resourceGroup.Name, server.Name).GetAwaiter().GetResult();

                Assert.True(resultGet.Response.IsSuccessStatusCode);
                Assert.Equal(AutomaticTuningServerMode.Custom, resultGet.Body.DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.On, resultGet.Body.Options["createIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Off, resultGet.Body.Options["dropIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.On, resultGet.Body.Options["forceLastGoodPlan"].DesiredState);

                // Set server autotuning options Auto
                parameters = new ServerAutomaticTuning()
                {
                    DesiredState = AutomaticTuningServerMode.Auto,
                    Options = new Dictionary<string, AutomaticTuningServerOptions>()
                    {
                        {"createIndex", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.Default} },
                        {"dropIndex", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.Default} },
                        {"forceLastGoodPlan", new AutomaticTuningServerOptions() {DesiredState=AutomaticTuningOptionModeDesired.On} }
                    }
                };

                resultUpdate = sqlClient.ServerAutomaticTuning.UpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, parameters).GetAwaiter().GetResult();

                Assert.True(resultUpdate.Response.IsSuccessStatusCode);

                resultGet = sqlClient.ServerAutomaticTuning.GetWithHttpMessagesAsync(resourceGroup.Name, server.Name).GetAwaiter().GetResult();

                Assert.True(resultGet.Response.IsSuccessStatusCode);
                Assert.Equal(AutomaticTuningServerMode.Auto, resultGet.Body.DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Default, resultGet.Body.Options["createIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Default, resultGet.Body.Options["dropIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.On, resultGet.Body.Options["forceLastGoodPlan"].DesiredState);
            }
        }

        [Fact]
        public void TestSetDatabaseAutotuningSettings()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create database
                string dbName = SqlManagementTestUtilities.GenerateName();
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });

                // Set server autotuning options Inherit
                DatabaseAutomaticTuning parameters = new DatabaseAutomaticTuning()
                {
                    DesiredState = AutomaticTuningMode.Inherit,
                    Options = new Dictionary<string, AutomaticTuningOptions>()
                    {
                        {"createIndex", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.Default} },
                        {"dropIndex", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.On} },
                        {"forceLastGoodPlan", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.Default} }
                    }
                };

                var resultUpdate = sqlClient.DatabaseAutomaticTuning.UpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name, parameters).GetAwaiter().GetResult();

                Assert.True(resultUpdate.Response.IsSuccessStatusCode);

                var resultGet = sqlClient.DatabaseAutomaticTuning.GetWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name).GetAwaiter().GetResult();

                Assert.True(resultGet.Response.IsSuccessStatusCode);
                Assert.Equal(AutomaticTuningMode.Inherit, resultGet.Body.DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Default, resultGet.Body.Options["createIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.On, resultGet.Body.Options["dropIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Default, resultGet.Body.Options["forceLastGoodPlan"].DesiredState);

                // Set server autotuning options Custom
                parameters = new DatabaseAutomaticTuning()
                {
                    DesiredState = AutomaticTuningMode.Custom,
                    Options = new Dictionary<string, AutomaticTuningOptions>()
                    {
                        {"createIndex", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.On} },
                        {"dropIndex", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.Off} },
                        {"forceLastGoodPlan", new AutomaticTuningOptions() {DesiredState=AutomaticTuningOptionModeDesired.Off} }
                    }
                };

                resultUpdate = sqlClient.DatabaseAutomaticTuning.UpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name, parameters).GetAwaiter().GetResult();

                Assert.True(resultUpdate.Response.IsSuccessStatusCode);

                resultGet = sqlClient.DatabaseAutomaticTuning.GetWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name).GetAwaiter().GetResult();

                Assert.True(resultGet.Response.IsSuccessStatusCode);
                Assert.Equal(AutomaticTuningMode.Custom, resultGet.Body.DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.On, resultGet.Body.Options["createIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Off, resultGet.Body.Options["dropIndex"].DesiredState);
                Assert.Equal(AutomaticTuningOptionModeDesired.Off, resultGet.Body.Options["forceLastGoodPlan"].DesiredState);

                // Set server autotuning options Auto
                parameters = new DatabaseAutomaticTuning()
                {
                    DesiredState = AutomaticTuningMode.Auto
                };

                resultUpdate = sqlClient.DatabaseAutomaticTuning.UpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name, parameters).GetAwaiter().GetResult();

                Assert.True(resultUpdate.Response.IsSuccessStatusCode);

                resultGet = sqlClient.DatabaseAutomaticTuning.GetWithHttpMessagesAsync(resourceGroup.Name, server.Name, db1.Name).GetAwaiter().GetResult();

                Assert.True(resultGet.Response.IsSuccessStatusCode);
                Assert.Equal(AutomaticTuningMode.Auto, resultGet.Body.DesiredState);
            }
        }
    }
}
