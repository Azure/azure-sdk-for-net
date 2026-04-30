// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.TrafficManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// A class representing a TrafficManagerEndpoint along with the instance operations that can be performed on it.
    /// </summary>
    public partial class TrafficManagerEndpointResource : ArmResource, IJsonModel<TrafficManagerEndpointData>, IPersistableModel<TrafficManagerEndpointData>
    {
        private static IJsonModel<TrafficManagerEndpointData> s_dataDeserializationInstance;
        private static IJsonModel<TrafficManagerEndpointData> DataDeserializationInstance => s_dataDeserializationInstance ??= new TrafficManagerEndpointData();
        private readonly ClientDiagnostics _endpointsClientDiagnostics;
        private readonly Endpoints _endpointsRestClient;
        private readonly TrafficManagerEndpointData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/trafficmanagerprofiles/TrafficManagerEndpoints";

        /// <summary> Initializes a new instance of TrafficManagerEndpointResource for mocking. </summary>
        protected TrafficManagerEndpointResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TrafficManagerEndpointResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TrafficManagerEndpointResource(ArmClient client, TrafficManagerEndpointData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of <see cref="TrafficManagerEndpointResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TrafficManagerEndpointResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string trafficManagerEndpointApiVersion);
            _endpointsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.TrafficManager", ResourceType.Namespace, Diagnostics);
            _endpointsRestClient = new Endpoints(_endpointsClientDiagnostics, Pipeline, Endpoint, trafficManagerEndpointApiVersion ?? "2022-04-01");
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual TrafficManagerEndpointData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="profileName"> The profileName. </param>
        /// <param name="endpointType"> The endpointType. </param>
        /// <param name="endpointName"> The endpointName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, TrafficManagerEndpointType endpointType, string endpointName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType.ToSerialString()}/{endpointName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="profileName"> The profileName. </param>
        /// <param name="endpointType"> The endpointType. </param>
        /// <param name="endpointName"> The endpointName. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointType, string endpointName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrafficManagerEndpointResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.ResourceType.Type, Id.Name, context);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrafficManagerEndpointResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.ResourceType.Type, Id.Name, context);
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

        /// <summary> Update a Traffic Manager endpoint. </summary>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrafficManagerEndpointResource>> UpdateAsync(TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.ResourceType.Type, Id.Name, TrafficManagerEndpointData.ToRequestContent(data), context);
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

        /// <summary> Update a Traffic Manager endpoint. </summary>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrafficManagerEndpointResource> Update(TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.ResourceType.Type, Id.Name, TrafficManagerEndpointData.ToRequestContent(data), context);
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

        /// <summary> Deletes a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, Id.ResourceType.Type, context);
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

        /// <summary> Deletes a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _endpointsClientDiagnostics.CreateScope("TrafficManagerEndpointResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _endpointsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, Id.ResourceType.Type, context);
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

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<TrafficManagerEndpointData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<TrafficManagerEndpointData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        TrafficManagerEndpointData IJsonModel<TrafficManagerEndpointData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<TrafficManagerEndpointData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<TrafficManagerEndpointData>(Data, options, AzureResourceManagerTrafficManagerContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        TrafficManagerEndpointData IPersistableModel<TrafficManagerEndpointData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<TrafficManagerEndpointData>(data, options, AzureResourceManagerTrafficManagerContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<TrafficManagerEndpointData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
