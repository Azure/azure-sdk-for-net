// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Monitor.Tests.Scenarios
{
    /** commenting this out because DataCollectionRules have a different error response format from everything else in AzureMonitor and so they can't be built with this SDK.
    public class DataCollectionRulesTests : TestBase
    {
        private const string ResourceGroupName = "netSdkTestRecord";
        private const string vmResourceUri = "/subscriptions/b97224f3-b199-49b1-84c7-25b09e8fbf84/resourcegroups/netSdkTestRecord/providers/Microsoft.Compute/virtualMachines/vm-dcrTestRecordSession";

        private RecordedDelegatingHandler handler;

        public DataCollectionRulesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        #region DCR
        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateDcrTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dcrName = "dcrSdkCreateTest";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dcr = CreateDcr(insightsClient, dcrName);
                Assert.NotNull(dcr);

                var dcrFromGet = insightsClient.DataCollectionRules.Get(ResourceGroupName, dcrName);
                insightsClient.DataCollectionRules.Delete(ResourceGroupName, dcrName);

                AreEqual(dcr, dcrFromGet);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DeleteDcrTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dcrName = "dcrSdkDeleteTest";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                var dcrDelete = CreateDcr(insightsClient, dcrName); ;

                Assert.NotNull(dcrDelete);

                var dcrList = insightsClient.DataCollectionRules.ListByResourceGroup(ResourceGroupName).ToList();
                Assert.Equal(1, dcrList.Count(x => x.Name == dcrName));

                insightsClient.DataCollectionRules.Delete(ResourceGroupName, dcrName);

                dcrList = insightsClient.DataCollectionRules.ListByResourceGroup(ResourceGroupName).ToList();
                Assert.Equal(0, dcrList.Count(x => x.Name == dcrName));
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListDcrBySubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string[] dcrNames = { "dcrListOneTest", "dcrListTwoTest", "dcrListThreeTest", "dcrListFourTest" }; ;
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                foreach (var dcrName in dcrNames) _ = CreateDcr(insightsClient, dcrName);

                var dcrList = insightsClient.DataCollectionRules.ListBySubscription().ToList();

                Assert.NotNull(dcrList);
                Assert.True(dcrList.Count >= 3, "List must be greather than 3 items");

                foreach (var dcrName in dcrNames)
                {
                    Assert.Equal(1, dcrList.Count(x => x.Name == dcrName));
                }

                foreach (var dcrName in dcrNames) insightsClient.DataCollectionRules.Delete(ResourceGroupName, dcrName);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void UpdateDcrTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dcrName = "dcrSdkUpdateTest";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dcr = CreateDcr(insightsClient, dcrName);
                Assert.NotNull(dcr);

                dcr = insightsClient.DataCollectionRules.Update(ResourceGroupName, dcrName, new Dictionary<string, string>
                {
                    { "TagUpdated", "ValueUpdate" }
                });
                Assert.NotNull(dcr);

                var dcrList = insightsClient.DataCollectionRules.ListByResourceGroup(ResourceGroupName).ToList();
                dcr = dcrList.FirstOrDefault(x => x.Name == dcrName);
                Assert.NotNull(dcr);
                Assert.True(dcr.Tags.Count == 1);
                Assert.Equal("TagUpdated", dcr.Tags.Keys.First());
                Assert.Equal("ValueUpdate", dcr.Tags["TagUpdated"]);

                insightsClient.DataCollectionRules.Delete(ResourceGroupName, dcrName);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ErrorResponseDcrTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dcrName = "dcrError";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dcrWithBadStream = new DataCollectionRuleResource
                {
                    Location = "eastus",
                    DataSources = new DataCollectionRuleDataSources
                    {
                        PerformanceCounters = new List<PerfCounterDataSource>
                            {
                                new PerfCounterDataSource
                                {
                                    Name = "perfCounterDataSource1",
                                    Streams = new List<string> { "Microsoft-UnknownStream" },
                                    SamplingFrequencyInSeconds = 10,
                                    CounterSpecifiers = new List<string>
                                    {
                                        "\\Memory\\% Committed Bytes In Use",
                                        "\\Memory\\Available Bytes",
                                        "\\Network Interface(*)\\Bytes Received/sec",
                                    }
                                }
                            }
                    },
                    Destinations = new DataCollectionRuleDestinations
                    {
                        AzureMonitorMetrics = new DestinationsSpecAzureMonitorMetrics { Name = "ammDestination" }
                    },
                    DataFlows = new List<DataFlow>
                        {
                            new DataFlow
                            {
                                Streams = new List<string>{ "Microsoft-UnknownStream" },
                                Destinations = new List<string>{ "ammDestination" }
                            }
                        }
                };

                try
                {
                    insightsClient.DataCollectionRules.Create(ResourceGroupName, dcrName, dcrWithBadStream);
                    Assert.True(false, "ErrorResponseException expected.");
                }
                catch (ErrorResponseCommonV2Exception monitorError) 
                {
                    Assert.NotNull(monitorError.Body?.Error);
                    Assert.Equal("Operation returned an invalid status code 'BadRequest'", monitorError.Message);

                    var errorDetail = monitorError.Body.Error;
                    Assert.Equal("Data collection rule is invalid", errorDetail.Message);
                    Assert.Equal("InvalidPayload", errorDetail.Code);

                    Assert.NotNull(errorDetail.Details);
                    Assert.Equal(2, errorDetail.Details.Count);

                    var errorDetailOne = errorDetail.Details[0];
                    Assert.Equal("InvalidStream", errorDetailOne.Code);
                    Assert.Equal("'Streams' item 0 must have one of the allowed values: Microsoft-InsightsMetrics,Microsoft-Perf.", errorDetailOne.Message);
                    Assert.Equal("Properties.DataSources.PerformanceCounters[0].Streams[0]", errorDetailOne.Target);

                    var errorDetailTwo = errorDetail.Details[1];
                    Assert.Equal("InvalidStream", errorDetailTwo.Code);
                    Assert.Equal("'Streams' item 0 must have one of the allowed values: Microsoft-AntiMalwareStatus,Microsoft-Auditd,Microsoft-CiscoAsa,Microsoft-CommonSecurityLog,Microsoft-ComputerGroup,Microsoft-ConfigurationChange,Microsoft-ContainerInventory,Microsoft-ContainerLog,Microsoft-ContainerLogV2,Microsoft-ContainerNodeInventory,Microsoft-DefenderForSqlAlerts,Microsoft-DefenderForSqlLogins,Microsoft-DefenderForSqlScanEvents,Microsoft-DefenderForSqlScanResults,Microsoft-DefenderForSqlTelemetry,Microsoft-Event,Microsoft-FirewallLog,Microsoft-HealthStateChange,Microsoft-Heartbeat,Microsoft-InsightsMetrics,Microsoft-KubeEvents,Microsoft-KubeHealth,Microsoft-KubeMonAgentEvents,Microsoft-KubeNodeInventory,Microsoft-KubePodInventory,Microsoft-KubePVInventory,Microsoft-KubeServices,Microsoft-NWConnectionMonitorPathResult,Microsoft-NWConnectionMonitorTestResult,Microsoft-OperationLog,Microsoft-OperationJson,Microsoft-Perf,Microsoft-ProcessInvestigator,Microsoft-ProtectionStatus,Microsoft-RomeDetectionEvent,Microsoft-SecurityBaseline,Microsoft-SecurityBaselineSummary,Microsoft-SecurityEvent,Microsoft-ServiceMap,Microsoft-SqlAtpStatus-DefenderForSql,Microsoft-Syslog,Microsoft-WindowsEvent,Microsoft-WorkloadDiagnosticLogs,Microsoft-CommonSecurityLog-Raw.", errorDetailTwo.Message);
                    Assert.Equal("Properties.DataFlows[0].Streams[0]", errorDetailTwo.Target);
                }
                catch (System.Exception)
                {
                    Assert.True(false, "General exception not expected");
                }
            }
        }
        #endregion

        #region DCRA
        [Fact]
        [Trait("Category", "Scenario")]
        public void DcrAssociationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dcrName = "dcraSdkCreateTest";
                var dcraName = "dcraSdkCreateTestAssoc";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dcr = CreateDcr(insightsClient, dcrName);
                Assert.NotNull(dcr);

                var dcra = insightsClient.DataCollectionRuleAssociations.Create(vmResourceUri, dcraName, new DataCollectionRuleAssociationProxyOnlyResource
                {
                    DataCollectionRuleId = dcr.Id,
                    Description = "Assoc with virtual machine"
                });
                Assert.NotNull(dcra);

                var dcraListByRule = insightsClient.DataCollectionRuleAssociations.ListByRule(ResourceGroupName, dcrName);
                Assert.Equal(1, dcraListByRule.Count(x => x.Name == dcraName.ToLower()));

                var dcraListByResource = insightsClient.DataCollectionRuleAssociations.ListByResource(vmResourceUri);
                Assert.Equal(1, dcraListByResource.Count(x => x.Name == dcraName));

                var dcraFromGet = insightsClient.DataCollectionRuleAssociations.Get(vmResourceUri, dcraName);
                AreEqual(dcra, dcraFromGet);

                insightsClient.DataCollectionRuleAssociations.Delete(vmResourceUri, dcra.Name);
                insightsClient.DataCollectionRules.Delete(ResourceGroupName, dcrName);
            }
        }
        #endregion

        #region DCRE
        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateDceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dceName = "createTestDce";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dce = CreateDce(insightsClient, dceName);
                Assert.NotNull(dce);

                var dceFromGet = insightsClient.DataCollectionEndpoints.Get(ResourceGroupName, dceName);
                insightsClient.DataCollectionEndpoints.Delete(ResourceGroupName, dceName);

                AreEqual(dce, dceFromGet);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DeleteDceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dceName = "deleteTestDce";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                var dceDelete = CreateDce(insightsClient, dceName); ;

                Assert.NotNull(dceDelete);

                var dceList = insightsClient.DataCollectionEndpoints.ListByResourceGroup(ResourceGroupName).ToList();
                Assert.Equal(1, dceList.Count(x => x.Name == dceName));

                insightsClient.DataCollectionEndpoints.Delete(ResourceGroupName, dceName);

                dceList = insightsClient.DataCollectionEndpoints.ListByResourceGroup(ResourceGroupName).ToList();
                Assert.Equal(0, dceList.Count(x => x.Name == dceName));
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListDceBySubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string[] dceNames = { "dceListOneTest", "dceListTwoTest", "dceListThreeTest", "dceListFourTest" }; ;
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                foreach (var dceName in dceNames) _ = CreateDce(insightsClient, dceName);

                var dceList = insightsClient.DataCollectionEndpoints.ListBySubscription().ToList();

                Assert.NotNull(dceList);
                Assert.True(dceList.Count >= 3, "List must be greather than 3 items");

                foreach (var dceName in dceNames)
                {
                    Assert.Equal(1, dceList.Count(x => x.Name == dceName));
                }

                foreach (var dceName in dceNames) insightsClient.DataCollectionEndpoints.Delete(ResourceGroupName, dceName);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void UpdateDceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var dceName = "dceSdkUpdateTest";
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);

                var dce = CreateDce(insightsClient, dceName);
                Assert.NotNull(dce);

                dce = insightsClient.DataCollectionEndpoints.Update(ResourceGroupName, dceName, new Dictionary<string, string>
                {
                    { "TagUpdated", "ValueUpdate" }
                });
                Assert.NotNull(dce);

                var dcrList = insightsClient.DataCollectionEndpoints.ListByResourceGroup(ResourceGroupName).ToList();
                dce = dcrList.FirstOrDefault(x => x.Name == dceName);
                Assert.NotNull(dce);
                Assert.True(dce.Tags.Count == 1);
                Assert.Equal("TagUpdated", dce.Tags.Keys.First());
                Assert.Equal("ValueUpdate", dce.Tags["TagUpdated"]);

                insightsClient.DataCollectionEndpoints.Delete(ResourceGroupName, dceName);
            }
        }
        #endregion

        #region Helpers
        private DataCollectionRuleResource CreateDcr(MonitorManagementClient insightsClient, string dcrName)
        {
            return insightsClient.DataCollectionRules.Create(
                    resourceGroupName: ResourceGroupName,
                    dataCollectionRuleName: dcrName,
                    new DataCollectionRuleResource
                    {
                        Location = "eastus",
                        Tags = new Dictionary<string, string>
                        {
                            { "tagOne", "valueOne" },
                            { "tagTwo", "valueTwo" }
                        },
                        DataSources = new DataCollectionRuleDataSources
                        {
                            PerformanceCounters = new List<PerfCounterDataSource>
                            {
                                new PerfCounterDataSource
                                {
                                    Name = "perfCounterDataSource1",
                                    Streams = new List<string> { "Microsoft-InsightsMetrics" },
                                    SamplingFrequencyInSeconds = 10,
                                    CounterSpecifiers = new List<string>
                                    {
                                        "\\Memory\\% Committed Bytes In Use",
                                        "\\Memory\\Available Bytes",
                                        "\\Network Interface(*)\\Bytes Received/sec",
                                    }
                                }
                            }
                        },
                        Destinations = new DataCollectionRuleDestinations
                        {
                            AzureMonitorMetrics = new DestinationsSpecAzureMonitorMetrics { Name = "ammDestination" }
                        },
                        DataFlows = new List<DataFlow>
                        {
                            new DataFlow
                            {
                                Streams = new List<string>{ "Microsoft-InsightsMetrics" },
                                Destinations = new List<string>{ "ammDestination" }
                            }
                        }
                    }
                );
        }

        private DataCollectionEndpointResource CreateDce(MonitorManagementClient insightsClient, string dceName)
        {
            return insightsClient.DataCollectionEndpoints.Create(
                resourceGroupName: ResourceGroupName,
                dataCollectionEndpointName: dceName,
                body: new DataCollectionEndpointResource
                {
                    Location = "eastus2euap",
                    Tags = new Dictionary<string, string>
                        {
                            { "tagOne", "valueOne" },
                            { "tagTwo", "valueTwo" }
                        },
                    NetworkAcls = new DataCollectionEndpointNetworkAcls { PublicNetworkAccess = "Enabled" }
                });
        }
        #endregion

        #region DCR AreEqual Helpers
        private static void AreEqual(DataCollectionRuleResource exp, DataCollectionRuleResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Etag, act.Etag);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.ProvisioningState, act.ProvisioningState);
                Assert.Equal(exp.Type, act.Type);
                Utilities.AreEqual(exp.Tags, act.Tags);

                AreEqual(exp.DataFlows, act.DataFlows);
                AreEqual(exp.DataSources, act.DataSources);
                AreEqual(exp.Destinations, act.Destinations);
            }
        }

        private static void AreEqual(IList<DataFlow> exp, IList<DataFlow> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(DataCollectionRuleDataSources exp, DataCollectionRuleDataSources act)
        {
            if (exp != null)
            {
                if (exp.PerformanceCounters != null)
                {
                    for (int i = 0; i < exp.PerformanceCounters.Count; i++)
                    {
                        AreEqual(exp.PerformanceCounters[i], act.PerformanceCounters[i]);
                    }
                }

                if (exp.WindowsEventLogs != null)
                {
                    for (int i = 0; i < exp.WindowsEventLogs.Count; i++)
                    {
                        AreEqual(exp.WindowsEventLogs[i], act.WindowsEventLogs[i]);
                    }
                }

                if (exp.Syslog != null)
                {
                    for (int i = 0; i < exp.Syslog.Count; i++)
                    {
                        AreEqual(exp.Syslog[i], act.Syslog[i]);
                    }
                }

                if (exp.Extensions != null)
                {
                    for (int i = 0; i < exp.Extensions.Count; i++)
                    {
                        AreEqual(exp.Extensions[i], act.Extensions[i]);
                    }
                }
            }
        }

        private static void AreEqual(DataCollectionRuleDestinations exp, DataCollectionRuleDestinations act)
        {
            if (exp != null)
            {
                if (exp.AzureMonitorMetrics != null)
                {
                    Assert.Equal(exp.AzureMonitorMetrics.Name, act.AzureMonitorMetrics.Name);
                }

                if (exp.LogAnalytics != null)
                {
                    for (int i = 0; i < exp.LogAnalytics.Count; i++)
                    {
                        AreEqual(exp.LogAnalytics[i], act.LogAnalytics[i]);
                    }
                }
            }
        }

        private static void AreEqual(DataFlow exp, DataFlow act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Destinations.ToJson(), act.Destinations.ToJson());
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
            }
        }

        private static void AreEqual(PerfCounterDataSource exp, PerfCounterDataSource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.CounterSpecifiers.ToJson(), act.CounterSpecifiers.ToJson());
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.SamplingFrequencyInSeconds, act.SamplingFrequencyInSeconds);
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
            }
        }

        private static void AreEqual(WindowsEventLogDataSource exp, WindowsEventLogDataSource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
                Assert.Equal(exp.XPathQueries.ToJson(), act.XPathQueries.ToJson());
            }
        }

        private static void AreEqual(SyslogDataSource exp, SyslogDataSource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.FacilityNames.ToJson(), act.FacilityNames.ToJson());
                Assert.Equal(exp.LogLevels.ToJson(), act.LogLevels.ToJson());
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
            }
        }

        private static void AreEqual(ExtensionDataSource exp, ExtensionDataSource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ExtensionName, act.ExtensionName);
                Assert.Equal(exp.ExtensionSettings.ToJson(), act.ExtensionSettings.ToJson());
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
            }
        }

        private static void AreEqual(LogAnalyticsDestination exp, LogAnalyticsDestination act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.WorkspaceResourceId, act.WorkspaceResourceId);
            }
        }
        #endregion

        #region DCRA AreEqual Helpers
        private static void AreEqual(DataCollectionRuleAssociationProxyOnlyResource exp, DataCollectionRuleAssociationProxyOnlyResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.DataCollectionRuleId.ToLower(), act.DataCollectionRuleId.ToLower());
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Etag, act.Etag);
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.ProvisioningState, act.ProvisioningState);
                Assert.Equal(exp.Type, act.Type);
            }
        }
        #endregion

        #region DCE AreEqual Helpers
        private static void AreEqual(DataCollectionEndpointResource exp, DataCollectionEndpointResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Etag, act.Etag);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.ProvisioningState, act.ProvisioningState);
                Assert.Equal(exp.Type, act.Type);
                Assert.Equal(exp.Kind, act.Kind);
                Assert.Equal(exp.ImmutableId, act.ImmutableId);
                Utilities.AreEqual(exp.Tags, act.Tags);

                Assert.Equal(exp?.ConfigurationAccess?.Endpoint, act?.ConfigurationAccess?.Endpoint);
                Assert.Equal(exp?.LogsIngestion?.Endpoint, act?.LogsIngestion?.Endpoint);
                Assert.Equal(exp?.NetworkAcls?.PublicNetworkAccess, act?.NetworkAcls?.PublicNetworkAccess);
            }
        }
        #endregion
    }
    */
}
