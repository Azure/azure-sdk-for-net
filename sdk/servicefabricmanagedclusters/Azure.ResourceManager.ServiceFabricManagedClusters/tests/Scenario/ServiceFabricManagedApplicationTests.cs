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
    internal class ServiceFabricManagedApplicationTests : ServiceFabricManagedClustersManagementTestBase
    {
        private ServiceFabricManagedApplicationCollection _appCollection;
        private string _appTypeId;
        public ServiceFabricManagedApplicationTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var cluster = await CreateServiceFabricManagedCluster(resourceGroup, Recording.GenerateAssetName("sfmctest"));
            var primaryNodeType = await CreateServiceFabricManagedNodeType(cluster, Recording.GenerateAssetName("node"), true);
            var appType = await CreateSFMAppType(cluster, Recording.GenerateAssetName("appType"));
            _appTypeId = appType.Id;
            _appCollection = cluster.GetServiceFabricManagedApplications();
        }

        [RecordedTest]
        public async Task CreateOrUpdateDelete()
        {
            // CreateOrUpdate
            string applicationName = Recording.GenerateAssetName("app");
            var data = new ServiceFabricManagedApplicationData(DefaultLocation)
            {
                Version = $"{_appTypeId}/versions/1.0",
            };
            var appType = await _appCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationName, data);
        }

        private void ValidateServiceFabricManagedApplicationType(ServiceFabricManagedApplicationTypeData appType, string appTypeName)
        {
            Assert.IsNotNull(appType);
            //Assert.IsNotEmpty(appType.Id);
            //Assert.AreEqual(appTypeName, appType.Name);
        }
    }
}
