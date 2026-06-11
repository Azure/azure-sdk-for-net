// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Documents.Tests
{
    /// <summary>
    /// Test environment settings for the Conversation Analysis SDK.
    /// </summary>
    public class DocumentServiceTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the master API key.
        /// </summary>
        public string ApiKey => GetRecordedVariable("DOCUMENTS_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the primary test project name.
        /// </summary>
        public string ProjectName => GetRecordedVariable("DOCUMENTS_PROJECT_NAME");

        /// <summary>
        /// Gets the deployment name.
        /// </summary>
        public string DeploymentName => GetRecordedVariable("DOCUMENTS_DEPLOYMENT_NAME");

        /// <summary>
        /// Gets the orchestration test project name.
        /// </summary>
        public string OrchestrationProjectName => GetRecordedVariable("DOCUMENTS_WORKFLOW_PROJECT_NAME");

        /// <summary>
        /// Gets the orchestration test deploymentName name.
        /// </summary>
        public string OrchestrationDeploymentName => GetRecordedVariable("DOCUMENTS_WORKFLOW_DEPLOYMENT_NAME");
        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public Uri Endpoint => new(GetRecordedVariable("DOCUMENTS_ENDPOINT"), UriKind.Absolute);

        /// <summary>
        /// Gets the source blob location.
        /// </summary>
        public string SourceLocation => GetRecordedVariable("DOCUMENTS_SOURCE_LOCATION");

        /// <summary>
        /// Gets the target blob folder location.
        /// </summary>
        public string TargetLocation => GetRecordedVariable("DOCUMENTS_TARGET_LOCATION");
    }
}
