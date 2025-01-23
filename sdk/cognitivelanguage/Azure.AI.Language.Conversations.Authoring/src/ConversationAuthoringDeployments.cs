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
    public partial class ConversationAuthoringDeployments
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringDeployments. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringDeployments(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
        }
    }
}
