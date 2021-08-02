// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Models
{
    [CodeGenModel("KnowledgeBaseQueryOptions")]
    public partial class QueryKnowledgeBaseOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueryKnowledgeBaseOptions"/> class with the specified <paramref name="question"/>.
        /// </summary>
        /// <param name="question">The question to answer.</param>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> is null.</exception>
        public QueryKnowledgeBaseOptions(string question)
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));

            Question = question;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="QueryKnowledgeBaseOptions"/> class with an exact QnA ID.
        /// </summary>
        public QueryKnowledgeBaseOptions(int qnaId)
        {
            QnaId = qnaId;
        }

        private QueryKnowledgeBaseOptions()
        {
        }

        /// <summary>
        /// Exact QnA ID to fetch from the knowledgebase. This field takes priority over <see cref="Question"/>.
        /// </summary>
        public int? QnaId { get; }

        /// <summary>
        /// User question to query against the knowledge base.
        /// </summary>
        public string Question { get; }
    }
}
