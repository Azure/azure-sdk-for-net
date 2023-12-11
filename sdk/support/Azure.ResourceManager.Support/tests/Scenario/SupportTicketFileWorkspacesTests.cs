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
    internal class SupportTicketFileWorkspacesTests : SupportManagementTestBase
    {
        private SubscriptionFileWorkspaceCollection _subscriptionFileWorkspaceCollection;
        private const string _existSupportTicketFileWorkspaceName = "dotnet_test_workspacename2";

        public SupportTicketFileWorkspacesTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _subscriptionFileWorkspaceCollection = await Task.Run(() => DefaultSubscription.GetSubscriptionFileWorkspaces());
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _subscriptionFileWorkspaceCollection.ExistsAsync(_existSupportTicketFileWorkspaceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketFileWorkspace = await _subscriptionFileWorkspaceCollection.GetAsync(_existSupportTicketFileWorkspaceName);
            ValidateSupportTicketFileWorkspaceData(supportTicketFileWorkspace.Value.Data, _existSupportTicketFileWorkspaceName);
        }

        [RecordedTest]
        public async Task Create()
        {
            var assetName = Recording.GenerateAssetName("test");
            var workspaceName = $"dotnet_sdk_test_new_workspace_name_{assetName}";
            await _subscriptionFileWorkspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName);
            var supportTicketFileWorkspace = await _subscriptionFileWorkspaceCollection.GetAsync(workspaceName);
            ValidateSupportTicketFileWorkspaceData(supportTicketFileWorkspace.Value.Data, workspaceName);
        }

        private void ValidateSupportTicketFileWorkspaceData(FileWorkspaceDetailData supportTicketFileWorkspace, string fileWorkspaceName)
        {
            Assert.IsNotNull(supportTicketFileWorkspace);
            Assert.IsNotEmpty(supportTicketFileWorkspace.Id);
            Assert.AreEqual(supportTicketFileWorkspace.Name, fileWorkspaceName);
        }
    }
}
