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
        public ServiceFabricManagedApplicationTypeTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
            Assert.IsTrue(flag);

            // Get
            var getAppType = await _appTypeCollection.GetAsync(appTypeName);
            ValidateServiceFabricManagedApplicationType(getAppType.Value.Data, appTypeName);

            // GetAll
            var list = await _appTypeCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateServiceFabricManagedApplicationType(list.FirstOrDefault().Data, appTypeName);

            // Delete
            await appType.DeleteAsync(WaitUntil.Completed);
            flag = await _appTypeCollection.ExistsAsync(appTypeName);
            Assert.IsFalse(flag);
        }

        private void ValidateServiceFabricManagedApplicationType(ServiceFabricManagedApplicationTypeData appType, string appTypeName)
        {
            Assert.IsNotNull(appType);
            //Assert.IsNotEmpty(appType.Id);
            //Assert.AreEqual(appTypeName, appType.Name);
        }
    }
}
