// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Text.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Text.Authoring
{
    [CodeGenClient("AuthoringClient")]
    [CodeGenSuppress("GetTextAuthoringDeploymentsClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringProjectsClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringModelsClient", typeof(string))]
    [CodeGenSuppress("GetTextAuthoringDeploymentsClient")]
    [CodeGenSuppress("GetTextAuthoringProjectsClient")]
    [CodeGenSuppress("GetTextAuthoringModelsClient")]
    [CodeGenSuppress("_cachedTextAuthoringDeployments")]
    [CodeGenSuppress("_cachedTextAuthoringProjects")]
    [CodeGenSuppress("_cachedTextAuthoringModels")]
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

        /// <summary> Initializes a new instance of TextAuthoringDeployments. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        public virtual TextAuthoringDeployments GetDeployments(string projectName, string deploymentName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringDeployments(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, deploymentName);
        }

        /// <summary> Initializes a new instance of TextAuthoringProjects. </summary>
        public virtual TextAuthoringProjects GetProjects(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringProjects(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of TextAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual TextAuthoringModels GetModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TextAuthoringModels(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }
    }
}
