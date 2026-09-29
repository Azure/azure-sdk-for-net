// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.AI.ContentUnderstanding.Tests
{
    internal sealed class ContentUnderstandingModelProfile
    {
        public ContentUnderstandingModelProfile(
            string completionModel,
            string? completionDeployment,
            string miniCompletionModel,
            string? miniCompletionDeployment,
            string embeddingModel,
            string? embeddingDeployment,
            bool includesPrebuiltAliases)
        {
            CompletionModel = completionModel;
            CompletionDeployment = completionDeployment;
            MiniCompletionModel = miniCompletionModel;
            MiniCompletionDeployment = miniCompletionDeployment;
            EmbeddingModel = embeddingModel;
            EmbeddingDeployment = embeddingDeployment;
            IncludesPrebuiltAliases = includesPrebuiltAliases;
        }

        public string CompletionModel { get; }

        public string? CompletionDeployment { get; }

        public string MiniCompletionModel { get; }

        public string? MiniCompletionDeployment { get; }

        public string EmbeddingModel { get; }

        public string? EmbeddingDeployment { get; }

        public bool IncludesPrebuiltAliases { get; }

        public bool IsConfigured =>
            !string.IsNullOrEmpty(CompletionDeployment) &&
            !string.IsNullOrEmpty(MiniCompletionDeployment) &&
            !string.IsNullOrEmpty(EmbeddingDeployment);

        public IDictionary<string, string> GetDefaultModelDeployments()
        {
            if (!IsConfigured)
            {
                throw new InvalidOperationException("Model deployments must be configured before creating defaults.");
            }

            var deployments = new Dictionary<string, string>
            {
                [CompletionModel] = CompletionDeployment!
            };

            if (!string.Equals(MiniCompletionModel, CompletionModel, StringComparison.Ordinal))
            {
                deployments[MiniCompletionModel] = MiniCompletionDeployment!;
            }
            else if (!string.Equals(MiniCompletionDeployment, CompletionDeployment, StringComparison.Ordinal))
            {
                throw new InvalidOperationException(
                    $"Completion and mini completion share model name '{CompletionModel}' but have different deployments " +
                    $"('{CompletionDeployment}' vs '{MiniCompletionDeployment}'). Use distinct model names or the same deployment.");
            }

            deployments[EmbeddingModel] = EmbeddingDeployment!;

            if (IncludesPrebuiltAliases)
            {
                deployments["prebuilt-analyzer-completion"] = CompletionDeployment!;
                deployments["prebuilt-analyzer-completion-mini"] = MiniCompletionDeployment!;
                deployments["prebuilt-analyzer-embedding"] = EmbeddingDeployment!;
            }

            return deployments;
        }
    }
}
