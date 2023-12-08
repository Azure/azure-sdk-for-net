// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;
using Azure.ResourceManager.DataLakeAnalytics.Models;

namespace Azure.ResourceManager.DataLakeAnalytics.Tests.Scenario
{
    public class DataLakeStoreAccountInformationCollectionTests : DataLakeAnalyticsManagementTestBase
    {
        public DataLakeStoreAccountInformationCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RecoveryServicesRG", AzureLocation.WestUS2);
        }
        //[RecordedTest]
        //public async Task CreateOrUpdate()
        //{
        //    var resourceGroup = await CreateResourceGroupAsync();
        //    var dataLakeAnalyticsAccountCollection = resourceGroup;
        //    var accountName = Recording.GenerateAssetName("datalake");
        //    var content = new DataLakeAnalyticsAccountCreateOrUpdateContent(AzureLocation.EastUS, "");
        //    var dataLakeAnalyticsAccount = await dataLakeAnalyticsAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, content);
        //}
    }
}
