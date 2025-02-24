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
    /// <param name="type"></param>
    /// <returns></returns>
    public abstract Func<object>? GetActivator(Type type);

    object IActivatorFactory.CreateObject(Type type)
    {
        var activator = GetActivator(type);
        if (activator is null)
        {
            throw new InvalidOperationException($"No activator found for {type.Name}.");
        }
        return activator();
    }
}
