// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    [CodeGenModel("RankRequest")]
    public partial class PersonalizerRankOptions
    {
        /// <summary>
        /// Features of the context used for Personalizer as a
        /// dictionary of dictionaries. This is determined by your application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps.
        /// Need to be JSON serializable. https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </summary>
        public IEnumerable<object> ContextFeatures { get; }

        /// <summary>
        /// The set of actions the Personalizer service can pick from.
        /// The set should not contain more than 50 actions.
        /// The order of the actions does not affect the rank result but the order
        /// should match the sequence your application would have used to display them.
        /// The first item in the array will be used as Baseline item in Offline Evaluations.
        /// </summary>
        public IEnumerable<PersonalizerRankableAction> Actions { get; }

        /// <summary>
        /// The set of action ids to exclude from ranking.
        /// Personalizer will consider the first non-excluded item in the array as the Baseline action when performing Offline Evaluations.
        /// </summary>
        public IEnumerable<string> ExcludedActions { get; }

        /// <summary>
        /// Initializes a new instance of the RankRequest class.
        /// </summary>
        public PersonalizerRankOptions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RankRequest class.
        /// </summary>
        /// <param name="actions">The set of actions the Personalizer service
        /// can pick from.
        /// The set should not contain more than 50 actions.
        /// The order of the actions does not affect the rank result but the
        /// order
        /// should match the sequence your application would have used to
        /// display them.
        /// The first item in the array will be used as Baseline item in
        /// Offline evaluations.</param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="excludedActions">The set of action ids to exclude from ranking.</param>
        /// <param name="eventId">Optionally pass an eventId that uniquely
        /// identifies this Rank event.
        /// If null, the service generates a unique eventId. The eventId will
        /// be used for associating this request with its reward, as well as seeding the
        /// pseudo-random generator when making a Personalizer call.</param>
        /// <param name="deferActivation">Send false if it is certain the
        /// rewardActionId in rank results will be shown to the user, therefore
        /// Personalizer will expect a Reward call, otherwise it will assign
        /// the default Reward to the event. Send true if it is possible the user will not
        /// see the action specified in the rank results, because the page is rendering
        /// later, or the Rank results may be overridden by code further downstream.</param>
        public PersonalizerRankOptions(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<object> contextFeatures = default, IEnumerable<string> excludedActions = default, string eventId = default, bool? deferActivation = default)
        {
            ContextFeatures = contextFeatures ?? new ChangeTrackingList<object>();
            Actions = actions;
            ExcludedActions = excludedActions ?? new ChangeTrackingList<string>();
            EventId = eventId;
            DeferActivation = deferActivation;
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();
    }
}
