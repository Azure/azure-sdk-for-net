// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using CdnProfile.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure CDN profile.
    /// </summary>
    public interface ICdnProfile  :
        IGroupableResource<ICdnManager, ProfileInner>,
        IRefreshable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        IUpdatable<CdnProfile.Update.IUpdate>
    {
        /// <summary>
        /// Gets endpoints in the CDN manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> Endpoints { get; }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Task<CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Checks if current instance of CDN profile Sku is Premium Verizon.
        /// </summary>
        /// <summary>
        /// Gets true if current instance of CDN Profile Sku is of Premium Verizon, false otherwise.
        /// </summary>
        bool IsPremiumVerizon { get; }

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>URI used to login to third party web portal.</return>
        string GenerateSsoUri();

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>URI used to login to third party web portal.</return>
        Task<string> GenerateSsoUriAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content in current profile. Available for Verizon Profiles.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadEndpointContent(string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content in current profile. Available for Verizon Profiles.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        Task LoadEndpointContentAsync(string endpointName, IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets CDN profile state.
        /// </summary>
        string ResourceState { get; }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>CustomDomainValidationResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult ValidateEndpointCustomDomain(string endpointName, string hostName);

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>CustomDomainValidationResult object if successful.</return>
        Task<CustomDomainValidationResult> ValidateEndpointCustomDomainAsync(
            string endpointName, 
            string hostName, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Sku.
        /// </summary>
        Microsoft.Azure.Management.Cdn.Fluent.Models.Sku Sku { get; }

        /// <summary>
        /// Starts stopped CDN endpoint in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StartEndpoint(string endpointName);

        /// <summary>
        /// Starts stopped CDN endpoint in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        Task StartEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Forcibly purges CDN endpoint content in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeEndpointContent(string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Forcibly purges CDN endpoint content in current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        Task PurgeEndpointContentAsync(string endpointName, IList<string> contentPaths, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops running CDN endpoint in the current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StopEndpoint(string endpointName);

        /// <summary>
        /// Stops running CDN endpoint in the current profile.
        /// </summary>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        Task StopEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Retrieves endpoints usage under current profile
        /// </summary>
        /// <returns>quotas and actual usages of endpoints under the current CDN profile</returns>
        IEnumerable<ResourceUsage> ListResourceUsage();
    }
}