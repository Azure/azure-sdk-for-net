// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
#pragma warning disable SA1402 // File may only contain a single type

    [CodeGenModel("CustomEntitiesTaskParameters")]
    internal partial class CustomEntitiesTaskParameters { }

    [CodeGenModel("CustomMultiClassificationTaskParameters")]
    internal partial class CustomMultiClassificationTaskParameters { }

    [CodeGenModel("CustomSingleClassificationTaskParameters")]
    internal partial class CustomSingleClassificationTaskParameters { }

    [CodeGenModel("EntitiesTaskParameters")]
    internal partial class EntitiesTaskParameters { }

    [CodeGenModel("EntityLinkingTaskParameters")]
    internal partial class EntityLinkingTaskParameters { }

    [CodeGenModel("ExtractiveSummarizationTaskParameters")]
    internal partial class ExtractiveSummarizationTaskParameters { }

    [CodeGenModel("KeyPhrasesTaskParameters")]
    internal partial class KeyPhrasesTaskParameters { }

    [CodeGenModel("SentimentAnalysisTaskParameters")]
    internal partial class SentimentAnalysisTaskParameters { }

    [CodeGenModel("PiiCategory")]
    internal readonly partial struct PiiEntityLegacyCategory { }

#pragma warning restore SA1402 // File may only contain a single type
}
