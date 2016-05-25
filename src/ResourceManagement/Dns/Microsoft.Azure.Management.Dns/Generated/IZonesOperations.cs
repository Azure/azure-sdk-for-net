
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
    /// ZonesOperations operations.
    /// </summary>
    public partial interface IZonesOperations
    {
        /// <summary>
        /// Creates or Updates a DNS zone within a resource group.
        /// </summary>
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Zone>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string zoneName, Zone parameters, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Removes a DNS zone from a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='zoneName'>
        /// The name of the zone without a terminating dot.
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
        Task<AzureOperationResponse<ZoneDeleteResult>> DeleteWithHttpMessagesAsync(string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Removes a DNS zone from a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='zoneName'>
        /// The name of the zone without a terminating dot.
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
        Task<AzureOperationResponse<ZoneDeleteResult>> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string zoneName, string ifMatch = default(string), string ifNoneMatch = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a DNS zone.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='zoneName'>
        /// The name of the zone without a terminating dot.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Zone>> GetWithHttpMessagesAsync(string resourceGroupName, string zoneName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
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
        Task<AzureOperationResponse<IPage<Zone>>> ListInResourceGroupWithHttpMessagesAsync(string resourceGroupName, string top = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the DNS zones within a resource group.
        /// </summary>
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
        Task<AzureOperationResponse<IPage<Zone>>> ListInSubscriptionWithHttpMessagesAsync(string top = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the DNS zones within a resource group.
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
        Task<AzureOperationResponse<IPage<Zone>>> ListInResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the DNS zones within a resource group.
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
        Task<AzureOperationResponse<IPage<Zone>>> ListInSubscriptionNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
