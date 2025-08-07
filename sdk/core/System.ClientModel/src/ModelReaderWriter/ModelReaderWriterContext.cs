// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// Context for <see cref="ModelReaderWriter"/> to work with AOT.
/// </summary>
public abstract class ModelReaderWriterContext
{
    /// <summary>
    /// Gets a <see cref="ModelReaderWriterTypeBuilder"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <exception cref="InvalidOperationException">When the context does not contain a <see cref="ModelReaderWriterTypeBuilder"/> for the given <see cref="Type"/>.</exception>
    public ModelReaderWriterTypeBuilder GetTypeBuilder(Type type)
    {
        if (!TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder? builder))
        {
            throw new InvalidOperationException($"No {nameof(ModelReaderWriterTypeBuilder)} found for {type.ToFriendlyName()}.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info.");
        }
        return builder!;
    }

    /// <summary>
    /// Tries to gets a <see cref="ModelReaderWriterTypeBuilder"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <param name="builder">The <see cref="ModelReaderWriterTypeBuilder"/> if found.</param>
    /// <returns>True if the corresponding <see cref="ModelReaderWriterTypeBuilder"/> if defined in the context otherwise false.</returns>
    public bool TryGetTypeBuilder(Type type, [NotNullWhen(true)] out ModelReaderWriterTypeBuilder? builder)
    {
        if (TryGetTypeBuilderCore(type, out builder) && builder is not null)
        {
            builder.Context = this;
            return true;
        }

        builder = null;
        return false;
    }

    /// <summary>
    /// Tries to gets a <see cref="ModelReaderWriterTypeBuilder"/> for the given <see cref="Type"/> to allow <see cref="ModelReaderWriter"/> to work with AOT.
    /// </summary>
    /// <param name="type">The type to get info for.</param>
    /// <param name="builder">The <see cref="ModelReaderWriterTypeBuilder"/> if found.</param>
    /// <returns>True if the corresponding <see cref="ModelReaderWriterTypeBuilder"/> if defined in the context otherwise false.</returns>
    protected virtual bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
    {
        builder = null;
        return false;
    }
}
