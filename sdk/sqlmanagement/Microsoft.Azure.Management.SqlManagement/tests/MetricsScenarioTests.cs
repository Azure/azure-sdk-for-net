// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class MetricsScenarioTests
    {
        private static readonly DateTime metricStartTime = new DateTime(2017, 6, 8, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime metricEndTime = metricStartTime.AddMinutes(10);

        [Fact]
        public void TestGetDatabaseMetrics()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create a database and get metrics
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                
                // Get metric definitions
                IEnumerable<MetricDefinition> metricDefinitions = sqlClient.Databases.ListMetricDefinitions(resourceGroup.Name, server.Name, dbName);

                // Verify metric definitions
                foreach(MetricDefinition definition in metricDefinitions)
                {
                    Assert.NotNull(definition.Name.LocalizedValue);
                    Assert.NotNull(definition.Name.Value);
                    Assert.NotNull(definition.ResourceUri);
                    Assert.NotNull(definition.Unit);

                    foreach(MetricAvailability a in definition.MetricAvailabilities)
                    {
                        Assert.NotNull(a.Retention);
                        Assert.NotNull(a.TimeGrain);
                    }
                }

                string filterString = string.Format("(name/value eq 'cpu_percent') and timeGrain eq '00:05:00' and startTime eq '{0}' and endTime eq '{1}'",
                    metricStartTime.ToString("s"),
                    metricEndTime.ToString("s"));
                IEnumerable<Metric> metrics = sqlClient.Databases.ListMetrics(resourceGroup.Name, server.Name, dbName, filterString);

                Assert.True(metrics.Count() > 0);

                foreach(Metric metric in metrics)
                {
                    Assert.NotNull(metric.StartTime);
                    Assert.NotNull(metric.EndTime);
                    Assert.NotNull(metric.TimeGrain);
                    Assert.NotNull(metric.Unit);
                    Assert.NotNull(metric.Name.LocalizedValue);
                    Assert.NotNull(metric.Name.Value);

                    foreach (MetricValue value in metric.MetricValues)
                    {
                        Assert.NotNull(value.Count);
                        Assert.NotNull(value.Average);
                        Assert.NotNull(value.Maximum);
                        Assert.NotNull(value.Minimum);
                        Assert.NotNull(value.Timestamp);
                        Assert.NotNull(value.Total);
                    }
                }
            }
        }

        [Fact]
        public void TestGetElasticPoolMetrics()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create a database and get metrics
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location
                };
                sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);

                // Get metric definitions
                IEnumerable<MetricDefinition> metricDefinitions = sqlClient.ElasticPools.ListMetricDefinitions(resourceGroup.Name, server.Name, epName);

                // Verify metric definitions
                foreach (MetricDefinition definition in metricDefinitions)
                {
                    Assert.NotNull(definition.Name.LocalizedValue);
                    Assert.NotNull(definition.Name.Value);
                    Assert.NotNull(definition.ResourceUri);
                    Assert.NotNull(definition.Unit);

                    foreach (MetricAvailability a in definition.MetricAvailabilities)
                    {
                        Assert.NotNull(a.Retention);
                        Assert.NotNull(a.TimeGrain);
                    }
                }

                string filterString = string.Format("(name/value eq 'cpu_percent') and timeGrain eq '00:05:00' and startTime eq '{0}' and endTime eq '{1}'",
                    metricStartTime.ToString("s"),
                    metricEndTime.ToString("s"));
                IEnumerable<Metric> metrics = sqlClient.ElasticPools.ListMetrics(resourceGroup.Name, server.Name, epName, filterString);

                Assert.True(metrics.Count() > 0);

                foreach (Metric metric in metrics)
                {
                    Assert.NotNull(metric.StartTime);
                    Assert.NotNull(metric.EndTime);
                    Assert.NotNull(metric.TimeGrain);
                    Assert.NotNull(metric.Unit);
                    Assert.NotNull(metric.Name.LocalizedValue);
                    Assert.NotNull(metric.Name.Value);

                    foreach (MetricValue value in metric.MetricValues)
                    {
                        Assert.NotNull(value.Count);
                        Assert.NotNull(value.Average);
                        Assert.NotNull(value.Maximum);
                        Assert.NotNull(value.Minimum);
                        Assert.NotNull(value.Timestamp);
                        Assert.NotNull(value.Total);
                    }
                }
            }
        }
    }
}
