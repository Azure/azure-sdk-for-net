// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

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
        public KeyVaultTestBase(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            this.client = context.GetServiceClient<KeyVaultManagementClient>();
            this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.tenantId = testEnv.Tenant;
                this.subscriptionId = testEnv.SubscriptionId;
                var graphClient = context.GetServiceClient<GraphRbacManagementClient>();
                graphClient.TenantID = this.tenantId;
                graphClient.BaseUri = new Uri("https://graph.windows.net");
                this.objectId = graphClient.User.Get(testEnv.UserName).ObjectId;
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

            var provider = resourcesClient.Providers.Get("Microsoft.KeyVault");
            this.location = provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();

        }
    }
}