
namespace Microsoft.Azure.Management.Dns
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for ZonesOperations.
    /// </summary>
    public static partial class ZonesOperationsExtensions
    {
            /// <summary>
            /// Creates or Updates a DNS zone within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the CreateOrUpdate operation.
            /// </param>
            /// <param name='ifMatch'>
            /// The etag of Zone.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. Set to '*' to force
            /// Create-If-Not-Exist. Other values will be ignored.
            /// </param>
            public static Zone CreateOrUpdate(this IZonesOperations operations, string resourceGroupName, string zoneName, Zone parameters, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).CreateOrUpdateAsync(resourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or Updates a DNS zone within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the CreateOrUpdate operation.
            /// </param>
            /// <param name='ifMatch'>
            /// The etag of Zone.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. Set to '*' to force
            /// Create-If-Not-Exist. Other values will be ignored.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Zone> CreateOrUpdateAsync(this IZonesOperations operations, string resourceGroupName, string zoneName, Zone parameters, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, zoneName, parameters, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Removes a DNS zone from a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='ifMatch'>
            /// Defines the If-Match condition. The delete operation will be performed
            /// only if the ETag of the zone on the server matches this value.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. The delete operation will be
            /// performed only if the ETag of the zone on the server does not match this
            /// value.
            /// </param>
            public static ZoneDeleteResult Delete(this IZonesOperations operations, string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).DeleteAsync(resourceGroupName, zoneName, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Removes a DNS zone from a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='ifMatch'>
            /// Defines the If-Match condition. The delete operation will be performed
            /// only if the ETag of the zone on the server matches this value.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. The delete operation will be
            /// performed only if the ETag of the zone on the server does not match this
            /// value.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ZoneDeleteResult> DeleteAsync(this IZonesOperations operations, string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(resourceGroupName, zoneName, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Removes a DNS zone from a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='ifMatch'>
            /// Defines the If-Match condition. The delete operation will be performed
            /// only if the ETag of the zone on the server matches this value.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. The delete operation will be
            /// performed only if the ETag of the zone on the server does not match this
            /// value.
            /// </param>
            public static ZoneDeleteResult BeginDelete(this IZonesOperations operations, string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).BeginDeleteAsync(resourceGroupName, zoneName, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Removes a DNS zone from a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='ifMatch'>
            /// Defines the If-Match condition. The delete operation will be performed
            /// only if the ETag of the zone on the server matches this value.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. The delete operation will be
            /// performed only if the ETag of the zone on the server does not match this
            /// value.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ZoneDeleteResult> BeginDeleteAsync(this IZonesOperations operations, string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, zoneName, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            public static Zone Get(this IZonesOperations operations, string resourceGroupName, string zoneName)
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).GetAsync(resourceGroupName, zoneName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone without a terminating dot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Zone> GetAsync(this IZonesOperations operations, string resourceGroupName, string zoneName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, zoneName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            public static IPage<Zone> ListInResourceGroup(this IZonesOperations operations, string resourceGroupName, string top = default(string))
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).ListInResourceGroupAsync(resourceGroupName, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Zone>> ListInResourceGroupAsync(this IZonesOperations operations, string resourceGroupName, string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListInResourceGroupWithHttpMessagesAsync(resourceGroupName, top, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            public static IPage<Zone> ListInSubscription(this IZonesOperations operations, string top = default(string))
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).ListInSubscriptionAsync(top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Zone>> ListInSubscriptionAsync(this IZonesOperations operations, string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListInSubscriptionWithHttpMessagesAsync(top, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Zone> ListInResourceGroupNext(this IZonesOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).ListInResourceGroupNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Zone>> ListInResourceGroupNextAsync(this IZonesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListInResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Zone> ListInSubscriptionNext(this IZonesOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IZonesOperations)s).ListInSubscriptionNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the DNS zones within a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Zone>> ListInSubscriptionNextAsync(this IZonesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListInSubscriptionNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
