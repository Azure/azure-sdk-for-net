// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableAppServiceSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName
        /// Operation Id: ListSiteIdentifiersAssignedToHostName
        /// </summary>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceIdentifierData> GetAllSiteIdentifierDataAsync(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            async Task<Page<AppServiceIdentifierData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetAllSiteIdentifierData");
                scope.Start();
                try
                {
                    var response = await DefaultRestClient.ListSiteIdentifiersAssignedToHostNameAsync(Id.SubscriptionId, nameIdentifier, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AppServiceIdentifierData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetAllSiteIdentifierData");
                scope.Start();
                try
                {
                    var response = await DefaultRestClient.ListSiteIdentifiersAssignedToHostNameNextPageAsync(nextLink, Id.SubscriptionId, nameIdentifier, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName
        /// Operation Id: ListSiteIdentifiersAssignedToHostName
        /// </summary>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceIdentifierData> GetAllSiteIdentifierData(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            Page<AppServiceIdentifierData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetAllSiteIdentifierData");
                scope.Start();
                try
                {
                    var response = DefaultRestClient.ListSiteIdentifiersAssignedToHostName(Id.SubscriptionId, nameIdentifier, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AppServiceIdentifierData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetAllSiteIdentifierData");
                scope.Start();
                try
                {
                    var response = DefaultRestClient.ListSiteIdentifiersAssignedToHostNameNextPage(nextLink, Id.SubscriptionId, nameIdentifier, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
