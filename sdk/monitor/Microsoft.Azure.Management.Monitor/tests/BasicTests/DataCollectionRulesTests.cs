// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Monitor.Tests.Helpers;

using Newtonsoft.Json;

using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class DataCollectionRulesTests : TestBase
    {
        #region DCR Tests
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateDataCollectionRuleTest()
        {
            DataCollectionRuleResource expectedResult = new DataCollectionRuleResource(
                new DataCollectionRuleDestinations(), 
                new List<DataFlow>(), 
                "eastus", "Second DCR", 
                new DataCollectionRuleDataSources());

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResult, insightsClient.SerializationSettings);            
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);
            
            var result = insightsClient.DataCollectionRules.Create("rg-amcs-test", "dcrCreateDataCollectionRuleTest", new DataCollectionRuleResource(
                    destinations: new DataCollectionRuleDestinations(), 
                    dataFlows: new List<DataFlow>(), 
                    location: "eastus", 
                    description: "Second DCR", 
                    dataSources: new DataCollectionRuleDataSources(), 
                    provisioningState: null, 
                    tags: null, 
                    id: null, 
                    name: null, 
                    type: null, 
                    etag: null
                ));

            AreEqual(expectedResult, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public async Task DeleteDataCollectionRuleTestAsync()
        {
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var monitorManagementClient = GetMonitorManagementClient(handler);

            var response = await monitorManagementClient.DataCollectionRules.DeleteWithHttpMessagesAsync("rg-amcs-test", "dcrDeleteDataCollectionRuleTest");
            
            Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetDataCollectionRuleTest()
        {
            var expectedResult = new DataCollectionRuleResource(
                new DataCollectionRuleDestinations(),
                new List<DataFlow>(),
                "eastus", "Second DCR",
                new DataCollectionRuleDataSources());

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResult, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);
            
            var result = insightsClient.DataCollectionRules.Get("rg-amcs-test", "dcrGetDataCollectionRuleTest");

            AreEqual(expectedResult, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListDataCollectionRulesByResourceGroupTest()
        {
            List<DataCollectionRuleResource> expectedResult = new List<DataCollectionRuleResource>
            {
                new DataCollectionRuleResource(
                    new DataCollectionRuleDestinations
                    {
                        AzureMonitorMetrics = new DestinationsSpecAzureMonitorMetrics("defaultAmm")
                    },
                    new List<DataFlow>(),
                    "eastus", "First DCR",
                    new DataCollectionRuleDataSources()),
                new DataCollectionRuleResource(new DataCollectionRuleDestinations(), new List<DataFlow>(), "eastus", "Second DCR", new DataCollectionRuleDataSources()),
                new DataCollectionRuleResource(new DataCollectionRuleDestinations(), new List<DataFlow>(), "eastus", "Third DCR", new DataCollectionRuleDataSources())
            };

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResult, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualDcrs = insightsClient.DataCollectionRules.ListByResourceGroup(resourceGroupName: "rg-amcs-test");

            AreEqual(expectedResult, actualDcrs.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListDataCollectionRulesBySusbscriptionTest()
        {
            List<DataCollectionRuleResource> expectedResult = new List<DataCollectionRuleResource>
            {
                new DataCollectionRuleResource(
                    new DataCollectionRuleDestinations
                    {
                        LogAnalytics = new List<LogAnalyticsDestination>
                        { 
                            new LogAnalyticsDestination("/subscription/aaa/", "la-testing")
                        }
                    },
                    new List<DataFlow>(),
                    "eastus", "First DCR",
                    new DataCollectionRuleDataSources()),
                new DataCollectionRuleResource(new DataCollectionRuleDestinations(), new List<DataFlow>(), "eastus", "Second DCR", new DataCollectionRuleDataSources()),
            };

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResult, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);
            
            var actualDcrs = insightsClient.DataCollectionRules.ListBySubscription();

            AreEqual(expectedResult, actualDcrs.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void UpdateDataCollectionRuleTest()
        {
            var expectedResult = new ResourceForUpdate(new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            });

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResult, insightsClient.SerializationSettings);
            
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            ActionGroupPatchBody bodyParameter = new ActionGroupPatchBody
            {
                Enabled = true,
                Tags = null
            };

            var result = insightsClient.DataCollectionRules.Update("rg-amcs-test", "dcrUpdateDataCollectionRuleTest", expectedResult);
            Utilities.AreEqual(expectedResult.Tags, result.Tags);
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

        private static void AreEqual(List<DataCollectionRuleResource> exp, List<DataCollectionRuleResource> act)
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
                Assert.Equal(exp.ScheduledTransferPeriod, act.ScheduledTransferPeriod);
                Assert.Equal(exp.Streams.ToJson(), act.Streams.ToJson());
            }
        }

        private static void AreEqual(WindowsEventLogDataSource exp, WindowsEventLogDataSource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.ScheduledTransferPeriod, act.ScheduledTransferPeriod);
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

        #region DCRA Tests
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateDataCollectionRuleAssociationTest()
        {
            var expectedResult = GetOneDcra("CreateTest");

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SerializeDcra(expectedResult, insightsClient.SerializationSettings))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var result = insightsClient.DataCollectionRuleAssociations.Create(
                resourceUri: "/subscriptions/xxxxxxx-xxxx-xxxx/resourceGroups/rgGroup/providers/Microsoft.Compute/virtualMachines/vm-Test", 
                associationName: "dcrBcdrTestAssoc", 
                body: expectedResult);

            AreEqual(expectedResult, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public async Task DeleteDataCollectionRuleAssociationTestAsync()
        {
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var monitorManagementClient = GetMonitorManagementClient(handler);

            var response = await monitorManagementClient.DataCollectionRuleAssociations.DeleteWithHttpMessagesAsync(
                resourceUri: "/subscriptions/xxxxxxx-xxxx-xxxx/resourceGroups/rgGroup/providers/Microsoft.Compute/virtualMachines/vm-Test",
                associationName: "dcrBcdrTestAssoc");

            Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetDataCollectionRuleAssociationTest()
        {
            var expectedResult = GetOneDcra("GetTest");

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SerializeDcra(expectedResult, insightsClient.SerializationSettings))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var result = insightsClient.DataCollectionRuleAssociations.Get("rg-amcs-test", "dcrAssoc");

            AreEqual(expectedResult, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListDataCollectionRulesAssociationByResourceTest()
        {
            var expectedResult = GetListDcra();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SerializeDcraList(expectedResult, insightsClient.SerializationSettings))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualDcrs = insightsClient.DataCollectionRuleAssociations.ListByResource(
                resourceUri: "/subscriptions/xxxxxxx-xxxx-xxxx/resourceGroups/rgGroup/providers/Microsoft.Compute/virtualMachines/vm-Test");

            AreEqual(expectedResult, actualDcrs.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListDataCollectionRulesAssociationByRuleTest()
        {
            var expectedResult = GetListDcra();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SerializeDcraList(expectedResult, insightsClient.SerializationSettings))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualDcrs = insightsClient.DataCollectionRuleAssociations.ListByRule(
                "rg-amcs-test", "dcrGetDataCollectionRuleTest");

            AreEqual(expectedResult, actualDcrs.ToList());
        }
        #endregion

        #region DCRA Helpers
        private DataCollectionRuleAssociationProxyOnlyResource GetOneDcra(string id) 
        { 
            return new DataCollectionRuleAssociationProxyOnlyResource(
                    dataCollectionRuleId: "/subscriptions/xxxxxxx-xxxx-xxxx/resourceGroups/rgGroup/providers/Microsoft.Insights/dataCollectionRules/dcrName",
                    description: "Associate VM to DCR",
                    provisioningState: null,
                    id: id,
                    name: "dcrBcdrTestAssoc",
                    type: "Microsoft.Insights/dataCollectionRuleAssociations",
                    etag: null
                );
        }

        private List<DataCollectionRuleAssociationProxyOnlyResource> GetListDcra()
        {
            return new List<DataCollectionRuleAssociationProxyOnlyResource> 
            { 
                GetOneDcra("First DCRA"),
                GetOneDcra("Second DCRA"),
                GetOneDcra("Third DCRA")
            };
        }

        private string SerializeDcra(DataCollectionRuleAssociationProxyOnlyResource drca, JsonSerializerSettings jsonSerializerSettings)
        {
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(drca, jsonSerializerSettings);
            var currPos = serializedObject.IndexOf("\"properties\":", 0);
            serializedObject = serializedObject.Insert(currPos, "\"name\":\"" + drca.Name + "\",\r\n\"type\":\"" + drca.Type + "\",\r\n\"id\":\"" + drca.Id + "\",\r\n");
            
            return serializedObject;
        }

        private string SerializeDcraList(List<DataCollectionRuleAssociationProxyOnlyResource> drcaList, JsonSerializerSettings jsonSerializerSettings)
        {
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(drcaList, jsonSerializerSettings);

            var startIndex = 0;
            foreach (var dcra in drcaList)
            {
                var currPos = serializedObject.IndexOf("\"properties\":", startIndex);
                serializedObject = serializedObject.Insert(currPos, "\"name\":\"" + dcra.Name + "\",\r\n\"type\":\"" + dcra.Type + "\",\r\n\"id\":\"" + dcra.Id + "\",\r\n");
                startIndex = serializedObject.IndexOf("\"properties\":", startIndex) + 1;
            }

            return string.Concat("{ \"value\":", serializedObject, "}");
        }

        private static void AreEqual(DataCollectionRuleAssociationProxyOnlyResource exp, DataCollectionRuleAssociationProxyOnlyResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.DataCollectionRuleId, act.DataCollectionRuleId);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Etag, act.Etag);
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.ProvisioningState, act.ProvisioningState);
                Assert.Equal(exp.Type, act.Type);
            }
        }

        private static void AreEqual(List<DataCollectionRuleAssociationProxyOnlyResource> exp, List<DataCollectionRuleAssociationProxyOnlyResource> act) 
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }
        #endregion
    }
}