// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public partial class TrafficManagerProfileResource
    {
        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<TrafficManagerEndpointResource>> GetTrafficManagerEndpointAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await GetTrafficManagerEndpointAsync((TrafficManagerEndpointType)Enum.Parse(typeof(TrafficManagerEndpointType), endpointType, true), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<TrafficManagerEndpointResource> GetTrafficManagerEndpoint(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return GetTrafficManagerEndpoint((TrafficManagerEndpointType)Enum.Parse(typeof(TrafficManagerEndpointType), endpointType, true), endpointName, cancellationToken);
        }

        /// <summary> Deletes a Traffic Manager profile. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _profilesClientDiagnostics.CreateScope("TrafficManagerProfileResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _profilesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
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

        /// <summary> Deletes a Traffic Manager profile. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _profilesClientDiagnostics.CreateScope("TrafficManagerProfileResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _profilesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
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
