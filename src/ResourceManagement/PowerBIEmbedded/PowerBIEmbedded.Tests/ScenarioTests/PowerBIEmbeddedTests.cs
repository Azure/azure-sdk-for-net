//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.PowerBIEmbedded;
using Microsoft.Azure.Management.PowerBIEmbedded.Models;
using PowerBIEmbedded.Tests.Helpers;
using PowerBIEmbedded.Tests.ScenarioTests.PowerBIEmbedded.Tests.ScenarioTests;
using ResourceGroups.Tests;
using Xunit;
using System.Linq;

namespace PowerBIEmbedded.Tests.ScenarioTests
{
    public class PowerBIEmbeddedTests : PowerBITestBase
    {
        [Fact]
        public void TestCreateWorkspaceCollection()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);

                Assert.NotNull(workspaceCollection);
            }
        }

        [Fact]
        public void TestGetWorkspaceCollectionListByResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection1 = this.CreateWorkspaceCollection(resourceGroup);
                var workspaceCollection2 = this.CreateWorkspaceCollection(resourceGroup);

                var allWorkspaces = this.powerBIClient.WorkspaceCollections.ListByResourceGroup(resourceGroup.Name).ToList();

                Assert.NotNull(workspaceCollection1);
                Assert.NotNull(workspaceCollection2);
                Assert.Equal(2, allWorkspaces.Count);
                Assert.Equal(workspaceCollection1.Name, allWorkspaces[0].Name);
                Assert.Equal(workspaceCollection2.Name, allWorkspaces[1].Name);
            }
        }

        [Fact]
        public void TestGetWorkspaceCollectionListAll()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup1 = this.CreateResourceGroup();
                var resourceGroup2 = this.CreateResourceGroup();

                var workspaceCollection1 = this.CreateWorkspaceCollection(resourceGroup1);
                var workspaceCollection2 = this.CreateWorkspaceCollection(resourceGroup2);

                var allWorkspaces = this.powerBIClient.WorkspaceCollections.ListBySubscription().ToList();

                Assert.NotNull(workspaceCollection1);
                Assert.NotNull(workspaceCollection2);
                Assert.True(allWorkspaces.Count > 2);
                Assert.Equal(workspaceCollection1.Name, allWorkspaces[allWorkspaces.Count - 2].Name);
                Assert.Equal(workspaceCollection2.Name, allWorkspaces[allWorkspaces.Count - 1].Name);
            }
        }

        [Fact]
        public void TestGetWorkspaceCollectionByName()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                var result = this.powerBIClient.WorkspaceCollections.GetByName(resourceGroup.Name, workspaceCollection.Name);

                Assert.Equal(workspaceCollection.Name, result.Name);
            }
        }

        [Fact]
        public void TestGetWorkspaceCollectionAccessKeys()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                var result = this.powerBIClient.WorkspaceCollections.GetAccessKeys(resourceGroup.Name, workspaceCollection.Name);

                Assert.NotNull(result);
                Assert.False(string.IsNullOrWhiteSpace(result.Key1));
                Assert.False(string.IsNullOrWhiteSpace(result.Key2));
            }
        }

        [Fact]
        public void TestRegenerateAccessKey1()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                var accessKeyRequest = new WorkspaceCollectionAccessKey(AccessKeyName.Key1);
                var originalKeys = this.powerBIClient.WorkspaceCollections.GetAccessKeys(resourceGroup.Name, workspaceCollection.Name);
                var result = this.powerBIClient.WorkspaceCollections.RegenerateKey(resourceGroup.Name, workspaceCollection.Name, accessKeyRequest);
                var newKeys = this.powerBIClient.WorkspaceCollections.GetAccessKeys(resourceGroup.Name, workspaceCollection.Name);

                // Key1 is different, Key2 is the same
                Assert.NotEqual(originalKeys.Key1, result.Key1);
                Assert.Equal(originalKeys.Key2, result.Key2);

                // Regenerated keys are the same as new keys
                Assert.Equal(result.Key1, newKeys.Key1);
                Assert.Equal(result.Key2, newKeys.Key2);
            }
        }

        [Fact]
        public void TestRegenerateAccessKey2()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                var accessKeyRequest = new WorkspaceCollectionAccessKey(AccessKeyName.Key2);
                var originalKeys = this.powerBIClient.WorkspaceCollections.GetAccessKeys(resourceGroup.Name, workspaceCollection.Name);
                var result = this.powerBIClient.WorkspaceCollections.RegenerateKey(resourceGroup.Name, workspaceCollection.Name, accessKeyRequest);
                var newKeys = this.powerBIClient.WorkspaceCollections.GetAccessKeys(resourceGroup.Name, workspaceCollection.Name);

                // Key1 is different, Key2 is the same
                Assert.Equal(originalKeys.Key1, result.Key1);
                Assert.NotEqual(originalKeys.Key2, result.Key2);

                // Regenerated keys are the same as new keys
                Assert.Equal(result.Key1, newKeys.Key1);
                Assert.Equal(result.Key2, newKeys.Key2);
            }
        }

        [Fact]
        public void TestGetWorkspaces()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                var workspaces = this.powerBIClient.Workspaces.List(resourceGroup.Name, workspaceCollection.Name).ToList();

                Assert.NotNull(workspaces);
                Assert.Equal(0, workspaces.Count);
            }
        }

        [Fact]
        public void TestRemoveWorkspaceCollection()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);

                var resourceGroup = this.CreateResourceGroup();
                var workspaceCollection = this.CreateWorkspaceCollection(resourceGroup);
                try
                {
                    this.powerBIClient.WorkspaceCollections.Delete(resourceGroup.Name, workspaceCollection.Name);
                }
                catch
                {
                    // Noop: There known issue in delete with regard to long running processes.  Workspace collection is successfully deleted
                }

                Assert.Throws<ErrorException>(() => this.powerBIClient.WorkspaceCollections.GetByName(resourceGroup.Name, workspaceCollection.Name));
            }
        }
    }
}
