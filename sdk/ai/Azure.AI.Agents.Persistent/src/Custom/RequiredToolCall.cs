// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
public abstract partial class RequiredToolCall : RequiredAction { }
