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
        private SubscriptionFileWorkspaceResource subscriptionFileWorkspaceResource { get; set; }

        public SupportTicketFileTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            // currently not working
            var resource = SubscriptionFileWorkspaceResource.CreateResourceIdentifier("cca0326c-4c31-46d8-8fcb-c67023a46f4b", _existSupportTicketFileWorkspaceName);
            //SupportTicketFileResource.CreateResourceIdentifier("cca0326c-4c31-46d8-8fcb-c67023a46f4b", _existSupportTicketFileWorkspaceName, )
            subscriptionFileWorkspaceResource = await Task.Run(() => Client.GetSubscriptionFileWorkspaceResource(resource));
            _supportTicketFileCollection = subscriptionFileWorkspaceResource.GetSupportTicketFiles();
            //_subscriptionFileWorkspaceCollection = await Task.Run(() => DefaultSubscription.GetFi());
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
            var supportTicketFileWorkspace = await Task.Run(() => _supportTicketFileCollection.GetAll());
            //ValidateSupportTicketFileData(supportTicketFileWorkspace.Value.Data);
        }

        private void ValidateSupportTicketFileData(FileDetailData supportTicketFileWorkspace)
        {
            Assert.IsNotNull(supportTicketFileWorkspace);
            Assert.IsNotEmpty(supportTicketFileWorkspace.Id);
            Assert.AreEqual(supportTicketFileWorkspace.Name, supportTicketFileWorkspace.Name);
        }
    }
}
