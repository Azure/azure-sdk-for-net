// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> A slot with it&apos;s associated features and list of excluded actions. </summary>
    [CodeGenModel("SlotRequest")]
    public partial class PersonalizerSlotOptions
    {
        /// <summary>
        /// List of dictionaries containing slot features.
        /// Need to be JSON serializable. https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </summary>
        public IList<object> Features { get; }

        /// <summary>
        /// Initializes a new instance of the RankRequest class.
        /// </summary>
        public PersonalizerSlotOptions()
        {
            CustomInit();
        }

        /// <summary> Initializes a new instance of SlotRequest. </summary>
        /// <param name="id"> Slot ID. </param>
        /// <param name="baselineAction">
        /// <param name="excludedActions">The set of action ids to exclude from ranking. Need to be JSON serializable.
        /// https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features. </param>
        /// <param name="features"> List of dictionaries containing features. </param>
        /// The &apos;baseline action&apos; ID for the slot.
        ///
        /// The BaselineAction is the Id of the Action your application would use in that slot if Personalizer didn&apos;t exist.
        ///
        /// BaselineAction must be defined for every slot.
        ///
        /// BaselineAction should never be part of ExcludedActions.
        ///
        /// Each slot must have a unique BaselineAction which corresponds to an an action from the event&apos;s Actions list.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="baselineAction"/> is null. </exception>
        public PersonalizerSlotOptions(string id, string baselineAction, IList<object> features = default, IList<string> excludedActions = default)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Features = features ?? new ChangeTrackingList<object>();
            ExcludedActions = excludedActions ?? new ChangeTrackingList<string>();
            BaselineAction = baselineAction ?? throw new ArgumentNullException(nameof(baselineAction));
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();
    }
}
