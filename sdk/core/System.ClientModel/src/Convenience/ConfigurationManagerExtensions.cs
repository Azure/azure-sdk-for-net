// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel;

/// <summary>
/// .
/// </summary>
public static class ConfigurationManagerExtensions
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="sectionName"></param>
    /// <returns></returns>
    public static ClientConnection GetConnection(this IConfigurationManager configuration, string sectionName)
        => configuration.GetSection(sectionName).GetConnection();

    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    /// <returns></returns>
    public static ClientConnection GetConnection(this IConfigurationSection section)
    {
        var credential = CreateCredentials(section);
        return new ClientConnection(section.Key, section["Endpoint"], credential.Credential, credential.Kind, section);
    }

    internal static (object? Credential, CredentialKind Kind) CreateCredentials(IConfigurationSection section)
    {
        CredentialKind credentialKind;
        object? credential = default;
        if (section["Credential:CredentialSource"] is null)
        {
            credentialKind = CredentialKind.None;
        }
        else if (section["Credential:CredentialSource"]!.Equals("ApiKey", StringComparison.Ordinal))
        {
            credentialKind = CredentialKind.ApiKeyString;
            credential = section["Credential:Key"];
        }
        else
        {
            throw new Exception($"Unsupported credential source '{section["Credential:CredentialSource"]}'.");
        }

        return (credential, credentialKind);
    }
}
