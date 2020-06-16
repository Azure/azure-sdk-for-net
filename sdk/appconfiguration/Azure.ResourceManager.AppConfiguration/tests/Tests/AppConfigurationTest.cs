// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.AppConfiguration.Models.Sku;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class AppConfigurationTest : AppConfigurationClientBase
    {
        public AppConfigurationTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task AppConfigurationListKeyValues()
        {
            var resourceGroup = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AzureLocation, resourceGroup);
            //create configuration
            var configurationStoreName = Recording.GenerateAssetName("configuration");
            var configurationCreateResult = await ConfigurationStoresOperations.StartCreateAsync(resourceGroup, configurationStoreName, new ConfigurationStore("westus", new Sku("Standard")));
            var configCreate = (await WaitForCompletionAsync(configurationCreateResult)).Value;

            //list configuration
            var configListResult = ConfigurationStoresOperations.ListKeysAsync(resourceGroup, configurationStoreName);
            var conList = await configListResult.ToEnumerableAsync();
            //# ConfigurationStoresListKeys[post]
            //    keys = list(self.mgmtclient.configurationstores.listkeys(resourcegroup.name, CONFIGURATIONSTORENAME))
            var configRegenerateResult = ConfigurationStoresOperations.RegenerateKeyAsync(resourceGroup, configurationStoreName, new RegenerateKeyParameters(conList.First().Id));

            //if self.islive:
            //    # create key-value
            //    self.createkv(key.connectionstring)
            //create Key
            //var addConfigurationsetting = await PrivateEndpointConnectionsClient
            //[skip]
            //var listkeyvalueResult = await ConfigurationStoresClient.ListKeyValueAsync(resourceGroup, CONFIGURATIONSTORENAME,KEY,LABEL);
            //# ConfigurationStoresListKeyValue[post]
            //    BODY = {
            //        "key": KEY,
            //  "label": LABEL
            //}
            //    result = self.mgmtclient.configurationstores.listkeyvalue(resourcegroup.name, CONFIGURATIONSTORENAME, BODY)
        }

        [Test]
        public async Task AppConfiguration()
        {
            //string SERVICENAME = "myapimrndxyz";
            //string VNETNAME = "vnetname";
            //string SUBNET = "subnetname";
            //string ENDPOINTNAME = "endpointxyz";D:\sdk\20200507\azure-sdk-for-net\sdk\appconfiguration\Azure.Management.AppConfiguration\src\Generated\Operations\PrivateEndpointConnectionsRestClient.cs
            string configurationStoreName = Recording.GenerateAssetName("configuration");
            string privateEndpointConnectionName = Recording.GenerateAssetName("privateendpoint");
            var resourceGroup = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AzureLocation, resourceGroup);
            //JsonElement jsonElement= new JsonElement() { }
            //DeserializeConfigurationStore
            var configurationCreateResult = await ConfigurationStoresOperations.StartCreateAsync(resourceGroup, configurationStoreName, new ConfigurationStore("westus", new Sku("Standard")));
            var configCreate = await WaitForCompletionAsync(configurationCreateResult);
            //if (Mode == RecordedTestMode.Record)
            //{
            //   await PrivateEndpointConnectionsClient.StartCreateOrUpdateAsync(resourceGroup, CONFIGURATIONSTORENAME, SUBNET, ENDPOINTNAME, configCreate.Id);
            //   string resourceGroupName, string configStoreName, string privateEndpointConnectionName, PrivateEndpoint privateEndpoint = null, PrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, CancellationToken cancellationToken = default
            //}
            var configurationGetResult = await ConfigurationStoresOperations.GetAsync(resourceGroup, configurationStoreName);
            //TODO these are not ready
            //PRIVATEENDPOINTCONNECTIONNAME = configurationGetResult.Value.Endpoint;
            //privateconnectionid = confstore.privateendpointconnections[0].id
            //            BODY = {
            //# "id": "https://management.azure.com/subscriptions/" + self.settings.SUBSCRIPTIONID + "/resourceGroups/" + resourcegroup.name + "/providers/Microsoft.AppConfiguration/configurationStores/" + CONFIGURATIONSTORENAME + "/privateEndpointConnections/" + PRIVATEENDPOINTCONNECTIONNAME,
            //                "id": privateconnectionid,
            //          "privateendpoint": {
            //                    "id": "/subscriptions/" + self.settings.SUBSCRIPTIONID + "/resourceGroups/" + resourcegroup.name + "/providers/Microsoft.Network/privateEndpoints/" + ENDPOINTNAME,
            //          },
            //          "privatelinkserviceconnectionstate": {
            //                    "status": "Approved",
            //            "description": "Auto-Approved"
            //          }
            //            }
            //            result = self.mgmtclient.privateendpointconnections.begincreateorupdate(
            //                resourcegroup.name,
            //                CONFIGURATIONSTORENAME,
            //                PRIVATEENDPOINTCONNECTIONNAME,
            //                BODY)
            //            # id=BODY["id"],
            //            # privateendpoint=BODY["privateendpoint"],
            //            # privatelinkserviceconnectionstate=BODY["privatelinkserviceconnectionstate"])
            //        result = result.result()
            //[Skip]
            //var privateendpointgetResult = await PrivateEndpointConnectionsClient.GetAsync(resourceGroup, CONFIGURATIONSTORENAME, PRIVATEENDPOINTCONNECTIONNAME);

            var listByConfigurationResult = PrivateLinkResourcesOperations.ListByConfigurationStoreAsync(resourceGroup, configurationStoreName);

            var listByConfigurationRes = await listByConfigurationResult.ToEnumerableAsync();
            var privateLinkResourceName = listByConfigurationRes.First().Name;
            //[Skip]
            //var privatelinkresourcegetResult = await PrivateLinkResourcesClient.GetAsync(resourceGroup, CONFIGURATIONSTORENAME, PRIVATELINKRESOURCENAME);

            var listByConfigurationStoreResult = PrivateEndpointConnectionsOperations.ListByConfigurationStoreAsync(resourceGroup, configurationStoreName);
            var listByConfigurationStoreRe = await listByConfigurationStoreResult.ToEnumerableAsync();
            //# PrivateEndpointConnectionList[get]
            //    result = list(self.mgmtclient.privateendpointconnections.listbyconfigurationstore(resourcegroup.name, CONFIGURATIONSTORENAME))

            var operationListResult = Operations.ListAsync();

            var configurationStoreListByResourceGroupResult = ConfigurationStoresOperations.ListByResourceGroupAsync(resourceGroup);

            var configurationStoresListResult = ConfigurationStoresOperations.ListAsync(resourceGroup);

            var configurationStoresBeginUpdateResult = ConfigurationStoresOperations.StartUpdateAsync(resourceGroup, configurationStoreName, new ConfigurationStoreUpdateParameters()
            {
                Tags = new Dictionary<string, string> { { "category", "Marketing" } },
                Sku = new Sku("Standard")
            });
        }
    }
}
