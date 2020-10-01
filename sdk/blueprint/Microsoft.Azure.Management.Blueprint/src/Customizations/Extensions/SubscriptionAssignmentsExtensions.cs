namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AssignmentsOperations.
    /// </summary>
    public static partial class SubscriptionAssignmentsExtensions
    {
        /// <summary>
        /// Create or update a Blueprint assignment.
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
        /// <param name='assignment'>
        /// assignment object to save.
        /// </param>
        public static Assignment CreateOrUpdateInSubscription(this IAssignmentsOperations operations, string subscriptionId, string assignmentName, Assignment assignment)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.CreateOrUpdateAsync(scope, assignmentName, assignment).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a Blueprint assignment.
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
        /// <param name='assignment'>
        /// assignment object to save.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Assignment> CreateOrUpdateInSubscriptionAsync(this IAssignmentsOperations operations, string subscriptionId, string assignmentName, Assignment assignment, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(scope, assignmentName, assignment, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a Blueprint assignment.
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
        public static Assignment GetInSubscription(this IAssignmentsOperations operations, string subscriptionId, string assignmentName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.GetInSubscriptionAsync(scope, assignmentName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a Blueprint assignment.
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
        public static async Task<Assignment> GetInSubscriptionAsync(this IAssignmentsOperations operations, string subscriptionId, string assignmentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, assignmentName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Delete a Blueprint assignment.
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
        /// <param name='assignmentDeleteBehavior'>
        /// If set to <see cref='AssignmentDeleteBehavior.All' />, this will delete all of the resources created by the assignment.
        /// This functionality is disabled by default.
        /// </param>
        public static Assignment DeleteInSubscription(this IAssignmentsOperations operations, string subscriptionId, string assignmentName, string assignmentDeleteBehavior = default(string))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.DeleteAsync(scope, assignmentName, assignmentDeleteBehavior).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a Blueprint assignment.
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
        /// <param name='assignmentDeleteBehavior'>
        /// If set to <see cref='AssignmentDeleteBehavior.All' />, this will delete all of the resources created by the assignment.
        /// This functionality is disabled by default.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Assignment> DeleteInSubscriptionAsync(this IAssignmentsOperations operations, string subscriptionId, string assignmentName, string assignmentDeleteBehavior = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(scope, assignmentName, assignmentDeleteBehavior, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// List Blueprint assignments within a subscription.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        public static IPage<Assignment> ListInSubscription(this IAssignmentsOperations operations, string subscriptionId)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.ListAsync(scope).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List Blueprint assignments within a subscription.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='subscriptionId'>
        /// azure subscriptionId, which we assign the blueprint to.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<Assignment>> ListInSubscriptionAsync(this IAssignmentsOperations operations, string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
