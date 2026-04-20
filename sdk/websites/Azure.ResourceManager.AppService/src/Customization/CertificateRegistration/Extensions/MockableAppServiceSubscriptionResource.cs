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
        private ClientDiagnostics _appServiceCertificateOrderClientDiagnostics;
        private AppServiceCertificateOrdersRestOperations _appServiceCertificateOrderRestClient;
        private ClientDiagnostics _appServiceCertificateOrdersClientDiagnostics;
        private AppServiceCertificateOrdersRestOperations _appServiceCertificateOrdersRestClient;
        private ClientDiagnostics AppServiceCertificateOrderClientDiagnostics => _appServiceCertificateOrderClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppService", AppServiceCertificateOrderResource.ResourceType.Namespace, Diagnostics);
        private AppServiceCertificateOrdersRestOperations AppServiceCertificateOrderRestClient => _appServiceCertificateOrderRestClient ??= new AppServiceCertificateOrdersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(AppServiceCertificateOrderResource.ResourceType));
        private ClientDiagnostics AppServiceCertificateOrdersClientDiagnostics => _appServiceCertificateOrdersClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppService", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AppServiceCertificateOrdersRestOperations AppServiceCertificateOrdersRestClient => _appServiceCertificateOrdersRestClient ??= new AppServiceCertificateOrdersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        /// <summary>
        /// Description for List all certificate orders in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.CertificateRegistration/certificateOrders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceCertificateOrderResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppServiceCertificateOrderResource> GetAppServiceCertificateOrdersAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AppServiceCertificateOrderRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AppServiceCertificateOrderRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AppServiceCertificateOrderResource(Client, AppServiceCertificateOrderData.DeserializeAppServiceCertificateOrderData(e)), AppServiceCertificateOrderClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceCertificateOrders", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for List all certificate orders in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.CertificateRegistration/certificateOrders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceCertificateOrderResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppServiceCertificateOrderResource> GetAppServiceCertificateOrders(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AppServiceCertificateOrderRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AppServiceCertificateOrderRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AppServiceCertificateOrderResource(Client, AppServiceCertificateOrderData.DeserializeAppServiceCertificateOrderData(e)), AppServiceCertificateOrderClientDiagnostics, Pipeline, "MockableAppServiceSubscriptionResource.GetAppServiceCertificateOrders", "value", "nextLink", cancellationToken);
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestDomainAsync(CancellationToken cancellationToken = default)
        {
            using var scope = DomainsClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.GetControlCenterSsoRequestDomain");
            scope.Start();
            try
            {
                var response = await DomainsRestClient.GetControlCenterSsoRequestAsync(Id.SubscriptionId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequestDomain(CancellationToken cancellationToken = default)
        {
            using var scope = DomainsClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.GetControlCenterSsoRequestDomain");
            scope.Start();
            try
            {
                var response = DomainsRestClient.GetControlCenterSsoRequest(Id.SubscriptionId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.CertificateRegistration/validateCertificateRegistrationInformation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ValidatePurchaseInformation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Information for a certificate order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response> ValidateAppServiceCertificateOrderPurchaseInformationAsync(AppServiceCertificateOrderData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = AppServiceCertificateOrdersClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.ValidateAppServiceCertificateOrderPurchaseInformation");
            scope.Start();
            try
            {
                var response = await AppServiceCertificateOrdersRestClient.ValidatePurchaseInformationAsync(Id.SubscriptionId, data, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.CertificateRegistration/validateCertificateRegistrationInformation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_ValidatePurchaseInformation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Information for a certificate order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response ValidateAppServiceCertificateOrderPurchaseInformation(AppServiceCertificateOrderData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = AppServiceCertificateOrdersClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.ValidateAppServiceCertificateOrderPurchaseInformation");
            scope.Start();
            try
            {
                var response = AppServiceCertificateOrdersRestClient.ValidatePurchaseInformation(Id.SubscriptionId, data, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
