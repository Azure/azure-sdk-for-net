// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SemanticPrioritizedFields
    {
        /// <summary> Defines the content fields to be used for semantic ranking, captions, highlights, and answers.
        /// <para> For the best result, the selected fields should contain text in natural language form. The order of the fields in the array represents their priority.
        /// Fields with lower priority may get truncated if the content is long.</para>
        /// </summary>
        [CodeGenMember("PrioritizedContentFields")]
        public IList<SemanticField> ContentFields { get; }

        /// <summary> Defines the keyword fields to be used for semantic ranking, captions, highlights, and answers.
        /// <para> For the best result, the selected fields should contain a list of keywords. The order of the fields in the array represents their priority.
        /// Fields with lower priority may get truncated if the content is long. </para>
        /// </summary>
        [CodeGenMember("PrioritizedKeywordsFields")]
        public IList<SemanticField> KeywordsFields { get; }
    }
}
