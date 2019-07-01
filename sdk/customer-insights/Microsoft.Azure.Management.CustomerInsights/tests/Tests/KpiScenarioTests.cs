// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class KpiScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static KpiScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CrdKpiFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName = TestUtilities.GenerateName("testProfile232");
                var profileResourceFormat = Helpers.GetTestProfile(profileName);

                var kpiName = TestUtilities.GenerateName("kpiTest4545");

                var kpiResourceFormat = new KpiResourceFormat
                                            {
                                                EntityType = EntityTypes.Profile,
                                                EntityTypeName = profileName,
                                                DisplayName =
                                                    new Dictionary<string, string> { { "en-us", "Kpi DisplayName" } },
                                                Description =
                                                    new Dictionary<string, string> { { "en-us", "Kpi Description" } },
                                                CalculationWindow = CalculationWindowTypes.Day,
                                                Function = KpiFunctions.Sum,
                                                Expression = "SavingAccountBalance",
                                                GroupBy = new[] { "SavingAccountBalance" },
                                                Unit = "unit",
                                                ThresHolds =
                                                    new KpiThresholds
                                                        {
                                                            LowerLimit = 5.0m,
                                                            UpperLimit = 50.0m,
                                                            IncreasingKpi = true
                                                        },
                                                Aliases =
                                                    new[] { new KpiAlias { AliasName = "alias", Expression = "Id+4" } }
                                            };

                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName, profileResourceFormat);

                var createKpiResult = aciClient.Kpi.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    kpiName,
                    kpiResourceFormat);

                Assert.Equal(kpiName, createKpiResult.KpiName);
                Assert.Equal(createKpiResult.Name, HubName + "/" + kpiName);
                Assert.Equal("Microsoft.CustomerInsights/hubs/kpi", createKpiResult.Type);

                var getKpiResult = aciClient.Kpi.Get(ResourceGroupName, HubName, kpiName);
                Assert.Equal(kpiName, getKpiResult.KpiName);
                Assert.Equal(getKpiResult.Name, HubName + "/" + kpiName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal("Microsoft.CustomerInsights/hubs/kpi", getKpiResult.Type, StringComparer.OrdinalIgnoreCase);

                var listKpiResult = aciClient.Kpi.ListByHub(ResourceGroupName, HubName);
                Assert.True(listKpiResult.ToList().Count >= 1);
                Assert.Contains(listKpiResult.ToList(), kpiReturned => kpiName == kpiReturned.KpiName);

                var deleteKpiResult =
                    aciClient.Kpi.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, kpiName).Result;

                Assert.Equal(HttpStatusCode.OK, deleteKpiResult.Response.StatusCode);
            }
        }
    }
}