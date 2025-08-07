// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MarketplaceOrdering.Models;
using Azure.ResourceManager.Resources;

// temporary: moving the whole class here because we want to rename the GetAll and GetAllAsync which is returning resource data to GetAllData and GetAllDataAsync, but we cannot do that using configuration
// also we want this class no longer implements IEnumerable or IAsyncEnumerable, therefore we made this customization.
// we could remove all the things here once the polymorphic resource change is merged, and hide the GetAllData and GetAllDataAsync methods.
[assembly:CodeGenSuppressType("MarketplaceAgreementCollection")]
namespace Azure.ResourceManager.MarketplaceOrdering
{
    /// <summary>
    /// A class representing a collection of <see cref="MarketplaceAgreementResource" /> and their operations.
    /// Each <see cref="MarketplaceAgreementResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="MarketplaceAgreementCollection" /> instance call the GetMarketplaceAgreements method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class MarketplaceAgreementCollection : ArmCollection
    {
        private readonly ClientDiagnostics _marketplaceAgreementClientDiagnostics;
        private readonly MarketplaceAgreementsRestOperations _marketplaceAgreementRestClient;
        private readonly ClientDiagnostics _marketplaceAgreementsClientDiagnostics;
        private readonly MarketplaceAgreementsRestOperations _marketplaceAgreementsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MarketplaceAgreementCollection"/> class for mocking. </summary>
        protected MarketplaceAgreementCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MarketplaceAgreementCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MarketplaceAgreementCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _marketplaceAgreementClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MarketplaceOrdering", MarketplaceAgreementResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MarketplaceAgreementResource.ResourceType, out string marketplaceAgreementApiVersion);
            _marketplaceAgreementRestClient = new MarketplaceAgreementsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, marketplaceAgreementApiVersion);
            _marketplaceAgreementsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MarketplaceOrdering", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _marketplaceAgreementsRestClient = new MarketplaceAgreementsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get marketplace agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_GetAgreement</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual async Task<Response<MarketplaceAgreementResource>> GetAsync(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.Get");
            scope.Start();
            try
            {
                var response = await _marketplaceAgreementRestClient.GetAgreementAsync(Id.SubscriptionId, publisherId, offerId, planId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MarketplaceAgreementResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get marketplace agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_GetAgreement</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual Response<MarketplaceAgreementResource> Get(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.Get");
            scope.Start();
            try
            {
                var response = _marketplaceAgreementRestClient.GetAgreement(Id.SubscriptionId, publisherId, offerId, planId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MarketplaceAgreementResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List marketplace agreements in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MarketplaceAgreementTermData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MarketplaceAgreementTermData> GetAllDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MarketplaceAgreementTermData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _marketplaceAgreementsClientDiagnostics.CreateScope("MarketplaceAgreementCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _marketplaceAgreementsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// List marketplace agreements in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MarketplaceAgreementTermData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MarketplaceAgreementTermData> GetAllData(CancellationToken cancellationToken = default)
        {
            Page<MarketplaceAgreementTermData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _marketplaceAgreementsClientDiagnostics.CreateScope("MarketplaceAgreementCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _marketplaceAgreementsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_GetAgreement</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.Exists");
            scope.Start();
            try
            {
                var response = await _marketplaceAgreementRestClient.GetAgreementAsync(Id.SubscriptionId, publisherId, offerId, planId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_GetAgreement</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual Response<bool> Exists(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.Exists");
            scope.Start();
            try
            {
                var response = _marketplaceAgreementRestClient.GetAgreement(Id.SubscriptionId, publisherId, offerId, planId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MarketplaceAgreementResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual async Task<NullableResponse<MarketplaceAgreementResource>> GetIfExistsAsync(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _marketplaceAgreementRestClient.GetAsync(Id.SubscriptionId, null, publisherId, offerId, planId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MarketplaceAgreementResource>(response.GetRawResponse());
                return Response.FromValue(new MarketplaceAgreementResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MarketplaceAgreements_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MarketplaceAgreementResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publisherId"> Publisher identifier string of image being deployed. </param>
        /// <param name="offerId"> Offer identifier string of image being deployed. </param>
        /// <param name="planId"> Plan identifier string of image being deployed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherId"/>, <paramref name="offerId"/> or <paramref name="planId"/> is null. </exception>
        public virtual NullableResponse<MarketplaceAgreementResource> GetIfExists(string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));
            Argument.AssertNotNullOrEmpty(planId, nameof(planId));

            using var scope = _marketplaceAgreementClientDiagnostics.CreateScope("MarketplaceAgreementCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _marketplaceAgreementRestClient.Get(Id.SubscriptionId, null, publisherId, offerId, planId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MarketplaceAgreementResource>(response.GetRawResponse());
                return Response.FromValue(new MarketplaceAgreementResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
