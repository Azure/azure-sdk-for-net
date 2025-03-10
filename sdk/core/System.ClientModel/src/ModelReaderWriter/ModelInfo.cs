// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to create objects without needing reflection.
/// </summary>
public abstract class ModelInfo
{
    /// <summary>
    /// Creates an object of the type associated with this ModelInfo.
    /// </summary>
    public abstract object CreateObject();

    /// <summary>
    /// Gets an <see cref="IEnumerable"/> representation of the object.
    /// </summary>
    /// <returns>An <see cref="IEnumerable"/> representation if its a collection otherwise null.</returns>
    public virtual IEnumerable? GetEnumerable(object obj) => null;
}
