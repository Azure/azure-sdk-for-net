// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
}
