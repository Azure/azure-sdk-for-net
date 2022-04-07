// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests
{
    /// <summary>
    /// Test environment settings for the Conversation Analysis SDK.
    /// </summary>
    public class ConversationAnalysisTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the master API key.
        /// </summary>
        public string ApiKey => GetRecordedVariable("AZURE_CONVERSATIONS_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the primary test project name.
        /// </summary>
        public string ProjectName => GetRecordedVariable("AZURE_CONVERSATIONS_PROJECT_NAME");

        /// <summary>
        /// Gets the deployment name.
        /// </summary>
        public string DeploymentName => GetRecordedVariable("AZURE_CONVERSATIONS_DEPLOYMENT_NAME");

        /// <summary>
        /// Gets the orchestration test project name.
        /// </summary>
        public string OrchestrationProjectName => GetRecordedVariable("AZURE_CONVERSATIONS_WORKFLOW_PROJECT_NAME");

        /// <summary>
        /// Gets the orchestration test deploymentName name.
        /// </summary>
        public string OrchestrationDeploymentName => GetRecordedVariable("AZURE_CONVERSATIONS_WORKFLOW_DEPLOYMENT_NAME");
        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("AZURE_CONVERSATIONS_ENDPOINT"), UriKind.Absolute);

        /// <summary>
        /// Gets a <see cref="ConversationsProject"/> using the <see cref="ProjectName"/> and <see cref="DeploymentName"/>.
        /// </summary>
        public ConversationsProject Project => new ConversationsProject(ProjectName, DeploymentName);

        /// <summary>
        /// Gets an orchestration <see cref="ConversationsProject"/> using the <see cref="OrchestrationProjectName"/> and <see cref="DeploymentName"/>.
        /// </summary>
        public ConversationsProject OrchestrationProject => new ConversationsProject(OrchestrationProjectName, OrchestrationDeploymentName);
    }
}
