// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.TrafficManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(TrafficManagerEndpointType), typeof(string), typeof(TrafficManagerEndpointData), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(TrafficManagerEndpointType), typeof(string), typeof(TrafficManagerEndpointData), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(TrafficManagerEndpointType), typeof(string), typeof(CancellationToken))]
    public partial class NestedEndpointTrafficManagerEndpointCollection
    {
        private const string EndpointType = "NestedEndpoints";

        /// <summary> Create or update a Traffic Manager nested endpoint. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<NestedEndpointTrafficManagerEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, TrafficManagerEndpointData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                TrafficManagerArmOperation<NestedEndpointTrafficManagerEndpointResource> operation = new TrafficManagerArmOperation<NestedEndpointTrafficManagerEndpointResource>(Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Create or update a Traffic Manager nested endpoint. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<NestedEndpointTrafficManagerEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, TrafficManagerEndpointData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                TrafficManagerArmOperation<NestedEndpointTrafficManagerEndpointResource> operation = new TrafficManagerArmOperation<NestedEndpointTrafficManagerEndpointResource>(Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Gets a Traffic Manager nested endpoint. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<NestedEndpointTrafficManagerEndpointResource>> GetAsync(string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a Traffic Manager nested endpoint. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<NestedEndpointTrafficManagerEndpointResource> Get(string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the Traffic Manager nested endpoint exists in Azure. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string endpointName, CancellationToken cancellationToken = default)
        {
            NullableResponse<NestedEndpointTrafficManagerEndpointResource> response = await GetIfExistsAsync(endpointName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Checks to see if the Traffic Manager nested endpoint exists in Azure. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string endpointName, CancellationToken cancellationToken = default)
        {
            NullableResponse<NestedEndpointTrafficManagerEndpointResource> response = GetIfExists(endpointName, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this Traffic Manager nested endpoint from the service. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<NestedEndpointTrafficManagerEndpointResource>> GetIfExistsAsync(string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = result.Status switch
                {
                    200 => Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result),
                    404 => Response.FromValue((TrafficManagerEndpointData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<NestedEndpointTrafficManagerEndpointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this Traffic Manager nested endpoint from the service. </summary>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<NestedEndpointTrafficManagerEndpointResource> GetIfExists(string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("NestedEndpointTrafficManagerEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EndpointType, endpointName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = result.Status switch
                {
                    200 => Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result),
                    404 => Response.FromValue((TrafficManagerEndpointData)null, result),
                    _ => throw new RequestFailedException(result)
                };
                if (response.Value == null)
                {
                    return new NoValueResponse<NestedEndpointTrafficManagerEndpointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new NestedEndpointTrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
