// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Options for configuring how recorded test variables are handled during test recording and playback.
/// </summary>
public class RecordedVariableOptions
{
    private string? _sanitizedValue;

    /// <summary>
    /// Marks the variable as a secret that should be sanitized during recording.
    /// </summary>
    /// <param name="sanitizedValue">The type of sanitized value to use.</param>
    /// <returns>The current options instance for method chaining.</returns>
    public RecordedVariableOptions IsSecret(SanitizedValue sanitizedValue = default)
    {
        _sanitizedValue = GetStringValue(sanitizedValue);
        return this;
    }

    /// <summary>
    /// Marks the variable as a secret with a custom sanitized value.
    /// </summary>
    /// <param name="sanitizedValue">The custom value to use when sanitizing.</param>
    /// <returns>The current options instance for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="sanitizedValue"/> is null.</exception>
    public RecordedVariableOptions IsSecret(string sanitizedValue)
    {
        if (sanitizedValue == null)
            throw new ArgumentNullException(nameof(sanitizedValue));

        _sanitizedValue = sanitizedValue;
        return this;
    }

    private string GetStringValue(SanitizedValue sanitizedValue)
    {
        return sanitizedValue switch
        {
            SanitizedValue.Base64 => "Kg==",
            _ => RecordedTestBase.SanitizeValue,
        };
    }

    /// <summary>
    /// Applies the configured options to the given value.
    /// </summary>
    /// <param name="value">The original value to process.</param>
    /// <returns>The processed value, sanitized if configured as a secret.</returns>
    public string Apply(string value)
    {
        if (_sanitizedValue != null)
        {
            value = _sanitizedValue;
        }

        return value;
    }
}
