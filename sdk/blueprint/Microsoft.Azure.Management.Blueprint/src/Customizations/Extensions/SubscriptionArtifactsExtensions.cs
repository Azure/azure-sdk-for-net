namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ArtifactsOperations.
    /// </summary>
    public static partial class SubscriptionArtifactsExtensions
    {
        /// <summary>
        /// Create or update Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        /// <param name='artifact'>
        /// Blueprint artifact to save.
        /// </param>
        public static Artifact CreateOrUpdateInSubscription(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName, Artifact artifact)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.CreateOrUpdateAsync(scope, blueprintName, artifactName, artifact).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        /// <param name='artifact'>
        /// Blueprint artifact to save.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Artifact> CreateOrUpdateInSubscriptionAsync(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName, Artifact artifact, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(scope, blueprintName, artifactName, artifact, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        public static Artifact GetInSubscription(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.GetAsync(scope, blueprintName, artifactName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Artifact> GetInSubscriptionAsync(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, blueprintName, artifactName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Delete a Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        public static Artifact DeleteInSubscription(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.DeleteAsync(scope, blueprintName, artifactName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a Blueprint artifact.
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
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Artifact> DeleteInSubscriptionAsync(this IArtifactsOperations operations, string subscriptionId, string blueprintName, string artifactName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(scope, blueprintName, artifactName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// List artifacts for a given Blueprint.
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
        public static IPage<Artifact> ListInSubscription(this IArtifactsOperations operations, string subscriptionId, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.ListAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List artifacts for a given Blueprint.
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
        public static async Task<IPage<Artifact>> ListInSubscriptionAsync(this IArtifactsOperations operations, string subscriptionId, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
