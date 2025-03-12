// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

internal class ReflectionContext : ModelReaderWriterContext
{
    private Dictionary<Type, ModelBuilder>? _modelInfos;
    private Dictionary<Type, ModelBuilder> ModelInfos => _modelInfos ??= [];

    public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
    {
        if (ModelInfos.TryGetValue(type, out modelInfo))
        {
            return true;
        }

        modelInfo = new ReflectionModelInfo(type);
        ModelInfos[type] = modelInfo;

        return true;
    }
}
