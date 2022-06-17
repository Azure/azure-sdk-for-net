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
        public string ProjectName => GetRecordedVariable("CONVERSATIONS_PROJECT_NAME");

        /// <summary>
        /// Gets the deployment name.
        /// </summary>
        public string DeploymentName => GetRecordedVariable("CONVERSATIONS_DEPLOYMENT_NAME");

        /// <summary>
        /// Gets the orchestration test project name.
        /// </summary>
        public string OrchestrationProjectName => GetRecordedVariable("CONVERSATIONS_WORKFLOW_PROJECT_NAME");

        /// <summary>
        /// Gets the orchestration test deploymentName name.
        /// </summary>
        public string OrchestrationDeploymentName => GetRecordedVariable("CONVERSATIONS_WORKFLOW_DEPLOYMENT_NAME");
        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("CONVERSATIONS_ENDPOINT"), UriKind.Absolute);
    }
}
