// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
using Azure.ResourceManager.HybridCompute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.HybridCompute
{
    /// <summary>
    /// A Class representing an ArcGateway along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="ArcGatewayResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetArcGatewayResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetArcGateway method.
    /// </summary>
    public partial class ArcGatewayResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ArcGatewayResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="gatewayName"> The gatewayName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gatewayName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _arcGatewayGatewaysClientDiagnostics;
        private readonly GatewaysRestOperations _arcGatewayGatewaysRestClient;
        private readonly ArcGatewayData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.HybridCompute/gateways";

        /// <summary> Initializes a new instance of the <see cref="ArcGatewayResource"/> class for mocking. </summary>
        protected ArcGatewayResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArcGatewayResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ArcGatewayResource(ArmClient client, ArcGatewayData data) : this(client, data.Id)
========
using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
    /// <summary>
    /// A Class representing an Association along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="AssociationResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetAssociationResource method.
    /// Otherwise you can get one from its parent resource <see cref="TrafficControllerResource"/> using the GetAssociation method.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `TrafficControllerAssociationResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AssociationResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AssociationResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="trafficControllerName"> The trafficControllerName. </param>
        /// <param name="associationName"> The associationName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string associationName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _associationAssociationsInterfaceClientDiagnostics;
        private readonly AssociationsInterfaceRestOperations _associationAssociationsInterfaceRestClient;
        private readonly AssociationData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ServiceNetworking/trafficControllers/associations";

        /// <summary> Initializes a new instance of the <see cref="AssociationResource"/> class for mocking. </summary>
        protected AssociationResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AssociationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal AssociationResource(ArmClient client, AssociationData data) : this(client, data.Id)
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        {
            HasData = true;
            _data = data;
        }

<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <summary> Initializes a new instance of the <see cref="ArcGatewayResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ArcGatewayResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _arcGatewayGatewaysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.HybridCompute", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string arcGatewayGatewaysApiVersion);
            _arcGatewayGatewaysRestClient = new GatewaysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, arcGatewayGatewaysApiVersion);
========
        /// <summary> Initializes a new instance of the <see cref="AssociationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal AssociationResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _associationAssociationsInterfaceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceNetworking", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string associationAssociationsInterfaceApiVersion);
            _associationAssociationsInterfaceRestClient = new AssociationsInterfaceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, associationAssociationsInterfaceApiVersion);
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual ArcGatewayData Data
========
        public virtual AssociationData Data
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// Retrieves information about the view of a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Get a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual async Task<Response<ArcGatewayResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Get");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
========
        public virtual async Task<Response<AssociationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Get");
            scope.Start();
            try
            {
                var response = await _associationAssociationsInterfaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AssociationResource(Client, new AssociationData(response.Value)), response.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// Retrieves information about the view of a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Get a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual Response<ArcGatewayResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Get");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
========
        public virtual Response<AssociationResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Get");
            scope.Start();
            try
            {
                var response = _associationAssociationsInterfaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AssociationResource(Client, new AssociationData(response.Value)), response.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// The operation to delete a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Delete a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Delete");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new HybridComputeArmOperation(_arcGatewayGatewaysClientDiagnostics, Pipeline, _arcGatewayGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
========
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Delete");
            scope.Start();
            try
            {
                var response = await _associationAssociationsInterfaceRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ServiceNetworkingArmOperation(_associationAssociationsInterfaceClientDiagnostics, Pipeline, _associationAssociationsInterfaceRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// The operation to delete a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Delete a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Delete");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new HybridComputeArmOperation(_arcGatewayGatewaysClientDiagnostics, Pipeline, _arcGatewayGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
========
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Delete");
            scope.Start();
            try
            {
                var response = _associationAssociationsInterfaceRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new ServiceNetworkingArmOperation(_associationAssociationsInterfaceClientDiagnostics, Pipeline, _associationAssociationsInterfaceRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// The operation to update a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Update a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual async Task<Response<ArcGatewayResource>> UpdateAsync(ArcGatewayPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Update");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
========
        public virtual async Task<Response<AssociationResource>> UpdateAsync(AssociationPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Update");
            scope.Start();
            try
            {
                var response = await _associationAssociationsInterfaceRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch.ToTrafficControllerAssociationPatch(), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AssociationResource(Client, new AssociationData(response.Value)), response.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// The operation to update a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// Update a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual Response<ArcGatewayResource> Update(ArcGatewayPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.Update");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken);
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
========
        public virtual Response<AssociationResource> Update(AssociationPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.Update");
            scope.Start();
            try
            {
                var response = _associationAssociationsInterfaceRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, patch.ToTrafficControllerAssociationPatch(), cancellationToken);
                return Response.FromValue(new AssociationResource(Client, new AssociationData(response.Value)), response.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual async Task<Response<ArcGatewayResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
========
        public virtual async Task<Response<AssociationResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.AddTag");
========
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.AddTag");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = await _associationAssociationsInterfaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual Response<ArcGatewayResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
========
        public virtual Response<AssociationResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.AddTag");
========
            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.AddTag");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = _associationAssociationsInterfaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual async Task<Response<ArcGatewayResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.SetTags");
========
        public virtual async Task<Response<AssociationResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.SetTags");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = await _associationAssociationsInterfaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual Response<ArcGatewayResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.SetTags");
========
        public virtual Response<AssociationResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.SetTags");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = _associationAssociationsInterfaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual async Task<Response<ArcGatewayResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.RemoveTag");
========
        public virtual async Task<Response<AssociationResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.RemoveTag");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = await _associationAssociationsInterfaceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
========
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
        public virtual Response<ArcGatewayResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayResource.RemoveTag");
========
        public virtual Response<AssociationResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _associationAssociationsInterfaceClientDiagnostics.CreateScope("AssociationResource.RemoveTag");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var originalResponse = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new ArcGatewayResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
========
                    var originalResponse = _associationAssociationsInterfaceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new AssociationResource(Client, new AssociationData(originalResponse.Value)), originalResponse.GetRawResponse());
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
<<<<<<<< HEAD:sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Generated/ArcGatewayResource.cs
                    var patch = new ArcGatewayPatch();
========
                    var patch = new AssociationPatch();
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.cs
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
