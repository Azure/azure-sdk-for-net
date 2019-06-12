namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AssignmentOperations.
    /// </summary>
    public static partial class SubscriptionAssignmentOperationsExtensions
    {
        /// <summary>
        /// List Operations for given blueprint assignment within a subscription.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        /// <param name='assignmentName'>
        /// name of the assignment.
        /// </param>
        public static IPage<AssignmentOperation> ListInSubscription(this IAssignmentOperations operations, string subscriptionId, string assignmentName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.ListAsync(scope, assignmentName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List Operations for given blueprint assignment within a subscription.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        /// <param name='assignmentName'>
        /// name of the assignment.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<AssignmentOperation>> ListInSubscriptionAsync(this IAssignmentOperations operations, string subscriptionId, string assignmentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, assignmentName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a Blueprint assignment operation.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        /// <param name='assignmentName'>
        /// name of the assignment.
        /// </param>
        /// <param name='assignmentOperationName'>
        /// name of the assignment operation.
        /// </param>
        public static AssignmentOperation GetInSubscription(this IAssignmentOperations operations, string subscriptionId, string assignmentName, string assignmentOperationName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.GetAsync(scope, assignmentName, assignmentOperationName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a Blueprint assignment operation.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        /// <param name='assignmentName'>
        /// name of the assignment.
        /// </param>
        /// <param name='assignmentOperationName'>
        /// name of the assignment operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<AssignmentOperation> GetInSubscriptionAsync(this IAssignmentOperations operations, string subscriptionId, string assignmentName, string assignmentOperationName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, assignmentName, assignmentOperationName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}