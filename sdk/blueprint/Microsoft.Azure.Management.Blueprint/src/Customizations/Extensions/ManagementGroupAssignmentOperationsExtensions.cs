namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AssignmentOperations.
    /// </summary>
    public static partial class ManagementGroupAssignmentOperationsExtensions
    {
        /// <summary>
        /// Lists Operations for given blueprint assignment within a management group.
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
        public static IPage<AssignmentOperation> ListInManagementGroup(this IAssignmentOperations operations, string managementGroupName, string assignmentName)
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.ListAsync(resourceScope, assignmentName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists Operations for given blueprint assignment within a management group.
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
        public static async Task<IPage<AssignmentOperation>> ListInManagementGroupAsync(this IAssignmentOperations operations, string managementGroupName, string assignmentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceScope, assignmentName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets a Blueprint assignment operation.
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
        /// <param name='assignmentOperationName'>
        /// The name of the assignment operation.
        /// </param>
        public static AssignmentOperation GetInManagementGroup(this IAssignmentOperations operations, string managementGroupName, string assignmentName, string assignmentOperationName)
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.GetAsync(resourceScope, assignmentName, assignmentOperationName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a Blueprint assignment operation.
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
        /// <param name='assignmentOperationName'>
        /// The name of the assignment operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<AssignmentOperation> GetInManagementGroupAsync(this IAssignmentOperations operations, string managementGroupName, string assignmentName, string assignmentOperationName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceScope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceScope, assignmentName, assignmentOperationName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}

