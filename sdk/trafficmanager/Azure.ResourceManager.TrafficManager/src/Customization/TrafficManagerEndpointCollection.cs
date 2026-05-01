// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.TrafficManager.Models;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// The class to overcome issue with the TrafficManagerEndpointData Collection REST API where there is no REST API counterpart that GETs all
    /// endpoint data resources. The all endpoint data resources are retrieved from the collection of endpoints attached to <see cref="TrafficManagerProfileData"/>.
    /// </summary>
    public partial class TrafficManagerEndpointCollection : ArmCollection, IEnumerable<TrafficManagerEndpointData>, IAsyncEnumerable<TrafficManagerEndpointData>
    {
        private readonly ClientDiagnostics _endpointsClientDiagnostics;
        private readonly Endpoints _endpointsRestClient;
        private readonly TrafficManagerProfileData _profileData;

        /// <summary> Initializes a new instance of TrafficManagerEndpointCollection for mocking. </summary>
        protected TrafficManagerEndpointCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TrafficManagerEndpointCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// /// <param name="profileData">The parent profile data. </param>
        internal TrafficManagerEndpointCollection(ArmClient client, ResourceIdentifier id, TrafficManagerProfileData profileData) : base(client, id)
        {
            TryGetApiVersion(TrafficManagerEndpointResource.ResourceType, out string trafficManagerEndpointApiVersion);
            _endpointsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.TrafficManager", TrafficManagerEndpointResource.ResourceType.Namespace, Diagnostics);
            _endpointsRestClient = new Endpoints(_endpointsClientDiagnostics, Pipeline, Endpoint, trafficManagerEndpointApiVersion ?? "2022-04-01");
            this._profileData = profileData;
        }

        /// <summary>
        /// Asynchronously lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="TrafficManagerEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TrafficManagerEndpointData> GetAllAsync()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(Page.FromValues(this._profileData.Endpoints.AsEnumerable(), null, null)), null);
        }

        /// <summary>
        /// Lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="TrafficManagerEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TrafficManagerEndpointData> GetAll()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateEnumerable(_ => Page.FromValues(this._profileData.Endpoints, null, null), null, null);
        }

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<TrafficManagerEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, ParseEndpointType(endpointType), endpointName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<TrafficManagerEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, TrafficManagerEndpointType endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, TrafficManagerEndpointData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new TrafficManagerArmOperation<TrafficManagerEndpointResource>(Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<TrafficManagerEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, ParseEndpointType(endpointType), endpointName, data, cancellationToken);
        }

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<TrafficManagerEndpointResource> CreateOrUpdate(WaitUntil waitUntil, TrafficManagerEndpointType endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, TrafficManagerEndpointData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new TrafficManagerArmOperation<TrafficManagerEndpointResource>(Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TrafficManagerEndpointResource>> GetAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrafficManagerEndpointResource>> GetAsync(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TrafficManagerEndpointResource> Get(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return Get(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrafficManagerEndpointResource> Get(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<TrafficManagerEndpointData> response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficManagerEndpointData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return Exists(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficManagerEndpointData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<TrafficManagerEndpointResource>> GetIfExistsAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<TrafficManagerEndpointResource>> GetIfExistsAsync(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficManagerEndpointData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<TrafficManagerEndpointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<TrafficManagerEndpointResource> GetIfExists(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return GetIfExists(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<TrafficManagerEndpointResource> GetIfExists(TrafficManagerEndpointType endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, endpointType.ToSerialString(), endpointName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<TrafficManagerEndpointData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(TrafficManagerEndpointData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((TrafficManagerEndpointData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<TrafficManagerEndpointResource>(response.GetRawResponse());
                }
                return Response.FromValue(new TrafficManagerEndpointResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static TrafficManagerEndpointType ParseEndpointType(string endpointType)
        {
            return (TrafficManagerEndpointType)Enum.Parse(typeof(TrafficManagerEndpointType), endpointType, true);
        }

        IEnumerator<TrafficManagerEndpointData> IEnumerable<TrafficManagerEndpointData>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TrafficManagerEndpointData> IAsyncEnumerable<TrafficManagerEndpointData>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync().GetAsyncEnumerator(cancellationToken);
        }
    }
}
