// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenClient("AuthoringClient")]
    [CodeGenSuppress("GetConversationAuthoringDeploymentClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringProjectClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringExportedModelClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringTrainedModelClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringDeploymentClient")]
    [CodeGenSuppress("GetConversationAuthoringProjectClient")]
    [CodeGenSuppress("GetConversationAuthoringExportedModelClient")]
    [CodeGenSuppress("GetConversationAuthoringTrainedModelClient")]
    [CodeGenSuppress("_cachedConversationAuthoringDeployment")]
    [CodeGenSuppress("_cachedConversationAuthoringProject")]
    [CodeGenSuppress("_cachedConversationAuthoringExportedModel")]
    [CodeGenSuppress("_cachedConversationAuthoringTrainedModel")]
    public partial class ConversationAnalysisAuthoringClient
    {
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of ConversationAnalysisAuthoringClient. </summary>
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

        /// <summary> Initializes a new instance of ConversationAuthoringDeployment. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        public virtual ConversationAuthoringDeployment GetDeployment(string projectName, string deploymentName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringDeployment(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, deploymentName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringProject. </summary>
        public virtual ConversationAuthoringProject GetProject(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringProject(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="exportedModelName"> The exported model name to use for this subclient. </param>
        public virtual ConversationAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringExportedModel(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, exportedModelName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="trainedModelLabel"> The trained model label to use for this subclient. </param>
        public virtual ConversationAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringTrainedModel(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, trainedModelLabel);
        }
    }
}
