// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class ElasticPoolCrudScenarioTests
    {
        [Fact]
        public void TestCreateDropElasticPool()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };
                List<string> names = new List<string>();

                // Create elastic pool
                //
                string epName = SqlManagementTestUtilities.GenerateName();
                names.Add(epName);
                sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, new ElasticPool()
                { 
                    Location = server.Location
                });

                // Create a elasticPool with Tags and Basic Edition specified
                // 
                epName = SqlManagementTestUtilities.GenerateName();
                names.Add(epName);
                var ep2Input = new ElasticPool()
                {
                    Location = server.Location,
                    Sku = SqlTestConstants.DefaultElasticPoolSku(),
                    Tags = tags,
                };

                // Create a elasticPool with all parameters specified
                // 
                epName = SqlManagementTestUtilities.GenerateName();
                names.Add(epName);
                var ep3Input = new ElasticPool()
                {
                    Location = server.Location,
                    Sku = SqlTestConstants.DefaultElasticPoolSku(),
                    Tags = tags,
                };
                sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, ep3Input);

                foreach (string name in names)
                {
                    sqlClient.ElasticPools.Delete(resourceGroup.Name, server.Name, name);
                }
            }
        }

        [Fact]
        public void TestUpdateElasticPoolWithCreateOrUpdateAndListActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Func<string, string, string, ElasticPool, ElasticPool> updateFunc = sqlClient.ElasticPools.CreateOrUpdate;
                Func<ElasticPool> createModelFunc = () => new ElasticPool(server.Location);
                TestUpdateElasticPool(sqlClient, resourceGroup, server, createModelFunc, updateFunc);
            };
        }

        [Fact]
        public void TestUpdateElasticPoolWithUpdateAndListActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Func<string, string, string, ElasticPoolUpdate, ElasticPool> updateFunc = sqlClient.ElasticPools.Update;
                Func<ElasticPoolUpdate> createModelFunc = () => new ElasticPoolUpdate();
                TestUpdateElasticPool(sqlClient, resourceGroup, server, createModelFunc, updateFunc);
            };
        }

        [Fact]
        public async Task TestCancelUpdateElasticPoolOperation()
        {
            /* *
             * In this test we only test the cancel operation on resize pool from Premium to Premium
             *    since currently we only support Cancel pool resize operation on Premium <-> Premium
             * */
            string testPrefix = "sqlelasticpoollistcanceloperation-";
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup("West Europe");
                Server server = context.CreateServer(resourceGroup, "westeurope");
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Dictionary<string, string> tags = new Dictionary<string, string>()
                {
                    { "tagKey1", "TagValue1"}
                };

                // Create a premium elastic pool with required parameters
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ElasticPoolEdition.Premium + "Pool"),
                    Tags = tags,
                };
                var elasticPool = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, elasticPool, epName);
                Assert.NotNull(elasticPool);

                // Update elastic pool to Premium with 250 DTU
                var epUpdateReponse = sqlClient.ElasticPools.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, epName, new ElasticPool()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ElasticPoolEdition.Premium + "Pool")
                    {
                        Capacity = 250,
                    },
                    Tags = tags
                });

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(15));
                }

                // Get the pool update operation for new added properties on elastic pool operations: ETA, Operation Description and IsCancellable
                //   Expected they have null value since not been updated by operation progress
                AzureOperationResponse<IPage<ElasticPoolOperation>> response = sqlClient.ElasticPoolOperations.ListByElasticPoolWithHttpMessagesAsync(resourceGroup.Name, server.Name, epName).Result;
                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
                IList<ElasticPoolOperation> responseObject = response.Body.ToList();
                Assert.Single(responseObject);
                Assert.NotNull(responseObject[0].PercentComplete);
                Assert.NotNull(responseObject[0].EstimatedCompletionTime);
                Assert.NotNull(responseObject[0].Description);
                Assert.NotNull(responseObject[0].IsCancellable);

                // Cancel the elastic pool update operation
                string requestId = responseObject[0].Name;
                sqlClient.ElasticPoolOperations.Cancel(resourceGroup.Name, server.Name, epName, Guid.Parse(requestId));
                CloudException ex = await Assert.ThrowsAsync<CloudException>(() => sqlClient.GetPutOrPatchOperationResultAsync(epUpdateReponse.Result, new Dictionary<string, List<string>>(), CancellationToken.None));
                Assert.Contains("OperationCancelled", ex.Body.Code);

                // Make sure the elastic pool is not updated due to cancel operation
                var epGetResponse = sqlClient.ElasticPools.Get(resourceGroup.Name, server.Name, epName);
                Assert.Equal(125, epGetResponse.Dtu);
                Assert.Equal("Premium", epGetResponse.Edition);
            }
        }

        private void TestUpdateElasticPool<TUpdateModel>(
            SqlManagementClient sqlClient,
            ResourceGroup resourceGroup,
            Server server,
            Func<TUpdateModel> createModelFunc,
            Func<string, string, string, TUpdateModel, ElasticPool> updateFunc)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>()
                {
                    { "tagKey1", "TagValue1" }
                };

            // Create a elasticPool with parameters Tags
            // 
            string epName = SqlManagementTestUtilities.GenerateName();
            var epInput = new ElasticPool()
            {
                Location = server.Location,
                Sku = new Microsoft.Azure.Management.Sql.Models.Sku("StandardPool"),
                Tags = tags,
                DatabaseDtuMax = 20,
                DatabaseDtuMin = 0
            };
            var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
            SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);
            var epa = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
            Assert.NotNull(epa);
            Assert.Equal(1, epa.Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());

            // Update elasticPool Dtu
            // 
            dynamic epInput2 = createModelFunc();
            epInput2.Sku = returnedEp.Sku;
            epInput2.Sku.Capacity = 200;

            returnedEp = updateFunc(resourceGroup.Name, server.Name, epName, epInput2);
            SqlManagementTestUtilities.ValidateElasticPool(epInput2, returnedEp, epName);
            epa = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
            Assert.NotNull(epa);
            Assert.Equal(2, epa.Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "UPDATE").Count());

            // Update elasticPool Dtu Max
            // 
            dynamic epInput3 = createModelFunc();
            epInput3.Sku = returnedEp.Sku;
            epInput3.DatabaseDtuMax = 100;

            returnedEp = updateFunc(resourceGroup.Name, server.Name, epName, epInput3);
            SqlManagementTestUtilities.ValidateElasticPool(epInput3, returnedEp, epName);
            epa = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
            Assert.NotNull(epa);
            Assert.Equal(3, epa.Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
            Assert.Equal(2, epa.Where(a => a.Operation == "UPDATE").Count());

            // Update elasticPool Dtu Min
            // 
            dynamic epInput4 = createModelFunc();
            epInput4.Sku = returnedEp.Sku;
            epInput4.DatabaseDtuMin = 10;

            returnedEp = updateFunc(resourceGroup.Name, server.Name, epName, epInput4);
            SqlManagementTestUtilities.ValidateElasticPool(epInput4, returnedEp, epName);
            epa = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
            Assert.NotNull(epa);
            Assert.Equal(4, epa.Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
            Assert.Equal(3, epa.Where(a => a.Operation == "UPDATE").Count());

            // Update elasticPool Maintenance Configuration Id
            dynamic epInput5 = createModelFunc();
            epInput5.MaintenanceConfigurationId = SqlManagementTestUtilities.GetTestMaintenanceConfigurationId(sqlClient.SubscriptionId);
            returnedEp = updateFunc(resourceGroup.Name, server.Name, epName, epInput5);
            SqlManagementTestUtilities.ValidateElasticPool(epInput5, returnedEp, epName);
            epa = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
            Assert.NotNull(epa);
            Assert.Equal(5, epa.Count());
            Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
            Assert.Equal(4, epa.Where(a => a.Operation == "UPDATE").Count());
        }

        [Fact]
        public void TestGetAndListElasticPool()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, ElasticPool> inputs = new Dictionary<string, ElasticPool>();

                // Create elastic pools to run the get/List tests on.
                for (int i = 0; i < 3; i++)
                {
                    string name = SqlManagementTestUtilities.GenerateName();
                    inputs.Add(name, new ElasticPool()
                    {
                        Location = server.Location,
                        Sku = SqlTestConstants.DefaultElasticPoolSku(),
                    });
                    sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, name, inputs[name]);
                }

                // Get each database and compare to the results of create database
                //
                foreach (var ep in inputs)
                {
                    var response = sqlClient.ElasticPools.Get(resourceGroup.Name, server.Name, ep.Key);
                    SqlManagementTestUtilities.ValidateElasticPool(ep.Value, response, ep.Key);
                }

                var listResponse = sqlClient.ElasticPools.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(inputs.Count(), listResponse.Count());

                foreach (var ep in listResponse)
                {
                    SqlManagementTestUtilities.ValidateElasticPool(inputs[ep.Name], ep, ep.Name);
                }

                foreach (var ep in inputs)
                {
                    SqlManagementTestUtilities.ValidateElasticPool(ep.Value, listResponse.Single(e => e.Name == ep.Key), ep.Key);
                }
            }
        }
    }
}
