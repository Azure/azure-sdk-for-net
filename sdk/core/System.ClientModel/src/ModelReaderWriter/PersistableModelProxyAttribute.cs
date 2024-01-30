// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// Attribute that indicates a proxy <see cref="Type"/> to use for reading a model.
/// The proxy <see cref="Type"/> must implement <see cref="IPersistableModel{T}"/> and have a public or non-public parameterless constructor.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class PersistableModelProxyAttribute : Attribute
{
    /// <summary>
    /// Instantiates a new instance of the <see cref="PersistableModelProxyAttribute"/> class.
    /// </summary>
    /// <param name="proxyType">
    /// The <see cref="Type"/> to create and call read on.
    /// The <see cref="Type"/> must have a public or non-public parameterless constructor.
    /// The <see cref="Type"/> must implement <see cref="IPersistableModel{T}"/> where T is the type of the abstract class.
    /// </param>
    public PersistableModelProxyAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type proxyType)
    {
        ProxyType = proxyType;
    }

    /// <summary>
    /// Gets the <see cref="Type"/> to create and call read on.
    /// The <see cref="Type"/> must have a public or non-public parameterless constructor.
    /// The <see cref="Type"/> must implement <see cref="IPersistableModel{T}"/> where T is the type of the abstract class.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    public Type ProxyType { get; }
}
