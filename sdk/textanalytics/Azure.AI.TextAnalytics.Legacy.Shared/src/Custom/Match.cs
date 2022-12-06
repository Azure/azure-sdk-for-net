// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics.Legacy
{
    /// <summary> The Match. </summary>
    internal partial class Match
    {
        internal Match(double confidenceScore, string text, int offset, int length)
        {
            // We shipped TA 5.0.0 Text == string.Empty if the service returned a null value for Text.
            // Because we don't want to introduce a breaking change, we are transforming that null to string.Empty
            Text = text ?? string.Empty;

            ConfidenceScore = confidenceScore;
            Text = text;
            Offset = offset;
            Length = length;
        }
    }
}
