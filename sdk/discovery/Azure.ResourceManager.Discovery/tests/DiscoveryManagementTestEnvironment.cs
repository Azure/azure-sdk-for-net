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
    }
}
