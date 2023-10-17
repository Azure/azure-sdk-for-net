// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class SupportTicketFileTests : SupportManagementTestBase
    {
        private SupportTicketFileCollection _supportTicketFileCollection;
        private const string _existSupportTicketFileWorkspaceName = "dotnet_test_workspacename";
        private const string _existSupportTicketFileName = "dotnet_test_filename.txt";
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
            var flag = await _supportTicketFileCollection.ExistsAsync(_existSupportTicketFileWorkspaceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketFile = await _supportTicketFileCollection.GetAsync(_existSupportTicketFileName);
            ValidateSupportTicketFileData(supportTicketFile.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketFileCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketFileData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketFileName).Data);
        }

        private void ValidateSupportTicketFileData(FileDetailData supportTicketFile)
        {
            Assert.IsNotNull(supportTicketFile);
            Assert.IsNotEmpty(supportTicketFile.Id);
            Assert.AreEqual(supportTicketFile.Name, _existSupportTicketFileName);
        }
    }
}
