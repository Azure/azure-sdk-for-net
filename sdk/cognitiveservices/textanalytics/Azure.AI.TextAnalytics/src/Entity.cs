// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct Entity
    {
        /// <summary>
        /// Entity text as appears in the request.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets entity type from Named Entity Recognition model.
        /// Entity type, such as Person/Location/Org/SSN etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets entity sub type from Named Entity Recognition model.
        /// Entity sub type, such as Age/Year/TimeRange etc.
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Gets or sets start position (in Unicode characters) for the entity
        /// match text.
        /// Start position (in Unicode characters) for the entity text.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets length (in Unicode characters) for the entity match
        /// text.
        /// Length (in Unicode characters) for the entity text.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets (optional) If an entity type is recognized, a decimal
        /// number denoting the confidence level of the entity type will be
        /// returned.
        /// Confidence score between 0 and 1 of the extracted entity.
        /// </summary>
        public double Score { get; set; }
    }
}
