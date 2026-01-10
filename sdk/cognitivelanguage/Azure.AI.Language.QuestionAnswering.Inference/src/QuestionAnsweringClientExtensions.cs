// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.AI.Language.QuestionAnswering.Inference;
using Azure.Core;
using Azure.Core.Extensions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="QuestionAnsweringClient"/> to client builder. </summary>
    [CodeGenType("LanguageQuestionAnsweringInferenceClientBuilderExtensions")]
    public static partial class QuestionAnsweringClientExtensions
    {
    }
}
