// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagedApplicationTypeTests : ServiceFabricManagedClustersManagementTestBase
    {
        private ServiceFabricManagedClusterResource _cluster;
        private ServiceFabricManagedApplicationTypeCollection _appTypeCollection;
        public ServiceFabricManagedApplicationTypeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _cluster = await CreateServiceFabricManagedCluster(resourceGroup, Recording.GenerateAssetName("sfmctest"));
            _appTypeCollection = _cluster.GetServiceFabricManagedApplicationTypes();
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string appTypeName = Recording.GenerateAssetName("appType");
            var appType = await CreateSFMAppType(_cluster, appTypeName);
            ValidateServiceFabricManagedApplicationType(appType.Data, appTypeName);

            // Exist
            var flag = await _appTypeCollection.ExistsAsync(appTypeName);
            Assert.That((bool)flag, Is.True);

            // Get
            var getAppType = await _appTypeCollection.GetAsync(appTypeName);
            ValidateServiceFabricManagedApplicationType(getAppType.Value.Data, appTypeName);

            // GetAll
            var list = await _appTypeCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateServiceFabricManagedApplicationType(list.FirstOrDefault().Data, appTypeName);

            // Delete
            await appType.DeleteAsync(WaitUntil.Completed);
            flag = await _appTypeCollection.ExistsAsync(appTypeName);
            Assert.That((bool)flag, Is.False);
        }

        //[TestCase(null)] // 405: The HTTP method 'GET' is not supported at scope 'Microsoft.ServiceFabric/managedclusters/sfmctest3040/applicationTypes/appType111'
        //[TestCase(true)] // 405: The HTTP method 'GET' is not supported at scope 'Microsoft.ServiceFabric/managedclusters/sfmctest3040/applicationTypes/appType111'
        [TestCase(false)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string appTypeName = Recording.GenerateAssetName("appType");
            var appType = await CreateSFMAppType(_cluster, appTypeName);

            // AddTag
            await appType.AddTagAsync("addtagkey", "addtagvalue");
            appType = await _appTypeCollection.GetAsync(appTypeName);
            Assert.That(appType.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = appType.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await appType.RemoveTagAsync("addtagkey");
            appType = await _appTypeCollection.GetAsync(appTypeName);
            Assert.That(appType.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateServiceFabricManagedApplicationType(ServiceFabricManagedApplicationTypeData appType, string appTypeName)
        {
            Assert.That(appType, Is.Not.Null);
            Assert.That((string)appType.Id, Is.Not.Empty);
            Assert.That(appType.Name, Is.EqualTo(appTypeName));
            Assert.That(appType.Location, Is.EqualTo(DefaultLocation));
            Assert.That(appType.ProvisioningState, Is.EqualTo("Succeeded"));
        }
    }
}
