namespace Microsoft.Azure.Management.Blueprint.Customizations.Extensions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Blueprint.Models;
    using Microsoft.Rest.Azure;

    public static partial class ManagementGroupAssignmentsExtentions
    {
        /// <summary>
        /// Creates or updates a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment will be saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        /// <param name='assignment'>
        /// The assignment object to save.
        /// </param>

        public static Assignment CreateOrUpdateInManagementGroup(this IAssignmentsOperations operations, string managementGroupName, string assignmentName, Assignment assignment)
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.CreateOrUpdateAsync(resourceScope, assignmentName, assignment).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates or updates a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment will be saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        /// <param name='assignment'>
        /// The assignment object to save.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Assignment> CreateOrUpdateInManagementGroupAsync(this IAssignmentsOperations operations, string managementGroupName, string assignmentName, Assignment assignment, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceScope, assignmentName, assignment, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment is saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        public static Assignment GetInSubscription(this IAssignmentsOperations operations, string managementGroupName, string assignmentName)
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.GetInSubscriptionAsync(resourceScope, assignmentName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment is saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Assignment> GetInManagementGroupAsync(this IAssignmentsOperations operations, string managementGroupName, string assignmentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceScope, assignmentName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Deletes a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment is saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        /// <param name='assignmentDeleteBehavior'>
        /// If set to <see cref='AssignmentDeleteBehavior.All' />, this will delete all of the resources created by the assignment.
        /// The default is to preserve resources with <see cref="AssignmentDeleteBehavior.None" />.
        /// </param>
        public static Assignment DeleteInManagementGroup(this IAssignmentsOperations operations, string managementGroupName, string assignmentName, string assignmentDeleteBehavior = default(string))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.DeleteAsync(resourceScope, assignmentName, assignmentDeleteBehavior).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a Blueprint assignment in a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignment is saved.
        /// </param>
        /// <param name='assignmentName'>
        /// The name of the assignment.
        /// </param>
        /// <param name='assignmentDeleteBehavior'>
        /// If set to <see cref='AssignmentDeleteBehavior.All' />, this will delete all of the resources created by the assignment.
        /// This functionality is disabled by default.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Assignment> DeleteInManagementGroupAsync(this IAssignmentsOperations operations, string managementGroupName, string assignmentName, string assignmentDeleteBehavior = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(resourceScope, assignmentName, assignmentDeleteBehavior, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Lists Blueprint assignments within a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignments are saved.
        /// </param>
        public static IPage<Assignment> ListInManagementGroup(this IAssignmentsOperations operations, string managementGroupName)
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.ListAsync(resourceScope).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists Blueprint assignments within a management group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// The name of the management group where the assignments are saved.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<Assignment>> ListInManagementGroupAsync(this IAssignmentsOperations operations, string managementGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceScope, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}

