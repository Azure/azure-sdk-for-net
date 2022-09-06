// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Tests
{
    internal class HDInsightApplicationTests : HDInsightManagementTestBase
    {
        private HDInsightClusterResource _cluster;
        private HDInsightApplicationCollection _applicationCollection => _cluster.GetHDInsightApplications();

        public HDInsightApplicationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var storageAccount = await CreateStorageAccount(resourceGroup, Recording.GenerateAssetName("azstorageforcluster"));
            _cluster = await CreateDefaultHadoopCluster(resourceGroup, storageAccount, Recording.GenerateAssetName("cluster"));
        }

        private async Task<HDInsightApplicationResource> CreateApplication(string applicationName)
        {
            var properties = new HDInsightApplicationProperties()
            {
                ApplicationType = "CustomApplication",
            };
            var scriptActionName = Recording.GenerateAssetName("InstallHue");
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
            string applicationName = Recording.GenerateAssetName("application");
            var application = await CreateApplication(applicationName);
            ValidateApplication(application);
            Assert.AreEqual(applicationName, application.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string applicationName = Recording.GenerateAssetName("application");
            await CreateApplication(applicationName);
            bool flag = await _applicationCollection.ExistsAsync(applicationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string applicationName = Recording.GenerateAssetName("application");
            await CreateApplication(applicationName);
            var application = await _applicationCollection.GetAsync(applicationName);
            ValidateApplication(application);
            Assert.AreEqual(applicationName, application.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string applicationName = Recording.GenerateAssetName("application");
            await CreateApplication(applicationName);
            var list = await _applicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        [Ignore("Delete application operation cannot be performed on this cluster at this time as it is not in 'Running' state.")]
        public async Task Delete()
        {
            string applicationName = Recording.GenerateAssetName("application");
            var application = await CreateApplication(applicationName);
            bool flag = await _applicationCollection.ExistsAsync(applicationName);
            Assert.IsTrue(flag);

            await application.DeleteAsync(WaitUntil.Completed);
            flag = await _applicationCollection.ExistsAsync(applicationName);
            Assert.IsFalse(flag);
        }

        private void ValidateApplication(HDInsightApplicationResource application)
        {
            Assert.IsNotNull(application);
            Assert.IsNotNull(application.Data.Properties.CreatedDate);
            Assert.AreEqual("CustomApplication", application.Data.Properties.ApplicationType);
            Assert.AreEqual(1, application.Data.Properties.InstallScriptActions.Count);
        }
    }
}
