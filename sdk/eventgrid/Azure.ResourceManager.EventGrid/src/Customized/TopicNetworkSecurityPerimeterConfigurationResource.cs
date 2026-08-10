// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// GA API compatibility: The old SDK exposed Get/Reconcile with a split (perimeterGuid, associationName) signature
// and a two-argument CreateResourceIdentifier. These partial methods provide the legacy overloads on top of the
// generated single-argument methods. They cannot be removed without breaking the shipped GA surface.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // CodeGenSuppress the generated parameterless-id surface that does not match GA/main:
    // - CreateResourceIdentifier(4-arg): main exposes a 5-arg form (perimeterGuid + associationName).
    // - Get/GetAsync(perimeterGuid, associationName): the new generator emits these 2-param overloads on
    //   the RESOURCE because the resource id is a composite "{perimeterGuid}.{associationName}"; main's
    //   resource exposes only the parameterless Get()/GetAsync(). These 2-param overloads are extra public
    //   methods absent on main, so they are suppressed here and replaced with parameterless versions below.
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("Get", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class TopicNetworkSecurityPerimeterConfigurationResource
    {
        /// <summary> Creates a resource identifier for a topic network security perimeter configuration resource. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="resourceName"> The resource name. </param>
        /// <param name="perimeterGuid"> The network security perimeter GUID. </param>
        /// <param name="associationName"> The network security perimeter association name. </param>
        /// <returns> The resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{resourceName}/networkSecurityPerimeterConfigurations/{perimeterGuid}.{associationName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Gets this network security perimeter configuration resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        // Self-contained (calls the REST client directly) because the generated 2-param
        // Get(perimeterGuid, associationName, ...) overload it would otherwise delegate to is suppressed
        // above. The composite resource id is split to recover the two path segments.
        public virtual async Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            using DiagnosticScope scope = _networkSecurityPerimeterConfigurationsClientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _networkSecurityPerimeterConfigurationsRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    NetworkSecurityPerimeterResourceType.Topics.ToString(),
                    Id.Parent.Name,
                    perimeterGuid,
                    associationName,
                    context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetworkSecurityPerimeterConfigurationData> response = Response.FromValue(NetworkSecurityPerimeterConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets this network security perimeter configuration resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        // Self-contained (calls the REST client directly) because the generated 2-param
        // Get(perimeterGuid, associationName, ...) overload it would otherwise delegate to is suppressed
        // above. The composite resource id is split to recover the two path segments.
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            using DiagnosticScope scope = _networkSecurityPerimeterConfigurationsClientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _networkSecurityPerimeterConfigurationsRestClient.CreateGetRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    NetworkSecurityPerimeterResourceType.Topics.ToString(),
                    Id.Parent.Name,
                    perimeterGuid,
                    associationName,
                    context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetworkSecurityPerimeterConfigurationData> response = Response.FromValue(NetworkSecurityPerimeterConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TopicNetworkSecurityPerimeterConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Reconciles this network security perimeter configuration resource. </summary>
        /// <param name="waitUntil"> The condition to wait for before the operation completes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation to reconcile the resource. </returns>
        public virtual async Task<ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            using DiagnosticScope scope = _networkSecurityPerimeterConfigurationsClientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationResource.Reconcile");
            scope.Start();
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation;
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _networkSecurityPerimeterConfigurationsRestClient.CreateReconcileRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    NetworkSecurityPerimeterResourceType.Topics.ToString(),
                    Id.Parent.Name,
                    perimeterGuid,
                    associationName,
                    context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                operation = new EventGridArmOperation<NetworkSecurityPerimeterConfigurationData>(
                    new NetworkSecurityPerimeterConfigurationDataOperationSource(),
                    _networkSecurityPerimeterConfigurationsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            return new NetworkSecurityPerimeterConfigurationCompatOperation<TopicNetworkSecurityPerimeterConfigurationResource>(operation, data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }

        /// <summary> Reconciles this network security perimeter configuration resource. </summary>
        /// <param name="waitUntil"> The condition to wait for before the operation completes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation to reconcile the resource. </returns>
        public virtual ArmOperation<TopicNetworkSecurityPerimeterConfigurationResource> Reconcile(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            using DiagnosticScope scope = _networkSecurityPerimeterConfigurationsClientDiagnostics.CreateScope("TopicNetworkSecurityPerimeterConfigurationResource.Reconcile");
            scope.Start();
            ArmOperation<NetworkSecurityPerimeterConfigurationData> operation;
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _networkSecurityPerimeterConfigurationsRestClient.CreateReconcileRequest(
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    NetworkSecurityPerimeterResourceType.Topics.ToString(),
                    Id.Parent.Name,
                    perimeterGuid,
                    associationName,
                    context);
                Response response = Pipeline.ProcessMessage(message, context);
                operation = new EventGridArmOperation<NetworkSecurityPerimeterConfigurationData>(
                    new NetworkSecurityPerimeterConfigurationDataOperationSource(),
                    _networkSecurityPerimeterConfigurationsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            return new NetworkSecurityPerimeterConfigurationCompatOperation<TopicNetworkSecurityPerimeterConfigurationResource>(operation, data => new TopicNetworkSecurityPerimeterConfigurationResource(Client, data));
        }
    }
}
