// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class WorkspaceTests : ManagementRecordedTestBase<MachineLearningTestEnvironment>
    {
        private readonly string _location = "southcentralus";

        private ResourceGroup _resourceGroup;
        private Subscription _subscription;
        private string _appInsigntsId;
        private string _keyVaultId;
        private string _storageAccountId;
        private Workspace _workspace;

        public WorkspaceTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {}

        [RecordedTest]
        public async Task WorkspaceCrud()
        {
            // create
            var workspaceName = Recording.GenerateAssetName("mlsWorkspace");
            var workspaceData = new WorkspaceData()
            {
                Location = _location,
                ApplicationInsights = _appInsigntsId,
                KeyVault = _keyVaultId,
                StorageAccount = _storageAccountId,
                Identity = new Identity()
                {
                    //Type = ResourceIdentityType.None // => "message": "Make sure to create your workspace using a client which support MSI",
                    Type = ResourceIdentityType.SystemAssigned
                },
            };
            //workspaceData.Tags.Add("for", "test"); // or else when deserializing tags => System.Text.Json.JsonException : A property 'tags' defined as non-nullable but received as null from the service. This exception only happens in DEBUG builds of the library and would be ignored in the release build
            _workspace = (await _resourceGroup.GetWorkspaces().CreateOrUpdateAsync(workspaceName, workspaceData)).Value;
            Assert.NotNull(_workspace);
            Assert.AreEqual(workspaceName, _workspace.Id.Name);

            await TestListAsync();
            await TestGetAsync();
            await TestUpdateAsync();
            await TestRemoveAsync();
        }

        private async Task TestListAsync()
        {
            var listResults = _resourceGroup.GetWorkspaces().ListAsync();
            Assert.AreEqual(1, await listResults.CountAsync());
        }

        private async Task TestGetAsync()
        {
            var workspace = await _resourceGroup.GetWorkspaces().GetAsync(_workspace.Data.Name);
            Assert.NotNull(workspace);
            Assert.AreEqual(_workspace.Data.Id, workspace.Value.Data.Id);
        }

        private async Task TestUpdateAsync()
        {
            // update via put
            var workspaceData = _workspace.Data;
            workspaceData.Tags = new Dictionary<string, string> { { "new", "tag" } };
            workspaceData.ContainerRegistry = null; // or else "message":"Property id '' at path 'properties.containerRegistry' is invalid. Expect fully qualified resource Id that start with '/subscriptions/{subscriptionId}' or '/providers/{resourceProviderNamespace}/'."
            _workspace = (await _resourceGroup.GetWorkspaces().CreateOrUpdateAsync(_workspace.Data.Name, workspaceData)).Value;
            Assert.AreEqual("tag", _workspace.Data.Tags["new"]);

            // update via patch
            var update = new WorkspaceUpdateParameters();
            update.Tags.Add("newer", "tag");
            await _workspace.UpdateAsync(update);
            _workspace = await _workspace.GetAsync();
            Assert.AreEqual("tag", _workspace.Data.Tags["newer"]);
        }

        private async Task TestRemoveAsync()
        {
            var workspace = (await _resourceGroup.GetWorkspaces().GetAsync(_workspace.Data.Name)).Value;
            await workspace.DeleteAsync();
            var workspaces = _resourceGroup.GetWorkspaces().ListAsync();
            Assert.AreEqual(0, await workspaces.CountAsync());
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _subscription = await GlobalClient.GetSubscriptions().TryGetAsync(SessionEnvironment.SubscriptionId);
            var rgName = SessionRecording.GenerateAssetName("testRg-");
            _resourceGroup = await _subscription.GetResourceGroups().Construct(_location).CreateOrUpdateAsync(rgName);
            _keyVaultId = (await CreateGenericKeyVaultAsync()).Id;
            _storageAccountId = (await CreateGenericStorageAccountAsync()).Id;
            _appInsigntsId = (await CreateGenericAppInsightsAsync()).Id;
            StopSessionRecording();
        }

        private async Task<GenericResource> CreateGenericStorageAccountAsync()
        {
            GenericResourceData data = ConstructGenericStorageAccount();
            var id = _resourceGroup.Id.AppendProviderResource("Microsoft.Storage", "storageAccounts", SessionRecording.GenerateAssetName("testsa"));
            return await _subscription.GetGenericResources().CreateOrUpdateAsync(id, data);
        }

        private GenericResourceData ConstructGenericStorageAccount()
        {
            var storageAccount = new GenericResourceData()
            {
                Location = _location,
                Sku = new Core.Sku("Standard_GRS")
            };
            return storageAccount;
        }

        private async Task<GenericResource> CreateGenericKeyVaultAsync()
        {
            GenericResourceData data = ConstructGenericKeyVault();
            var id = _resourceGroup.Id.AppendProviderResource("Microsoft.KeyVault", "vaults", SessionRecording.GenerateAssetName("mltestkv"));
            return await _subscription.GetGenericResources().CreateOrUpdateAsync(id, data).ConfigureAwait(false);
        }

        private GenericResourceData ConstructGenericKeyVault()
        {
            var sku = new JsonObject()
            {
                {"family", "A" },
                {"name", "standard"}
            };
            var allPermissions = new string[] { "all" };
            var accessPolicyPermissions = new JsonObject
            {
                { "keys", allPermissions },
                { "secrets", allPermissions },
                { "certificates", allPermissions },
                { "storage", allPermissions }
            };
            var accessPolicies = new JsonObject[]
            {
                new JsonObject()
                {
                    { "tenantId", TestEnvironment.TenantId },
                    { "objectId", TestEnvironment.ObjectId },
                    { "permissions", accessPolicyPermissions }
                }
            };
            var ipRules = new JsonObject[]
            {
                new JsonObject()
                {
                    { "value", "1.2.3.4/32" }
                },
                new JsonObject()
                {
                    { "value", "1.0.0.0/25" }
                }
            };
            var networkAcls = new JsonObject()
            {
                { "bypass", "AzureServices" },
                { "defaultAction", "Allow" },
                { "IpRules", ipRules }
            };
            var vault = new GenericResourceData()
            {
                Location = _location,
                Properties = new JsonObject()
                {
                    { "tenantId", TestEnvironment.TenantId },
                    { "sku", sku },
                    { "accessPolicies", accessPolicies },
                    { "enablePurgeProtection", true },
                    { "networkAcls", networkAcls }
                }
            };
            return vault;
        }

        private async Task<GenericResource> CreateGenericAppInsightsAsync()
        {
            GenericResourceData data = ConstructGenericAppInsights();
            var id = _resourceGroup.Id.AppendProviderResource("Microsoft.Insights", "components", SessionRecording.GenerateAssetName("testappinsights"));
            return await _subscription.GetGenericResources().CreateOrUpdateAsync(id, data);
        }

        private GenericResourceData ConstructGenericAppInsights()
        {
            var appInsights = new GenericResourceData()
            {
                Location = _location,
                Kind = "web",
                Properties = new JsonObject()
            };
            return appInsights;
        }
    }
}
