// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.Discovery.Tests
{
    public class DiscoveryTestEnvironment : TestEnvironment
    {
        // Workspace
        public string WorkspaceEndpoint => GetRecordedVariable("AZURE_DISCOVERY_WORKSPACE_ENDPOINT", options => options.IsSecret("https://test-wkspc.workspace.discovery.azure.com"));
        public string ProjectName => GetRecordedVariable("AZURE_DISCOVERY_PROJECT_NAME");
        public string InvestigationName => GetRecordedVariable("AZURE_DISCOVERY_INVESTIGATION_NAME");

        // Bookshelf
        public string BookshelfEndpoint => GetRecordedVariable("AZURE_DISCOVERY_BOOKSHELF_ENDPOINT", options => options.IsSecret("https://test-bkshlf.bookshelf.discovery.azure.com"));
        public string KnowledgeBaseName => GetRecordedVariable("KNOWLEDGE_BASE_NAME");
        public string KnowledgeBaseDescription => GetRecordedOptionalVariable("KNOWLEDGE_BASE_DESCRIPTION")
            ?? "Use this tool to query information about immersion cooling systems or liquid cooling technologies.";
        public string KnowledgeBaseCopilotInstruction => GetRecordedOptionalVariable("KNOWLEDGE_BASE_COPILOT_INSTRUCTION")
            ?? "Use this tool to query information about immersion cooling systems or liquid cooling technologies.";

        // Agent (used as task assignee / author)
        public string AgentName => GetRecordedOptionalVariable("AGENT_NAME") ?? "Discovery";

        // Tools / supercomputer
        public string NodePoolId => GetRecordedOptionalVariable("NODE_POOL_ID");
        public string ProjectArmId => GetRecordedOptionalVariable("PROJECT_ARM_ID");
        public string ToolId => GetRecordedOptionalVariable("TOOL_ID");

        // Knowledge base storage
        public string StorageAssetId => GetRecordedOptionalVariable("STORAGE_ASSET_ID", options => options.IsSecret());
        public string UserAssignedIdentity => GetRecordedOptionalVariable("USER_ASSIGNED_IDENTITY", options => options.IsSecret());

        /// <summary>
        /// Local developer credential. The base implementation prefers an interactive
        /// broker (which requires <c>msalruntime</c> and is unavailable on headless
        /// Linux); here we use the CLI/PowerShell-friendly <see cref="DefaultAzureCredential"/>
        /// fallback so <c>az login</c> works locally. CI/live pipelines never reach this
        /// path because they authenticate via the service-principal/pipeline credentials.
        /// </summary>
        protected override TokenCredential CreateDeveloperCredential()
            => new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = true,
                    ExcludeWorkloadIdentityCredential = true,
                    ExcludeBrokerCredential = true,
                    ExcludeVisualStudioCodeCredential = true,
                });
    }
}
