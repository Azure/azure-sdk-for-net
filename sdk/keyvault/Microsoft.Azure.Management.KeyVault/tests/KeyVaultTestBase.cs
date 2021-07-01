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
using Microsoft.Azure.Management.KeyVault.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Models;

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
        public AccessPolicyEntry accPol { get; internal set; }
        public string objectIdGuid { get; internal set; }
        public string rgName { get; internal set; }
        public Dictionary<string, string> tags { get; internal set; }
        public Guid tenantIdGuid { get; internal set; }
        public string vaultName { get; internal set; }
        public VaultProperties vaultProperties { get; internal set; }

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
                graphClient.BaseUri = testEnv.Endpoints.GraphUri;
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

            Initialize();
        }

        private void Initialize()
        {
            rgName = TestUtilities.GenerateName("sdktestrg");
            resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

            vaultName = TestUtilities.GenerateName("sdktestvault");
            tenantIdGuid = Guid.Parse(tenantId);
            objectIdGuid = objectId;
            tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };
            accPol = new AccessPolicyEntry
            {
                TenantId = tenantIdGuid,
                ObjectId = objectIdGuid,
                Permissions = new Permissions
                {
                    Keys = new string[] { KeyPermissions.All },
                    Secrets = new string[] { SecretPermissions.All },
                    Certificates = new string[] { CertificatePermissions.All },
                    Storage = new string[] { StoragePermissions.All },
                }
            };

            IList < IPRule > ipRules = new List<IPRule>();
            ipRules.Add(new IPRule() { Value = "1.2.3.4/32" });
            ipRules.Add(new IPRule() { Value = "1.0.0.0/25" });

            vaultProperties = new VaultProperties
            {
                EnabledForDeployment = true,
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
                EnableSoftDelete = true,
                Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku { Name = SkuName.Standard },
                TenantId = tenantIdGuid,
                VaultUri = "",
                NetworkAcls = new NetworkRuleSet() { Bypass = "AzureServices", DefaultAction = "Allow", IpRules = ipRules, VirtualNetworkRules = null },
                AccessPolicies = new[] { accPol }
            };
        }
    }
}