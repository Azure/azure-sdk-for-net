// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file contains type forwarding declarations for types that have
// been moved from the Azure.AI.Language.QuestionAnswering assembly
// into the Azure.AI.Language.QuestionAnswering.Inference assembly.
// Keeping these forwards preserves binary compatibility for existing
// consumers who compiled against the original locations.

using System.Runtime.CompilerServices;
using Azure.AI.Language.QuestionAnswering; // For nested types like ServiceVersion
using Microsoft.Extensions.Azure; // For QuestionAnsweringClientExtensions

// Forward core client and options types
[assembly: TypeForwardedTo(typeof(QuestionAnsweringClient))]
[assembly: TypeForwardedTo(typeof(QuestionAnsweringClientOptions))]
[assembly: TypeForwardedTo(typeof(QuestionAnsweringClientOptions.ServiceVersion))]

// Forward audience & project helpers
[assembly: TypeForwardedTo(typeof(QuestionAnsweringAudience))]
[assembly: TypeForwardedTo(typeof(QuestionAnsweringProject))]

// Forward model factory (public entry point). Generated backing factory maps via CodeGenType attribute.
[assembly: TypeForwardedTo(typeof(QuestionAnsweringModelFactory))]

// Forward query option/result models
[assembly: TypeForwardedTo(typeof(AnswersOptions))]
[assembly: TypeForwardedTo(typeof(AnswersFromTextOptions))]
[assembly: TypeForwardedTo(typeof(AnswersFromTextResult))]
[assembly: TypeForwardedTo(typeof(AnswersResult))]
[assembly: TypeForwardedTo(typeof(ShortAnswerOptions))]
[assembly: TypeForwardedTo(typeof(AnswerSpan))]
[assembly: TypeForwardedTo(typeof(KnowledgeBaseAnswer))]
[assembly: TypeForwardedTo(typeof(KnowledgeBaseAnswerContext))]
[assembly: TypeForwardedTo(typeof(KnowledgeBaseAnswerDialog))]
[assembly: TypeForwardedTo(typeof(KnowledgeBaseAnswerPrompt))]
[assembly: TypeForwardedTo(typeof(TextAnswer))]
[assembly: TypeForwardedTo(typeof(TextDocument))]

// Forward value-like structs / discriminators
[assembly: TypeForwardedTo(typeof(StringIndexType))]
[assembly: TypeForwardedTo(typeof(LogicalOperationKind))]
[assembly: TypeForwardedTo(typeof(RankerKind))]
[assembly: TypeForwardedTo(typeof(Scorer))]
[assembly: TypeForwardedTo(typeof(MatchingPolicy))]
[assembly: TypeForwardedTo(typeof(MatchingPolicyFieldsType))]

// Forward filtering / configuration models
[assembly: TypeForwardedTo(typeof(MetadataFilter))]
[assembly: TypeForwardedTo(typeof(MetadataRecord))]
[assembly: TypeForwardedTo(typeof(PrebuiltQueryMatchingPolicy))]
[assembly: TypeForwardedTo(typeof(QueryFilters))]
[assembly: TypeForwardedTo(typeof(QueryPreferences))]

// Forward extension methods container in Microsoft.Extensions.Azure
[assembly: TypeForwardedTo(typeof(QuestionAnsweringClientExtensions))]

