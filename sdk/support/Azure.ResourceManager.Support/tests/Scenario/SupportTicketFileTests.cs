// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Support.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class SupportTicketFileTests : SupportManagementTestBase
    {
        private SupportTicketFileCollection _supportTicketFileCollection;
        private const string _existSupportTicketFileWorkspaceName = "dotnet_test_workspacename2";
        private const string _existSupportTicketFileName = "dotnet_test_filename1.txt";
        private const string _subscriptionId = "cca0326c-4c31-46d8-8fcb-c67023a46f4b";

        private SubscriptionFileWorkspaceResource subscriptionFileWorkspaceResource { get; set; }

        public SupportTicketFileTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resource = SubscriptionFileWorkspaceResource.CreateResourceIdentifier(_subscriptionId, _existSupportTicketFileWorkspaceName);
            subscriptionFileWorkspaceResource = await Task.Run(() => Client.GetSubscriptionFileWorkspaceResource(resource));
            _supportTicketFileCollection = subscriptionFileWorkspaceResource.GetSupportTicketFiles();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportTicketFileCollection.ExistsAsync(_existSupportTicketFileName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketFile = await _supportTicketFileCollection.GetAsync(_existSupportTicketFileName);
            ValidateSupportTicketFileData(supportTicketFile.Value.Data, _existSupportTicketFileName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketFileCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketFileData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketFileName).Data, _existSupportTicketFileName);
        }

        [RecordedTest]
        public async Task CreateAndUpload()
        {
            //  Create file
            var assetName = Recording.GenerateAssetName("test");
            var fileName = $"dotnet_sdk_test_new_file_{assetName}.txt";
            var resource = SupportTicketFileResource.CreateResourceIdentifier(_subscriptionId, _existSupportTicketFileWorkspaceName, fileName);
            var fileData = new SupportFileDetailData(resource, fileName, resource.ResourceType, new ResourceManager.Models.SystemData(), DateTimeOffset.Now, 4, 4, 1, null);
            await _supportTicketFileCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileName, fileData);
            var supportTicketFile = await _supportTicketFileCollection.GetAsync(fileName);
            ValidateSupportTicketFileData(supportTicketFile.Value.Data, fileName);

            //  Upload content
            var fileSize = supportTicketFile.Value.Data.FileSize;
            var uploadFile = new UploadFileContent() { ChunkIndex = 0, Content = "VGVzdA==" };
            await supportTicketFile.Value.UploadAsync(uploadFile);
            supportTicketFile = await _supportTicketFileCollection.GetAsync(_existSupportTicketFileName);
            Assert.IsNotNull(supportTicketFile);
            Assert.IsNotEmpty(supportTicketFile.Value.Data.Id);
            Assert.AreEqual(supportTicketFile.Value.Data.Name, _existSupportTicketFileName);
            Assert.Greater(supportTicketFile.Value.Data.FileSize, fileSize);
        }

        private void ValidateSupportTicketFileData(SupportFileDetailData supportTicketFile, string fileName)
        {
            Assert.IsNotNull(supportTicketFile);
            Assert.IsNotEmpty(supportTicketFile.Id);
            Assert.AreEqual(supportTicketFile.Name, fileName);
        }
    }
}
