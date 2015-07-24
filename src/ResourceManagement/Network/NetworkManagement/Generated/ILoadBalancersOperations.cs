namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// LoadBalancersOperations operations.
    /// </summary>
    public partial interface ILoadBalancersOperations
    {
        /// <summary>
        /// The delete loadbalancer operation deletes the specified
        /// loadbalancer.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='loadBalancerName'>
        /// The name of the loadBalancer.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string loadBalancerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete loadbalancer operation deletes the specified
        /// loadbalancer.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='loadBalancerName'>
        /// The name of the loadBalancer.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string loadBalancerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get ntework interface operation retreives information about
        /// the specified network interface.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='loadBalancerName'>
        /// The name of the loadBalancer.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> GetWithHttpMessagesAsync(string resourceGroupName, string loadBalancerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put LoadBalancer operation creates/updates a LoadBalancer
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='loadBalancerName'>
        /// The name of the loadBalancer.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/delete LoadBalancer operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string loadBalancerName, LoadBalancer parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put LoadBalancer operation creates/updates a LoadBalancer
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='loadBalancerName'>
        /// The name of the loadBalancer.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/delete LoadBalancer operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string loadBalancerName, LoadBalancer parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a subscription.
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<LoadBalancer>>> ListAllWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<LoadBalancer>>> ListWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a subscription.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<LoadBalancer>>> ListAllNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a resource group.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<LoadBalancer>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
