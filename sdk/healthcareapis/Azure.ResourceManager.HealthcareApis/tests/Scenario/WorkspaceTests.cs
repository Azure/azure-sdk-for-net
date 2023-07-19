// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    internal class WorkspaceTests : HealthcareApisManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private HealthcareApisWorkspaceCollection _workspaceCollection;
        private const string _workspaceNamePrefix = "workspace";

        public WorkspaceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _workspaceCollection = _resourceGroup.GetHealthcareApisWorkspaces();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            var workspace = await CreateHealthcareApisWorkspace(_resourceGroup,workspaceName);
            ValidateHealthcareApisWorkspace(workspace.Data, workspaceName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);
            var flag = await _workspaceCollection.ExistsAsync(workspaceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);
            var workspace = await _workspaceCollection.GetAsync(workspaceName);
            ValidateHealthcareApisWorkspace(workspace.Value.Data, workspaceName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);
            var list = await _workspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateHealthcareApisWorkspace(list.FirstOrDefault().Data, workspaceName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            var workspace = await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);
            var flag = await _workspaceCollection.ExistsAsync(workspaceName);
            Assert.IsTrue(flag);

            await workspace.DeleteAsync(WaitUntil.Completed);
            flag = await _workspaceCollection.ExistsAsync(workspaceName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            var workspace = await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);

            // AddTag
            await workspace.AddTagAsync("addtagkey", "addtagvalue");
            workspace = await _workspaceCollection.GetAsync(workspaceName);
            Assert.AreEqual(1, workspace.Data.Tags.Count);
            KeyValuePair<string, string> tag = workspace.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await workspace.RemoveTagAsync("addtagkey");
            workspace = await _workspaceCollection.GetAsync(workspaceName);
            Assert.AreEqual(0, workspace.Data.Tags.Count);
        }

        private void ValidateHealthcareApisWorkspace(HealthcareApisWorkspaceData workspace, string workspaceName)
        {
            Assert.IsNotNull(workspace);
            Assert.IsNotNull(workspace.Id);
            Assert.IsNotNull(workspace.ETag);
            Assert.AreEqual(workspaceName, workspace.Name);
            Assert.AreEqual("Microsoft.HealthcareApis/workspaces", workspace.ResourceType.ToString());
            Assert.AreEqual(DefaultLocation, workspace.Location);
        }
    }
}
