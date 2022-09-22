using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Azure.Management.Network;
using Identity = Microsoft.Azure.Management.Kusto.Models.Identity;

namespace Kusto.Tests.ScenarioTests
{
    public class KustoTestBase : TestBase
    {
        private const string TenantIdKey = "TenantId";
        private const string SubIdKey = "SubId";
        public string scriptUrl = "https://dortest.blob.core.windows.net/dor/df.txt";
        private string scriptUrlSasToken = "todo"; // TODO: when running in recording mode - use actual sas token (just token).
        public string forceUpdateTag = "tag1";
        public string forceUpdateTag2 = "tag2";
        public bool continueOnErrors = false;

        public string clientIdForPrincipal = "713c3475-5021-4f3b-a650-eaa9a83f25a4";
        public string consumerGroupName = "$Default";
        public readonly string tableName = "MyTest";
        public readonly string resourceGroupForTest = "test-clients-rg";
        public readonly string clusterForEventGridTest = "eventgridclienttest";
        public readonly string clusterForEventGridTestObjectId = "a4f74545-0569-49ab-a902-f712fcf2f9e0";
        public readonly string databaseForEventGridTest = "databasetest";
        private readonly string sharedAccessPolicyNameForIotHub = "registryRead";
        public readonly string clusterForKeyVaultPropertiesTest = "eventgridclienttest";
        public readonly string KeyNameForKeyVaultPropertiesTest = "clientstestkey";
        public readonly string KeyVersionForKeyVaultPropertiesTest = "6fd57d53ad6b4b53bacb062c98c761a0";
        public readonly string KeyVaultUriForKeyVaultPropertiesTest = "https://clientstestkv.vault.azure.net/";
        public readonly string MultiDatabaseRouting = "Multi";
        public readonly string scriptName = "dor";
        public readonly string dataFormat = "CSV";
        public readonly string defaultPrincipalsModificationKind = "Replace";
        public readonly string principaName = "principal1";
        public readonly string principalAadObjectId = "3c634984-c431-4b6a-ad59-f27ccd22708b";
        public readonly string clusterPrincipalRole = "AllDatabasesAdmin";
        public readonly string databasePrincipalRole = "Viewer";
        public readonly string principalType = "App";
        public readonly string runningState = "Running";
        public readonly string stoppedState = "Stopped";
        public readonly string databaseShareOrigin = "Direct";
        public readonly DateTime retrievalStartDate = DateTime.MinValue;
        public string tenantId { get; }
        public string location { get; }
        private string subscriptionId { get; }
        public KustoManagementClient client { get; }
        public NetworkManagementClient networkManagementClient { get; }
        private ResourceManagementClient resourcesClient { get; }
        public string rgName { get; internal set; }
        public string clusterName { get; internal set; }
        public string followerClusterName { get; internal set; }
        public string databaseName { get; internal set; }
        public string attachedDatabaseConfigurationName { get; internal set; }
        public string eventHubConnectionName { get; internal set; }
        public string eventGridConnectinoName { get; internal set; }
        public string iotHubConnectionName { get; internal set; }
        public string privateEndpointConnectionName { get; internal set; }
        public string managedPrivateEndpointName { get; internal set; }
        public string privateNetworkSubnetId { get; internal set; }
        public string iotHubResourceId { get; internal set; }
        public string eventHubResourceId { get; internal set; }
        public string eventHubNamespaceResourceId { get; internal set; }
        public string clusterForEventGridTestResourceId { get; internal set; }
        public string storageAccountForEventGridResourceId { get; internal set; }
        public string leaderClusterResourceId { get; internal set; }
        public string followerClusterResourceId { get; internal set; }
        public AzureSku sku1 { get; set; }
        public AzureSku sku2 { get; set; }
        public TimeSpan? softDeletePeriod1 { get; set; }
        public TimeSpan? hotCachePeriod1 { get; set; }
        public TimeSpan? softDeletePeriod2 { get; set; }
        public TimeSpan? hotCachePeriod2 { get; set; }
        public Cluster cluster { get; set; }
        private Cluster followerCluster { get; set; }
        public ReadWriteDatabase database { get; set; }
        public AttachedDatabaseConfiguration attachedDatabaseConfiguration { get; set; }
        public EventHubDataConnection eventhubConnection { get; set; }
        public EventGridDataConnection eventGridDataConnection { get; set; }
        public IotHubDataConnection iotHubDataConnection { get; set; }
        public Script script { get; set; }
        public List<TrustedExternalTenant> trustedExternalTenants { get; set; }
        public KeyVaultProperties keyVaultProperties { get; set; }
        public TableLevelSharingProperties tableLevelSharingProperties { get; set; }

