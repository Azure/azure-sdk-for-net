// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.TrafficManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    [CodeGenType("TrafficManagerUserMetricResource")]
    public partial class TrafficManagerUserMetricsResource
    {
        /// <summary> Backward-compatible CreateOrUpdate. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<TrafficManagerUserMetricsResource> CreateOrUpdate(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, cancellationToken);
        }

        /// <summary> Backward-compatible CreateOrUpdateAsync. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation<TrafficManagerUserMetricsResource>> CreateOrUpdateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete a subscription-level key used for Real User Metrics collection. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _trafficManagerUserMetricsKeysClientDiagnostics.CreateScope("TrafficManagerUserMetricsResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateDeleteRequest(Id.SubscriptionId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerDeleteOperationResult> response = Response.FromValue(TrafficManagerDeleteOperationResult.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new TrafficManagerArmOperation<TrafficManagerDeleteOperationResult>(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new TrafficManagerNonGenericArmOperation(operation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a subscription-level key used for Real User Metrics collection. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _trafficManagerUserMetricsKeysClientDiagnostics.CreateScope("TrafficManagerUserMetricsResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateDeleteRequest(Id.SubscriptionId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerDeleteOperationResult> response = Response.FromValue(TrafficManagerDeleteOperationResult.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new TrafficManagerArmOperation<TrafficManagerDeleteOperationResult>(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new TrafficManagerNonGenericArmOperation(operation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
