// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Network
{
    internal class VirtualMachineScaleSetResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _publicIPAddressesClientDiagnostics;
        private PublicIPAddressesRestOperations _publicIPAddressesRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResourceExtensionClient"/> class for mocking. </summary>
        protected VirtualMachineScaleSetResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PublicIPAddressesClientDiagnostics => _publicIPAddressesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PublicIPAddressesRestOperations PublicIPAddressesRestClient => _publicIPAddressesRestClient ??= new PublicIPAddressesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        internal Pageable<PublicIPAddressResource> GetAllPublicIpAddresses(CancellationToken cancellationToken = default)
        {
            Page<PublicIPAddressResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PublicIPAddressesClientDiagnostics.CreateScope("VirtualMachineScaleSetResourceExtensionClient.GetAllPublicIpAddresses");
                scope.Start();
                try
                {
                    var response = PublicIPAddressesRestClient.ListAll(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PublicIPAddressResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PublicIPAddressesClientDiagnostics.CreateScope("VirtualMachineScaleSetResourceExtensionClient.GetAllPublicIpAddresses");
                scope.Start();
                try
                {
                    var response = PublicIPAddressesRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        internal AsyncPageable<PublicIPAddressResource> GetAllPublicIpAddressesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PublicIPAddressResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PublicIPAddressesClientDiagnostics.CreateScope("VirtualMachineScaleSetResourceExtensionClient.GetAllPublicIpAddresses");
                scope.Start();
                try
                {
                    var response = await PublicIPAddressesRestClient.ListAllAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PublicIPAddressResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PublicIPAddressesClientDiagnostics.CreateScope("VirtualMachineScaleSetResourceExtensionClient.GetAllPublicIpAddresses");
                scope.Start();
                try
                {
                    var response = await PublicIPAddressesRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
