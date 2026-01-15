// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    [CodeGenType("LanguageQuestionAnsweringInferenceModelFactory")]
    public static partial class QuestionAnsweringModelFactory
    {
        /// <summary> Represents List of Question Answers. </summary>
        /// <param name="answers"> Represents Answer Result list. </param>
        /// <returns> A new <see cref="AnswersResult"/> instance for mocking. </returns>
        public static AnswersResult AnswersResult(IEnumerable<KnowledgeBaseAnswer> answers = default)
            => LanguageQuestionAnsweringInferenceModelFactory.AnswersResult(answers);

        /// <summary> Represents knowledge base answer. </summary>
        /// <param name="questions"> List of questions associated with the answer. </param>
        /// <param name="answer"> Answer text. </param>
        /// <param name="confidence"> Answer confidence score, value ranges from 0 to 1. </param>
        /// <param name="qnaId"> ID of the QnA result. </param>
        /// <param name="source"> Source of QnA result. </param>
        /// <param name="metadata"> Metadata associated with the answer. </param>
        /// <param name="dialog"> Dialog associated with Answer. </param>
        /// <param name="shortAnswer"> Answer span object of QnA with respect to user's question. </param>
        /// <returns> A new <see cref="KnowledgeBaseAnswer"/> instance for mocking. </returns>
        public static KnowledgeBaseAnswer KnowledgeBaseAnswer(
            IEnumerable<string> questions = default,
            string answer = default,
            double? confidence = default,
            int? qnaId = default,
            string source = default,
            IDictionary<string, string> metadata = default,
            KnowledgeBaseAnswerDialog dialog = default,
            AnswerSpan shortAnswer = default)
            => LanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswer(questions, answer, confidence, qnaId, source, metadata, dialog, shortAnswer);

        /// <summary> Represents the answer results. </summary>
        /// <param name="answers"> Represents the answer results. </param>
        /// <returns> A new <see cref="AnswersFromTextResult"/> instance for mocking. </returns>
        public static AnswersFromTextResult AnswersFromTextResult(IEnumerable<TextAnswer> answers = default)
            => LanguageQuestionAnsweringInferenceModelFactory.AnswersFromTextResult(answers);

        /// <summary> Represents answer result. </summary>
        /// <param name="answer"> Answer. </param>
        /// <param name="confidence"> answer confidence score, value ranges from 0 to 1. </param>
        /// <param name="id"> record ID. </param>
        /// <param name="shortAnswer"> Answer span object with respect to user's question. </param>
        /// <param name="offset"> The sentence offset from the start of the document. </param>
        /// <param name="length"> The length of the sentence. </param>
        /// <returns> A new <see cref="TextAnswer"/> instance for mocking. </returns>
        public static TextAnswer TextAnswer(
            string answer = default,
            double? confidence = default,
            string id = default,
            AnswerSpan shortAnswer = default,
            int? offset = default,
            int? length = default)
            => LanguageQuestionAnsweringInferenceModelFactory.TextAnswer(answer, confidence, id, shortAnswer, offset, length);

        /// <summary> Answer span object of QnA. </summary>
        /// <param name="text"> Predicted text of answer span. </param>
        /// <param name="confidence"> Predicted score of answer span, value ranges from 0 to 1. </param>
        /// <param name="offset"> The answer span offset from the start of answer. </param>
        /// <param name="length"> The length of the answer span. </param>
        /// <returns> A new <see cref="AnswerSpan"/> instance for mocking. </returns>
        public static AnswerSpan AnswerSpan(
            string text = default,
            double? confidence = default,
            int? offset = default,
            int? length = default)
            => LanguageQuestionAnsweringInferenceModelFactory.AnswerSpan(text, confidence, offset, length);

        /// <summary> Dialog associated with Answer. </summary>
        /// <param name="isContextOnly"> To mark if a prompt is relevant only with a previous question or not. </param>
        /// <param name="prompts"> List of prompts associated with the answer. </param>
        /// <returns> A new <see cref="KnowledgeBaseAnswerDialog"/> instance for mocking. </returns>
        public static KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(
            bool? isContextOnly = default,
            IEnumerable<KnowledgeBaseAnswerPrompt> prompts = default)
            => LanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswerDialog(isContextOnly, prompts);

        /// <summary> Prompt for an answer. </summary>
        /// <param name="displayOrder"> Index of the prompt - used in ordering of the prompts. </param>
        /// <param name="id"> QnA ID corresponding to the prompt. </param>
        /// <param name="displayText"> Text displayed to represent a follow up question prompt. </param>
        /// <returns> A new <see cref="KnowledgeBaseAnswerPrompt"/> instance for mocking. </returns>
        public static KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(
            int? displayOrder = default,
            int? id = default,
            string displayText = default)
            => LanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswerPrompt(displayOrder, id, displayText);
    }
}
