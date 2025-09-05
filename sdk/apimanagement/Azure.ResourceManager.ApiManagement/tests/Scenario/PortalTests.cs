// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class PortalTests : ApiManagementManagementTestBase
    {
        public PortalTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Standard, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        [Ignore("Creation failed")]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementPortalRevisions();

            var revisionId = Recording.GenerateAssetName("revisionId");
            var portalRevisionContract = new ApiManagementPortalRevisionData
            {
                Description = new string('a', 99),
                IsCurrent = true
            };

            // create portal revision
            var portalRevision = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, revisionId, portalRevisionContract)).Value;

            Assert.NotNull(portalRevision);
            Assert.IsFalse(portalRevision.Data.IsCurrent);

            //get
            var getPortalRevision = (await collection.GetAsync(revisionId)).Value;

            Assert.NotNull(getPortalRevision);
            Assert.IsFalse(portalRevision.Data.IsCurrent);

            var updateDescription = "Updated " + portalRevisionContract.Description;

            var updatedResult = (await getPortalRevision.UpdateAsync(
                WaitUntil.Completed,
                ETag.All,
                new ApiManagementPortalRevisionData { Description = updateDescription })).Value;

            Assert.NotNull(updatedResult);
            Assert.IsFalse(portalRevision.Data.IsCurrent);
            Assert.AreEqual(updateDescription, updatedResult.Data.Description);

            //list
            var listPortalRevision = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listPortalRevision.Count, 1);
        }
    }
}
