// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Evaluator IDs for built-in evaluators.
    /// </summary>
    public static class EvaluatorIDs
    {
        public const string Relevance = "azureai://built-in/evaluators/relevance";
        public const string HateUnfairness = "azureai://built-in/evaluators/hate_unfairness";
        public const string Violence = "azureai://built-in/evaluators/violence";
        public const string Groundedness = "azureai://built-in/evaluators/groundedness";
        public const string GroundednessPro = "azureai://built-in/evaluators/groundedness_pro";
        public const string BleuScore = "azureai://built-in/evaluators/bleu_score";
        public const string CodeVulnerability = "azureai://built-in/evaluators/code_vulnerability";
        public const string Coherence = "azureai://built-in/evaluators/coherence";
        public const string ContentSafety = "azureai://built-in/evaluators/content_safety";
        public const string DocumentRetrieval = "azureai://built-in/evaluators/document_retrieval";
        public const string F1Score = "azureai://built-in/evaluators/f1_score";
        public const string Fluency = "azureai://built-in/evaluators/fluency";
        public const string GleuScore = "azureai://built-in/evaluators/gleu_score";
        public const string IndirectAttack = "azureai://built-in/evaluators/indirect_attack";
        public const string IntentResolution = "azureai://built-in/evaluators/intent_resolution";
        public const string MeteorScore = "azureai://built-in/evaluators/meteor_score";
        public const string ProtectedMaterial = "azureai://built-in/evaluators/protected_material";
        public const string QA = "azureai://built-in/evaluators/qa";
        public const string Retrieval = "azureai://built-in/evaluators/retrieval";
        public const string RougeScore = "azureai://built-in/evaluators/rouge_score";
        public const string SelfHarm = "azureai://built-in/evaluators/self_harm";
        public const string Sexual = "azureai://built-in/evaluators/sexual";
        public const string SimilarityScore = "azureai://built-in/evaluators/similarity_score";
        public const string TaskAdherence = "azureai://built-in/evaluators/task_adherence";
        public const string ToolCallAccuracy = "azureai://built-in/evaluators/tool_call_accuracy";
        public const string UngroundedAttributes = "azureai://built-in/evaluators/ungrounded_attributes";
        public const string ResponseCompleteness = "azureai://built-in/evaluators/response_completeness";

        // AOAI Graders
        public const string LabelGrader = "azureai://built-in/evaluators/label_grader";
        public const string StringCheckGrader = "azureai://built-in/evaluators/string_check_grader";
        public const string TextSimilarityGrader = "azureai://built-in/evaluators/text_similarity_grader";
    }
}
