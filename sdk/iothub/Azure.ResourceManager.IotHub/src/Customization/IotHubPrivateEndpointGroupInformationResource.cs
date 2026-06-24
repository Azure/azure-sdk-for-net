// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.IotHub.Models;

namespace Azure.ResourceManager.IotHub
{
    /// <summary>
    /// A class representing a IotHubPrivateEndpointGroupInformation along with the instance operations that can be performed on it.
    /// </summary>
    // Customization justification:
    // GroupIdInformation is intentionally kept as a plain TypeSpec model for swagger compatibility. This
    // resource wrapper restores the previous C# child-resource API surface over the generated ResourceData
    // model without changing generated code.
    public partial class IotHubPrivateEndpointGroupInformationResource : ArmResource, IJsonModel<IotHubPrivateEndpointGroupInformationData>
    {
        private static IJsonModel<IotHubPrivateEndpointGroupInformationData> s_dataDeserializationInstance;
        private readonly ClientDiagnostics _privateLinkResourcesClientDiagnostics;
        private readonly PrivateLinkResources _privateLinkResourcesRestClient;
        private readonly IotHubPrivateEndpointGroupInformationData _data;

        private static IJsonModel<IotHubPrivateEndpointGroupInformationData> DataDeserializationInstance => s_dataDeserializationInstance ??= new IotHubPrivateEndpointGroupInformationData();

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Devices/iotHubs/privateLinkResources";

        /// <summary> Initializes a new instance of IotHubPrivateEndpointGroupInformationResource for mocking. </summary>
        protected IotHubPrivateEndpointGroupInformationResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="IotHubPrivateEndpointGroupInformationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal IotHubPrivateEndpointGroupInformationResource(ArmClient client, IotHubPrivateEndpointGroupInformationData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of <see cref="IotHubPrivateEndpointGroupInformationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal IotHubPrivateEndpointGroupInformationResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string iotHubPrivateEndpointGroupInformationApiVersion);
            _privateLinkResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.IotHub", ResourceType.Namespace, Diagnostics);
            _privateLinkResourcesRestClient = new PrivateLinkResources(_privateLinkResourcesClientDiagnostics, Pipeline, Endpoint, iotHubPrivateEndpointGroupInformationApiVersion ?? "2026-03-01-preview");
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual IotHubPrivateEndpointGroupInformationData Data
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
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="groupId"> The groupId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/iotHubs/{resourceName}/privateLinkResources/{groupId}";
            return new ResourceIdentifier(resourceId);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        /// <summary> Get the specified private link resource for the given IotHub. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IotHubPrivateEndpointGroupInformationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("IotHubPrivateEndpointGroupInformationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<IotHubPrivateEndpointGroupInformationData> response = Response.FromValue(IotHubPrivateEndpointGroupInformationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new IotHubPrivateEndpointGroupInformationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the specified private link resource for the given IotHub. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IotHubPrivateEndpointGroupInformationResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("IotHubPrivateEndpointGroupInformationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<IotHubPrivateEndpointGroupInformationData> response = Response.FromValue(IotHubPrivateEndpointGroupInformationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new IotHubPrivateEndpointGroupInformationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        void IJsonModel<IotHubPrivateEndpointGroupInformationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<IotHubPrivateEndpointGroupInformationData>)Data).Write(writer, options);

        IotHubPrivateEndpointGroupInformationData IJsonModel<IotHubPrivateEndpointGroupInformationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        BinaryData IPersistableModel<IotHubPrivateEndpointGroupInformationData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<IotHubPrivateEndpointGroupInformationData>(Data, options, AzureResourceManagerIotHubContext.Default);

        IotHubPrivateEndpointGroupInformationData IPersistableModel<IotHubPrivateEndpointGroupInformationData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<IotHubPrivateEndpointGroupInformationData>(data, options, AzureResourceManagerIotHubContext.Default);

        string IPersistableModel<IotHubPrivateEndpointGroupInformationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
