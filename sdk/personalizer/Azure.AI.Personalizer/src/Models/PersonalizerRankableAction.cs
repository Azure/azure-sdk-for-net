// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> An action with its associated features used for ranking. </summary>
    [CodeGenModel("RankableAction")]
    public partial class PersonalizerRankableAction
    {
        /// <summary>
        /// List of dictionaries containing features.
        /// Need to be JSON serializable. https://docs.microsoft.com/azure/cognitive-services/personalizer/concepts-features.
        /// </summary>
        public IList<object> Features { get; }

        /// <summary>
        /// The index of the action in the original request
        /// </summary>
        internal int Index { get; set; }
    }
}
