// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class GlobalRulestackResource
    {
        /// <summary> List of AppIds for GlobalRulestack ApiVersion. </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<string> GetAppIdsAsync(string appIdVersion = default, string appPrefix = default, string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetAppIdsAsyncCollectionResultOfT(
                _globalRulestackRestClient,
                Id.Name,
                appIdVersion,
                appPrefix,
                skip,
                top,
                context);
        }

        /// <summary> List of AppIds for GlobalRulestack ApiVersion. </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<string> GetAppIds(string appIdVersion = default, string appPrefix = default, string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetAppIdsCollectionResultOfT(
                _globalRulestackRestClient,
                Id.Name,
                appIdVersion,
                appPrefix,
                skip,
                top,
                context);
        }

        /// <summary> List of countries for Rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RulestackCountry"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RulestackCountry> GetCountriesAsync(string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetCountriesAsyncCollectionResultOfT(_globalRulestackRestClient, Id.Name, skip, top, context);
        }

        /// <summary> List of countries for Rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RulestackCountry"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RulestackCountry> GetCountries(string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetCountriesCollectionResultOfT(_globalRulestackRestClient, Id.Name, skip, top, context);
        }

        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<string> GetFirewallsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetFirewallsAsyncCollectionResultOfT(_globalRulestackRestClient, Id.Name, context);
        }

        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<string> GetFirewalls(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetFirewallsCollectionResultOfT(_globalRulestackRestClient, Id.Name, context);
        }

        /// <summary> List predefined URL categories for rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PredefinedUrlCategory"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetPredefinedUrlCategoriesAsyncCollectionResultOfT(_globalRulestackRestClient, Id.Name, skip, top, context);
        }

        /// <summary> List predefined URL categories for rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PredefinedUrlCategory"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new GlobalRulestackGetPredefinedUrlCategoriesCollectionResultOfT(_globalRulestackRestClient, Id.Name, skip, top, context);
        }
    }
}
