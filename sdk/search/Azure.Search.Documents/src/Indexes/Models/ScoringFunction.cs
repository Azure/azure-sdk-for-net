// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class ScoringFunction
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ScoringFunction"/> class.
        /// </summary>
        /// <param name="fieldName">The name of the field used as input to the scoring function.</param>
        /// <param name="boost">A multiplier for the raw score. Must be a positive number not equal to 1.0.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        private protected ScoringFunction(string fieldName, double boost)
        {
            FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            Boost = boost;
        }
    }
}
