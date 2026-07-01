// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for Project resource operations.
    /// </summary>
    public class ProjectResourceTests : DiscoveryManagementTestBase
    {
        public ProjectResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListProjectsByWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // Act
            var projects = new List<ProjectResource>();
            await foreach (var project in workspace.Value.GetProjects().GetAllAsync())
            {
                projects.Add(project);
            }

            // Assert
            Assert.That(projects, Is.Not.Null);
            // List may be empty but should not throw
        }

        [RecordedTest]
        public async Task GetProject()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var projectName = TestEnvironment.ProjectName;

            // Act
            var project = await workspace.Value.GetProjects().GetAsync(projectName);

            // Assert
            Assert.That(project.Value, Is.Not.Null);
            Assert.That(project.Value.Data.Name, Is.EqualTo(projectName));
        }

        [RecordedTest]
        [Ignore("Requires proper ProjectProperties configuration with settings")]
        public async Task CreateProject()
        {
            // Arrange - matching Python/Java payload (location only)
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var projectName = "test-proj-dotnet01";

            var projectData = new ProjectData(DefaultLocation);

            // Act
            var operation = await workspace.Value.GetProjects().CreateOrUpdateAsync(
                WaitUntil.Completed,
                projectName,
                projectData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(projectName));
        }

        [RecordedTest]
        [Ignore("Requires existing project to delete - should create first then delete")]
        public async Task DeleteProject()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var projectName = "test-proj-dotnet01";
            var project = await workspace.Value.GetProjects().GetAsync(projectName);

            // Act
            var operation = await project.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing project with properties that can be updated")]
        public async Task UpdateProject()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var projectName = TestEnvironment.ProjectName;
            var project = await workspace.Value.GetProjects().GetAsync(projectName);

            // Update tags matching Python/Java pattern
            var updateData = project.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await workspace.Value.GetProjects().CreateOrUpdateAsync(
                WaitUntil.Completed,
                projectName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }
    }
}
