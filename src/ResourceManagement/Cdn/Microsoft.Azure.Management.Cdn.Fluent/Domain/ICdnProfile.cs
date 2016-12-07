// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;
    using CdnProfile.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN profile.
    /// </summary>
    public interface ICdnProfile  :
        IGroupableResource,
        IRefreshable<ICdnProfile>,
        IWrapper<ProfileInner>,
        IUpdatable<CdnProfile.Update.IUpdate>
    {
        /// <return>Endpoints in the CDN manager profile, indexed by the name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,ICdnEndpoint> Endpoints { get; }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

        /// <summary>
        /// Checks if current instance of CDN profile Sku is Premium Verizon.
        /// </summary>
        /// <return>True if current instance of CDN Profile Sku is of Premium Verizon, false otherwise.</return>
        bool IsPremiumVerizon { get; }

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>URI used to login to third party web portal.</return>
        string GenerateSsoUri();

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content in current profile. Available for Verizon Profiles.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadEndpointContent(string endpointName, IList<string> contentPaths);

        /// <return>CDN profile state.</return>
        string ResourceState { get; }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>CustomDomainValidationResult object if successful.</return>
        CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName);

        /// <return>Sku.</return>
        Sku Sku { get; }

        /// <summary>
        /// Starts stopped CDN endpoint in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StartEndpoint(string endpointName);

        /// <summary>
        /// Forcibly purges CDN endpoint content in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeEndpointContent(string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Stops running CDN endpoint in the current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StopEndpoint(string endpointName);
    }
}