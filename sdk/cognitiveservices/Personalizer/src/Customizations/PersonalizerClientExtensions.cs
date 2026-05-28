using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Personalizer
{
    /// <summary>
    /// Extension methods for Events.
    /// </summary>
    public static partial class PersonalizerClientExtensions
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
    }
}
