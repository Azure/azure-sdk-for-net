// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Control the phrases to be used in the summary. </summary>
    public partial class PhraseControl
    {
        /// <summary> Initializes a new instance of PhraseControl. </summary>
        /// <param name="targetPhrase"> The target phrase to control. </param>
        /// <param name="strategy"> The strategy to use in phrase control. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetPhrase"/> is null. </exception>
        public PhraseControl(string targetPhrase, PhraseControlStrategy strategy)
        {
            Argument.AssertNotNull(targetPhrase, nameof(targetPhrase));

            TargetPhrase = targetPhrase;
            Strategy = strategy;
        }

        /// <summary> The target phrase to control. </summary>
        public string TargetPhrase { get; set; }
        /// <summary> The strategy to use in phrase control. </summary>
        public PhraseControlStrategy Strategy { get; set; }
    }
}
