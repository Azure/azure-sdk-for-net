// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiCollectionTests : ApiManagementManagementTestBase
    {
        public ApiCollectionTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        // For playback
        private async Task<ApiManagementServiceResource> GetApiManagementServiceAsync()
        {
            var resourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync("sdktestrg");
            var collection = resourceGroup.Value.GetApiManagementServices();
            return (await collection.GetAsync("sdktestapi")).Value;
        }

        [Test]
        public async Task CreateOrUpdate_GetAll_Get_Delete ()
        {
            // Please create the resource first.
            var apiManagementService = await GetApiManagementServiceAsync();
            var collection = apiManagementService.GetApis();

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    var newitem = (await item.GetAsync()).Value;
                    Assert.NotNull(newitem.Data.DisplayName);
                    await newitem.DeleteAsync(WaitUntil.Completed, "*");
                }
            }

            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiCreateOrUpdateContent()
            {
                Description = "apidescription5200",
                //AuthenticationSettings = new AuthenticationSettingsContract()
                //{
                //    OAuth2 = new OAuth2AuthenticationSettingsContract()
                //    {
                //        AuthorizationServerId = "authorizationServerId2283",
                //        Scope = "oauth2scope2580"
                //    }
                //},
                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract()
                {
                    Header = "header4520",
                    Query = "query3037"
                },
                DisplayName = "apiname1463",
                ServiceUri = new Uri("http://newechoapi.cloudapp.net/api"),
                Path = "newapiPath",
                Protocols = { ApiOperationInvokableProtocol.Https, ApiOperationInvokableProtocol.Http }
            };
            var result = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.AreEqual(result.Data.Name, apiName);
            Assert.AreEqual(result.Data.Path, "newapiPath");
        }
    }
}
