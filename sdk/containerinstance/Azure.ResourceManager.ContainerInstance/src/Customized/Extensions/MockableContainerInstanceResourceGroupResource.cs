// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    // Workaround for generator bug https://github.com/Azure/azure-sdk-for-net/issues/58204:
    // adds DeleteSubnetServiceAssociationLink methods on ResourceGroupResource scope.
    // Delegates to the REST client on the subscription mockable.
    public partial class MockableContainerInstanceResourceGroupResource
    {
        private ClientDiagnostics _subnetServiceAssociationLinkClientDiagnostics;
        private SubnetServiceAssociationLink _subnetServiceAssociationLinkRestClient;

        private ClientDiagnostics SubnetServiceAssociationLinkClientDiagnostics => _subnetServiceAssociationLinkClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ContainerInstance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SubnetServiceAssociationLink SubnetServiceAssociationLinkRestClient => _subnetServiceAssociationLinkRestClient ??= new SubnetServiceAssociationLink(SubnetServiceAssociationLinkClientDiagnostics, Pipeline, Endpoint, "2025-09-01");

        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="waitUntil"> Specifies whether to wait for the operation to complete. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkName, nameof(virtualNetworkName));
            Argument.AssertNotNullOrEmpty(subnetName, nameof(subnetName));

            using DiagnosticScope scope = SubnetServiceAssociationLinkClientDiagnostics.CreateScope("MockableContainerInstanceResourceGroupResource.DeleteSubnetServiceAssociationLink");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = SubnetServiceAssociationLinkRestClient.CreateDeleteSubnetServiceAssociationLinkRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualNetworkName, subnetName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.Location.ToString());
                ContainerInstanceArmOperation operation = new ContainerInstanceArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="waitUntil"> Specifies whether to wait for the operation to complete. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual ArmOperation DeleteSubnetServiceAssociationLink(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkName, nameof(virtualNetworkName));
            Argument.AssertNotNullOrEmpty(subnetName, nameof(subnetName));

            using DiagnosticScope scope = SubnetServiceAssociationLinkClientDiagnostics.CreateScope("MockableContainerInstanceResourceGroupResource.DeleteSubnetServiceAssociationLink");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = SubnetServiceAssociationLinkRestClient.CreateDeleteSubnetServiceAssociationLinkRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualNetworkName, subnetName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.Location.ToString());
                ContainerInstanceArmOperation operation = new ContainerInstanceArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
