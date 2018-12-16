using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Reflection;
using Microsoft.Azure.Management.Kusto.Models;

namespace Kusto.Tests.ScenarioTests
{
    public class KustoTestBase : TestBase
    {
        private const string TenantIdKey = "TenantId";
        private const string ObjectIdKey = "ObjectId";
        private const string LocationKey = "location";
        private const string SubIdKey = "SubId";
        private const string ApplicationIdKey = "ApplicationId";
        public string eventHubResourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/ofertestgroup/providers/Microsoft.EventHub/namespaces/eventHubForClients/eventhubs/eventhubtest";
        public string consumerGroupName = "consumergrouptest";
        public string databaseForNestedResourceName = "testDbForClients";
        public string clusterForNestedResourceName = "kustoclusterforclients";
        public string resourceGroupForNestedResourcesName = "ofertestgroup";
        public string locationForNestedResources = "Central US";
        public string tableNameForNestedResources1 = "TestTableForClients";
        public string tableNameForNestedResources2 = "TestTableForClients2";
        public string MappingNameForNestedResources1 = "TestIngestionMappingForTable1";
        public string MappingNameForNestedResources2 = "TestIngestionMappingForTable2";
        public string dataFormat = "CSV";



        public string tenantId { get; set; }
        public string location { get; set; }
        public string subscriptionId { get; set; }
        public KustoManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }
        public string rgName { get; internal set; }
        public string clusterName { get; internal set; }
        public string databaseName { get; internal set; }
        public string eventHubConnectionName { get; internal set; }
        public Dictionary<string, string> tags { get; internal set; }
        public AzureSku sku1 { get; set; }
        public AzureSku sku2 { get; set; }
        public int softDeletePeriodInDays1 { get; set; }
        public int hotCachePeriodInDays1 { get; set; }
        public int softDeletePeriodInDays2 { get; set; }
        public int hotCachePeriodInDays2 { get; set; }
        public string eventHubName { get; set; }
        public Cluster cluster { get; set; }
        public Database database { get; set; }
        public EventHubConnection eventhubConnection { get; set; }
        public List<TrustedExternalTenant> trustedExternalTenants { get; set; }

        public KustoTestBase(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            this.client = context.GetServiceClient<KustoManagementClient>();
            this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.tenantId = testEnv.Tenant;
                this.subscriptionId = testEnv.SubscriptionId;
                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[SubIdKey] = subscriptionId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables[TenantIdKey];
                subscriptionId = HttpMockServer.Variables[SubIdKey];
            }

            var provider = resourcesClient.Providers.Get("Microsoft.Kusto");
            this.location = provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "clusters")
                    {
                        return true;
                    }
                    return false;
                }
            ).First().Locations.FirstOrDefault();

            Initialize();
        }

        private void Initialize()
        {
            rgName = TestUtilities.GenerateName("sdktestrg");
            resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = this.location });

            clusterName = TestUtilities.GenerateName("testcluster");
            databaseName = TestUtilities.GenerateName("testdatabase");
            eventHubConnectionName = TestUtilities.GenerateName("eventhubConection");

            sku1 = new AzureSku(name: "D13_v2", capacity: 2);
            sku2 = new AzureSku(name: "D14_v2", capacity: 2);

            trustedExternalTenants = new List<TrustedExternalTenant>(1) {new TrustedExternalTenant(this.tenantId)};

            hotCachePeriodInDays1 = 2;
            softDeletePeriodInDays1 = 4;

            hotCachePeriodInDays2 = 3;
            softDeletePeriodInDays2 = 6;

            cluster = new Cluster(sku: new AzureSku(name: "D13_v2"), location: this.location, trustedExternalTenants: trustedExternalTenants);
            database = new Database(this.location, softDeletePeriodInDays1, hotCachePeriodInDays: hotCachePeriodInDays1);
            eventhubConnection = new EventHubConnection(eventHubResourceId, consumerGroupName, location: this.location, tableName: tableNameForNestedResources1, mappingRuleName: MappingNameForNestedResources1, dataFormat: dataFormat);
        }
    }
}