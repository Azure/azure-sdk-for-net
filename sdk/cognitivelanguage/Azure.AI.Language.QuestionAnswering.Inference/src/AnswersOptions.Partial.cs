// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    /// <summary>
    /// Client-specific helpers for <see cref="AnswersOptions"/>.
    /// </summary>
    public partial class AnswersOptions
    {
        /// <summary>
        /// Sets the question to ask of the knowledge base.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <returns>The updated <see cref="AnswersOptions"/> instance.</returns>
        internal AnswersOptions WithQuestion(string question)
        {
            Question = Argument.CheckNotNullOrEmpty(question, nameof(question));
            return this;
        }

        /// <summary>
        /// Sets the exact QnA identifier to fetch from the knowledge base.
        /// </summary>
        /// <param name="qnaId">The QnA identifier.</param>
        /// <returns>The updated <see cref="AnswersOptions"/> instance.</returns>
        internal AnswersOptions WithQnaId(int qnaId)
        {
            QnaId = qnaId;
            return this;
        }

        /// <summary>
        /// Gets or sets the maximum number of answers to return.
        /// </summary>
        public int? Size
        {
            get => Top;
            set => Top = value;
        }
    }
}
