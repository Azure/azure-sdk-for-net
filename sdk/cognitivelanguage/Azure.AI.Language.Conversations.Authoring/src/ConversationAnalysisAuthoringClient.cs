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
    [CodeGenSuppress("GetConversationAuthoringCopyProjectClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringDeploymentResourcesClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringDeploymentsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringProjectsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringProjectFilesClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringTrainingClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringModelsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringPrebuiltsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringExportedModelsClient", typeof(string))]
    public partial class ConversationAnalysisAuthoringClient
    {
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AnalyzeConversationAuthoringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisAuthoringClient(Uri endpoint, AzureKeyCredential credential, AnalyzeConversationAuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AnalyzeConversationAuthoringClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of ProjectFilesAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ProjectFilesAuthoringConversationAnalysis GetProjectFiles(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectFilesAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of CopyProjectAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual CopyProjectAuthoringConversationAnalysis GetCopyProject(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new CopyProjectAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of DeploymentResourcesAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual DeploymentResourcesAuthoringConversationAnalysis GetDeploymentResources(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentResourcesAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of DeploymentsAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual DeploymentsAuthoringConversationAnalysis GetDeployments(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ProjectsAuthoringConversationAnalysis. </summary>
        public virtual ProjectsAuthoringConversationAnalysis GetProjects()
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of TrainingAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual TrainingAuthoringConversationAnalysis GetTraining(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TrainingAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ModelsAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ModelsAuthoringConversationAnalysis GetModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ModelsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of PrebuiltsAuthoringConversationAnalysis. </summary>
        public virtual PrebuiltsAuthoringConversationAnalysis GetPrebuilts()
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new PrebuiltsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ExportedModelsAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ExportedModelsAuthoringConversationAnalysis GetExportedModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ExportedModelsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }
    }
}
