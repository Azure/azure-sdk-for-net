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
        public ConversationAnalysisAuthoringClient(Uri endpoint, AzureKeyCredential credential, ConversationAnalysisAuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationAnalysisAuthoringClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of ConversationAuthoringProjectFiles. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringProjectFiles GetProjectFiles(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringProjectFiles(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringCopyProject. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringCopyProject GetCopyProject(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringCopyProject(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringDeploymentResources. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringDeploymentResources GetDeploymentResources(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringDeploymentResources(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringDeployments. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringDeployments GetDeployments(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringDeployments(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringProjects. </summary>
        public virtual ConversationAuthoringProjects GetProjects()
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringProjects(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringTraining. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringTraining GetTraining(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringTraining(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringModels GetModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringModels(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringPrebuilts. </summary>
        public virtual ConversationAuthoringPrebuilts GetPrebuilts()
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringPrebuilts(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringExportedModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringExportedModels GetExportedModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringExportedModels(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }
    }
}
