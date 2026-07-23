// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenSuppress(nameof(OutputItemFunctionToolCallOutput), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ItemFieldFunctionToolCallOutputStatus?))]
public static partial class ExtensionsOpenAIModelFactory
{
}
