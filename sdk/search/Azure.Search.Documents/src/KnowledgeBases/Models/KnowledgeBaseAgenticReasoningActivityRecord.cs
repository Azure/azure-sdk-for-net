// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    public partial class KnowledgeBaseAgenticReasoningActivityRecord
    {
        /// <summary> The retrieval reasoning effort configuration. </summary>
        [Obsolete("This property is not returned by any service version this library targets.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KnowledgeRetrievalReasoningEffort RetrievalReasoningEffort { get; internal set; }
    }
}
