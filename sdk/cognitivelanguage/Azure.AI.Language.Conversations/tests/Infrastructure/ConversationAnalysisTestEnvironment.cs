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
        public string ApiKey => GetRecordedVariable("CONVERSATIONS_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the primary test project name.
        /// </summary>
        public string ProjectName => GetRecordedVariable("CONVERSATIONS_PROJECT");

        /// <summary>
        /// Gets the deployment name.
        /// </summary>
        public string DeploymentName => "production";

        /// <summary>
        /// Gets the orchestration test project name.
        /// </summary>
        public string OrchestrationProjectName => "antischTwo";

        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("CONVERSATIONS_URI"), UriKind.Absolute);

        /// <summary>
        /// Gets a <see cref="ConversationsProject"/> using the <see cref="ProjectName"/> and <see cref="DeploymentName"/>.
        /// </summary>
        public ConversationsProject Project => new ConversationsProject(ProjectName, DeploymentName);

        /// <summary>
        /// Gets an orchestration <see cref="ConversationsProject"/> using the <see cref="OrchestrationProjectName"/> and <see cref="DeploymentName"/>.
        /// </summary>
        public ConversationsProject OrchestrationProject => new ConversationsProject(OrchestrationProjectName, DeploymentName);
    }
}
