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
    /// Contains tests for service tier advisor
    /// </summary>
    public class Sql2ServiceTierAdvisorScenarioTests : TestBase
    {
        [Fact]
        public void ListServiceTierAdvisors()
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
                        var response = sqlClient.ServiceTierAdvisors.List(resGroupName, server.Name, "AdventureWorks2012");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(1, response.ServiceTierAdvisors.Count);
                        Assert.Equal("current", response.ServiceTierAdvisors[0].Name);
                        Assert.Equal("Web", response.ServiceTierAdvisors[0].Properties.CurrentServiceLevelObjective);
                        Assert.Equal("Basic", response.ServiceTierAdvisors[0].Properties.UsageBasedRecommendationServiceLevelObjective);
                        Assert.Equal(4, response.ServiceTierAdvisors[0].Properties.ServiceLevelObjectiveUsageMetrics.Count);
                        Assert.Equal("Basic", response.ServiceTierAdvisors[0].Properties.ServiceLevelObjectiveUsageMetrics[0].ServiceLevelObjective);
                    });
            }
        }

        [Fact]
        public void GetServiceTierAdvisors()
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
                        var response = sqlClient.ServiceTierAdvisors.Get(resGroupName, server.Name, "AdventureWorks2012", "Current");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal("current", response.ServiceTierAdvisor.Name);
                        Assert.Equal("Web", response.ServiceTierAdvisor.Properties.CurrentServiceLevelObjective);
                        Assert.Equal("Basic", response.ServiceTierAdvisor.Properties.UsageBasedRecommendationServiceLevelObjective);
                        Assert.Equal(4, response.ServiceTierAdvisor.Properties.ServiceLevelObjectiveUsageMetrics.Count);
                        Assert.Equal("Basic", response.ServiceTierAdvisor.Properties.ServiceLevelObjectiveUsageMetrics[0].ServiceLevelObjective);
                    });
            }
        }
        
        [Fact]
        public void GetDatabasesExpanded()
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
                        var response = sqlClient.Databases.GetExpanded(resGroupName, server.Name, "AutoScaleSterlingTest4", "upgradeHint,serviceTierAdvisors");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal("AutoScaleSterlingTest4", response.Database.Name);
                        Assert.Equal("S2", response.Database.Properties.UpgradeHint.TargetServiceLevelObjective);
                        Assert.Equal(1, response.Database.Properties.ServiceTierAdvisors.Count);
                        Assert.Equal("S3", response.Database.Properties.ServiceTierAdvisors[0].Properties.UsageBasedRecommendationServiceLevelObjective);
                        Assert.Equal(4, response.Database.Properties.ServiceTierAdvisors[0].Properties.ServiceLevelObjectiveUsageMetrics.Count);
                    });
            }
        }

        [Fact]
        public void ListDatabasesExpanded()
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
                        var response = sqlClient.Databases.ListExpanded(resGroupName, server.Name, "upgradeHint,serviceTierAdvisors");
                        TestUtilities.ValidateOperationResponse(response, HttpStatusCode.OK);
                        Assert.Equal(12, response.Databases.Count);
                        Assert.Equal("AutoScaleSterlingTest4", response.Databases[0].Name);
                        Assert.Equal("S2", response.Databases[0].Properties.UpgradeHint.TargetServiceLevelObjective);
                        Assert.Equal(1, response.Databases[0].Properties.ServiceTierAdvisors.Count);
                        Assert.Equal("S3", response.Databases[0].Properties.ServiceTierAdvisors[0].Properties.UsageBasedRecommendationServiceLevelObjective);
                        Assert.Equal(4, response.Databases[0].Properties.ServiceTierAdvisors[0].Properties.ServiceLevelObjectiveUsageMetrics.Count);
                    });
            }
        }
    }
}
