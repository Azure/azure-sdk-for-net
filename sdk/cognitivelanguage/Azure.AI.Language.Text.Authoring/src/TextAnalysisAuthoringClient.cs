// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Text.Authoring
{
    [CodeGenClient("AuthoringClient")]
    [CodeGenSuppress("GetTextAuthoringDeploymentClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringProjectClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringExportedModelClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringTrainedModelClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringDeploymentClient")]
    [CodeGenSuppress("GetTextAuthoringProjectClient")]
    [CodeGenSuppress("GetTextAuthoringExportedModelClient")]
    [CodeGenSuppress("GetTextAuthoringTrainedModelClient")]
    [CodeGenSuppress("_cachedTextAuthoringDeployment")]
    [CodeGenSuppress("_cachedTextAuthoringProject")]
    [CodeGenSuppress("_cachedTextAuthoringTrainedModel")]
    [CodeGenSuppress("_cachedTextAuthoringExportedModel")]
    public partial class TextAnalysisAuthoringClient
    {
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AnalyzeTextAuthoringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public TextAnalysisAuthoringClient(Uri endpoint, AzureKeyCredential credential, TextAnalysisAuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new TextAnalysisAuthoringClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of TextAuthoringDeployment. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        public virtual TextAuthoringDeployment GetDeployment(string projectName, string deploymentName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringDeployment(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, deploymentName);
        }

        /// <summary> Initializes a new instance of TextAuthoringProject. </summary>
        public virtual TextAuthoringProject GetProject(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringProject(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of TextAuthoringExportedModel. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="exportedModelName"> The exported model name to use for this subclient. </param>
        public virtual TextAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringExportedModel(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, exportedModelName);
        }

        /// <summary> Initializes a new instance of TextAuthoringTrainedModel. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="trainedModelLabel"> The trained model label to use for this subclient. </param>
        public virtual TextAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringTrainedModel(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, trainedModelLabel);
        }
    }
}
