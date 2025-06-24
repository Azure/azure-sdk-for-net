// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class RecordedVariableOptions
{
    private readonly Dictionary<string, string> _secretConnectionStringParameters = new Dictionary<string, string>();
    private string? _sanitizedValue;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public RecordedVariableOptions HasSecretConnectionStringParameter(string name, SanitizedValue sanitizedValue = default)
    {
        _secretConnectionStringParameters[name] = GetStringValue(sanitizedValue);
        return this;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    public RecordedVariableOptions HasSecretConnectionStringParameter(string name, string sanitizedValue)
    {
        _secretConnectionStringParameters[name] = sanitizedValue;
        return this;
    }

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

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="sanitizedValue"></param>
    /// <returns></returns>
    private string GetStringValue(SanitizedValue sanitizedValue)
    {
        return sanitizedValue switch
        {
            SanitizedValue.Base64 => "Kg==",
            _ => RecordedTestBase.SanitizeValue,
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Apply(string value)
    {
        if (_secretConnectionStringParameters.Any())
        {
            var parsed = ""; // TODO ConnectionString.Parse(value, allowEmptyValues: true);

            foreach (var connectionStringParameter in _secretConnectionStringParameters)
            {
                parsed.Replace(connectionStringParameter.Key, connectionStringParameter.Value);
            }

            value = parsed.ToString();
        }

        if (_sanitizedValue != null)
        {
            value = _sanitizedValue;
        }

        return value;
    }
}
