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
    private static readonly HashSet<string> FirstClassProperties = new() { "CredentialSource", "Key", "KEY", "Endpoint" };

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
        Dictionary<string, string>? metadata = null;
        foreach (var child in section.GetChildren())
        {
            if (!FirstClassProperties.Contains(child.Key) && !string.IsNullOrEmpty(child.Value))
            {
                metadata ??= new Dictionary<string, string>();
                metadata[child.Key] = child.Value!;
            }
        }
        return new ClientConnection(section.Key, section["Endpoint"] ?? "$auto", credential.Credential, credential.Kind, metadata, section);
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
