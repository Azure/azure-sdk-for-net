namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PublishedArtifactsOperations.
    /// </summary>
    public static partial class SubscriptionPublishedArtifactsExtensions
    {
        /// <summary>
        /// Get an artifact for a published Blueprint.
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
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        public static Artifact GetInSubscription(this IPublishedArtifactsOperations operations, string subscriptionId, string blueprintName, string versionId, string artifactName)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.GetAsync(scope, blueprintName, versionId, artifactName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an artifact for a published Blueprint.
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
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='artifactName'>
        /// name of the artifact.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Artifact> GetInSubscriptionAsync(this IPublishedArtifactsOperations operations, string subscriptionId, string blueprintName, string versionId, string artifactName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, blueprintName, versionId, artifactName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// List artifacts for a published Blueprint.
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
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        public static IPage<Artifact> ListInSubscription(this IPublishedArtifactsOperations operations, string subscriptionId, string blueprintName, string versionId)
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            return operations.ListAsync(scope, blueprintName, versionId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// List artifacts for a published Blueprint.
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
        /// <param name='versionId'>
        /// version of the published blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<Artifact>> ListInSubscriptionAsync(this IPublishedArtifactsOperations operations, string subscriptionId, string blueprintName, string versionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.SubscriptionScope, subscriptionId);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, blueprintName, versionId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
