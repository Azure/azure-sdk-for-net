namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PublishedBlueprintsOperations.
    /// </summary>
    public static partial class ManagementGroupPublishedBlueprintsExtensions
    {
        /// <summary>
        /// Publish a new version of the Blueprint with the latest artifacts. Published
        /// Blueprints are immutable.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        public static PublishedBlueprint CreateInManagementGroup(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.CreateAsync(scope, blueprintName, versionId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Publish a new version of the Blueprint with the latest artifacts. Published
        /// Blueprints are immutable.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='publishedBlueprint'>
        /// published blueprint object
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<PublishedBlueprint> CreateInManagementGroupAsync(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId, PublishedBlueprint publishedBlueprint = default(PublishedBlueprint), CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.CreateWithHttpMessagesAsync(scope, blueprintName, versionId, publishedBlueprint, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a published Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        public static PublishedBlueprint GetInManagementGroup(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.GetAsync(scope, blueprintName, versionId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a published Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<PublishedBlueprint> GetInManagementGroupAsync(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, blueprintName, versionId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Delete a published Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        public static PublishedBlueprint DeleteInManagementGroup(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.DeleteAsync(scope, blueprintName, versionId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a published Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<PublishedBlueprint> DeleteInManagementGroupAsync(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, string versionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(scope, blueprintName, versionId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// List published versions of given Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        public static IPage<PublishedBlueprint> ListInManagementGroup(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.ListAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List published versions of given Blueprint.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<PublishedBlueprint>> ListInManagementGroupAsync(this IPublishedBlueprintsOperations operations, string managementGroupName, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
