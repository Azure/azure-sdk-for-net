// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The strategy to use in phrase control. </summary>
    public enum PhraseControlStrategy
    {
        /// <summary> The model will have higher probability to select the target phrase in the summary if there are multiple alternates. </summary>
        Encourage,
        /// <summary> The model will have lower probability to select the target phrase in the summary if there are multiple alternates. </summary>
        Discourage,
        /// <summary> The model will avoid to select the target phrase in the summary. </summary>
        Disallow
    }
}
