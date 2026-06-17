// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.TrafficManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    // TODO - this rename attribute is also incorrect. we need to remove it and do it correctly.
    [CodeGenType("TrafficManagerUserMetricResource")]
    public partial class TrafficManagerUserMetricsResource
    {
        // TODO - we need to remove these customizations to fix this issue: https://github.com/Azure/azure-sdk-for-net/issues/59410
        // These customizations are incorrectly introduced when we migrate this RP to the new typespec generator.
        /// <summary> Create or update a TrafficManagerUserMetric. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<TrafficManagerUserMetricsResource>> CreateOrUpdateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _trafficManagerUserMetricsKeysClientDiagnostics.CreateScope("TrafficManagerUserMetricsResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerUserMetricData> response = Response.FromValue(TrafficManagerUserMetricData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                TrafficManagerArmOperation<TrafficManagerUserMetricsResource> operation = new TrafficManagerArmOperation<TrafficManagerUserMetricsResource>(Response.FromValue(new TrafficManagerUserMetricsResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a TrafficManagerUserMetric. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<TrafficManagerUserMetricsResource> CreateOrUpdate(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _trafficManagerUserMetricsKeysClientDiagnostics.CreateScope("TrafficManagerUserMetricsResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerUserMetricData> response = Response.FromValue(TrafficManagerUserMetricData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                TrafficManagerArmOperation<TrafficManagerUserMetricsResource> operation = new TrafficManagerArmOperation<TrafficManagerUserMetricsResource>(Response.FromValue(new TrafficManagerUserMetricsResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
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
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), context);
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
                HttpMessage message = _trafficManagerUserMetricsKeysRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), context);
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
