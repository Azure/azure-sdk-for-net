// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A mined opinion object contains opinions extracted from a sentence.
    /// It consists of both an aspect that these opinions are about, and the actual
    /// opinions themselves.
    /// </summary>
    public readonly struct MinedOpinion
    {
        internal MinedOpinion(AspectSentiment aspect, IReadOnlyList<OpinionSentiment> opinions)
        {
            Aspect = aspect;
            Opinions = new List<OpinionSentiment>(opinions);
        }

        /// <summary>
        /// Get the aspect in text, such as the attributes of products or services.
        /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
        /// "Hotel Foo".</para>
        /// </summary>
        public AspectSentiment Aspect { get; }
        /// <summary>
        /// The list of opinions that are related to the aspect.
        /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
        /// "Hotel Foo" and "good" is the opinion related to the aspect.</para>
        /// </summary>
        public IReadOnlyCollection<OpinionSentiment> Opinions { get; }
    }
}
