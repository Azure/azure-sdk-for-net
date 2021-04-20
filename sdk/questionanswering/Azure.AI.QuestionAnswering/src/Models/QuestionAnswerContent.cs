// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.QuestionAnswering.Models
{
    public partial class QuestionAnswerContent
    {
        /// <summary>
        /// List of metadata associated with the answer.
        /// </summary>
        [CodeGenMember("Metadata")]
        internal IList<MetadataDTO> InternalMetadata { get; }

        /// <summary>
        /// Gets metadata associated with the answers.
        /// </summary>
        public IDictionary<string, string> Metadata { get; } // TODO: Convert between InternalMetadata and Metadata.
    }
}
