
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
    /// Extension methods for RecordSetsOperations.
    /// </summary>
    public static partial class RecordSetsOperationsExtensions
    {
            /// <summary>
            /// Updates a RecordSet within a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Update operation.
            /// </param>
            /// <param name='ifMatch'>
            /// The etag of Zone.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. Set to '*' to force
            /// Create-If-Not-Exist. Other values will be ignored.
            /// </param>
            public static RecordSet Update(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).UpdateAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, parameters, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates a RecordSet within a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Update operation.
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
            public static async Task<RecordSet> UpdateAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, parameters, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or Updates a RecordSet within a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the CreateOrUpdate operation.
            /// </param>
            /// <param name='ifMatch'>
            /// The etag of Recordset.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. Set to '*' to force
            /// Create-If-Not-Exist. Other values will be ignored.
            /// </param>
            public static RecordSet CreateOrUpdate(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).CreateOrUpdateAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, parameters, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or Updates a RecordSet within a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the CreateOrUpdate operation.
            /// </param>
            /// <param name='ifMatch'>
            /// The etag of Recordset.
            /// </param>
            /// <param name='ifNoneMatch'>
            /// Defines the If-None-Match condition. Set to '*' to force
            /// Create-If-Not-Exist. Other values will be ignored.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RecordSet> CreateOrUpdateAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, parameters, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Removes a RecordSet from a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
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
            public static void Delete(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string ifMatch = default(string), string ifNoneMatch = default(string))
            {
                Task.Factory.StartNew(s => ((IRecordSetsOperations)s).DeleteAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, ifMatch, ifNoneMatch), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Removes a RecordSet from a DNS zone.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
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
            public static async Task DeleteAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string ifMatch = default(string), string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, ifMatch, ifNoneMatch, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets a RecordSet.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            public static RecordSet Get(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType)
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).GetAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a RecordSet.
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
            /// <param name='relativeRecordSetName'>
            /// The name of the RecordSet, relative to the name of the zone.
            /// </param>
            /// <param name='recordType'>
            /// The type of DNS record. Possible values include: 'A', 'AAAA', 'CNAME',
            /// 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RecordSet> GetAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, zoneName, relativeRecordSetName, recordType, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the RecordSets of a specified type in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the zone.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone from which to enumerate RecordsSets.
            /// </param>
            /// <param name='recordType'>
            /// The type of record sets to enumerate. Possible values include: 'A',
            /// 'AAAA', 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            public static IPage<RecordSet> ListByType(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, RecordType recordType, string top = default(string))
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).ListByTypeAsync(resourceGroupName, zoneName, recordType, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the RecordSets of a specified type in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the zone.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone from which to enumerate RecordsSets.
            /// </param>
            /// <param name='recordType'>
            /// The type of record sets to enumerate. Possible values include: 'A',
            /// 'AAAA', 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<RecordSet>> ListByTypeAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, RecordType recordType, string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByTypeWithHttpMessagesAsync(resourceGroupName, zoneName, recordType, top, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all RecordSets in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the zone.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone from which to enumerate RecordSets.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            public static IPage<RecordSet> ListAllInResourceGroup(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string top = default(string))
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).ListAllInResourceGroupAsync(resourceGroupName, zoneName, top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all RecordSets in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the zone.
            /// </param>
            /// <param name='zoneName'>
            /// The name of the zone from which to enumerate RecordSets.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns the default number of zones.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<RecordSet>> ListAllInResourceGroupAsync(this IRecordSetsOperations operations, string resourceGroupName, string zoneName, string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListAllInResourceGroupWithHttpMessagesAsync(resourceGroupName, zoneName, top, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the RecordSets of a specified type in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<RecordSet> ListByTypeNext(this IRecordSetsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).ListByTypeNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the RecordSets of a specified type in a DNS zone.
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
            public static async Task<IPage<RecordSet>> ListByTypeNextAsync(this IRecordSetsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByTypeNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all RecordSets in a DNS zone.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<RecordSet> ListAllInResourceGroupNext(this IRecordSetsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IRecordSetsOperations)s).ListAllInResourceGroupNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all RecordSets in a DNS zone.
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
            public static async Task<IPage<RecordSet>> ListAllInResourceGroupNextAsync(this IRecordSetsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListAllInResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
