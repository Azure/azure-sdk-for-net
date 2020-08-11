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
        public string eventHubResourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/ofertestgroup/providers/Microsoft.EventHub/namespaces/eventHubNamespaceForClients/eventhubs/eventhubtest";
        public string storageAccountForEventGridResourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/ofertestgroup/providers/Microsoft.Storage/storageAccounts/foreventgridtest";
        public string iotHubResourceId = "/subscriptions/11d5f159-a21d-4a6c-8053-c3aae30057cf/resourceGroups/OferTestGroup/providers/Microsoft.Devices/IotHubs/ofertestiot";
        public string clientIdForPrincipal = "713c3475-5021-4f3b-a650-eaa9a83f25a4";
        public string dBprincipalMail = "oflipman@microsoft.com";
        public string consumerGroupName = "$Default";
        public readonly string tableName = "MyTest";
        public readonly string resourceGroupForTest = "ofertestgroup";
        public readonly string clusterForEventGridTest = "ofertestforclient";
        public readonly string databaseForEventGridTest = "databasetest";
        public readonly string sharedAccessPolicyNameForIotHub = "read";
        public readonly string clusterForKeyVaultPropertiesTest = "ofertestforclient";
        public readonly string KeyNameForKeyVaultPropertiesTest = "TestClientKey";
        public readonly string KeyVersionForKeyVaultPropertiesTest = "4d294ee7ce964d8bb6d04c1245276e93";
        public readonly string KeyVaultUriForKeyVaultPropertiesTest = "https://testforclient.vault.azure.net/";

        public string tenantId { get; set; }
        public string location { get; set; }
        public string subscriptionId { get; set; }
        public KustoManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }
        public string rgName { get; internal set; }
        public string clusterName { get; internal set; }
        public string followerClusterName { get; internal set; }
        public string databaseName { get; internal set; }
        public string attachedDatabaseConfigurationName { get; internal set; }
        public string eventHubConnectionName { get; internal set; }
        public string eventGridConnectinoName { get; internal set; }
        public string iotHubConnectionName { get; internal set; }
        public Dictionary<string, string> tags { get; internal set; }
        public AzureSku sku1 { get; set; }
        public AzureSku sku2 { get; set; }
        public TimeSpan? softDeletePeriod1 { get; set; }
        public TimeSpan? hotCachePeriod1 { get; set; }
        public TimeSpan? softDeletePeriod2 { get; set; }
        public TimeSpan? hotCachePeriod2 { get; set; }
        public string defaultPrincipalsModificationKind { get; set; }
        public Cluster cluster { get; set; }
        public Cluster followerCluster { get; set; }
        public ReadWriteDatabase database { get; set; }
        public AttachedDatabaseConfiguration attachedDatabaseConfiguration { get; set; }
        public EventHubDataConnection eventhubConnection { get; set; }
        public EventGridDataConnection eventGridDataConnection { get; set; }
        public IotHubDataConnection iotHubDataConnection { get; set; }
        public List<TrustedExternalTenant> trustedExternalTenants { get; set; }
        public string dataFormat { get; set; }
        public List<DatabasePrincipal> databasePrincipals { get; set; }
        public DatabasePrincipal databasePrincipal { get; set; }
        public KeyVaultProperties keyVaultProperties { get; set; }

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
            followerClusterName = TestUtilities.GenerateName("testfollower");
            databaseName = TestUtilities.GenerateName("testdatabase");
            attachedDatabaseConfigurationName = TestUtilities.GenerateName("testattacheddatabaseconfiguration");
            eventHubConnectionName = TestUtilities.GenerateName("eventhubConnection");
            eventGridConnectinoName = TestUtilities.GenerateName("eventGridConnection");
            iotHubConnectionName = TestUtilities.GenerateName("iothubConnection");

            sku1 = new AzureSku(name: "Standard_D13_v2", "Standard", capacity: 2);
            sku2 = new AzureSku(name: "Standard_D14_v2", "Standard", capacity: 2);

            trustedExternalTenants = new List<TrustedExternalTenant>(1) { new TrustedExternalTenant(this.tenantId) };

            hotCachePeriod1 = TimeSpan.FromDays(2);
            softDeletePeriod1 = TimeSpan.FromDays(4);

            hotCachePeriod2 = TimeSpan.FromDays(3);
            softDeletePeriod2 = TimeSpan.FromDays(6);
            dataFormat = "CSV";

            defaultPrincipalsModificationKind = "Replace";

            cluster = new Cluster(sku: new AzureSku(name: "Standard_D13_v2", "Standard", 2), location: this.location, trustedExternalTenants: trustedExternalTenants);
            followerCluster = new Cluster(sku: new AzureSku(name: "Standard_D13_v2", "Standard", 2), location: this.location, trustedExternalTenants: trustedExternalTenants);
            database = new ReadWriteDatabase(location: this.location, softDeletePeriod: softDeletePeriod1, hotCachePeriod: hotCachePeriod1);
            eventhubConnection = new EventHubDataConnection(eventHubResourceId, consumerGroupName, location: this.location);
            eventGridDataConnection = new EventGridDataConnection(storageAccountForEventGridResourceId, eventHubResourceId, consumerGroupName, tableName: tableName, dataFormat: dataFormat, location: location);
            iotHubDataConnection = new IotHubDataConnection(iotHubResourceId, consumerGroupName, sharedAccessPolicyNameForIotHub, location: location);

            databasePrincipal = GetDatabasePrincipalList(dBprincipalMail, "Admin");
            databasePrincipals = new List<DatabasePrincipal> {databasePrincipal};

            var leaderClusterResourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Kusto/Clusters/{clusterName}";
            attachedDatabaseConfiguration = new AttachedDatabaseConfiguration(location: this.location, databaseName: databaseName, clusterResourceId: leaderClusterResourceId, defaultPrincipalsModificationKind: defaultPrincipalsModificationKind);

            keyVaultProperties = new KeyVaultProperties(KeyNameForKeyVaultPropertiesTest, KeyVersionForKeyVaultPropertiesTest, KeyVaultUriForKeyVaultPropertiesTest);
        }

        private DatabasePrincipal GetDatabasePrincipalList(string userEmail, string role)
        {
            return new DatabasePrincipal()
            {
                Name = "User1",
                Email = userEmail,
                Fqn = $"aaduser={userEmail}",
                Role = role,
                Type = "User",
                AppId = ""
            };
        }

    }
}
