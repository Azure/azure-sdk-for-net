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
    [CodeGenSuppress("ExportAsync", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Export", typeof(WaitUntil), typeof(string), typeof(StringIndexType), typeof(AnalyzeConversationAuthoringExportedProjectFormat?), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class ConversationAuthoringProjectFiles
    {
        private readonly string _projectName;

        /// <summary> Initializes a new instance of ConversationAuthoringProjectFiles. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="projectName"> The new project name. </param>
        internal ConversationAuthoringProjectFiles(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _projectName = projectName;
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
        public virtual async Task<Operation> ExportAsync(WaitUntil waitUntil, string projectName, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
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
        public virtual Operation Export(WaitUntil waitUntil, string projectName, AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Export(waitUntil, projectName, "Utf16CodeUnit", exportedProjectFormat?.ToString(), assetKind, trainedModelLabel, context);
        }
    }
}
