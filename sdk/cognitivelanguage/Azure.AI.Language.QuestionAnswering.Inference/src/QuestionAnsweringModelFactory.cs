// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public static partial class QuestionAnsweringModelFactory
    {
        public static AnswersResult AnswersResult(IEnumerable<KnowledgeBaseAnswer> answers = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.AnswersResult(answers);

        public static KnowledgeBaseAnswer KnowledgeBaseAnswer(IEnumerable<string> questions = null, string answer = null, double? confidence = null, int? qnaId = null, string source = null, IReadOnlyDictionary<string, string> metadata = null, KnowledgeBaseAnswerDialog dialog = null, AnswerSpan shortAnswer = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswer(questions, answer, confidence, qnaId, source, metadata, dialog, shortAnswer);

        public static KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = null, IEnumerable<KnowledgeBaseAnswerPrompt> prompts = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswerDialog(isContextOnly, prompts);

        public static KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = null, int? qnaId = null, string displayText = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswerPrompt(displayOrder, qnaId, displayText);

        public static AnswerSpan AnswerSpan(string text = null, double? confidence = null, int? offset = null, int? length = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.AnswerSpan(text, confidence, offset, length);

        public static AnswersFromTextResult AnswersFromTextResult(IEnumerable<TextAnswer> answers = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.AnswersFromTextResult(answers);

        public static TextAnswer TextAnswer(string answer = null, double? confidence = null, string id = null, AnswerSpan shortAnswer = null, int? offset = null, int? length = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.TextAnswer(answer, confidence, id, shortAnswer, offset, length);

        public static KnowledgeBaseAnswerContext KnowledgeBaseAnswerContext(int previousQnaId = default, string previousQuestion = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.KnowledgeBaseAnswerContext(previousQnaId, previousQuestion);

        public static ShortAnswerOptions ShortAnswerOptions(bool enable = default, double? confidenceThreshold = null, int? top = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.ShortAnswerOptions(enable, confidenceThreshold, top);

        public static AnswersFromTextOptions AnswersFromTextOptions(string question = null, IEnumerable<TextDocument> textDocuments = null, string language = null, StringIndexType? stringIndexType = null) =>
            AILanguageQuestionAnsweringInferenceModelFactory.AnswersFromTextOptions(question, textDocuments, language, stringIndexType);
    }
}
