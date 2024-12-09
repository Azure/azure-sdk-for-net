// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning;

/// <summary>
/// Gets the kind of a <see cref="IBicepValue"/>.
/// </summary>
public enum BicepValueKind
{
    /// <summary>
    /// The value has not been set.
    /// </summary>
    Unset,

    /// <summary>
    /// The value has been set to a literal .NET object.
    /// </summary>
    Literal,

    /// <summary>
    /// The value has been set to a Bicep expression.
    /// </summary>
    Expression
}
