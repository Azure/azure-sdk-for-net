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
        /// Convenience method to submit an analysis long running operation for conversations and return the response once processed.
        /// <param name="analyzeConversationOperationInput"> The content of the <see cref="AnalyzeConversationOperationResult"/>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationOperationInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual Response<AnalyzeConversationOperationState> AnalyzeConversationOperation(AnalyzeConversationOperationInput analyzeConversationOperationInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationOperationInput, nameof(analyzeConversationOperationInput));
            Argument.AssertNotNull(cancellationToken, nameof(cancellationToken));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationAnalysisClient.AnalyzeConversationOperation");
            scope.Start();

            using RequestContent content = analyzeConversationOperationInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeConversationSubmitOperationRequest(content, context);
                Operation<BinaryData> operation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationAnalysisClient.AnalyzeConversationOperation", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeConversationOperationState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Convenience method to submit an analysis long running operation for conversations and return the response once processed.
        /// <param name="analyzeConversationOperationInput"> The content of the <see cref="AnalyzeConversationOperationResult"/>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationOperationInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The task containing the <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual async Task<Response<AnalyzeConversationOperationState>> AnalyzeConversationOperationAsync(AnalyzeConversationOperationInput analyzeConversationOperationInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationOperationInput, nameof(analyzeConversationOperationInput));
            Argument.AssertNotNull(cancellationToken, nameof(cancellationToken));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationAnalysisClient.AnalyzeConversationOperation");
            scope.Start();

            using RequestContent content = analyzeConversationOperationInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeConversationSubmitOperationRequest(content, context);
                Operation<BinaryData> operation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationAnalysisClient.AnalyzeConversationOperation", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed).ConfigureAwait(false);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeConversationOperationState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
