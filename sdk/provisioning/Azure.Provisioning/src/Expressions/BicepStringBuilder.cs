// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Azure.Provisioning.Utilities;

namespace Azure.Provisioning.Expressions;

// In addition to whether things are secure, also consider tracking
// dependencies across boundaries for automatic module splitting in
// the future

/// <summary>
/// Utility to construct complex interpolated Bicep strings.
/// </summary>
public class BicepStringBuilder
{
    private readonly List<BicepExpression> _expressions = [];
    private bool _isSecure = false;

    /// <summary>
    /// Append literal text.
    /// </summary>
    /// <param name="text">Literal text.</param>
    /// <returns>This BicepStringBuilder.</returns>
    public BicepStringBuilder Append(string text)
    {
        _expressions.Add(BicepSyntax.Value(text));
        return this;
    }

    /// <summary>
    /// Append a bicep expression.
    /// </summary>
    /// <param name="expression">Bicep expression.</param>
    /// <returns>This BicepStringBuilder.</returns>
    public BicepStringBuilder Append(BicepExpression expression)
    {
        _expressions.Add(expression);
        return this;
    }

    /// <summary>
    /// Append an interpolated string composed of literals, expressions,
    /// BicepValues, and ProvisioningParameters.
    /// </summary>
    /// <param name="handler">Bicep interpolated string builder.</param>
    /// <returns>This BicepStringBuilder.</returns>
    public BicepStringBuilder Append(BicepInterpolatedStringHandler handler)
    {
        _expressions.AddRange(handler._expressions);
        _isSecure = _isSecure || handler._isSecure;
        return this;
    }

    /// <summary>
    /// Combine all the subexpressions into a single interpolated string.
    /// </summary>
    /// <returns>The composed <see cref="BicepValue{String}"/> value.</returns>
    public BicepValue<string> Build()
    {
        BicepValue<string> value = new(new InterpolatedStringExpression([.. _expressions]));
        value._isSecure = _isSecure;
        return value;
    }

    /// <summary>
    /// Implicitly convert a builder to a <see cref="BicepValue{String}"/> so
    /// users aren't required to explicitly call <see cref="Build"/>.
    /// </summary>
    /// <param name="value">The builder.</param>
    public static implicit operator BicepValue<string>(BicepStringBuilder value) =>
        value.Build();
}

/// <summary>
/// Interpolated string handler for building interpolated Bicep string
/// expressions.  This is an implementation detail for the C# compiler.  Users
/// should prefer either <see cref="BicepFunction.Interpolate"/> or
/// <see cref="BicepStringBuilder"/> for constructing interpolated strings.
/// </summary>
/// <param name="literalLength">Combined length of all literal segments.</param>
/// <param name="formattedCount">Number of formatted segments.</param>
[InterpolatedStringHandler]
#pragma warning disable CS9113 // Parameter is unread - literalLength is required for compiler pattern
public ref struct BicepInterpolatedStringHandler(int literalLength, int formattedCount)
#pragma warning restore CS9113 // Parameter is unread.
{
    internal readonly List<BicepExpression> _expressions = new(capacity: 2 * formattedCount + 1);
    internal bool _isSecure = false;

    public void AppendLiteral(string text) =>
        _expressions.Add(BicepSyntax.Value(text));

    public void AppendFormatted<T>(T t)
    {
        if (t is ProvisioningVariable v)
        {
            _expressions.Add(BicepSyntax.Var(v.BicepIdentifier));
            _isSecure = _isSecure || ((IBicepValue)v.Value).IsSecure;
        }
        else if (t is IBicepValue b)
        {
            _expressions.Add(b.Compile());
            _isSecure = _isSecure || b.IsSecure;
        }
        else if (t is BicepExpression exp)
        {
            _expressions.Add(exp);
        }
        else if (t is FormattableString formattable)
        {
            AppendFormattableString(formattable);
        }
        else
        {
            string? s = t?.ToString();
            if (s is not null)
            {
                _expressions.Add(BicepSyntax.Value(s));
            }
        }
    }

    internal void AppendFormattableString(FormattableString value)
    {
        var formatSpan = value.Format.AsSpan();
        foreach (var (span, isLiteral, index) in FormattableStringHelpers.GetFormattableStringFormatParts(formatSpan))
        {
            if (isLiteral)
            {
                AppendLiteral(span.ToString());
            }
            else
            {
                // this is not a literal therefore an argument
                AppendFormatted(value.GetArgument(index));
            }
        }
    }

    internal readonly BicepValue<string> Build()
    {
        BicepValue<string> value = new(new InterpolatedStringExpression([.. _expressions]));
        value._isSecure = _isSecure;
        return value;
    }

    public static implicit operator BicepInterpolatedStringHandler(FormattableString formattable)
    {
        var handler = new BicepInterpolatedStringHandler(formattable.Format.Length, formattable.ArgumentCount);
        handler.AppendFormattableString(formattable);
        return handler;
    }
}
