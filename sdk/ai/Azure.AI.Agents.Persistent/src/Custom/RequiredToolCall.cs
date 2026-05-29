// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.AI.Agents.Persistent;

/// <summary>
/// An abstract, base representation for a tool call that an Agents API run requires outputs
/// from in order to continue.
/// </summary>
/// <remarks>
/// <see cref="RequiredToolCall"/> is the abstract base type for all required tool calls. Its
/// concrete type can be one of:
/// <list type="bullet">
/// <item> <see cref="RequiredFunctionToolCall"/> </item>
/// </list>
/// </remarks>
[CodeGenSuppress("RequiredToolCall", typeof(string))]
public abstract partial class RequiredToolCall : RequiredAction
{
    // Backward-compat: old contract had protected RequiredToolCall(string id)
    protected RequiredToolCall(string id) : base((string)null)
    {
        Id = id;
    }
}
