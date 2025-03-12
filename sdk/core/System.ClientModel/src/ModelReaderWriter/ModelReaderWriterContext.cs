// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// Context for <see cref="ModelReaderWriter"/> to work with AOT.
/// </summary>
public abstract class ModelReaderWriterContext
{
    /// <summary>
    /// Gets a <see cref="ModelBuilder"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <exception cref="InvalidOperationException">When the context does not contain a <see cref="ModelBuilder"/> for the given <see cref="Type"/>.</exception>
    public ModelBuilder GetModelBuilder(Type type)
    {
        if (!TryGetModelBuilder(type, out ModelBuilder? builder))
        {
            throw new InvalidOperationException($"No model info found for {type.Name}.");
        }
        return builder;
    }

    /// <summary>
    /// Tries to gets a <see cref="ModelBuilder"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <param name="builder">The <see cref="ModelBuilder"/> if found.</param>
    /// <returns>True if the corresponding <see cref="ModelBuilder"/> if defined in the context otherwise false.</returns>
    public virtual bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
    {
        builder = null;
        return false;
    }
}
