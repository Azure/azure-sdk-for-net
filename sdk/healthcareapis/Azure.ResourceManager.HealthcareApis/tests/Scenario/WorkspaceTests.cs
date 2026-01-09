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
            Assert.That((bool)flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidateHealthcareApisWorkspace(list.FirstOrDefault().Data, workspaceName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string workspaceName = Recording.GenerateAssetName(_workspaceNamePrefix);
            var workspace = await CreateHealthcareApisWorkspace(_resourceGroup, workspaceName);
            var flag = await _workspaceCollection.ExistsAsync(workspaceName);
            Assert.That((bool)flag, Is.True);

            await workspace.DeleteAsync(WaitUntil.Completed);
            flag = await _workspaceCollection.ExistsAsync(workspaceName);
            Assert.That((bool)flag, Is.False);
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
            Assert.That(workspace.Data.Tags, Has.Count.EqualTo(1));
            KeyValuePair<string, string> tag = workspace.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(tag.Key, Is.EqualTo("addtagkey"));
                Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
            });

            // RemoveTag
            await workspace.RemoveTagAsync("addtagkey");
            workspace = await _workspaceCollection.GetAsync(workspaceName);
            Assert.That(workspace.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateHealthcareApisWorkspace(HealthcareApisWorkspaceData workspace, string workspaceName)
        {
            Assert.That(workspace, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(workspace.Id, Is.Not.Null);
                Assert.That(workspace.ETag, Is.Not.Null);
                Assert.That(workspace.Name, Is.EqualTo(workspaceName));
                Assert.That(workspace.ResourceType.ToString(), Is.EqualTo("Microsoft.HealthcareApis/workspaces"));
                Assert.That(workspace.Location, Is.EqualTo(DefaultLocation));
            });
        }
    }
}
