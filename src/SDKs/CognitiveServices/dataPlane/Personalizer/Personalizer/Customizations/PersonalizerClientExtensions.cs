using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Personalizer
{
    /// <summary>
    /// Extension methods for Events.
    /// </summary>
    public static class PersonalizerClientExtensions
    {
        /// <summary>
        /// Report reward to allocate to the top ranked action for the specified event.
        /// </summary>
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// The event id this reward applies to.
        /// </param>
        /// <param name='reward'>
        /// The reward should be a floating point number.
        /// </param>
        public static void Reward(this IPersonalizerClient client, string eventId, RewardRequest reward)
        {
            client.Events.Reward(eventId, reward);
        }

        /// <summary>
        /// Report reward to allocate to the top ranked action for the specified event.
        /// </summary>
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// The event id this reward applies to.
        /// </param>
        /// <param name='reward'>
        /// The reward to be assigned to an action. Value must be
        /// between -1 and 1 inclusive.
        /// </param>
        public static void Reward(this IPersonalizerClient client, string eventId, double reward)
        {
            client.Events.Reward(eventId, new RewardRequest { Value = reward });
        }

        /// <summary>
        /// Report reward to allocate to the top ranked action for the specified event.
        /// </summary>
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// The event id this reward applies to.
        /// </param>
        /// <param name='reward'>
        /// The reward should be a floating point number.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static Task RewardAsync(this IPersonalizerClient client, string eventId, RewardRequest reward, CancellationToken cancellationToken = default(CancellationToken))
        {
            return client.Events.RewardAsync(eventId, reward, cancellationToken);
        }

        /// <summary>
        /// Report reward to allocate to the top ranked action for the specified event.
        /// </summary>
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// The event id this reward applies to.
        /// </param>
        /// <param name='reward'>
        /// The reward to be assigned to an action. Value must be
        /// between -1 and 1 inclusive.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static Task RewardAsync(this IPersonalizerClient client, string eventId, double reward, CancellationToken cancellationToken = default(CancellationToken))
        {
            return client.Events.RewardAsync(eventId, new RewardRequest { Value = reward }, cancellationToken);
        }

        /// <summary>
        /// A Personalizer rank request.
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// The operations group for this extension method.
        /// </param>
        /// <param name='rankRequest'>
        /// A Personalizer request.
        /// </param>
        public static RankResponse Rank(this IPersonalizerClient client, RankRequest rankRequest)
        {
            return client.Events.Rank(rankRequest);
        }

        /// <summary>
        /// A Personalizer rank request.
        /// </summary>
        /// <param name="client">The PersonalizerClient for this extension method.</param>
        /// <param name="features">Features of the context used for Personalizer as a dictionary of dictionaries.</param>
        /// <param name="actions">The set of actions the Personalizer service can pick from.</param>
        /// <param name="eventId">Optionally pass an eventId that uniquely identifies this Rank event.</param>
        /// <param name="excludedActions">The set of action ids to exclude from ranking.</param>
        /// <param name="deferActivation">Send false if the user will see the rank results.</param>
        /// <returns></returns>
        public static RankResponse Rank(
            this IPersonalizerClient client,
            List<object> features,
            List<RankableAction> actions,
            string eventId = null,
            List<string> excludedActions = null,
            bool deferActivation = false)
        {
            return client.Events.Rank(new RankRequest
            {
                ContextFeatures = features,
                Actions = actions,
                EventId = eventId,
                ExcludedActions = excludedActions,
                DeferActivation = deferActivation
            });
        }

        /// <summary>
        /// A Personalizer rank request.
        /// </summary>
        /// <param name='client'>
        /// The PersonalizerClient for this extension method.
        /// </param>
        /// <param name='rankRequest'>
        /// A Personalizer request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static Task<RankResponse> RankAsync(this IPersonalizerClient client, RankRequest rankRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            return client.Events.RankAsync(rankRequest, cancellationToken);
        }

        /// <summary>
        /// A Personalizer rank request.
        /// </summary>
        /// <param name="client">The PersonalizerClient for this extension method.</param>
        /// <param name="features">Features of the context used for Personalizer as a dictionary of dictionaries.</param>
        /// <param name="actions">The set of actions the Personalizer service can pick from.</param>
        /// <param name="eventId">Optionally pass an eventId that uniquely identifies this Rank event.</param>
        /// <param name="excludedActions">The set of action ids to exclude from ranking.</param>
        /// <param name="deferActivation">Send false if the user will see the rank results.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static Task<RankResponse> RankAsync(
            this IPersonalizerClient client,
            List<object> features,
            List<RankableAction> actions,
            string eventId = null,
            List<string> excludedActions = null,
            bool deferActivation = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return client.Events.RankAsync(new RankRequest
            {
                ContextFeatures = features,
                Actions = actions,
                EventId = eventId,
                ExcludedActions = excludedActions,
                DeferActivation = deferActivation
            }, cancellationToken);
        }

    }
}