        public KustoTestBase(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            networkManagementClient = context.GetServiceClient<NetworkManagementClient>();
            client = context.GetServiceClient<KustoManagementClient>();
            resourcesClient = context.GetServiceClient<ResourceManagementClient>();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = testEnv.Tenant;
                subscriptionId = testEnv.SubscriptionId;
                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[SubIdKey] = subscriptionId;

                var provider = resourcesClient.Providers.Get("Microsoft.Kusto");
                location = provider.ResourceTypes.Where(
                    (resType) =>
                    {
                        if (resType.ResourceType == "clusters")
                        {
                            return true;
                        }
                        return false;
                    }
                ).First().Locations.FirstOrDefault();
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                location = "";
                tenantId = HttpMockServer.Variables[TenantIdKey];
                subscriptionId = HttpMockServer.Variables[SubIdKey];
            }

            Initialize();
        }

        private void Initialize()
        {
            rgName = TestUtilities.GenerateName("sdktestrg");
            resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

            clusterName = TestUtilities.GenerateName("testcluster");
            followerClusterName = TestUtilities.GenerateName("testfollower");
            databaseName = TestUtilities.GenerateName("testdatabase");
            attachedDatabaseConfigurationName = TestUtilities.GenerateName("testattacheddatabaseconfiguration");
            eventHubConnectionName = TestUtilities.GenerateName("eventhubConnection");
            eventGridConnectinoName = TestUtilities.GenerateName("eventGridConnection");
            iotHubConnectionName = TestUtilities.GenerateName("iothubConnection");
            privateEndpointConnectionName = TestUtilities.GenerateName("privateendpointname");
            managedPrivateEndpointName = TestUtilities.GenerateName("managedprivateendpointname");

            clusterForEventGridTestResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupForTest}/providers/Microsoft.Kusto/Clusters/{clusterForEventGridTest}";
            eventHubNamespaceResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.EventHub/namespaces/testclientsns22";
            eventHubResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.EventHub/namespaces/testclientsns22/eventhubs/testclientseh";
            storageAccountForEventGridResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.Storage/storageAccounts/testclients";
            iotHubResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.Devices/IotHubs/test-clients-iot";
            privateNetworkSubnetId = $"/subscriptions/{subscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.Network/virtualNetworks/test-clients-vnet/subnets/default";
            leaderClusterResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Kusto/Clusters/{clusterName}";
            followerClusterResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Kusto/Clusters/{followerClusterName}";

            sku1 = new AzureSku(name: "Standard_D13_v2", "Standard", capacity: 2);
            sku2 = new AzureSku(name: "Standard_D14_v2", "Standard", capacity: 2);

            trustedExternalTenants = new List<TrustedExternalTenant>(1) { new TrustedExternalTenant(this.tenantId) };

            hotCachePeriod1 = TimeSpan.FromDays(2);
            softDeletePeriod1 = TimeSpan.FromDays(4);

            hotCachePeriod2 = TimeSpan.FromDays(3);
            softDeletePeriod2 = TimeSpan.FromDays(6);

            cluster = new Cluster(sku: new AzureSku(name: "Standard_D13_v2", "Standard", 2), location: location, trustedExternalTenants: trustedExternalTenants,  identity: new Identity(IdentityType.SystemAssigned));
            followerCluster = new Cluster(sku: new AzureSku(name: "Standard_D13_v2", "Standard", 2), location: location, trustedExternalTenants: trustedExternalTenants);
            database = new ReadWriteDatabase(location: location, softDeletePeriod: softDeletePeriod1, hotCachePeriod: hotCachePeriod1);
            eventhubConnection = new EventHubDataConnection(eventHubResourceId, consumerGroupName, location: location);
            eventGridDataConnection = new EventGridDataConnection(storageAccountForEventGridResourceId, eventHubResourceId, consumerGroupName, tableName: tableName, dataFormat: dataFormat, location: location);
            iotHubDataConnection = new IotHubDataConnection(iotHubResourceId, consumerGroupName, sharedAccessPolicyNameForIotHub, location: location);
            script = new Script( scriptUrl: scriptUrl, scriptUrlSasToken: scriptUrlSasToken, forceUpdateTag: forceUpdateTag, continueOnErrors: continueOnErrors);

            attachedDatabaseConfiguration = new AttachedDatabaseConfiguration(databaseName, leaderClusterResourceId, defaultPrincipalsModificationKind, location: location);
            keyVaultProperties = new KeyVaultProperties(KeyNameForKeyVaultPropertiesTest, KeyVersionForKeyVaultPropertiesTest, KeyVaultUriForKeyVaultPropertiesTest);
            tableLevelSharingProperties = new TableLevelSharingProperties(
                new List<string> {"tableToInclude"}, new List<string> {"tableToExclude"},
                new List<string> {"externalTableToInclude"}, new List<string> {"externalTableToExclude"},
                new List<string> {"materializedViewToInclude"}, new List<string> {"materializedViewToExclude"});
        }
    }
}
