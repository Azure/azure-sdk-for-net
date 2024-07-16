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
    public partial class ConversationsClient
    {
        /// <summary>
        /// [Convenience method to submit an analysis job for conversations and return the response once processed.
        /// <param name="analyzeConversationJobsInput"> The content of the <see cref="AnalyzeConversationJobsInput"/>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationJobsInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual Response<AnalyzeConversationJobState> AnalyzeConversationsOperation(AnalyzeConversationJobsInput analyzeConversationJobsInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationJobsInput, nameof(analyzeConversationJobsInput));
            Argument.AssertNotNull(cancellationToken, nameof(cancellationToken));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationsClient.AnalyzeConversationsOperation");
            scope.Start();

            using RequestContent content = analyzeConversationJobsInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeConversationsSubmitJobRequest(content, context);
                Operation<BinaryData> operation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "ConversationsClient.AnalyzeConversationsOperation", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeConversationJobState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Convenience method to submit an analysis job for conversations and return the response once processed.
        /// <param name="analyzeConversationJobsInput"> The content of the <see cref="AnalyzeConversationJobsInput"/>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzeConversationJobsInput"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The task containing the <see cref="Response"/> representing the result of the long running operation on the service. </returns>
        /// </summary>
        public virtual async Task<Response<AnalyzeConversationJobState>> AnalyzeConversationsOperationAsync(AnalyzeConversationJobsInput analyzeConversationJobsInput, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(analyzeConversationJobsInput, nameof(analyzeConversationJobsInput));
            Argument.AssertNotNull(cancellationToken, nameof(cancellationToken));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ConversationsClient.AnalyzeConversationsOperationAsync");
            scope.Start();

            using RequestContent content = analyzeConversationJobsInput.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeConversationsSubmitJobRequest(content, context);
                Operation<BinaryData> operation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "ConversationsClient.AnalyzeConversationsOperationAsync", OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed).ConfigureAwait(false);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeConversationJobState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
