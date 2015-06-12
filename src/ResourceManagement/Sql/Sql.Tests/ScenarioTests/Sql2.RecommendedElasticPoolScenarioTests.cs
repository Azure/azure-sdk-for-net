using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for recommended elastic pools
    /// </summary>
    public class Sql2RecommendedElasticPoolScenarioTests : TestBase
    {
        [Fact]
        public void ListAllPools()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        var response = sqlClient.RecommendedElasticPools.List(resGroupName, server.Name);
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(2, response.RecommendedElasticPools.Count());

                        ValidateRecommendedElasticPool(response.RecommendedElasticPools[0],
                            "ElasticPool1",
                            "Microsoft.Sql/servers/recommendedElasticPools",
                            "Standard",
                            1000f,
                            100.6f,
                            200.5f,
                            1000.3f,
                            DateTime.Parse("2014-11-01T00:00:00"),
                            DateTime.Parse("2014-11-15T00:00:00"),
                            900.2f,
                            350.0f);
                    });
            }
        }
        
        [Fact]
        public void ListPoolsExpanded()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        var response = sqlClient.RecommendedElasticPools.ListExpanded(resGroupName, server.Name, "databases,metrics");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(2, response.RecommendedElasticPools.Count());
                        Assert.Equal(0, response.RecommendedElasticPools[0].Properties.Databases.Count);
                        Assert.Equal(3, response.RecommendedElasticPools[0].Properties.Metrics.Count);
                        Assert.Equal(1, response.RecommendedElasticPools[1].Properties.Databases.Count);
                        Assert.Equal(3, response.RecommendedElasticPools[1].Properties.Metrics.Count);
                    });
            }
        }
        

        [Fact]
        public void GetPoolByName()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        var response = sqlClient.RecommendedElasticPools.Get(resGroupName, server.Name, "ElasticPool1");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        ValidateRecommendedElasticPool(response.RecommendedElasticPool,
                            "ElasticPool1",
                            "Microsoft.Sql/servers/recommendedElasticPools",
                            "Standard",
                            1000f,
                            100.6f,
                            200.5f,
                            1000.3f,
                            DateTime.Parse("2014-11-01T00:00:00"),
                            DateTime.Parse("2014-11-15T00:00:00"),
                            900.2f,
                            350.0f);
                    });
            }
        }

        [Fact]
        public void GetDatabasesForPool()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        var response = sqlClient.RecommendedElasticPools.ListDatabases(resGroupName, server.Name, "ElasticPool1");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(1, response.Databases.Count());
                        Assert.Equal("28acaef5-d228-4660-bb67-546ec8482496", response.Databases[0].Properties.DatabaseId);
                    });
            }
        }

        [Fact]
        public void GetMetricsForPool()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    (sqlClient, resGroupName, server) =>
                    {
                        var response = sqlClient.RecommendedElasticPools.ListMetrics(resGroupName, server.Name, "ElasticPool1");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(3, response.RecommendedElasticPoolsMetrics.Count());
                        ValidateRecommendedElasticPoolMetric(
                            response.RecommendedElasticPoolsMetrics[0],
                            DateTime.Parse("4/1/2015 12:00:00 AM"),
                            100.5f,
                            15.4f);
                    });
            }
        }

        /// <summary>
        /// Validate metrics for recommended elastic pool.
        /// </summary>
        /// <param name="recommendedElasticPoolsMetric"></param>
        /// <param name="dateTime">DateTeim</param>
        /// <param name="dtu">Dtu</param>
        /// <param name="sizeGB">Size in gigabytes</param>
        private void ValidateRecommendedElasticPoolMetric(RecommendedElasticPoolMetric recommendedElasticPoolsMetric, DateTime dateTime, double dtu, double sizeGB)
        {
            Assert.Equal(recommendedElasticPoolsMetric.DateTime, dateTime);
            Assert.Equal(recommendedElasticPoolsMetric.Dtu, dtu, 2);
            Assert.Equal(recommendedElasticPoolsMetric.SizeGB, sizeGB, 2);
        }

        /// <summary>
        /// Validate recommended elastic pool properties
        /// </summary>
        /// <param name="recommendedElasticPool">Recommended elastic pool object</param>
        /// <param name="name">Name</param>
        /// <param name="type">Type</param>
        /// <param name="edition">Edition</param>
        /// <param name="dtu">Dtu</param>
        /// <param name="databaseDtuMin">Dtu min</param>
        /// <param name="databaseDtuMax">Dtu max</param>
        /// <param name="storageMB">Storage MB</param>
        /// <param name="observationPeriodStart">Observation start</param>
        /// <param name="observationPeriodEnd">Observation end</param>
        /// <param name="maxObservedDtu">Max observed Dtu</param>
        /// <param name="maxObservedStorageMB">Max observed storage MB</param>
        private void ValidateRecommendedElasticPool(RecommendedElasticPool recommendedElasticPool, string name, string type, string edition, float dtu, float databaseDtuMin, float databaseDtuMax, float storageMB, DateTime observationPeriodStart, DateTime observationPeriodEnd, float maxObservedDtu, float maxObservedStorageMB)
        {
            Assert.Equal(recommendedElasticPool.Name, name);
            Assert.Equal(recommendedElasticPool.Type, type);
            Assert.Equal(recommendedElasticPool.Properties.DatabaseEdition, edition);
            Assert.Equal(recommendedElasticPool.Properties.Dtu, dtu, 2);
            Assert.Equal(recommendedElasticPool.Properties.DatabaseDtuMin, databaseDtuMin, 2);
            Assert.Equal(recommendedElasticPool.Properties.DatabaseDtuMax, databaseDtuMax, 2);
            Assert.Equal(recommendedElasticPool.Properties.StorageMB, storageMB, 2);
            Assert.Equal(recommendedElasticPool.Properties.ObservationPeriodStart, observationPeriodStart);
            Assert.Equal(recommendedElasticPool.Properties.ObservationPeriodEnd, observationPeriodEnd);
            Assert.Equal(recommendedElasticPool.Properties.MaxObservedDtu, maxObservedDtu, 2);
            Assert.Equal(recommendedElasticPool.Properties.MaxObservedStorageMB, maxObservedStorageMB, 2);
        }
    }
}

