// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.Language.Documents.Tests
{
    /// <summary>
    /// Test environment settings for the Conversation Analysis SDK.
    /// </summary>
    public class DocumentServiceTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Returns the credential used for local developer authentication.
        /// The base implementation uses a broker/Visual Studio Code chain pinned to the
        /// Azure SDK test tenant, which does not work for headless runs or when the
        /// resource lives in a different tenant. This override uses the standard developer
        /// credential chain (Azure CLI, Visual Studio, Visual Studio Code, Azure PowerShell),
        /// excluding Managed Identity so a non-VM dev box does not stall on the IMDS probe.
        /// CI is unaffected because it authenticates via the pipeline credential before this
        /// method is reached.
        /// </summary>
        protected override TokenCredential CreateDeveloperCredential()
            => new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = true,
                    ExcludeWorkloadIdentityCredential = true,
                });

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
