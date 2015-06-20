namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> GetWithOperationResponseAsync(string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string loadBalancerName, LoadBalancer parameters, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancer>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string loadBalancerName, LoadBalancer parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a subscription.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancerListResponse>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancerListResponse>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancerListResponse>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List loadBalancer opertion retrieves all the loadbalancers in
        /// a resource group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LoadBalancerListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
