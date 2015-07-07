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
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, loadBalancerName, null, cancellationToken).ConfigureAwait(false);
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
            public static void BeginDelete(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName)
            {
                Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).BeginDeleteAsync(resourceGroupName, loadBalancerName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task BeginDeleteAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, loadBalancerName, null, cancellationToken).ConfigureAwait(false);
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
                AzureOperationResponse<LoadBalancer> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, loadBalancerName, null, cancellationToken).ConfigureAwait(false);
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
            public static LoadBalancer CreateOrUpdate(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters)
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
            public static async Task<LoadBalancer> CreateOrUpdateAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancer> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, loadBalancerName, parameters, null, cancellationToken).ConfigureAwait(false);
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
            public static LoadBalancer BeginCreateOrUpdate(this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters)
            {
                return Task.Factory.StartNew(s => ((ILoadBalancersOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, loadBalancerName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task<LoadBalancer> BeginCreateOrUpdateAsync( this ILoadBalancersOperations operations, string resourceGroupName, string loadBalancerName, LoadBalancer parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancer> result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, loadBalancerName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List loadBalancer opertion retrieves all the loadbalancers in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static LoadBalancerListResult ListAll(this ILoadBalancersOperations operations)
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
            public static async Task<LoadBalancerListResult> ListAllAsync( this ILoadBalancersOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResult> result = await operations.ListAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
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
            public static LoadBalancerListResult List(this ILoadBalancersOperations operations, string resourceGroupName)
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
            public static async Task<LoadBalancerListResult> ListAsync( this ILoadBalancersOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResult> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false);
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
            public static LoadBalancerListResult ListAllNext(this ILoadBalancersOperations operations, string nextLink)
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
            public static async Task<LoadBalancerListResult> ListAllNextAsync( this ILoadBalancersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResult> result = await operations.ListAllNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
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
            public static LoadBalancerListResult ListNext(this ILoadBalancersOperations operations, string nextLink)
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
            public static async Task<LoadBalancerListResult> ListNextAsync( this ILoadBalancersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<LoadBalancerListResult> result = await operations.ListNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
