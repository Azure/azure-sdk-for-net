using System;
using System.Linq;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;

namespace KeyVault.Management.Tests
{
    public class KeyVaultTestBase : TestBase
    {
        private const string TenantIdKey = "TenantId";
        private const string ObjectIdKey = "ObjectId";
        private const string LocationKey = "location";
        private const string SubIdKey = "SubId";
        private const string ApplicationIdKey = "ApplicationId";

        public string tenantId { get; set; }
        public string objectId { get; set; }
        public string applicationId { get; set; }
        public string location { get; set; }
        public string subscriptionId { get; set; }

        public KeyVaultManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }
        public KeyVaultTestBase()
        {
            var testFactory = new CSMTestEnvironmentFactory();
            var testEnv = testFactory.GetTestEnvironment();
            this.client = GetServiceClient<KeyVaultManagementClient>(testFactory);
            this.resourcesClient = GetServiceClient<ResourceManagementClient>(testFactory);
            
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.tenantId = testEnv.AuthorizationContext.TenantId;
                this.subscriptionId = testEnv.SubscriptionId;
                var graphClient = GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);
                this.objectId = graphClient.User.Get(testEnv.AuthorizationContext.UserId).User.ObjectId;
                this.applicationId = Guid.NewGuid().ToString();                
                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[ObjectIdKey] = objectId;
                HttpMockServer.Variables[SubIdKey] = subscriptionId;
                HttpMockServer.Variables[ApplicationIdKey] = applicationId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables[TenantIdKey];
                objectId = HttpMockServer.Variables[ObjectIdKey];
                subscriptionId = HttpMockServer.Variables[SubIdKey];
                applicationId = HttpMockServer.Variables[ApplicationIdKey];
            }

            var providers = resourcesClient.Providers.Get("Microsoft.KeyVault");
            this.location = providers.Provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.Name == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();

        }
    }
}
