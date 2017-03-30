// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ElasticPoolCrudScenarioTests
    {
        [Fact]
        public void TestCreateDropElasticPool()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCreateDropElasticPool", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };
                List<string> names = new List<string>();

                // Create elastic pool
                //
                string epName = SqlManagementTestUtilities.GenerateName(testPrefix);
                names.Add(epName);
                sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, new ElasticPool()
                { 
                    Location = server.Location
                });

                // Create a elasticPool with Tags and Basic Edition specified
                // 
                epName = SqlManagementTestUtilities.GenerateName(testPrefix);
                names.Add(epName);
                var ep2Input = new ElasticPool()
                {
                    Location = server.Location,
                    Edition = SqlTestConstants.DefaultElasticPoolEdition,
                    Tags = tags,                    
                };

                // Create a elasticPool with all parameters specified
                // 
                epName = SqlManagementTestUtilities.GenerateName(testPrefix);
                names.Add(epName);
                var ep3Input = new ElasticPool()
                {
                    Location = server.Location,
                    Edition = DatabaseEdition.Standard,
                    Tags = tags,
                };
                sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, ep3Input);

                foreach (string name in names)
                {
                    sqlClient.ElasticPools.Delete(resourceGroup.Name, server.Name, name);
                }
            });
        }

        [Fact]
        public void TestUpdateElasticPoolAndListActivity()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestUpdateElasticPoolAndListActivity", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
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
                    Edition = DatabaseEdition.Standard,
                    Tags = tags,
                    Dtu = 100,
                    DatabaseDtuMax = 20,
                    DatabaseDtuMin = 0             
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);
                var epa = sqlClient.ElasticPools.ListActivity(resourceGroup.Name, server.Name, epName);
                Assert.NotNull(epa);
                Assert.Equal(1, epa.Count());
                Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());

                // Update elasticPool Dtu
                // 
                ElasticPool epInput2 = new ElasticPool()
                {
                    Location = server.Location,
                    Dtu = 200
                };
                returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput2);
                SqlManagementTestUtilities.ValidateElasticPool(epInput2, returnedEp, epName);
                epa = sqlClient.ElasticPools.ListActivity(resourceGroup.Name, server.Name, epName);
                Assert.NotNull(epa);
                Assert.Equal(2, epa.Count());
                Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
                Assert.Equal(1, epa.Where(a => a.Operation == "UPDATE").Count());

                // Update elasticPool Dtu Max
                // 
                ElasticPool epInput3 = new ElasticPool()
                {
                    Location = server.Location,
                    DatabaseDtuMax = 100
                };
                returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput3);
                SqlManagementTestUtilities.ValidateElasticPool(epInput3, returnedEp, epName);
                epa = sqlClient.ElasticPools.ListActivity(resourceGroup.Name, server.Name, epName);
                Assert.NotNull(epa);
                Assert.Equal(3, epa.Count());
                Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
                Assert.Equal(2, epa.Where(a => a.Operation == "UPDATE").Count());

                // Update elasticPool Dtu Min
                // 
                ElasticPool epInput4 = new ElasticPool()
                {
                    Location = server.Location,
                    DatabaseDtuMin = 10
                };
                returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput4);
                SqlManagementTestUtilities.ValidateElasticPool(epInput4, returnedEp, epName);
                epa = sqlClient.ElasticPools.ListActivity(resourceGroup.Name, server.Name, epName);
                Assert.NotNull(epa);
                Assert.Equal(4, epa.Count());
                Assert.Equal(1, epa.Where(a => a.Operation == "CREATE").Count());
                Assert.Equal(3, epa.Where(a => a.Operation == "UPDATE").Count());
            });
        }

        [Fact]
        public void TestGetAndListElasticPool()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestGetAndListElasticPool", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                Dictionary<string, ElasticPool> inputs = new Dictionary<string, ElasticPool>();

                // Create elastic pools to run the get/List tests on.
                for (int i = 0; i < 3; i++)
                {
                    string name = SqlManagementTestUtilities.GenerateName(testPrefix);
                    inputs.Add(name, new ElasticPool()
                    {
                        Location = server.Location,
                        Edition = SqlTestConstants.DefaultElasticPoolEdition
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
            });
        }
    }
}
