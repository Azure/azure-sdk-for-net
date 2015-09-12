//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for ElasticPools
    /// </summary>
    public class Sql2ElasticPoolScenarioTests : TestBase
    {
        [Fact]
        public void ElasticPoolCrud()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resPoolName = TestUtilities.GenerateName("csm-sql-respoolcrud");
                string resPool2Name = TestUtilities.GenerateName("csm-sql-respoolcrud");

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        //////////////////////////////////////////////////////////////////////
                        // Create Elastic Pool Test with all values specified (Default values)
                        var pool1Properties = new ElasticPoolCreateOrUpdateProperties()
                        {
                            Edition = "Standard",
                            Dtu = 200,
                            DatabaseDtuMax = 100,
                            DatabaseDtuMin = 10,
                            StorageMB = 204800
                        };

                        var pool1 = sqlClient.ElasticPools.CreateOrUpdate(resGroupName, server.Name, resPoolName, new ElasticPoolCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = pool1Properties
                        });

                        TestUtilities.ValidateOperationResponse(pool1, HttpStatusCode.Created);
                        ValidateElasticPool(
                            pool1.ElasticPool,
                            resPoolName,
                            pool1Properties.Edition,
                            pool1Properties.DatabaseDtuMax,
                            pool1Properties.DatabaseDtuMin,
                            pool1Properties.Dtu,
                            pool1Properties.StorageMB);

                        var pool2Properties = new ElasticPoolCreateOrUpdateProperties()
                        {
                            Edition = "Standard",
                        };

                        var pool2 = sqlClient.ElasticPools.CreateOrUpdate(resGroupName, server.Name, resPool2Name, new ElasticPoolCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = pool2Properties
                        });

                        TestUtilities.ValidateOperationResponse(pool2, HttpStatusCode.Created);
                        ValidateElasticPool(
                            pool2.ElasticPool,
                            resPool2Name,
                            pool1Properties.Edition,
                            100,
                            0,
                            200,
                            204800);

                        //////////////////////////////////////////////////////////////////////
                        // Update Elastic Pool Test
                        pool1Properties.Dtu = 200;
                        pool1Properties.DatabaseDtuMax = 50;
                        pool1Properties.DatabaseDtuMin = 0;

                        var pool3 = sqlClient.ElasticPools.CreateOrUpdate(resGroupName, server.Name, resPoolName, new ElasticPoolCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = pool1Properties
                        });

                        TestUtilities.ValidateOperationResponse(pool3, HttpStatusCode.OK);
                        ValidateElasticPool(
                            pool3.ElasticPool,
                            resPoolName,
                            pool1Properties.Edition,
                            pool1Properties.DatabaseDtuMax,
                            pool1Properties.DatabaseDtuMin,
                            pool1Properties.Dtu,
                            pool1Properties.StorageMB);

                        //////////////////////////////////////////////////////////////////////
                        // Get Elastic Pool Test.
                        var pool4 = sqlClient.ElasticPools.Get(resGroupName, server.Name, resPoolName);

                        TestUtilities.ValidateOperationResponse(pool4, HttpStatusCode.OK);
                        ValidateElasticPool(
                            pool4.ElasticPool,
                            resPoolName,
                            pool3.ElasticPool.Properties.Edition,
                            pool3.ElasticPool.Properties.DatabaseDtuMax,
                            pool3.ElasticPool.Properties.DatabaseDtuMin,
                            pool3.ElasticPool.Properties.Dtu,
                            pool3.ElasticPool.Properties.StorageMB);

                        //////////////////////////////////////////////////////////////////////
                        // Get Elastic Pool Test.
                        var pools = sqlClient.ElasticPools.List(resGroupName, server.Name);

                        TestUtilities.ValidateOperationResponse(pools, HttpStatusCode.OK);
                        Assert.Equal(2, pools.ElasticPools.Count);

                        //////////////////////////////////////////////////////////////////////
                        // Get Elastic Pool Activity Test.
                        var activity = sqlClient.ElasticPools.ListActivity(resGroupName, server.Name, resPoolName);
                        TestUtilities.ValidateOperationResponse(activity, HttpStatusCode.OK);
                        Assert.True(activity.ElasticPoolActivities.Count > 0);

                        //////////////////////////////////////////////////////////////////////
                        // Delete Elastic Pool Test.
                        var resp = sqlClient.ElasticPools.Delete(resGroupName, server.Name, pool1.ElasticPool.Name);
                        TestUtilities.ValidateOperationResponse(resp, HttpStatusCode.OK);

                        resp = sqlClient.ElasticPools.Delete(resGroupName, server.Name, pool2.ElasticPool.Name);
                        TestUtilities.ValidateOperationResponse(resp, HttpStatusCode.OK);
                    });
            }
        }

        [Fact]
        public void ElasticPoolDatabaseOperations()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resPoolName = TestUtilities.GenerateName("csm-sql-respoolcrud");

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        //////////////////////////////////////////////////////////////////////
                        // Create Elastic Pool Test with all values specified (Default values)
                        var pool1Properties = new ElasticPoolCreateOrUpdateProperties()
                        {
                            Edition = "Standard",
                            Dtu = 200,
                            DatabaseDtuMax = 100,
                            DatabaseDtuMin = 10,
                            StorageMB = 204800
                        };

                        var pool1 = sqlClient.ElasticPools.CreateOrUpdate(resGroupName, server.Name, resPoolName, new ElasticPoolCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = pool1Properties
                        });

                        TestUtilities.ValidateOperationResponse(pool1, HttpStatusCode.Created);

                        ////////////////////////////////////////////////////////////////////
                        // Create database in Elastic Pool
                        var databaseName = TestUtilities.GenerateName("csm-sql-respoolcrud");
                        var db1 = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, databaseName, new DatabaseCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new DatabaseCreateOrUpdateProperties()
                            {
                                ElasticPoolName = pool1.ElasticPool.Name,
                            }
                        });

                        TestUtilities.ValidateOperationResponse(db1, HttpStatusCode.Created);

                        //////////////////////////////////////////////////////////////////////
                        // Move database into Elastic Pool
                        var database2Name = TestUtilities.GenerateName("csm-sql-respoolcrud");
                        var db2 = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, database2Name, new DatabaseCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new DatabaseCreateOrUpdateProperties()
                            {
                                Edition = "Basic"
                            }
                        });
                        TestUtilities.ValidateOperationResponse(db2, HttpStatusCode.Created);

                        var moveResult = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, database2Name, new DatabaseCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new DatabaseCreateOrUpdateProperties()
                            {
                                ElasticPoolName = pool1.ElasticPool.Name,
                            }
                        });
                        TestUtilities.ValidateOperationResponse(moveResult, HttpStatusCode.OK);

                        //////////////////////////////////////////////////////////////////////
                        // Get database acitivity
                        var activity = sqlClient.ElasticPools.ListDatabaseActivity(resGroupName, server.Name, resPoolName);
                        TestUtilities.ValidateOperationResponse(moveResult, HttpStatusCode.OK);
                        Assert.True(activity.ElasticPoolDatabaseActivities.Count > 0);
                    });
            }
        }

        /// <summary>
        /// Validates the Elastic pool properties
        /// </summary>
        /// <param name="pool">The elastic pool to validate</param>
        /// <param name="poolName">The expected name of the pool</param>
        /// <param name="edition">The expected edition of the pool</param>
        /// <param name="dbDtuCap">The expected max DTU of a database in the pool</param>
        /// <param name="dbDtu">The expected min DTU of a database in the pool</param>
        /// <param name="dtuGuarantee">The expected DTU of the pool</param>
        /// <param name="storageLimit">The expected storage limit of the pool</param>
        private void ValidateElasticPool(ElasticPool pool, string poolName, string edition, int? dbDtuCap, int? dbDtu, int? dtuGuarantee, int? storageLimit)
        {
            Assert.Equal(pool.Name, poolName);

            Assert.Equal(edition, pool.Properties.Edition);
            Assert.Equal(dbDtuCap.Value, pool.Properties.DatabaseDtuMax);
            Assert.Equal(dbDtu.Value, pool.Properties.DatabaseDtuMin);
            Assert.Equal(dtuGuarantee.Value, pool.Properties.Dtu);
            Assert.Equal(storageLimit.Value, pool.Properties.StorageMB);
        }
    }
}
