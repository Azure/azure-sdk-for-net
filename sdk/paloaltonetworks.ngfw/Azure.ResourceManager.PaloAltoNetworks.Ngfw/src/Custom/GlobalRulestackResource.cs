// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class GlobalRulestackResource
    {
        /// <summary>
        /// List of Firewalls associated with Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<string> GetFirewallsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetFirewallsRequest(Id.Name, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of Firewalls associated with Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<string> GetFirewalls(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetFirewallsRequest(Id.Name, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of AppIds for GlobalRulestack ApiVersion
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listAppIds. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetAppIds. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetAppIdsRequest(Id.Name, appIdVersion, appPrefix, skip, top, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetAppIds", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of AppIds for GlobalRulestack ApiVersion
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listAppIds. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetAppIds. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="appIdVersion"></param>
        /// <param name="appPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetAppIdsRequest(Id.Name, appIdVersion, appPrefix, skip, top, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => e.GetString(), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetAppIds", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of countries for Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listCountries. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetCountries. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<RulestackCountry> GetCountriesAsync(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetCountriesRequest(Id.Name, skip, top, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => RulestackCountry.DeserializeRulestackCountry(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetCountries", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of countries for Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listCountries. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetCountries. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<RulestackCountry> GetCountries(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetCountriesRequest(Id.Name, skip, top, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => RulestackCountry.DeserializeRulestackCountry(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetCountries", "value", null, cancellationToken);
        }

        /// <summary>
        /// List predefined URL categories for rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listPredefinedUrlCategories. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetPredefinedUrlCategories. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetPredefinedUrlCategoriesRequest(Id.Name, skip, top, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => PredefinedUrlCategory.DeserializePredefinedUrlCategory(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetPredefinedUrlCategories", "value", null, cancellationToken);
        }

        /// <summary>
        /// List predefined URL categories for rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/listPredefinedUrlCategories. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetPredefinedUrlCategories. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GlobalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _globalRulestackRestClient.CreateGetPredefinedUrlCategoriesRequest(Id.Name, skip, top, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => PredefinedUrlCategory.DeserializePredefinedUrlCategory(e, null), _globalRulestackClientDiagnostics, Pipeline, "GlobalRulestackResource.GetPredefinedUrlCategories", "value", null, cancellationToken);
        }
    }
}
