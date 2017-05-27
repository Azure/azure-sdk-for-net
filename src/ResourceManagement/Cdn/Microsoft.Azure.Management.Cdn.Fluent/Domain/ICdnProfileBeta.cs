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
    /// Members of CDN profile that are in Beta.
    /// </summary>
    public interface ICdnProfileBeta  : IBeta
    {
        /// <summary>
        /// Checks the availability of an endpoint name without creating the CDN endpoint asynchronously.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The Observable of the result if successful.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts a stopped CDN endpoint asynchronously.
        /// </summary>
        /// <param name="endpointName">A name of an endpoint under the profile.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously generates a dynamic SSO URI used to sign into the CDN supplemental portal used for advanced management tasks.
        /// </summary>
        /// <return>Observable to URI used to login to third party web portal.</return>
        Task<string> GenerateSsoUriAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS in current profile asynchronously.
        /// </summary>
        /// <param name="endpointName">A name of the endpoint under the profile.</param>
        /// <param name="hostName">The host name of the custom domain, which must be a domain name.</param>
        /// <return>The Observable to CustomDomainValidationResult object if successful.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult> ValidateEndpointCustomDomainAsync(string endpointName, string hostName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops a running CDN endpoint asynchronously.
        /// </summary>
        /// <param name="endpointName">A name of an endpoint under the profile.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopEndpointAsync(string endpointName, CancellationToken cancellationToken = default(CancellationToken));
    }
}