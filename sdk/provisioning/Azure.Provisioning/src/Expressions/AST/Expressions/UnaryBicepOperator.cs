// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Specifies the operator used in a Bicep unary expression.
/// </summary>
public enum UnaryBicepOperator
{
    /// <summary>
    /// Emits the logical NOT operator (<c>!</c>).
    /// </summary>
    Not,
    /// <summary>
    /// Emits the arithmetic negation operator (<c>-</c>).
    /// </summary>
    Negate,
    /// <summary>
    /// Emits the non-null assertion operator (postfix <c>!</c>).
    /// </summary>
    SuppressNull
}
