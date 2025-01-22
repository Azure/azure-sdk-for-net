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
    public partial class AnalyzeConversationAuthoringClient
    {
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AnalyzeConversationAuthoringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public AnalyzeConversationAuthoringClient(Uri endpoint, AzureKeyCredential credential, AnalyzeConversationAuthoringClientOptions options)
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

        /// <summary> Initializes a new instance of CopyProjectConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual CopyProjectConversationAuthoringAnalysis GetCopyProjectConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new CopyProjectConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of DeploymentResourcesConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual DeploymentResourcesConversationAuthoringAnalysis GetDeploymentResourcesConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentResourcesConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of DeploymentsConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual DeploymentsConversationAuthoringAnalysis GetDeploymentsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ProjectsConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ProjectsConversationAuthoringAnalysis GetProjectsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ProjectFilesConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ProjectFilesConversationAuthoringAnalysis GetProjectFilesConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectFilesConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of TrainingConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual TrainingConversationAuthoringAnalysis GetTrainingConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TrainingConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ModelsConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ModelsConversationAuthoringAnalysis GetModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of PrebuiltsConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual PrebuiltsConversationAuthoringAnalysis GetPrebuiltsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new PrebuiltsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ExportedModelsConversationAuthoringAnalysis. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ExportedModelsConversationAuthoringAnalysis GetExportedModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ExportedModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }
    }
}
