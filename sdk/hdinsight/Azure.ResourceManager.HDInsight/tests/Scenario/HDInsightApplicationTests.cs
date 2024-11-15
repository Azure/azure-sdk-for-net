// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class HDInsightApplicationTests : HDInsightManagementTestBase
    {
        private HDInsightClusterResource _cluster;
        private string _applicationName, _scriptActionName;
        private HDInsightApplicationCollection _applicationCollection => _cluster.GetHDInsightApplications();

        public HDInsightApplicationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            //Due to the HDInsightManagementTestBase's previous update, vnet restricts the cluster name have the unique first six characters.
            string clsusterNamePrefix = "G" + rgName.Substring(DefaultResourceGroupPrefix.Length) + "Cluster";
            string clusterName = Recording.GenerateAssetName(clsusterNamePrefix);
            string storageAccountName = Recording.GenerateAssetName("azstorageforcluster");
            string containerName = Recording.GenerateAssetName("container");
            _applicationName = Recording.GenerateAssetName("application");
            _scriptActionName = Recording.GenerateAssetName("InstallHue");
            var resourceGroup = await CreateResourceGroup(rgName);
            var accessKey = await CreateStorageResources(resourceGroup, storageAccountName, containerName);
            _cluster = await CreateDefaultHadoopCluster(resourceGroup, clusterName, storageAccountName, containerName, accessKey);
        }

        private async Task<HDInsightApplicationResource> CreateApplication(string applicationName, string scriptActionName)
        {
            var properties = new HDInsightApplicationProperties()
            {
                ApplicationType = "CustomApplication",
            };
            var uri = new Uri("https://hdiconfigactions.blob.core.windows.net/linuxhueconfigactionv02/install-hue-uber-v02.sh");
            var roles = new[] { "edgenode" };
            properties.InstallScriptActions.Add(new RuntimeScriptAction(scriptActionName, uri, roles)
            {
                Parameters = "-version latest -port 20000"
            });
            properties.ComputeRoles.Add(new HDInsightClusterRole()
            {
                Name = "edgenode",
                TargetInstanceCount = 1,
                HardwareVmSize = "Large"
            });

            var data = new HDInsightApplicationData()
            {
                Properties = properties,
            };
            data.Tags.Add("test", "test");
            var application = await _applicationCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationName, data);
            return application.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var application = await CreateApplication(_applicationName, _scriptActionName);
            ValidateApplication(application);
            Assert.AreEqual(_applicationName, application.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            await CreateApplication(_applicationName, _scriptActionName);
            bool flag = await _applicationCollection.ExistsAsync(_applicationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            await CreateApplication(_applicationName, _scriptActionName);
            var application = await _applicationCollection.GetAsync(_applicationName);
            ValidateApplication(application);
            Assert.AreEqual(_applicationName, application.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            await CreateApplication(_applicationName, _scriptActionName);
            var list = await _applicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        [Ignore("Delete application operation cannot be performed on this cluster at this time as it is not in 'Running' state.")]
        public async Task Delete()
        {
            var application = await CreateApplication(_applicationName, _scriptActionName);
            bool flag = await _applicationCollection.ExistsAsync(_applicationName);
            Assert.IsTrue(flag);

            await application.DeleteAsync(WaitUntil.Completed);
            flag = await _applicationCollection.ExistsAsync(_applicationName);
            Assert.IsFalse(flag);
        }

        private void ValidateApplication(HDInsightApplicationResource application)
        {
            Assert.IsNotNull(application);
            Assert.IsNotNull(application.Data.Properties.CreatedOn);
            Assert.AreEqual("CustomApplication", application.Data.Properties.ApplicationType);
            Assert.AreEqual(1, application.Data.Properties.InstallScriptActions.Count);
        }
        [Test]
        // regressation test for issue https://github.com/Azure/azure-sdk-for-net/issues/45709  only for not throwing exception
        public async Task GetHDInsightCluster()
        {
            string resourceGroupName = _cluster.Data.Id.ResourceGroupName;
            string clusterName = _cluster.Data.Name;
            string subscriptionId = _cluster.Data.Id.SubscriptionId;
            ResourceIdentifier resourceGroupIdenfier = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroup = await Client.GetResourceGroupResource(resourceGroupIdenfier).GetAsync();
            Assert.DoesNotThrowAsync(async () => { await resourceGroup.GetHDInsightClusterAsync(clusterName); });
        }
    }
}
