// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.SourceGeneration;

internal sealed record TypeBuilderSpec
{
    required public TypeRef Type { get; init; }
    required public string Modifier { get; init; }
    required public TypeBuilderKind Kind { get; init; }
    required public TypeRef? PersistableModelProxy { get; init; }
    required public TypeRef ContextType { get; init; }
}
