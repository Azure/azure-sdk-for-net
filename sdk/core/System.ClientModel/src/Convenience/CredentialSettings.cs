// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel;

/// <summary>
/// .
/// </summary>
public class CredentialSettings
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    public CredentialSettings(IConfigurationSection section)
    {
        if (section is null)
            throw new ArgumentNullException(nameof(section));

        CredentialSource = section["CredentialSource"];
        Key = section["Key"];
    }

    /// <summary>
    /// .
    /// </summary>
    public string? CredentialSource { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public string? Key { get; set; }
}
