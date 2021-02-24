// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A mined assessment object contains opinions extracted from a sentence.
    /// It consists of both the target that these assessments are about, and the actual
    /// assessment themselves.
    /// </summary>
    public readonly struct MinedAssessment
    {
        internal MinedAssessment(TargetSentiment target, IReadOnlyList<AssessmentSentiment> assessments)
        {
            Target = target;
            Assessments = new List<AssessmentSentiment>(assessments);
        }

        /// <summary>
        /// Get the aspect in text, such as the attributes of products or services.
        /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
        /// "Hotel Foo".</para>
        /// </summary>
        public TargetSentiment Target { get; }
        /// <summary>
        /// The list of opinions that are related to the aspect.
        /// <para>For example in "The food at Hotel Foo is good", "food" is an aspect of
        /// "Hotel Foo" and "good" is the opinion related to the aspect.</para>
        /// </summary>
        public IReadOnlyCollection<AssessmentSentiment> Assessments { get; }
    }
}
