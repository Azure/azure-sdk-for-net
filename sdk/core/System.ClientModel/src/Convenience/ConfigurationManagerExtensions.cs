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
    /// <typeparam name="T"></typeparam>
    /// <param name="configuration"></param>
    /// <param name="sectionName"></param>
    /// <returns></returns>
    public static T GetClientSettings<T>(this IConfiguration configuration, string sectionName)
        where T : ClientSettingsBase, new()
        => configuration.GetSection(sectionName).GetClientSettings<T>();

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="section"></param>
    /// <returns></returns>
    public static T GetClientSettings<T>(this IConfigurationSection section)
        where T : ClientSettingsBase, new()
    {
        T t = new();
        t.Read(section);
        return t;
    }

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
    /// <param name="configuration"></param>
    /// <param name="sectionName"></param>
    /// <param name="tokenProvider"></param>
    /// <returns></returns>
    public static ClientConnection GetConnection(this IConfigurationManager configuration, string sectionName, AuthenticationTokenProvider tokenProvider)
        => configuration.GetSection(sectionName).GetConnection(tokenProvider);

    private static ClientConnection GetConnection(this IConfigurationSection section, AuthenticationTokenProvider? tokenProvider = null)
    {
        CredentialKind kind = ClientConnection.GetCredentialKind(section);
        bool useKey = tokenProvider is null && kind == CredentialKind.ApiKeyString;
        return new ClientConnection(section.Key, section["Endpoint"], useKey ? section["Credential:Key"] : tokenProvider, kind, section);
    }
}
