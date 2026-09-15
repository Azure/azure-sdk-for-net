// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Specifies the operator used in a Bicep binary expression.
/// </summary>
public enum BinaryBicepOperator
{
    /// <summary>
    /// Emits the logical AND operator (<c>&amp;&amp;</c>).
    /// </summary>
    And,
    /// <summary>
    /// Emits the logical OR operator (<c>||</c>).
    /// </summary>
    Or,
    /// <summary>
    /// Emits the null-coalescing operator (<c>??</c>).
    /// </summary>
    Coalesce,
    /// <summary>
    /// Emits the case-sensitive equality operator (<c>==</c>).
    /// </summary>
    Equal,
    /// <summary>
    /// Emits the case-insensitive equality operator (<c>=~</c>).
    /// </summary>
    EqualIgnoreCase,
    /// <summary>
    /// Emits the case-sensitive inequality operator (<c>!=</c>).
    /// </summary>
    NotEqual,
    /// <summary>
    /// Emits the case-insensitive inequality operator (<c>!~</c>).
    /// </summary>
    NotEqualIgnoreCase,
    /// <summary>
    /// Emits the greater-than operator (<c>&gt;</c>).
    /// </summary>
    Greater,
    /// <summary>
    /// Emits the greater-than-or-equal operator (<c>&gt;=</c>).
    /// </summary>
    GreaterOrEqual,
    /// <summary>
    /// Emits the less-than operator (<c>&lt;</c>).
    /// </summary>
    Less,
    /// <summary>
    /// Emits the less-than-or-equal operator (<c>&lt;=</c>).
    /// </summary>
    LessOrEqual,
    /// <summary>
    /// Emits the addition operator (<c>+</c>).
    /// </summary>
    Add,
    /// <summary>
    /// Emits the subtraction operator (<c>-</c>).
    /// </summary>
    Subtract,
    /// <summary>
    /// Emits the multiplication operator (<c>*</c>).
    /// </summary>
    Multiply,
    /// <summary>
    /// Emits the division operator (<c>/</c>).
    /// </summary>
    Divide,
    /// <summary>
    /// Emits the modulo operator (<c>%</c>).
    /// </summary>
    Modulo
}
