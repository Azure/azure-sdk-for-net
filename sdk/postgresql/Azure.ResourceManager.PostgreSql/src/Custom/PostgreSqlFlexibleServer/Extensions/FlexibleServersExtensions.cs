// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    [CodeGenType("PostgreSqlFlexibleServersExtensions")]
    public static partial class FlexibleServersExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource.CreateResourceIdentifier" /> to create a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockablePostgreSqlFlexibleServersArmClient.GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.")]
        public static PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.");
        }

        /// <summary> Check the availability of name for resource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(locationName.Name, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check the availability of name for resource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(locationName.Name, content, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerCapabilityProperties"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteLocationBasedCapabilitiesAsync(locationName.Name, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerCapabilityProperties"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteLocationBasedCapabilities(locationName.Name, cancellationToken);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteVirtualNetworkSubnetUsageAsync(locationName.Name, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteVirtualNetworkSubnetUsage(locationName.Name, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerQuotaUsage"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).GetQuotaUsagesAsync(locationName.Name, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerQuotaUsage"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).GetQuotaUsages(locationName.Name, cancellationToken);
        }

        /// <summary> Gets the private DNS zone suffix. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        public static async Task<Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockablePostgreSqlFlexibleServersTenantResource(tenantResource).ExecuteGetPrivateDnsZoneSuffixAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the private DNS zone suffix. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        public static Response<string> ExecuteGetPrivateDnsZoneSuffix(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockablePostgreSqlFlexibleServersTenantResource(tenantResource).ExecuteGetPrivateDnsZoneSuffix(cancellationToken);
        }
    }
}
