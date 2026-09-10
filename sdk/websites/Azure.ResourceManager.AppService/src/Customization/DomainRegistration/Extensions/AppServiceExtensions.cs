// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Mocking;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    public static partial class AppServiceExtensions
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.CheckAppServiceDomainRegistrationAvailability(AppServiceDomainNameIdentifier,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="identifier"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(this SubscriptionResource subscriptionResource, AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckAppServiceDomainRegistrationAvailabilityAsync(identifier, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.CheckAppServiceDomainRegistrationAvailability(AppServiceDomainNameIdentifier,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="identifier"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(this SubscriptionResource subscriptionResource, AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckAppServiceDomainRegistrationAvailability(identifier, cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetAppServiceDomains(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AppServiceDomainResource> GetAppServiceDomainsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetAppServiceDomainsAsync(cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetAppServiceDomains(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AppServiceDomainResource> GetAppServiceDomains(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetAppServiceDomains(cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetAppServiceDomainRecommendations(DomainRecommendationSearchContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="content"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendationsAsync(this SubscriptionResource subscriptionResource, DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetAppServiceDomainRecommendationsAsync(content, cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetAppServiceDomainRecommendations(DomainRecommendationSearchContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendations(this SubscriptionResource subscriptionResource, DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetAppServiceDomainRecommendations(content, cancellationToken);
        }

        /// <summary>
        /// Gets an object representing an <see cref="AppServiceDomainResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AppServiceDomainResource.CreateResourceIdentifier" /> to create an <see cref="AppServiceDomainResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceArmClient.GetAppServiceDomainResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AppServiceDomainResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceDomainResource GetAppServiceDomainResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableAppServiceArmClient(client).GetAppServiceDomainResource(id);
        }

        /// <summary>
        /// Gets a collection of AppServiceDomainResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceResourceGroupResource.GetAppServiceDomains()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of AppServiceDomainResources and their operations over a AppServiceDomainResource. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceDomainCollection GetAppServiceDomains(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableAppServiceResourceGroupResource(resourceGroupResource).GetAppServiceDomains();
        }

        /// <summary>
        /// Description for Get a domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceResourceGroupResource.GetAppServiceDomainAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="domainName"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="domainName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<AppServiceDomainResource>> GetAppServiceDomainAsync(this ResourceGroupResource resourceGroupResource, string domainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableAppServiceResourceGroupResource(resourceGroupResource).GetAppServiceDomainAsync(domainName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Get a domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceResourceGroupResource.GetAppServiceDomain(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="domainName"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="domainName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AppServiceDomainResource> GetAppServiceDomain(this ResourceGroupResource resourceGroupResource, string domainName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableAppServiceResourceGroupResource(resourceGroupResource).GetAppServiceDomain(domainName, cancellationToken);
        }

        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.DomainRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DomainRegistrationProvider_ListOperations</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceTenantResource.GetOperationsDomainRegistrationProviders(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CsmOperationDescription> GetOperationsDomainRegistrationProvidersAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableAppServiceTenantResource(tenantResource).GetOperationsDomainRegistrationProvidersAsync(cancellationToken);
        }

        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.DomainRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DomainRegistrationProvider_ListOperations</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceTenantResource.GetOperationsDomainRegistrationProviders(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CsmOperationDescription> GetOperationsDomainRegistrationProviders(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableAppServiceTenantResource(tenantResource).GetOperationsDomainRegistrationProviders(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of TopLevelDomainResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetTopLevelDomains()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of TopLevelDomainResources and their operations over a TopLevelDomainResource. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TopLevelDomainCollection GetTopLevelDomains(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetTopLevelDomains();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetTopLevelDomainAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<TopLevelDomainResource>> GetTopLevelDomainAsync(this SubscriptionResource subscriptionResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableAppServiceSubscriptionResource(subscriptionResource).GetTopLevelDomainAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetTopLevelDomain(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<TopLevelDomainResource> GetTopLevelDomain(this SubscriptionResource subscriptionResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetTopLevelDomain(name, cancellationToken);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TopLevelDomainResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TopLevelDomainResource.CreateResourceIdentifier" /> to create a <see cref="TopLevelDomainResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceArmClient.GetTopLevelDomainResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TopLevelDomainResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TopLevelDomainResource GetTopLevelDomainResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableAppServiceArmClient(client).GetTopLevelDomainResource(id);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetControlCenterSsoRequestDomain(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestDomainAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableAppServiceSubscriptionResource(subscriptionResource).GetControlCenterSsoRequestDomainAsync(cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceSubscriptionResource.GetControlCenterSsoRequestDomain(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequestDomain(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableAppServiceSubscriptionResource(subscriptionResource).GetControlCenterSsoRequestDomain(cancellationToken);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DomainOwnershipIdentifierResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DomainOwnershipIdentifierResource.CreateResourceIdentifier" /> to create a <see cref="DomainOwnershipIdentifierResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableAppServiceArmClient.GetDomainOwnershipIdentifierResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="DomainOwnershipIdentifierResource"/> object. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableAppServiceArmClient(client).GetDomainOwnershipIdentifierResource(id);
        }
    }
}
