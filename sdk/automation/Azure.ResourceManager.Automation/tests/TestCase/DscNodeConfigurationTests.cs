// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class DscNodeConfigurationTests : AutomationManagementTestBase
    {
        public DscNodeConfigurationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<(DscConfigurationCollection Dsccollection, DscNodeConfigurationCollection NodeCollection)> GetDscConfigurationCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            DscConfigurationCollection dscCollection = accountResource.Value.GetDscConfigurations();
            DscNodeConfigurationCollection nodeCollection = accountResource.Value.GetDscNodeConfigurations();
            return (dscCollection, nodeCollection);
        }

        [TestCase]
        public async Task dscnodeconfigurationApiTests()
        {
            //0.prepare
            (DscConfigurationCollection dscCollection, DscNodeConfigurationCollection nodeCollection) = await GetDscConfigurationCollectionAsync();
            var configurationName = "SampleConfiguration";
            var dscinput = ResourceDataHelpers.GetDscConfigurationData(configurationName);
            var dsclro = await dscCollection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName, dscinput);
            DscConfigurationResource dscconfiguriationResource = dsclro.Value;
            dscconfiguriationResource = await dscCollection.GetAsync(configurationName);
            //1.CreateOrUpdate
            //var name = "localhost";
            //var name = Recording.GenerateAssetName(".dscnodeconfiguration");
            //var name2 = Recording.GenerateAssetName(".dscnodeconfiguration");
            //var name3 = Recording.GenerateAssetName(".dscnodeconfiguration");
            var dscName = dscconfiguriationResource.Data.Name;
            //var finalName = dscName + name;
            var input = ResourceDataHelpers.GetDscNodeConfigurationData(dscName);
            var lro = await nodeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "SampleConfiguration.localhost", input);
            //2.Get
            DscNodeConfigurationResource dscconfiguration2 = (await nodeCollection.GetAsync("SampleConfiguration.localhost")).Value;
            Assert.AreEqual("SampleConfiguration.localhost", dscconfiguration2.Data.Name);
            //3.GetAll
            _ = await nodeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "SampleConfiguration.localhost", input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName + name2, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, configurationName + name3, input);
            int count = 0;
            await foreach (var num in nodeCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4.Exists
            Assert.IsTrue(await nodeCollection.ExistsAsync("SampleConfiguration.localhost"));
            Assert.IsFalse(await nodeCollection.ExistsAsync("SampleConfiguration.localhost"+"1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await nodeCollection.ExistsAsync(null));
            //Resource
            //5.Get
            DscNodeConfigurationResource dscconfiguration3 = (await dscconfiguration2.GetAsync()).Value;
            ResourceDataHelpers.AssertDscNodeConfiguration(dscconfiguration2.Data, dscconfiguration3.Data);
            //6.Delete
            await dscconfiguration2.DeleteAsync(WaitUntil.Completed);
        }
    }
}
