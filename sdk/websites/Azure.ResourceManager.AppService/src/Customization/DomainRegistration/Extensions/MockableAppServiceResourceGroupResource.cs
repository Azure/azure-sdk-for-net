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
    public partial class MockableAppServiceResourceGroupResource : ArmResource
    {
        /// <summary> Gets a collection of AppServiceDomainResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of AppServiceDomainResources and their operations over a AppServiceDomainResource. </returns>
        public virtual AppServiceDomainCollection GetAppServiceDomains()
        {
            return GetCachedClient(client => new AppServiceDomainCollection(client, Id));
        }

        /// <summary>
        /// Description for Get a domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_Get</description>
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
        /// <param name="domainName"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AppServiceDomainResource>> GetAppServiceDomainAsync(string domainName, CancellationToken cancellationToken = default)
        {
            return await GetAppServiceDomains().GetAsync(domainName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Get a domain.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_Get</description>
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
        /// <param name="domainName"> Name of the domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<AppServiceDomainResource> GetAppServiceDomain(string domainName, CancellationToken cancellationToken = default)
        {
            return GetAppServiceDomains().Get(domainName, cancellationToken);
        }
    }
}
