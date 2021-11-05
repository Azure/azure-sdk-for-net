// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A sentence opinion object contains assessments extracted from a sentence.
    /// It consists of both the target that these assessments are about, and the actual
    /// assessment themselves.
    /// </summary>
    public readonly struct SentenceOpinion
    {
        internal SentenceOpinion(TargetSentiment target, IReadOnlyList<AssessmentSentiment> assessments)
        {
            Target = target;
            Assessments = new List<AssessmentSentiment>(assessments);
        }

        /// <summary>
        /// Get the target in text, such as the attributes of products or services.
        /// <para>For example in "The food at Hotel Foo is good", "food" is a target of
        /// "Hotel Foo".</para>
        /// </summary>
        public TargetSentiment Target { get; }
        /// <summary>
        /// The list of assessments that are related to the target.
        /// <para>For example in "The food at Hotel Foo is good", "food" is a target of
        /// "Hotel Foo" and "good" is the assessment related to the target.</para>
        /// </summary>
        public IReadOnlyCollection<AssessmentSentiment> Assessments { get; }
    }
}
