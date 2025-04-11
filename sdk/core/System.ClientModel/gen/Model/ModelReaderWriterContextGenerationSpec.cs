// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.SourceGeneration;

internal sealed record ModelReaderWriterContextGenerationSpec
{
    required public TypeRef Type { get; init; }
    required public string Modifier { get; init; }
    required public ImmutableEquatableArray<TypeBuilderSpec> TypeBuilders { get; init; }
    required public ImmutableEquatableArray<TypeRef> ReferencedContexts { get; init; }

    public IEnumerable<TypeRef> GetAllTypeRefs()
    {
        foreach (var typeRef in ReferencedContexts)
        {
            yield return typeRef;
        }

        foreach (var typeBuilder in TypeBuilders)
        {
            yield return typeBuilder.Type;
        }
    }
}
