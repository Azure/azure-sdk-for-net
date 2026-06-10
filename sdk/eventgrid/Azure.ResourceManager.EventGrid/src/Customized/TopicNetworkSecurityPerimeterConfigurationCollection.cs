// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: the new MPG generator emits the NSP
    // Resource class but never the matching per-parent Collection class. We hand-author
    // the Collection against the generator-produced internal NetworkSecurityPerimeterConfigurations
    // REST client and the auto-generated NetworkSecurityPerimeterConfigurationData.)
    /// <summary>
    /// A class representing a collection of <see cref="TopicNetworkSecurityPerimeterConfigurationResource"/> and their operations.
    /// Each <see cref="TopicNetworkSecurityPerimeterConfigurationResource"/> in the collection will belong to the same instance of <see cref="EventGridTopicResource"/>.
    /// To get a <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> instance call the GetTopicNetworkSecurityPerimeterConfigurations method from an instance of <see cref="EventGridTopicResource"/>.
    /// </summary>
    public partial class TopicNetworkSecurityPerimeterConfigurationCollection : ArmCollection,
        IEnumerable<NetworkSecurityPerimeterConfigurationData>,
        IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>
    {
        private const string TopicResourceTypeSegment = "topics";
        private const string DiagnosticNamespace = "Azure.ResourceManager.EventGrid";
        private const string DefaultApiVersion = "2025-07-15-preview";

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NetworkSecurityPerimeterConfigurations _restClient;

        /// <summary> Initializes a new instance of the <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> class for mocking. </summary>
        protected TopicNetworkSecurityPerimeterConfigurationCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TopicNetworkSecurityPerimeterConfigurationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TopicNetworkSecurityPerimeterConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(TopicNetworkSecurityPerimeterConfigurationResource.ResourceType, out string apiVersion);
            _clientDiagnostics = new ClientDiagnostics(DiagnosticNamespace, TopicNetworkSecurityPerimeterConfigurationResource.ResourceType.Namespace, Diagnostics);
            _restClient = new NetworkSecurityPerimeterConfigurations(_clientDiagnostics, Pipeline, Endpoint, apiVersion ?? DefaultApiVersion);
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != EventGridTopicResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, EventGridTopicResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a specific network security perimeter configuration with a topic. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                if (data == null)
                {
                    throw new RequestFailedException(result);
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all network security perimeter configurations associated with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetworkSecurityPerimeterConfigurationData> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
                _restClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                TopicResourceTypeSegment,
                Id.Name,
                context,
                "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll");
        }

        /// <summary> Get all network security perimeter configurations associated with a topic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetworkSecurityPerimeterConfigurationData> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
                _restClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                TopicResourceTypeSegment,
                Id.Name,
                context,
                "TopicNetworkSecurityPerimeterConfigurationCollection.GetAll");
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> response = await GetIfExistsAsync(perimeterGuid, associationName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.HasValue, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.Exists");
            scope.Start();
            try
            {
                NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> response = GetIfExists(perimeterGuid, associationName, cancellationToken);
                return Response.FromValue(response.HasValue, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                if (result.Status == 404)
                {
                    return new NoValueResponse<TopicNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="perimeterGuid"> The perimeter guid of the network security perimeter. </param>
        /// <param name="associationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<TopicNetworkSecurityPerimeterConfigurationResource> GetIfExists(string perimeterGuid, string associationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(perimeterGuid, nameof(perimeterGuid));
            Argument.AssertNotNullOrEmpty(associationName, nameof(associationName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, TopicResourceTypeSegment, Id.Name, perimeterGuid, associationName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                if (result.Status == 404)
                {
                    return new NoValueResponse<TopicNetworkSecurityPerimeterConfigurationResource>(result);
                }
                NetworkSecurityPerimeterConfigurationData data = NetworkSecurityPerimeterConfigurationData.FromResponse(result);
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NetworkSecurityPerimeterConfigurationData> IEnumerable<NetworkSecurityPerimeterConfigurationData>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NetworkSecurityPerimeterConfigurationData> IAsyncEnumerable<NetworkSecurityPerimeterConfigurationData>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
