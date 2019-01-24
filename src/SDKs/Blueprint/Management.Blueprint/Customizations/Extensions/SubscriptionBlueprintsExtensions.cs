using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Blueprint
{
    /// <summary>
    /// Extension methods for BlueprintsOperations.
    /// </summary>
    public static partial class SubscriptionBlueprintsExtensions
    {
        /// <summary>
        /// Create or update Blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='blueprint'>
        /// Blueprint definition.
        /// </param>
        public static BlueprintModel CreateOrUpdateInSubscription(this IBlueprintsOperations operations, string subscriptionId, string blueprintName, BlueprintModel blueprint)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.CreateOrUpdateAsync(scope, blueprintName, blueprint).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update Blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='blueprint'>
        /// Blueprint definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> CreateOrUpdateInSubscriptionAsync(this IBlueprintsOperations operations, string subscriptionId, string blueprintName, BlueprintModel blueprint, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(scope, blueprintName, blueprint, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        public static BlueprintModel GetInSubscription(this IBlueprintsOperations operations, string subscriptionId, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.GetAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> GetInSubscriptionAsync(this IBlueprintsOperations operations, string subscriptionId, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Delete a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        public static BlueprintModel DeleteInSubscription(this IBlueprintsOperations operations, string subscriptionId, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.DeleteAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> DeleteInSubscriptionAsync(this IBlueprintsOperations operations, string subscriptionId, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Create or update blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        public static IPage<BlueprintModel> ListInSubscription(this IBlueprintsOperations operations, string subscriptionId)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.ListAsync(scope).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we save the blueprint to.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<BlueprintModel>> ListInSubscriptionAsync(this IBlueprintsOperations operations, string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
