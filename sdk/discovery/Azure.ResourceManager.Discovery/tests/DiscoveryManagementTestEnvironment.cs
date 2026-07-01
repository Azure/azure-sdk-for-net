// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Test environment configuration for Azure.ResourceManager.Discovery tests.
    /// </summary>
    public class DiscoveryManagementTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the name of the resource group for testing.
        /// </summary>
        public string ResourceGroupName => GetRecordedVariable("AZURE_RESOURCE_GROUP_NAME");

        /// <summary>
        /// Gets the name of a Bookshelf resource for testing.
        /// </summary>
        public string BookshelfName => GetRecordedVariable("AZURE_DISCOVERY_BOOKSHELF_NAME");

        /// <summary>
        /// Gets the name of a Workspace resource for testing.
        /// </summary>
        public string WorkspaceName => GetRecordedVariable("AZURE_DISCOVERY_WORKSPACE_NAME");

        /// <summary>
        /// Gets the name of a Project resource for testing.
        /// </summary>
        public string ProjectName => GetRecordedVariable("AZURE_DISCOVERY_PROJECT_NAME");

        /// <summary>
        /// Gets the name of a Supercomputer resource for testing.
        /// </summary>
        public string SupercomputerName => GetRecordedVariable("AZURE_DISCOVERY_SUPERCOMPUTER_NAME");

        /// <summary>
        /// Gets the name of a Tool resource for testing.
        /// </summary>
        public string ToolName => GetRecordedVariable("AZURE_DISCOVERY_TOOL_NAME");

        /// <summary>
        /// Gets the name of a StorageContainer resource for testing.
        /// </summary>
        public string StorageContainerName => GetRecordedVariable("AZURE_DISCOVERY_STORAGE_CONTAINER_NAME");

        /// <summary>
        /// Gets the name of a StorageAsset resource for testing.
        /// </summary>
        public string StorageAssetName => GetRecordedVariable("AZURE_DISCOVERY_STORAGE_ASSET_NAME");

        /// <summary>
        /// Gets the name of a ChatModelDeployment resource for testing.
        /// </summary>
        public string ChatModelDeploymentName => GetRecordedVariable("AZURE_DISCOVERY_CHAT_MODEL_DEPLOYMENT_NAME");

        /// <summary>
        /// Gets the name of a NodePool resource for testing.
        /// </summary>
        public string NodePoolName => GetRecordedVariable("AZURE_DISCOVERY_NODE_POOL_NAME");
    }
}
