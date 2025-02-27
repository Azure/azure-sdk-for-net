// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Context for <see cref="ModelReaderWriter"/> to work with AOT.
/// </summary>
public abstract class ModelReaderWriterContext : IActivatorFactory
{
    /// <summary>
    /// Gets a factory method to construct a type for deserialization.
    /// </summary>
    /// <param name="type">The type to activate.</param>
    /// <returns></returns>
    public abstract ModelInfo? GetModelInfo(Type type);

    ModelInfo IActivatorFactory.GetModelInfo(Type type)
    {
        var modelInfo = GetModelInfo(type);
        if (modelInfo is null)
        {
            throw new InvalidOperationException($"No model info found for {type.Name}.");
        }
        return modelInfo;
    }
}
