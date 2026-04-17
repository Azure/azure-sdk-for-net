// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HDInsight.Models;

namespace Azure.ResourceManager.HDInsight
{
    public partial class HDInsightApplicationResource
    {
        /// <summary> Gets the async operation status. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetAzureAsyncOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _applicationsClientDiagnostics.CreateScope("HDInsightApplicationResource.GetAzureAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _applicationsRestClient.CreateGetAzureAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the async operation status. </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HDInsightAsyncOperationResult> GetAzureAsyncOperationStatus(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _applicationsClientDiagnostics.CreateScope("HDInsightApplicationResource.GetAzureAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _applicationsRestClient.CreateGetAzureAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(HDInsightAsyncOperationResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
