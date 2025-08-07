// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
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

        /// <summary>
        /// Description for Check if a resource name is available.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/checknameavailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Name availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceNameAvailability>> CheckAppServiceNameAvailabilityAsync(ResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            AppServiceNameAvailabilityContent nameAvailabilityContent = new AppServiceNameAvailabilityContent(content.Name, content.ResourceType)
            {
                IsFqdn = content.IsFqdn,
                EnvironmentId = content.EnvironmentId
            };

            var response = await CheckAppServiceNameAvailabilityAsync(nameAvailabilityContent, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(new ResourceNameAvailability(response.Value.IsNameAvailable, response.Value.Reason.ToString(), response.Value.Message, null), response.GetRawResponse());
        }

        /// <summary>
        /// Description for Check if a resource name is available.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/checknameavailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Name availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceNameAvailability> CheckAppServiceNameAvailability(ResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            AppServiceNameAvailabilityContent nameAvailabilityContent = new AppServiceNameAvailabilityContent(content.Name, content.ResourceType)
            {
                IsFqdn = content.IsFqdn,
                EnvironmentId = content.EnvironmentId
            };

            var response = CheckAppServiceNameAvailability(nameAvailabilityContent, cancellationToken);

            return Response.FromValue(new ResourceNameAvailability(response.Value.IsNameAvailable, response.Value.Reason.ToString(), response.Value.Message, null), response.GetRawResponse());
        }
    }
}
