// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenClient("AuthoringClient")]
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class AnalyzeConversationClient
    {
        private readonly string _apiVersion;

        public AnalyzeConversationClient(Uri endpoint, AzureKeyCredential credential, AnalyzeConversationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AnalyzeConversationClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        // New GetCopyProjectConversationAuthoringAnalysisClient method
        public virtual CopyProjectConversationAuthoringAnalysis GetCopyProjectConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new CopyProjectConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual DeploymentResourcesConversationAuthoringAnalysis GetDeploymentResourcesConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentResourcesConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual DeploymentsConversationAuthoringAnalysis GetDeploymentsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ProjectsConversationAuthoringAnalysis GetProjectsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ProjectFilesConversationAuthoringAnalysis GetProjectFilesConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectFilesConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual TrainingConversationAuthoringAnalysis GetTrainingConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TrainingConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ModelsConversationAuthoringAnalysis GetModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual PrebuiltsConversationAuthoringAnalysis GetPrebuiltsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new PrebuiltsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ExportedModelsConversationAuthoringAnalysis GetExportedModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ExportedModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation> ExportAsync(WaitUntil waitUntil, string projectName, AnalyzeConversationExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await ExportAsync(waitUntil, projectName, "Utf16CodeUnit", exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context).ConfigureAwait(false);
        }

        /// <summary> Triggers a job to export a project's data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="trainedModelLabel"> Trained model label to export. If the trainedModelLabel is null, the default behavior is to export the current working copy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation Export(WaitUntil waitUntil, string projectName, AnalyzeConversationExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Export(waitUntil, projectName, "Utf16CodeUnit", exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context);
        }
    }
}
