// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        private ClientDiagnostics _domainsClientDiagnostics;
        private DomainsRestOperations _domainsRestClient;
        private ClientDiagnostics _appServiceDomainDomainsClientDiagnostics;
        private DomainsRestOperations _appServiceDomainDomainsRestClient;

        private ClientDiagnostics DomainsClientDiagnostics => _domainsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppService", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private DomainsRestOperations DomainsRestClient => _domainsRestClient ??= new DomainsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics AppServiceDomainDomainsClientDiagnostics => _appServiceDomainDomainsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppService", AppServiceDomainResource.ResourceType.Namespace, Diagnostics);
        private DomainsRestOperations AppServiceDomainDomainsRestClient => _appServiceDomainDomainsRestClient ??= new DomainsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(AppServiceDomainResource.ResourceType));

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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        public virtual async Task<Response<DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));

            using var scope = DomainsClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.CheckAppServiceDomainRegistrationAvailability");
            scope.Start();
            try
            {
                var response = await DomainsRestClient.CheckAvailabilityAsync(Id.SubscriptionId, identifier, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identifier"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="identifier"/> is null. </exception>
        public virtual Response<DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(AppServiceDomainNameIdentifier identifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identifier, nameof(identifier));

            using var scope = DomainsClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.CheckAppServiceDomainRegistrationAvailability");
            scope.Start();
            try
            {
                var response = DomainsRestClient.CheckAvailability(Id.SubscriptionId, identifier, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceDomainResource> GetAppServiceDomainsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AppServiceDomainDomainsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AppServiceDomainDomainsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AppServiceDomainResource(Client, AppServiceDomainData.DeserializeAppServiceDomainData(e)), AppServiceDomainDomainsClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceDomains", "value", "nextLink", cancellationToken);
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
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceDomainResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceDomainResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceDomainResource> GetAppServiceDomains(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AppServiceDomainDomainsRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AppServiceDomainDomainsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AppServiceDomainResource(Client, AppServiceDomainData.DeserializeAppServiceDomainData(e)), AppServiceDomainDomainsClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceDomains", "value", "nextLink", cancellationToken);
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendationsAsync(DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            HttpMessage FirstPageRequest(int? pageSizeHint) => DomainsRestClient.CreateListRecommendationsRequest(Id.SubscriptionId, content);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DomainsRestClient.CreateListRecommendationsNextPageRequest(nextLink, Id.SubscriptionId, content);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => AppServiceDomainNameIdentifier.DeserializeAppServiceDomainNameIdentifier(e), DomainsClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceDomainRecommendations", "value", "nextLink", cancellationToken);
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Search parameters for domain name recommendations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceDomainNameIdentifier"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendations(DomainRecommendationSearchContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            HttpMessage FirstPageRequest(int? pageSizeHint) => DomainsRestClient.CreateListRecommendationsRequest(Id.SubscriptionId, content);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DomainsRestClient.CreateListRecommendationsNextPageRequest(nextLink, Id.SubscriptionId, content);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => AppServiceDomainNameIdentifier.DeserializeAppServiceDomainNameIdentifier(e), DomainsClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceDomainRecommendations", "value", "nextLink", cancellationToken);
        }

        /// <summary> Gets a collection of TopLevelDomainResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of TopLevelDomainResources and their operations over a TopLevelDomainResource. </returns>
        public virtual TopLevelDomainCollection GetTopLevelDomains()
        {
            return GetCachedClient(client => new TopLevelDomainCollection(client, Id));
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
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
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
        public virtual async Task<Response<TopLevelDomainResource>> GetTopLevelDomainAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetTopLevelDomains().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
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
        public virtual Response<TopLevelDomainResource> GetTopLevelDomain(string name, CancellationToken cancellationToken = default)
        {
            return GetTopLevelDomains().Get(name, cancellationToken);
        }
    }
}
