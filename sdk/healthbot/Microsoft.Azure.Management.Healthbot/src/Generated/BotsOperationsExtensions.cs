// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Healthbot
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for BotsOperations.
    /// </summary>
    public static partial class BotsOperationsExtensions
    {
            /// <summary>
            /// Create a new HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the created bot.
            /// </param>
            public static HealthBot Create(this IBotsOperations operations, string resourceGroupName, string botName, HealthBot parameters)
            {
                return operations.CreateAsync(resourceGroupName, botName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a new HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the created bot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<HealthBot> CreateAsync(this IBotsOperations operations, string resourceGroupName, string botName, HealthBot parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, botName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            public static HealthBot Get(this IBotsOperations operations, string resourceGroupName, string botName)
            {
                return operations.GetAsync(resourceGroupName, botName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<HealthBot> GetAsync(this IBotsOperations operations, string resourceGroupName, string botName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, botName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patch a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the required bot.
            /// </param>
            public static HealthBot Update(this IBotsOperations operations, string resourceGroupName, string botName, HealthBotUpdateParameters parameters)
            {
                return operations.UpdateAsync(resourceGroupName, botName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the required bot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<HealthBot> UpdateAsync(this IBotsOperations operations, string resourceGroupName, string botName, HealthBotUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, botName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            public static void Delete(this IBotsOperations operations, string resourceGroupName, string botName)
            {
                operations.DeleteAsync(resourceGroupName, botName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IBotsOperations operations, string resourceGroupName, string botName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, botName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a resource
            /// group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            public static IPage<HealthBot> ListByResourceGroup(this IBotsOperations operations, string resourceGroupName)
            {
                return operations.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a resource
            /// group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<HealthBot>> ListByResourceGroupAsync(this IBotsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IPage<HealthBot> List(this IBotsOperations operations)
            {
                return operations.ListAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<HealthBot>> ListAsync(this IBotsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create a new HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the created bot.
            /// </param>
            public static HealthBot BeginCreate(this IBotsOperations operations, string resourceGroupName, string botName, HealthBot parameters)
            {
                return operations.BeginCreateAsync(resourceGroupName, botName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a new HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for the created bot.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<HealthBot> BeginCreateAsync(this IBotsOperations operations, string resourceGroupName, string botName, HealthBot parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateWithHttpMessagesAsync(resourceGroupName, botName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            public static void BeginDelete(this IBotsOperations operations, string resourceGroupName, string botName)
            {
                operations.BeginDeleteAsync(resourceGroupName, botName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a HealthBot.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the Bot resource group in the user subscription.
            /// </param>
            /// <param name='botName'>
            /// The name of the Bot resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IBotsOperations operations, string resourceGroupName, string botName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, botName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a resource
            /// group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<HealthBot> ListByResourceGroupNext(this IBotsOperations operations, string nextPageLink)
            {
                return operations.ListByResourceGroupNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a resource
            /// group
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
            public static async Task<IPage<HealthBot>> ListByResourceGroupNextAsync(this IBotsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<HealthBot> ListNext(this IBotsOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns all the resources of a particular type belonging to a subscription.
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
            public static async Task<IPage<HealthBot>> ListNextAsync(this IBotsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
