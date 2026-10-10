// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.QuestionAnswering.Inference;

/// <summary>
/// Renames the generated <c>Scorer</c> model to <see cref="QuestionAnsweringScorer"/> so the
/// public name identifies the service it belongs to (AZC0012).
/// </summary>
[CodeGenType("Scorer")]
public readonly partial struct QuestionAnsweringScorer { }
