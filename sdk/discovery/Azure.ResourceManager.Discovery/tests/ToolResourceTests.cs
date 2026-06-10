// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Discovery.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for Tool resource operations.
    /// Tool is a top-level resource under ResourceGroup.
    /// </summary>
    public class ToolResourceTests : DiscoveryManagementTestBase
    {
        public ToolResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListToolsBySubscription()
        {
            // Arrange & Act
            var tools = new List<ToolResource>();
            await foreach (var tool in DefaultSubscription.GetToolsAsync())
            {
                tools.Add(tool);
            }

            // Assert
            Assert.That(tools, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ListToolsByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var tools = new List<ToolResource>();
            await foreach (var tool in resourceGroup.GetTools().GetAllAsync())
            {
                tools.Add(tool);
            }

            // Assert
            Assert.That(tools, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var toolName = TestEnvironment.ToolName;

            // Act
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Assert
            Assert.That(tool.Value, Is.Not.Null);
            Assert.That(tool.Value.Data.Name, Is.EqualTo(toolName));
        }

        [RecordedTest]
        public async Task CreateTool()
        {
            // Arrange - matching Python/Java definitionContent payload
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var toolName = "test-tool-dotnet01";

            var definitionContent = new Dictionary<string, BinaryData>
            {
                ["name"] = BinaryData.FromObjectAsJson("molpredictor"),
                ["description"] = BinaryData.FromObjectAsJson("Molecular property prediction for single SMILES strings."),
                ["version"] = BinaryData.FromObjectAsJson("1.0.0"),
                ["category"] = BinaryData.FromObjectAsJson("cheminformatics"),
                ["license"] = BinaryData.FromObjectAsJson("MIT"),
                ["infra"] = BinaryData.FromObjectAsJson(new[]
                {
                    new Dictionary<string, object>
                    {
                        ["name"] = "worker",
                        ["infra_type"] = "container",
                        ["image"] = new Dictionary<string, object> { ["acr"] = "demodiscoveryacr.azurecr.io/molpredictor:latest" },
                        ["compute"] = new Dictionary<string, object>
                        {
                            ["min_resources"] = new Dictionary<string, object> { ["cpu"] = "1", ["ram"] = "1Gi", ["storage"] = "32", ["gpu"] = "0" },
                            ["max_resources"] = new Dictionary<string, object> { ["cpu"] = "2", ["ram"] = "1Gi", ["storage"] = "64", ["gpu"] = "0" },
                            ["recommended_sku"] = new[] { "Standard_D4s_v6" },
                            ["pool_type"] = "static",
                            ["pool_size"] = 1,
                        }
                    }
                }),
                ["actions"] = BinaryData.FromObjectAsJson(new[]
                {
                    new Dictionary<string, object>
                    {
                        ["name"] = "predict",
                        ["description"] = "Predict molecular properties for SMILES strings.",
                        ["input_schema"] = new Dictionary<string, object>
                        {
                            ["type"] = "object",
                            ["properties"] = new Dictionary<string, object>
                            {
                                ["action"] = new Dictionary<string, object>
                                {
                                    ["type"] = "string",
                                    ["description"] = "The property to predict. Must be one of [log_p, boiling_point, solubility, density, critical_point]",
                                }
                            },
                            ["required"] = new[] { "action" },
                        },
                        ["command"] = "python molpredictor.py --action {{ action }}",
                        ["infra_node"] = "worker",
                    }
                }),
            };

            var toolData = new ToolData(DefaultLocation)
            {
                Properties = new ToolProperties("1.0.0", definitionContent),
            };

            // Act
            var operation = await resourceGroup.GetTools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                toolName,
                toolData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(toolName));
        }

        [RecordedTest]
        public async Task UpdateTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var toolName = TestEnvironment.ToolName;
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Update tags matching Python/Java pattern
            var updateData = tool.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await resourceGroup.GetTools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                toolName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }

        [RecordedTest]
        public async Task DeleteTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var toolName = "test-tool-dotnet01";
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Act
            var operation = await tool.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
