// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Description for Check if a domain is available for registration.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/checkDomainAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_CheckAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Check if a domain is available for registration.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/checkDomainAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_CheckAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get all domains in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/domains</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AppServiceDomainResource> GetAppServiceDomainsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get all domains in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/domains</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AppServiceDomainResource> GetAppServiceDomains(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get domain name recommendations based on keywords.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/listDomainRecommendations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_ListRecommendations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendationsAsync(DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get domain name recommendations based on keywords.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/listDomainRecommendations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_ListRecommendations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendations(DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary> Gets a collection of TopLevelDomainResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of TopLevelDomainResources and their operations over a TopLevelDomainResource. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TopLevelDomainCollection GetTopLevelDomains()
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get details of a top-level domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelDomains_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TopLevelDomainResource>> GetTopLevelDomainAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get details of a top-level domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelDomains_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TopLevelDomainResource> GetTopLevelDomain(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Generate a single sign-on request for the domain management portal.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/generateSsoRequest</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetControlCenterSsoRequest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestDomainAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Generate a single sign-on request for the domain management portal.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/generateSsoRequest</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetControlCenterSsoRequest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequestDomain(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }
    }
}
