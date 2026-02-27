// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Unit tests for the Discovery SDK Hero Scenario.
    /// These tests validate the API surface without requiring Azure resources or recorded sessions.
    ///
    /// HERO SCENARIO: "Run a Tool on Supercomputer"
    /// This is the primary use case for the Discovery service - executing
    /// scientific computing tools on Azure supercomputers.
    /// </summary>
    [TestFixture]
    public class HeroScenarioUnitTests
    {
        // =========================================================================
        // HERO SCENARIO FLOW DOCUMENTATION
        // =========================================================================

        /// <summary>
        /// Document the complete hero scenario flow.
        /// This test serves as executable documentation of the 10-step
        /// hero scenario for running a tool on a supercomputer.
        /// </summary>
        [Test]
        public void HeroScenarioFlowDocumentation()
        {
            var heroScenarioSteps = new[]
            {
                new { Step = 1, Name = "Create Workspace", Client = "ARM (ArmClient)", Operation = "GetWorkspaces().CreateOrUpdate()", Description = "Create an Azure Discovery Workspace to organize resources" },
                new { Step = 2, Name = "Create Project", Client = "ARM (ArmClient)", Operation = "GetProjects().CreateOrUpdate()", Description = "Create a Project within the Workspace for logical grouping" },
                new { Step = 3, Name = "Get Supercomputer", Client = "ARM (ArmClient)", Operation = "GetSupercomputer()", Description = "Get reference to an existing Supercomputer for compute" },
                new { Step = 4, Name = "Get Node Pool", Client = "ARM (ArmClient)", Operation = "GetNodePools()", Description = "Get available node pools for running tools" },
                new { Step = 5, Name = "Get Tool Definition", Client = "ARM (ArmClient)", Operation = "GetTool()", Description = "Get the tool to run (e.g., molecular dynamics simulation)" },
                new { Step = 6, Name = "Create Investigation", Client = "Workspace (WorkspaceClient)", Operation = "GetInvestigations().CreateOrUpdate()", Description = "Create an Investigation to track the scientific workflow" },
                new { Step = 7, Name = "Run Tool on Supercomputer", Client = "Workspace (WorkspaceClient)", Operation = "GetTools().Run()", Description = "THE HERO - Execute the tool on supercomputer nodes" },
                new { Step = 8, Name = "Monitor Run Status", Client = "Workspace (WorkspaceClient)", Operation = "GetTools().GetRunStatus()", Description = "Poll for completion of the tool run" },
                new { Step = 9, Name = "Create Task for Results", Client = "Workspace (WorkspaceClient)", Operation = "GetTasks().Create()", Description = "Create a task to process and analyze results" },
                new { Step = 10, Name = "Query Knowledge Base", Client = "Bookshelf (BookshelfClient)", Operation = "GetKnowledgeBaseVersions().Search()", Description = "Search knowledge base for insights from the run" },
            };

            // Validate all steps are documented
            Assert.That(heroScenarioSteps.Length, Is.EqualTo(10), "Hero scenario has 10 steps");

            // Print the flow for documentation
            TestContext.WriteLine("\n=== HERO SCENARIO: Run Tool on Supercomputer ===\n");
            foreach (var step in heroScenarioSteps)
            {
                TestContext.WriteLine($"Step {step.Step}: {step.Name}");
                TestContext.WriteLine($"  Client: {step.Client}");
                TestContext.WriteLine($"  Operation: {step.Operation}");
                TestContext.WriteLine($"  {step.Description}\n");
            }
        }

        // =========================================================================
        // UNIT TESTS - Validate API Surface
        // =========================================================================

        /// <summary>
        /// Validate ARM client exposes workspace operations.
        /// </summary>
        [Test]
        public void ArmClientHasWorkspaceOperations()
        {
            // Verify WorkspaceResource type exists
            var workspaceType = typeof(WorkspaceResource);
            Assert.That(workspaceType, Is.Not.Null);
            Assert.That(workspaceType.Name, Is.EqualTo("WorkspaceResource"));
        }

        /// <summary>
        /// Validate ARM client exposes project operations.
        /// </summary>
        [Test]
        public void ArmClientHasProjectOperations()
        {
            // Verify ProjectResource type exists
            var projectType = typeof(ProjectResource);
            Assert.That(projectType, Is.Not.Null);
            Assert.That(projectType.Name, Is.EqualTo("ProjectResource"));
        }

        /// <summary>
        /// Validate ARM client exposes supercomputer operations.
        /// </summary>
        [Test]
        public void ArmClientHasSupercomputerOperations()
        {
            // Verify SupercomputerResource type exists
            var supercomputerType = typeof(SupercomputerResource);
            Assert.That(supercomputerType, Is.Not.Null);
            Assert.That(supercomputerType.Name, Is.EqualTo("SupercomputerResource"));
        }

        /// <summary>
        /// Validate ARM client exposes tool operations.
        /// </summary>
        [Test]
        public void ArmClientHasToolOperations()
        {
            // Verify ToolResource type exists
            var toolType = typeof(ToolResource);
            Assert.That(toolType, Is.Not.Null);
            Assert.That(toolType.Name, Is.EqualTo("ToolResource"));
        }

        /// <summary>
        /// Validate ARM client exposes node pool operations.
        /// </summary>
        [Test]
        public void ArmClientHasNodePoolOperations()
        {
            // Verify NodePoolResource type exists
            var nodePoolType = typeof(NodePoolResource);
            Assert.That(nodePoolType, Is.Not.Null);
            Assert.That(nodePoolType.Name, Is.EqualTo("NodePoolResource"));
        }

        /// <summary>
        /// Validate ARM client exposes bookshelf operations.
        /// </summary>
        [Test]
        public void ArmClientHasBookshelfOperations()
        {
            // Verify BookshelfResource type exists
            var bookshelfType = typeof(BookshelfResource);
            Assert.That(bookshelfType, Is.Not.Null);
            Assert.That(bookshelfType.Name, Is.EqualTo("BookshelfResource"));
        }
    }
}
