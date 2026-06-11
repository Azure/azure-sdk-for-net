// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Test environment configuration for Azure.AI.Discovery tests.
    /// Environment variables are used for live tests and recorded for playback.
    /// </summary>
    public class DiscoveryTestEnvironment : TestEnvironment
    {
        // ----- Workspace -----

        /// <summary>
        /// Gets the Workspace service endpoint URL.
        /// </summary>
        public string WorkspaceEndpoint => GetRecordedVariable(
            "AZURE_DISCOVERY_WORKSPACE_ENDPOINT",
            options => options.IsSecret("https://test-wkspc.workspace.discovery.azure.com"));

        /// <summary>
        /// Gets the API key for the Workspace service (if using key-based auth).
        /// </summary>
        public string WorkspaceApiKey => GetRecordedVariable(
            "AZURE_DISCOVERY_WORKSPACE_KEY",
            options => options.IsSecret());

        /// <summary>
        /// Gets the name of a project for testing.
        /// </summary>
        public string ProjectName => GetRecordedVariable("AZURE_DISCOVERY_PROJECT_NAME",
            options => options.IsSecret("test-project"));

        /// <summary>
        /// Gets the name of an investigation for testing.
        /// </summary>
        public string InvestigationName => GetRecordedVariable("AZURE_DISCOVERY_INVESTIGATION_NAME",
            options => options.IsSecret("test-invst"));

        // ----- Bookshelf -----

        /// <summary>
        /// Gets the Bookshelf service endpoint URL.
        /// </summary>
        public string BookshelfEndpoint => GetRecordedVariable(
            "AZURE_DISCOVERY_BOOKSHELF_ENDPOINT",
            options => options.IsSecret("https://test-bkshlf.bookshelf.discovery.azure.com"));

        /// <summary>
        /// Gets the API key for the Bookshelf service (if using key-based auth).
        /// </summary>
        public string BookshelfApiKey => GetRecordedVariable(
            "AZURE_DISCOVERY_BOOKSHELF_KEY",
            options => options.IsSecret());

        /// <summary>
        /// Gets the name of a knowledge base for testing.
        /// </summary>
        public string KnowledgeBaseName => GetRecordedVariable("KNOWLEDGE_BASE_NAME",
            options => options.IsSecret("test-kb"));

        /// <summary>
        /// Gets the version of a knowledge base for testing.
        /// </summary>
        public string KnowledgeBaseVersion => GetRecordedVariable("KNOWLEDGE_BASE_VERSION",
            options => options.IsSecret("v1"));

        /// <summary>
        /// Gets the node pool ID for indexing operations.
        /// </summary>
        public string NodePoolId => GetRecordedVariable("NODE_POOL_ID",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Discovery/supercomputers/test-sc/nodePools/nodepool1"));

        /// <summary>
        /// Gets the full ARM resource ID for the project (used by indexing operations).
        /// </summary>
        public string ProjectArmId => GetRecordedVariable("PROJECT_ARM_ID",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Discovery/workspaces/test-wkspc/projects/test-project"));

        /// <summary>
        /// Gets the storage asset ID for knowledge base operations.
        /// </summary>
        public string StorageAssetId => GetRecordedVariable("STORAGE_ASSET_ID",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/test-rg/providers/microsoft.discovery/storagecontainers/test-storage/storageassets/test-sa"));

        /// <summary>
        /// Gets the user-assigned identity for knowledge base operations.
        /// </summary>
        public string UserAssignedIdentity => GetRecordedVariable("USER_ASSIGNED_IDENTITY",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-mi"));

        /// <summary>
        /// Gets the agent name used as task assignee.
        /// </summary>
        public string AgentName => GetRecordedVariable("AGENT_NAME",
            options => options.IsSecret("test-agent"));

        // ----- Tools -----

        /// <summary>
        /// Gets the tool ID for tool run operations.
        /// </summary>
        public string ToolId => GetRecordedVariable("TOOL_ID",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Discovery/tools/testtool"));

        /// <summary>
        /// Gets the node pool ID for tool run operations.
        /// </summary>
        public string ToolNodePoolId => GetRecordedVariable("TOOL_NODE_POOL_ID",
            options => options.IsSecret("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Discovery/supercomputers/test-sc/nodePools/nodepool1"));
    }
}
