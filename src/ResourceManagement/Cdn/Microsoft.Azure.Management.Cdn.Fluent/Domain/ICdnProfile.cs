// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN profile.
    /// </summary>
    public interface ICdnProfile  :
        ICdnProfileBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Cdn.Fluent.ICdnManager, ProfileInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<CdnProfile.Update.IUpdate>
    {
        /// <summary>
        /// Checks the availability of an endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The result if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

        /// <summary>
        /// Gets endpoints in the CDN manager profile, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> Endpoints { get; }

        /// <summary>
        /// Gets the SKU of the CDN profile.
        /// </summary>
        Models.Sku Sku { get; }

        /// <summary>
        /// Gets CDN profile state.
        /// </summary>
        string ResourceState { get; }

        /// <summary>
        /// Gets true if this CDN profile's SKU is of Premium Verizon, else false.
        /// </summary>
        bool IsPremiumVerizon { get; }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile.
        /// </summary>
        /// <param name="endpointName">A name of the endpoint under the profile.</param>
        /// <param name="hostName">The host name of the custom domain, which must be a domain name.</param>
        /// <return>CustomDomainValidationResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName);

        /// <summary>
        /// Starts a stopped CDN endpoint.
        /// </summary>
        /// <param name="endpointName">A name of an endpoint under the profile.</param>
        void StartEndpoint(string endpointName);

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>URI used to login to the third party web portal.</return>
        string GenerateSsoUri();

        /// <return>Quotas and actual usages of endpoints under the current CDN profile.</return>
        System.Collections.Generic.IEnumerable<ResourceUsage> ListResourceUsage();

        /// <summary>
        /// Stops a running CDN endpoint.
        /// </summary>
        /// <param name="endpointName">A name of an endpoint under the profile.</param>
        void StopEndpoint(string endpointName);
    }
}