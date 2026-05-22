// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SecurityWorkspaceSettingTests : SecurityCenterManagementTestBase
    {
        private const string _workspaceSettingName = "default";
        private SecurityWorkspaceSettingCollection _workspaceSettingCollection;

        public SecurityWorkspaceSettingTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
            _workspaceSettingCollection = DefaultSubscription.GetSecurityWorkspaceSettings();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _workspaceSettingCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [RecordedTest]
        [Ignore("InvalidTemplateDeployment. Resource 'testworkspace' was disallowed by policy.")]
        public async Task WorkspaceSettingE2EOperation()
        {
            var resourceGroup = await CreateResourceGroup();

            // TODO: Create a workspace

            SecurityWorkspaceSettingData data = new SecurityWorkspaceSettingData()
            {
                Scope = $"{DefaultSubscription.Id}",
                WorkspaceId = new ResourceIdentifier($"<WORKSPACE_ID>")
            };
            var workspaceSetting = await _workspaceSettingCollection.CreateOrUpdateAsync(WaitUntil.Completed, _workspaceSettingName, data);
            Assert.IsNotNull(workspaceSetting);

            // Exist
            bool flag = await _workspaceSettingCollection.ExistsAsync(_workspaceSettingName);
            Assert.IsTrue(flag);

            // Get
            var getResponse = await _workspaceSettingCollection.GetAsync(_workspaceSettingName);
            Assert.IsNotNull(getResponse);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _workspaceSettingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
