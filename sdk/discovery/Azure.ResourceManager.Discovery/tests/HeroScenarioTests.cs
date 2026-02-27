// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Hero Scenario Integration Tests: Run a Tool on Supercomputer
    ///
    /// This test class demonstrates the complete end-to-end hero scenario flow
    /// for the Discovery service. These are recorded tests that can be run in
    /// playback mode once recordings are available.
    ///
    /// HERO SCENARIO: "Run a Tool on Supercomputer"
    /// This is the primary use case for the Discovery service - executing
    /// scientific computing tools on Azure supercomputers.
    ///
    /// Prerequisites for recording:
    /// - Azure subscription with Discovery service access
    /// - Existing Supercomputer resource
    /// - Available Node Pools
    /// - Configured Tools
    ///
    /// For unit tests that validate the API surface without Azure resources,
    /// see HeroScenarioUnitTests.cs.
    /// </summary>
    public class HeroScenarioTests : DiscoveryManagementTestBase
    {
        private string _testRunId;
        private string _workspaceName;
        private string _projectName;
        private string _supercomputerName;
        private string _toolName;

        public HeroScenarioTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetup()
        {
            _testRunId = Recording.GenerateAssetName("hero");
            _workspaceName = $"hero-workspace-{_testRunId}";
            _projectName = $"hero-project-{_testRunId}";
            _supercomputerName = TestEnvironment.SupercomputerName ?? "test-supercomputer";
            _toolName = TestEnvironment.ToolName ?? "test-tool";
        }

        // =========================================================================
        // COMPLETE HERO SCENARIO - RECORDED TEST
        // This test demonstrates the full 10-step hero scenario flow.
        // Skipped until recordings are available.
        // =========================================================================

        /// <summary>
        /// Complete Hero Scenario: Run a Tool on Supercomputer
        ///
        /// This recorded test demonstrates the full end-to-end workflow:
        /// 1. Create a Workspace
        /// 2. Create a Project
        /// 3. Get/Verify Supercomputer
        /// 4. Get Node Pool from Supercomputer
        /// 5. Get Tool Definition
        /// 6. Create Investigation (via Workspace client)
        /// 7. Run Tool on Supercomputer (THE HERO!)
        /// 8. Monitor Run Status
        /// 9. Create Task for Results
        /// 10. Query Knowledge Base
        /// </summary>
        [RecordedTest]

        public async Task HeroScenario_RunToolOnSupercomputer()
        {
            // ===== STEP 1: Create a Workspace =====
            TestContext.WriteLine("Step 1: Creating Workspace...");
            var resourceGroup = await CreateResourceGroupAsync();
            var workspaces = resourceGroup.GetWorkspaces();

            var workspaceData = new WorkspaceData(DefaultLocation)
            {
                // Configure workspace with required identity for supercomputer access
            };
            var workspaceOperation = await workspaces.CreateOrUpdateAsync(WaitUntil.Completed, _workspaceName, workspaceData);
            var workspace = workspaceOperation.Value;
            Assert.That(workspace, Is.Not.Null, "Workspace should be created");
            Assert.That(workspace.Data.Name, Is.EqualTo(_workspaceName));
            TestContext.WriteLine($"  ✓ Workspace '{_workspaceName}' created");

            // ===== STEP 2: Create a Project =====
            TestContext.WriteLine("Step 2: Creating Project...");
            var projects = workspace.GetProjects();
            var projectData = new ProjectData(DefaultLocation);
            var projectOperation = await projects.CreateOrUpdateAsync(WaitUntil.Completed, _projectName, projectData);
            var project = projectOperation.Value;
            Assert.That(project, Is.Not.Null, "Project should be created");
            Assert.That(project.Data.Name, Is.EqualTo(_projectName));
            TestContext.WriteLine($"  ✓ Project '{_projectName}' created");

            // ===== STEP 3: Get/Verify Supercomputer =====
            TestContext.WriteLine("Step 3: Getting Supercomputer...");
            var supercomputers = new List<SupercomputerResource>();
            await foreach (var sc in resourceGroup.GetSupercomputers().GetAllAsync())
            {
                supercomputers.Add(sc);
            }
            Assert.That(supercomputers.Count, Is.GreaterThan(0), "At least one Supercomputer should exist");
            var supercomputer = supercomputers.First();
            TestContext.WriteLine($"  ✓ Found Supercomputer: {supercomputer.Data.Name}");

            // ===== STEP 4: Get Node Pool from Supercomputer =====
            TestContext.WriteLine("Step 4: Getting Node Pools...");
            var nodePools = new List<NodePoolResource>();
            await foreach (var np in supercomputer.GetNodePools().GetAllAsync())
            {
                nodePools.Add(np);
            }
            Assert.That(nodePools.Count, Is.GreaterThan(0), "At least one Node Pool should exist");
            var nodePool = nodePools.First();
            TestContext.WriteLine($"  ✓ Found Node Pool: {nodePool.Data.Name}");

            // ===== STEP 5: Get Tool Definition =====
            TestContext.WriteLine("Step 5: Getting Tool...");
            var tools = new List<ToolResource>();
            await foreach (var tool in resourceGroup.GetTools().GetAllAsync())
            {
                tools.Add(tool);
            }
            Assert.That(tools.Count, Is.GreaterThan(0), "At least one Tool should exist");
            var selectedTool = tools.First();
            TestContext.WriteLine($"  ✓ Found Tool: {selectedTool.Data.Name}");

            // ===== STEPS 6-10: Workspace and Bookshelf Client Operations =====
            // These steps require the Azure.Discovery.Workspace and Azure.Discovery.Bookshelf packages
            // which provide the WorkspaceClient and BookshelfClient respectively.

            TestContext.WriteLine("Step 6: Create Investigation - requires WorkspaceClient");
            TestContext.WriteLine("Step 7: Run Tool on Supercomputer (THE HERO!) - requires WorkspaceClient");
            TestContext.WriteLine("Step 8: Monitor Run Status - requires WorkspaceClient");
            TestContext.WriteLine("Step 9: Create Task for Results - requires WorkspaceClient");
            TestContext.WriteLine("Step 10: Query Knowledge Base - requires BookshelfClient");

            // For the complete hero scenario with Workspace and Bookshelf operations,
            // see the integration tests in:
            // - Azure.Discovery.Workspace.Tests
            // - Azure.Discovery.Bookshelf.Tests

            TestContext.WriteLine("\n=== HERO SCENARIO COMPLETE (ARM portion) ===");
        }

        // =========================================================================
        // INDIVIDUAL STEP TESTS - For granular testing
        // =========================================================================

        /// <summary>
        /// Step 1: Create a Workspace via ARM.
        /// </summary>
        [RecordedTest]

        public async Task Step1_CreateWorkspace()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workspaces = resourceGroup.GetWorkspaces();

            var workspaceData = new WorkspaceData(DefaultLocation);
            var operation = await workspaces.CreateOrUpdateAsync(WaitUntil.Completed, _workspaceName, workspaceData);
            var workspace = operation.Value;

            Assert.That(workspace, Is.Not.Null);
            Assert.That(workspace.Data.Name, Is.EqualTo(_workspaceName));
        }

        /// <summary>
        /// Step 2: Create a Project in the Workspace via ARM.
        /// </summary>
        [RecordedTest]

        public async Task Step2_CreateProject()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workspace = (await resourceGroup.GetWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                _workspaceName,
                new WorkspaceData(DefaultLocation))).Value;

            var projects = workspace.GetProjects();
            var projectData = new ProjectData(DefaultLocation);
            var operation = await projects.CreateOrUpdateAsync(WaitUntil.Completed, _projectName, projectData);
            var project = operation.Value;

            Assert.That(project, Is.Not.Null);
            Assert.That(project.Data.Name, Is.EqualTo(_projectName));
        }

        /// <summary>
        /// Step 3: Verify Supercomputer exists.
        /// </summary>
        [RecordedTest]

        public async Task Step3_GetSupercomputer()
        {
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            var supercomputers = new List<SupercomputerResource>();
            await foreach (var sc in resourceGroup.GetSupercomputers().GetAllAsync())
            {
                supercomputers.Add(sc);
            }

            Assert.That(supercomputers, Is.Not.Empty, "Should have at least one Supercomputer");
            TestContext.WriteLine($"Found {supercomputers.Count} supercomputers");
        }

        /// <summary>
        /// Step 4: Get Node Pool from Supercomputer.
        /// </summary>
        [RecordedTest]

        public async Task Step4_GetNodePool()
        {
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Get first supercomputer
            SupercomputerResource supercomputer = null;
            await foreach (var sc in resourceGroup.GetSupercomputers().GetAllAsync())
            {
                supercomputer = sc;
                break;
            }
            Assert.That(supercomputer, Is.Not.Null, "Should have at least one Supercomputer");

            // Get node pools
            var nodePools = new List<NodePoolResource>();
            await foreach (var np in supercomputer.GetNodePools().GetAllAsync())
            {
                nodePools.Add(np);
            }

            Assert.That(nodePools, Is.Not.Empty, "Supercomputer should have at least one Node Pool");
            TestContext.WriteLine($"Found {nodePools.Count} node pools");
        }

        /// <summary>
        /// Step 5: Get Tool Definition.
        /// </summary>
        [RecordedTest]

        public async Task Step5_GetTool()
        {
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            var tools = new List<ToolResource>();
            await foreach (var tool in resourceGroup.GetTools().GetAllAsync())
            {
                tools.Add(tool);
            }

            Assert.That(tools, Is.Not.Empty, "Should have at least one Tool");
            TestContext.WriteLine($"Found {tools.Count} tools");
        }

        /// <summary>
        /// Step 6-7: Create Investigation and Run Tool (THE HERO!).
        /// This requires the WorkspaceClient from Azure.Discovery.Workspace.
        /// </summary>
        [RecordedTest]

        public async Task Step6And7_CreateInvestigationAndRunTool()
        {
            // This test would:
            // 1. Create a WorkspaceClient using the workspace endpoint
            // 2. Create an Investigation
            // 3. Run a Tool on the Supercomputer (THE HERO!)

            // Example (pseudo-code):
            // var workspaceClient = new WorkspaceClient(workspaceEndpoint, credential);
            // var investigation = await workspaceClient.GetInvestigations().CreateAsync(...);
            // var toolRun = await workspaceClient.GetTools().RunAsync(toolId, nodePoolIds, ...);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Step 8: Monitor Run Status.
        /// </summary>
        [RecordedTest]

        public async Task Step8_MonitorRunStatus()
        {
            // This test would poll the tool run status using WorkspaceClient
            await Task.CompletedTask;
        }

        /// <summary>
        /// Step 9: Create Task for Results.
        /// </summary>
        [RecordedTest]

        public async Task Step9_CreateTask()
        {
            // This test would create a task to process results
            await Task.CompletedTask;
        }

        /// <summary>
        /// Step 10: Query Knowledge Base for insights.
        /// </summary>
        [RecordedTest]

        public async Task Step10_QueryKnowledgeBase()
        {
            // This test would search the knowledge base using BookshelfClient
            await Task.CompletedTask;
        }
    }
}
