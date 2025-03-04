// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Context for <see cref="ModelReaderWriter"/> to work with AOT.
/// </summary>
public abstract class ModelReaderWriterContext
{
    /// <summary>
    /// Gets a <see cref="ModelInfo"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <exception cref="InvalidOperationException">When the context does not contain a <see cref="ModelInfo"/> for the given <see cref="Type"/>.</exception>
    internal ModelInfo GetModelInfoInternal(Type type)
    {
        var modelInfo = GetModelInfo(type);
        if (modelInfo is null)
        {
            throw new InvalidOperationException($"No model info found for {type.Name}.");
        }
        return modelInfo;
    }

    /// <summary>
    /// Gets a <see cref="ModelInfo"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <returns>The corresponding <see cref="ModelInfo"/> if defined in the context otherwise null.</returns>
    public abstract ModelInfo? GetModelInfo(Type type);
}
