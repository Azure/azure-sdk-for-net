// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    // The custom code is to make operations pageable
    public partial class GlobalRulestackResource
    {
        private readonly GlobalRulestackRestOperations _globalRulestackRestOperations;

        /// <summary> Initializes a new instance of <see cref="GlobalRulestackResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GlobalRulestackResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string globalRulestackApiVersion);
            _globalRulestackClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PaloAltoNetworks.Ngfw", ResourceType.Namespace, Diagnostics);
            _globalRulestackRestClient = new GlobalRulestack(_globalRulestackClientDiagnostics, Pipeline, Endpoint, globalRulestackApiVersion ?? "2025-10-08");
            _globalRulestackRestOperations = new GlobalRulestackRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, globalRulestackApiVersion);
            ValidateResourceId(id);
        }

        /// <summary> List of AppIds for GlobalRulestack ApiVersion. </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListAppIdsRequest(Id.Name, appIdVersion, appPrefix, skip, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetAppIds", "value", null, cancellationToken);
        }

        /// <summary> List of AppIds for GlobalRulestack ApiVersion. </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListAppIdsRequest(Id.Name, appIdVersion, appPrefix, skip, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetAppIds", "value", null, cancellationToken);
        }

        /// <summary> List of countries for Rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RulestackCountry"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RulestackCountry> GetCountriesAsync(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListCountriesRequest(Id.Name, skip, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => RulestackCountry.DeserializeRulestackCountry(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetCountries", "value", null, cancellationToken);
        }

        /// <summary> List of countries for Rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RulestackCountry"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RulestackCountry> GetCountries(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListCountriesRequest(Id.Name, skip, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => RulestackCountry.DeserializeRulestackCountry(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetCountries", "value", null, cancellationToken);
        }

        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<string> GetFirewallsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListFirewallsRequest(Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }

        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<string> GetFirewalls(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListFirewallsRequest(Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }

        /// <summary> List predefined URL categories for rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PredefinedUrlCategory"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListPredefinedUrlCategoriesRequest(Id.Name, skip, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => PredefinedUrlCategory.DeserializePredefinedUrlCategory(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetPredefinedUrlCategories", "value", null, cancellationToken);
        }

        /// <summary> List predefined URL categories for rulestack. </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PredefinedUrlCategory"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestOperations.CreateListPredefinedUrlCategoriesRequest(Id.Name, skip, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => PredefinedUrlCategory.DeserializePredefinedUrlCategory(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetPredefinedUrlCategories", "value", null, cancellationToken);
        }
    }
}
