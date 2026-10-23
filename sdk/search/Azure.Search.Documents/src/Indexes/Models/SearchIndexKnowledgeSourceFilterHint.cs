// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexKnowledgeSourceFilterHint
    {
        /// <summary> Initializes a filter hint with explicit grounding values. </summary>
        /// <param name="field"> The filterable field name. </param>
        /// <param name="fieldValues"> The exhaustive set of grounding values. </param>
        public SearchIndexKnowledgeSourceFilterHint(string field, IEnumerable<string> fieldValues) : this(field)
        {
            Argument.AssertNotNull(fieldValues, nameof(fieldValues));
            foreach (string value in fieldValues)
            {
                FieldValues.Add(value);
            }
        }
    }
}
