// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The MultiSlotRankRequest. </summary>
    [CodeGenModel("MultiSlotRankRequest")]
    public partial class PersonalizerRankMultiSlotOptions
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
        public IList<object> ContextFeatures { get; }

        /// <summary>
        /// Initializes a new instance of the MultiSlotRankRequest class.
        /// </summary>
        public PersonalizerRankMultiSlotOptions()
        {
            CustomInit();
        }

        /// <summary> Initializes a new instance of MultiSlotRankRequest. </summary>
        /// <param name="actions">
        /// The set of actions the Personalizer service can pick from.
        ///
        /// The set should not contain more than 50 actions.
        ///
        /// The order of the actions does not affect the rank result but the order
        ///
        /// should match the sequence your application would have used to display them.
        ///
        /// The first item in the array will be used as Baseline item in Offline Evaluations.
        /// </param>
        /// <param name="slots">
        /// The set of slots the Personalizer service should select actions for.
        ///
        /// The set should not contain more than 50 slots.
        /// </param>
        /// <param name="contextFeatures">Features of the context used for
        /// Personalizer as a dictionary of dictionaries. This depends on the application, and
        /// typically includes features about the current user, their
        /// device, profile information, aggregated data about time and date, etc.
        /// Features should not include personally identifiable information (PII),
        /// unique UserIDs, or precise timestamps. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </param>
        /// <param name="eventId">Optionally pass an eventId that uniquely
        /// identifies this Rank event.
        /// If null, the service generates a unique eventId. The eventId will
        /// be used for associating this request with its reward, as well as seeding the
        /// pseudo-random generator when making a Personalizer call.</param>
        /// <param name="deferActivation">Optionally pass an eventId that uniquely
        /// Send false if it is certain the rewardActionId in rank results will be shown to the user, therefore
        /// Personalizer will expect a Reward call, otherwise it will assign the default
        /// Reward to the event. Send true if it is possible the user will not see the action specified in the rank results,
        /// (e.g. because the page is rendering later, or the Rank results may be overridden by code further downstream).
        /// You must call the Activate Event API if the event output is shown to users, otherwise Rewards will be ignored.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="actions"/> or <paramref name="slots"/> is null. </exception>
        public PersonalizerRankMultiSlotOptions(IEnumerable<PersonalizerRankableAction> actions, IEnumerable<PersonalizerSlotOptions> slots, IList<object> contextFeatures = default, string eventId = default, bool deferActivation = false)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }
            if (slots == null)
            {
                throw new ArgumentNullException(nameof(slots));
            }
            ContextFeatures = contextFeatures ?? new ChangeTrackingList<object>();
            Actions = actions.ToList();
            Slots = slots.ToList();
            EventId = eventId;
            DeferActivation = deferActivation;
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();
    }
}
