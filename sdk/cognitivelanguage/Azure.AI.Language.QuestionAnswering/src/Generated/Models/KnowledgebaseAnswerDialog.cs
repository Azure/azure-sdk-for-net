// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Models
{
    /// <summary> Dialog associated with Answer. </summary>
    public partial class KnowledgebaseAnswerDialog
    {
        /// <summary> Initializes a new instance of KnowledgebaseAnswerDialog. </summary>
        internal KnowledgebaseAnswerDialog()
        {
            Prompts = new ChangeTrackingList<KnowledgebaseAnswerPrompt>();
        }

        /// <summary> Initializes a new instance of KnowledgebaseAnswerDialog. </summary>
        /// <param name="isContextOnly"> To mark if a prompt is relevant only with a previous question or not. If true, do not include this QnA as search result for queries without context; otherwise, if false, ignores context and includes this QnA in search result. </param>
        /// <param name="prompts"> List of 0 to 20 prompts associated with the answer. </param>
        internal KnowledgebaseAnswerDialog(bool? isContextOnly, IReadOnlyList<KnowledgebaseAnswerPrompt> prompts)
        {
            IsContextOnly = isContextOnly;
            Prompts = prompts;
        }

        /// <summary> To mark if a prompt is relevant only with a previous question or not. If true, do not include this QnA as search result for queries without context; otherwise, if false, ignores context and includes this QnA in search result. </summary>
        public bool? IsContextOnly { get; }
        /// <summary> List of 0 to 20 prompts associated with the answer. </summary>
        public IReadOnlyList<KnowledgebaseAnswerPrompt> Prompts { get; }
    }
}
