﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        // VotingWebPkg.sfpkg from open source repo: https://github.com/Azure-Samples/service-fabric-dotnet-quickstart/tree/master/Voting
        private const string _appPackageUri = "https://dummyaccount.blob.core.windows.net/blobcontainer/VotingWebPkg.sfpkg";
        public ServiceFabricManagedApplicationTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<ServiceFabricManagedApplicationTypeVersionResource> CreateTypeVersion(ServiceFabricManagedApplicationTypeResource appType)
        {
            string versionName = "1.0.0";
            var data = new ServiceFabricManagedApplicationTypeVersionData(DefaultLocation)
            {
                AppPackageUri = new Uri(_appPackageUri)
            };
            var typeVersion = await appType.GetServiceFabricManagedApplicationTypeVersions().CreateOrUpdateAsync(WaitUntil.Completed, versionName, data);
            return typeVersion.Value;
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var cluster = await CreateServiceFabricManagedCluster(resourceGroup, Recording.GenerateAssetName("sfmctest"));
            var primaryNodeType = await CreateServiceFabricManagedNodeType(cluster, Recording.GenerateAssetName("node"), true);
            var appType = await CreateSFMAppType(cluster, "VotingType");
            _ = await CreateTypeVersion(appType);
            _appTypeId = appType.Id;
            _appCollection = cluster.GetServiceFabricManagedApplications();
        }

        private async Task<ServiceFabricManagedApplicationResource> CreateServiceFabricManagedApplication(string applicationName)
        {
            var data = new ServiceFabricManagedApplicationData(DefaultLocation)
            {
                Version = $"{_appTypeId}/versions/1.0.0",
            };
            var application = await _appCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationName, data);
            return application.Value;
        }

        [RecordedTest]
        [PlaybackOnly("Need manually upload a .sfpkg file to StorageAccount")]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string applicationName = Recording.GenerateAssetName("app");
            var application = await CreateServiceFabricManagedApplication(applicationName);
            ValidateServiceFabricManagedApplicationType(application.Data, applicationName);

            // Exist
            bool flag = await _appCollection.ExistsAsync(applicationName);
            Assert.IsTrue(flag);

            // Get
            var getApplication = await _appCollection.GetAsync(applicationName);
            ValidateServiceFabricManagedApplicationType(getApplication.Value.Data, applicationName);

            // GetAll
            var list = await _appCollection.GetAllAsync().ToEnumerableAsync();
            ValidateServiceFabricManagedApplicationType(list.FirstOrDefault(item => item.Data.Name == applicationName).Data, applicationName);

            // Delete
            await application.DeleteAsync(WaitUntil.Completed);
            flag = await _appCollection.ExistsAsync(applicationName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        [TestCase(false)]
        [PlaybackOnlyAttribute("Need manually upload a .sfpkg file to StorageAccount")]
        //[TestCase(null)] // The HTTP method 'GET' is not supported at scope 'Microsoft.ServiceFabric/managedclusters/sfmctest1063/applications/application5675'.
        //[TestCase(true)] // The HTTP method 'GET' is not supported at scope 'Microsoft.ServiceFabric/managedclusters/sfmctest1063/applications/application5675'.
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string applicationName = Recording.GenerateAssetName("application");
            var application = await CreateServiceFabricManagedApplication(applicationName);

            // AddTag
            await application.AddTagAsync("addtagkey", "addtagvalue");
            application = await _appCollection.GetAsync(applicationName);
            Assert.AreEqual(1, application.Data.Tags.Count);
            KeyValuePair<string, string> tag = application.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await application.RemoveTagAsync("addtagkey");
            application = await _appCollection.GetAsync(applicationName);
            Assert.AreEqual(0, application.Data.Tags.Count);
        }

        private void ValidateServiceFabricManagedApplicationType(ServiceFabricManagedApplicationData application, string appTypeName)
        {
            Assert.IsNotNull(application);
            Assert.IsNotEmpty(application.Id);
            Assert.AreEqual(appTypeName, application.Name);
            Assert.AreEqual(DefaultLocation, application.Location);
            Assert.AreEqual("Microsoft.ServiceFabric/managedclusters/applications", application.ResourceType.ToString());
        }
    }
}
