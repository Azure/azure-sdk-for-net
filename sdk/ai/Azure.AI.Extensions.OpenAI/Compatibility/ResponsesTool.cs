// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public abstract partial class ResponsesTool
{
    private protected ResponsesTool(ResponseToolKind kind) => Kind = kind;
    internal ResponsesTool() { }

    internal ResponseToolKind Kind { get; }
}
