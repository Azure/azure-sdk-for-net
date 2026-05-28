// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationAnalysisClient
    {
        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        private readonly TokenCredential _tokenCredential;

        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisClient(Uri endpoint, TokenCredential credential, ConversationsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationsClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? ConversationsAudience.AzurePublicCloud : options.Audience)}/.default";

            _tokenCredential = credential;

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Convenience method to submit an analysis long running operation for conversations and return the response once processed.
        /// <param name="analyzeConversationOperationInput"> The input for the analyze conversations operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationOperationInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual Response<AnalyzeConversationOperationState> AnalyzeConversations(AnalyzeConversationOperationInput analyzeConversationOperationInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationOperationInput, nameof(analyzeConversationOperationInput));

            using RequestContent content = analyzeConversationOperationInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            Operation<BinaryData> operation = AnalyzeConversations(WaitUntil.Completed, content, context);
            Response response = operation.GetRawResponse();
            return Response.FromValue(AnalyzeConversationOperationState.FromResponse(response), response);
        }

        /// <summary>
        /// Convenience method to submit an analysis long running operation for conversations and return the response once processed.
        /// <param name="analyzeConversationOperationInput"> The input for the analyze conversations operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationOperationInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual async Task<Response<AnalyzeConversationOperationState>> AnalyzeConversationsAsync(AnalyzeConversationOperationInput analyzeConversationOperationInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationOperationInput, nameof(analyzeConversationOperationInput));

            using RequestContent content = analyzeConversationOperationInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            Operation<BinaryData> operation = await AnalyzeConversationsAsync(WaitUntil.Completed, content, context).ConfigureAwait(false);
            Response response = operation.GetRawResponse();
            return Response.FromValue(AnalyzeConversationOperationState.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Submits an analysis long running operation for conversations and return the response once processed.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeConversations(AnalyzeConversationOperationInput,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> AnalyzeConversations(WaitUntil waitUntil, RequestContent content, RequestContext context = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationAnalysisClient.AnalyzeConversations");
            scope.Start();

            try
            {
                using HttpMessage message = CreateAnalyzeConversationSubmitOperationRequest(content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationAnalysisClient.AnalyzeConversations", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Submits an analysis long running operation for conversations and return the response once processed.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeConversationsAsync(AnalyzeConversationOperationInput,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> AnalyzeConversationsAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationAnalysisClient.AnalyzeConversations");
            scope.Start();

            try
            {
                using HttpMessage message = CreateAnalyzeConversationSubmitOperationRequest(content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationAnalysisClient.AnalyzeConversations", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
