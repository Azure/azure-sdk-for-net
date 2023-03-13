// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mock
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class SubscriptionResourceExtensionClient : ArmResource
    {
        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListSiteIdentifiersAssignedToHostName</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceIdentifierData> GetAllSiteIdentifierDataAsync(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            HttpMessage FirstPageRequest(int? pageSizeHint) => DefaultRestClient.CreateListSiteIdentifiersAssignedToHostNameRequest(Id.SubscriptionId, nameIdentifier);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DefaultRestClient.CreateListSiteIdentifiersAssignedToHostNameNextPageRequest(nextLink, Id.SubscriptionId, nameIdentifier);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, AppServiceIdentifierData.DeserializeAppServiceIdentifierData, DefaultClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetAllSiteIdentifierData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListSiteIdentifiersAssignedToHostName</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceIdentifierData> GetAllSiteIdentifierData(AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            HttpMessage FirstPageRequest(int? pageSizeHint) => DefaultRestClient.CreateListSiteIdentifiersAssignedToHostNameRequest(Id.SubscriptionId, nameIdentifier);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DefaultRestClient.CreateListSiteIdentifiersAssignedToHostNameNextPageRequest(nextLink, Id.SubscriptionId, nameIdentifier);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, AppServiceIdentifierData.DeserializeAppServiceIdentifierData, DefaultClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetAllSiteIdentifierData", "value", "nextLink", cancellationToken);
        }
    }
}
