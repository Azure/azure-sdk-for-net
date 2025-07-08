// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class RecordedVariableOptions
{
    private string? _sanitizedValue;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public RecordedVariableOptions IsSecret(SanitizedValue sanitizedValue = default)
    {
        _sanitizedValue = GetStringValue(sanitizedValue);
        return this;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public RecordedVariableOptions IsSecret(string sanitizedValue)
    {
        _sanitizedValue = sanitizedValue;
        return this;
    }

    private string GetStringValue(SanitizedValue sanitizedValue)
    {
        return sanitizedValue switch
        {
            SanitizedValue.Base64 => "Kg==",
            _ => throw new NotImplementedException() //RecordedTestBase.SanitizeValue,
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Apply(string value)
    {
        if (_sanitizedValue != null)
        {
            value = _sanitizedValue;
        }

        return value;
    }
}
