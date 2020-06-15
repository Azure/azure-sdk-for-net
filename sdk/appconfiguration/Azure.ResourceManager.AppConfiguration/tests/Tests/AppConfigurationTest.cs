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
        public async Task Test_AppConfiguration_list_Key_Values()
        {
            var resourceGroup = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AZURE_LOCATION, resourceGroup);
            //create configuration
            var configuration_Store_Name = Recording.GenerateAssetName("configuration");
            var configurationCreateResult = await ConfigurationStoresOperations.StartCreateAsync(resourceGroup, configuration_Store_Name, new ConfigurationStore("westus", new Sku("Standard")));
            var configCreate = (await WaitForCompletionAsync(configurationCreateResult)).Value;

            //list configuration
            var configListResult = ConfigurationStoresOperations.ListKeysAsync(resourceGroup, configuration_Store_Name);
            var conList = await configListResult.ToEnumerableAsync();
            //# ConfigurationStores_ListKeys[post]
            //    keys = list(self.mgmt_client.configuration_stores.list_keys(resource_group.name, CONFIGURATION_STORE_NAME))
            var configRegenerateResult = ConfigurationStoresOperations.RegenerateKeyAsync(resourceGroup, configuration_Store_Name,new RegenerateKeyParameters(conList.First().Id));

            //if self.is_live:
            //    # create key-value
            //    self.create_kv(key.connection_string)

            //create Key
            //var addConfigurationsetting = await PrivateEndpointConnectionsClient
            //[skip]
            //var listkeyvalueResult = await ConfigurationStoresClient.ListKeyValueAsync(resourceGroup, CONFIGURATION_STORE_NAME,KEY,LABEL);
            //# ConfigurationStores_ListKeyValue[post]
            //    BODY = {
            //        "key": KEY,
            //  "label": LABEL
            //}
            //    result = self.mgmt_client.configuration_stores.list_key_value(resource_group.name, CONFIGURATION_STORE_NAME, BODY)
        }

        [Test]
        public async Task Test_AppConfiguration()
        {
            //string SERVICE_NAME = "myapimrndxyz";
            //string VNET_NAME = "vnetname";
            //string SUB_NET = "subnetname";
            //string ENDPOINT_NAME = "endpointxyz";D:\sdk\20200507\azure-sdk-for-net\sdk\appconfiguration\Azure.Management.AppConfiguration\src\Generated\Operations\PrivateEndpointConnectionsRestClient.cs
            string configuration_Store_Name = Recording.GenerateAssetName("configuration");
            string private_Endpoint_Connection_Name = Recording.GenerateAssetName("privateendpoint");
            var resourceGroup = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AZURE_LOCATION, resourceGroup);
            //JsonElement jsonElement= new JsonElement() { }
            //DeserializeConfigurationStore
            var configurationCreateResult = await ConfigurationStoresOperations.StartCreateAsync(resourceGroup, configuration_Store_Name, new ConfigurationStore("westus", new Sku("Standard")));
            var configCreate = await WaitForCompletionAsync(configurationCreateResult);
            //if (Mode == RecordedTestMode.Record)
            //{
            //   await PrivateEndpointConnectionsClient.StartCreateOrUpdateAsync(resourceGroup, CONFIGURATION_STORE_NAME, SUB_NET, ENDPOINT_NAME, configCreate.Id);
            //   string resourceGroupName, string configStoreName, string privateEndpointConnectionName, PrivateEndpoint privateEndpoint = null, PrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, CancellationToken cancellationToken = default
            //}
            var configurationGetResult = await ConfigurationStoresOperations.GetAsync(resourceGroup, configuration_Store_Name);
            //TODO these are not ready
            //PRIVATE_ENDPOINT_CONNECTION_NAME = configurationGetResult.Value.Endpoint;
            //private_connection_id = conf_store.private_endpoint_connections[0].id
            //            BODY = {
            //# "id": "https://management.azure.com/subscriptions/" + self.settings.SUBSCRIPTION_ID + "/resourceGroups/" + resource_group.name + "/providers/Microsoft.AppConfiguration/configurationStores/" + CONFIGURATION_STORE_NAME + "/privateEndpointConnections/" + PRIVATE_ENDPOINT_CONNECTION_NAME,
            //                "id": private_connection_id,
            //          "private_endpoint": {
            //                    "id": "/subscriptions/" + self.settings.SUBSCRIPTION_ID + "/resourceGroups/" + resource_group.name + "/providers/Microsoft.Network/privateEndpoints/" + ENDPOINT_NAME,
            //          },
            //          "private_link_service_connection_state": {
            //                    "status": "Approved",
            //            "description": "Auto-Approved"
            //          }
            //            }
            //            result = self.mgmt_client.private_endpoint_connections.begin_create_or_update(
            //                resource_group.name,
            //                CONFIGURATION_STORE_NAME,
            //                PRIVATE_ENDPOINT_CONNECTION_NAME,
            //                BODY)
            //            # id=BODY["id"],
            //            # private_endpoint=BODY["private_endpoint"],
            //            # private_link_service_connection_state=BODY["private_link_service_connection_state"])
            //        result = result.result()
            //[Skip]
            //var private_endpoint_getResult = await PrivateEndpointConnectionsClient.GetAsync(resourceGroup, CONFIGURATION_STORE_NAME, PRIVATE_ENDPOINT_CONNECTION_NAME);

            var list_by_configuration_Result = PrivateLinkResourcesOperations.ListByConfigurationStoreAsync(resourceGroup, configuration_Store_Name);

            var list_by_configuration_Res = await list_by_configuration_Result.ToEnumerableAsync();
            var PRIVATE_LINK_RESOURCE_NAME = list_by_configuration_Res.First().Name;
            //[Skip]
            //var private_link_resource_getResult = await PrivateLinkResourcesClient.GetAsync(resourceGroup, CONFIGURATION_STORE_NAME, PRIVATE_LINK_RESOURCE_NAME);

            var list_by_configuration_storeResult = PrivateEndpointConnectionsOperations.ListByConfigurationStoreAsync(resourceGroup, configuration_Store_Name);
            var list_by_configuration_storeRe = await list_by_configuration_storeResult.ToEnumerableAsync();
            //# PrivateEndpointConnection_List[get]
            //    result = list(self.mgmt_client.private_endpoint_connections.list_by_configuration_store(resource_group.name, CONFIGURATION_STORE_NAME))

            var operationListResult = Operations.ListAsync();

            var configuration_store_list_by_resource_groupResult = ConfigurationStoresOperations.ListByResourceGroupAsync(resourceGroup);

            var configuration_stores_list_Result = ConfigurationStoresOperations.ListAsync(resourceGroup);

            var configuration_stores_begin_updateResult = ConfigurationStoresOperations.StartUpdateAsync(resourceGroup, configuration_Store_Name, new ConfigurationStoreUpdateParameters()
            {
                Tags = new Dictionary<string, string> { { "category", "Marketing" } },
                Sku = new Sku("Standard")
            });
        }
    }
}
