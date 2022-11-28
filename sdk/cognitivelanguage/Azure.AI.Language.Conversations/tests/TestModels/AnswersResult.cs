// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents List of Question Answers. </summary>
    public partial class AnswersResult
    {
        /// <summary> Initializes a new instance of AnswersResult. </summary>
        internal AnswersResult()
        {
            Answers = new ChangeTrackingList<KnowledgeBaseAnswer>();
        }

        /// <summary> Initializes a new instance of AnswersResult. </summary>
        /// <param name="answers"> Represents Answer Result list. </param>
        internal AnswersResult(IReadOnlyList<KnowledgeBaseAnswer> answers)
        {
            Answers = answers;
        }

        /// <summary> Represents Answer Result list. </summary>
        public IReadOnlyList<KnowledgeBaseAnswer> Answers { get; }
    }
}
