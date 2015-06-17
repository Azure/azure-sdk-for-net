namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class LoadBalancersOperationsExtensions
    {
            /// <summary>
            /// The delete loadbalancer operation deletes the specified loadbalancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the loadBalancer.
            /// </param>
            public static void Delete(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName)
            {
                Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).DeleteAsync(resourceGroupName, loadBalancerName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete loadbalancer operation deletes the specified loadbalancer.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the loadBalancer.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, loadBalancerName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get ntework interface operation retreives information about the
            /// specified network interface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the loadBalancer.
            /// </param>
            public static LoadBalancer Get(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).GetAsync(resourceGroupName, loadBalancerName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get ntework interface operation retreives information about the
            /// specified network interface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the loadBalancer.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<LoadBalancer> GetAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancer> result = await operations.GetWithOperationResponseAsync(resourceGroupName, loadBalancerName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put LoadBalancer operation creates/updates a LoadBalancer
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='loadBalancerName'>
            /// The name of the loadBalancer.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/delete LoadBalancer operation
            /// </param>
            public static LoadBalancerPutResponse CreateOrUpdate(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).CreateOrUpdateAsync(resourceGroupName, loadBalancerName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put LoadBalancer operation creates/updates a LoadBalancer
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<LoadBalancerPutResponse> CreateOrUpdateAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerPutResponse> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, loadBalancerName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static LoadBalancerListResponse ListAll(this ILoadBalancersOperations operations)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<LoadBalancerListResponse> ListAllAsync( this ILoadBalancersOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResponse> result = await operations.ListAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static LoadBalancerListResponse List(this ILoadBalancersOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<LoadBalancerListResponse> ListAsync( this ILoadBalancersOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResponse> result = await operations.ListWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static LoadBalancerListResponse ListAllNext(this ILoadBalancersOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<LoadBalancerListResponse> ListAllNextAsync( this ILoadBalancersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResponse> result = await operations.ListAllNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static LoadBalancerListResponse ListNext(this ILoadBalancersOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<LoadBalancerListResponse> ListNextAsync( this ILoadBalancersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResponse> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
