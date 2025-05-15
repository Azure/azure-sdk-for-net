// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.SourceGeneration;

internal enum TypeBuilderKind
{
    IPersistableModel,
    IList,
    IDictionary,
    Array,
    MultiDimensionalArray,
    ReadOnlyMemory,
    Unknown,
}
