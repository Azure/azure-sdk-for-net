
namespace Microsoft.Azure.Management.Dns
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// RecordSetsOperations operations.
    /// </summary>
    public partial interface IRecordSetsOperations
    {
        /// <summary>
        /// Updates a RecordSet within a DNS zone.
        /// </summary>
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
        /// The type of DNS record. Possible values include: 'A', 'AAAA',
        /// 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<RecordSet>> UpdateWithHttpMessagesAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates or Updates a RecordSet within a DNS zone.
        /// </summary>
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
        /// The type of DNS record. Possible values include: 'A', 'AAAA',
        /// 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<RecordSet>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, RecordSet parameters, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Removes a RecordSet from a DNS zone.
        /// </summary>
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
        /// The type of DNS record. Possible values include: 'A', 'AAAA',
        /// 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
        /// </param>
        /// <param name='ifMatch'>
        /// Defines the If-Match condition. The delete operation will be
        /// performed only if the ETag of the zone on the server matches this
        /// value.
        /// </param>
        /// <param name='ifNoneMatch'>
        /// Defines the If-None-Match condition. The delete operation will be
        /// performed only if the ETag of the zone on the server does not
        /// match this value.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a RecordSet.
        /// </summary>
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
        /// The type of DNS record. Possible values include: 'A', 'AAAA',
        /// 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<RecordSet>> GetWithHttpMessagesAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the RecordSets of a specified type in a DNS zone.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the zone.
        /// </param>
        /// <param name='zoneName'>
        /// The name of the zone from which to enumerate RecordsSets.
        /// </param>
        /// <param name='recordType'>
        /// The type of record sets to enumerate. Possible values include:
        /// 'A', 'AAAA', 'CNAME', 'MX', 'NS', 'PTR', 'SOA', 'SRV', 'TXT'
        /// </param>
        /// <param name='top'>
        /// Query parameters. If null is passed returns the default number of
        /// zones.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<RecordSet>>> ListByTypeWithHttpMessagesAsync(string resourceGroupName, string zoneName, RecordType recordType, string top = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all RecordSets in a DNS zone.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the zone.
        /// </param>
        /// <param name='zoneName'>
        /// The name of the zone from which to enumerate RecordSets.
        /// </param>
        /// <param name='top'>
        /// Query parameters. If null is passed returns the default number of
        /// zones.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<RecordSet>>> ListAllInResourceGroupWithHttpMessagesAsync(string resourceGroupName, string zoneName, string top = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the RecordSets of a specified type in a DNS zone.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<RecordSet>>> ListByTypeNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all RecordSets in a DNS zone.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<RecordSet>>> ListAllInResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
