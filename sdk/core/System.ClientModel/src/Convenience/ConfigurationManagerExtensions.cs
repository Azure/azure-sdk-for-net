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
        where T : ClientSettings, new()
        => configuration.GetSection(sectionName).GetClientSettings<T>();

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="section"></param>
    /// <returns></returns>
    public static T GetClientSettings<T>(this IConfigurationSection section)
        where T : ClientSettings, new()
    {
        T t = new();
        t.Read(section);
        return t;
    }
}
