// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    public partial class AnswersOptions
    {
        /// <summary>
        /// Sets the <see cref="Question"/>.
        /// </summary>
        /// <param name="question">The question to ask of the knowledge base.</param>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> is null.</exception>
        internal AnswersOptions WithQuestion(string question)
        {
            Question = Argument.CheckNotNullOrEmpty(question, nameof(question));
            return this;
        }

        /// <summary>
        /// Sets the <see cref="QnaId"/>.
        /// </summary>
        /// <param name="qnaId">The exact QnA ID to fetch from the knowledge base.</param>
        internal AnswersOptions WithQnaId(int qnaId)
        {
            QnaId = qnaId;
            return this;
        }
    }
}
