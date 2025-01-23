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

        /// <summary> Initializes a new instance of CopyProjectAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual CopyProjectAuthoringConversationAnalysis GetCopyProjectAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new CopyProjectAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of DeploymentResourcesAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual DeploymentResourcesAuthoringConversationAnalysis GetDeploymentResourcesAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentResourcesAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of DeploymentsAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual DeploymentsAuthoringConversationAnalysis GetDeploymentsAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ProjectsAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ProjectsAuthoringConversationAnalysis GetProjectsAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ProjectFilesAuthoringConversationAnalysis. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ProjectFilesAuthoringConversationAnalysis GetProjectFilesAuthoringConversationAnalysisClient(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectFilesAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of TrainingAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual TrainingAuthoringConversationAnalysis GetTrainingAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TrainingAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ModelsAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ModelsAuthoringConversationAnalysis GetModelsAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ModelsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of PrebuiltsAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual PrebuiltsAuthoringConversationAnalysis GetPrebuiltsAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new PrebuiltsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ExportedModelsAuthoringConversationAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ExportedModelsAuthoringConversationAnalysis GetExportedModelsAuthoringConversationAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ExportedModelsAuthoringConversationAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }
    }
}
