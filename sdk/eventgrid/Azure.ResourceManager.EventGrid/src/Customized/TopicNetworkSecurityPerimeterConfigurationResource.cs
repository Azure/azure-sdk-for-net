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
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
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
        public virtual Task<Response<TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return GetAsync(perimeterGuid, associationName, cancellationToken);
        }

        /// <summary> Gets this network security perimeter configuration resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        public virtual Response<TopicNetworkSecurityPerimeterConfigurationResource> Get(CancellationToken cancellationToken = default)
        {
            (string perimeterGuid, string associationName) = NetworkSecurityPerimeterConfigurationCompat.SplitAssociationName(Id);
            return Get(perimeterGuid, associationName, cancellationToken);
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
