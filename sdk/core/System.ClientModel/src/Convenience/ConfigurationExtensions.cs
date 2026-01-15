// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Static class containing extension methods for IConfiguration to get ClientSettings.
/// </summary>
[Experimental("SCME0002")]
public static class ConfigurationExtensions
{
    /// <summary>
    /// Creates an instance of <typeparamref name="T"/> and sets its properties from the specified <see cref="IConfiguration"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="ClientSettings"/> to create.</typeparam>
    /// <param name="configuration">The <see cref="IConfiguration"/> to bind the properties of <typeparamref name="T"/> from.</param>
    /// <param name="sectionName">The section of <see cref="IConfiguration"/> to bind from.</param>
    public static T GetClientSettings<T>(this IConfiguration configuration, string sectionName)
        where T : ClientSettings, new()
        => new ReferenceConfigurationSection(configuration, sectionName).GetClientSettings<T>();

    internal static T GetClientSettings<T>(this ReferenceConfigurationSection section)
        where T : ClientSettings, new()
    {
        T t = new();
        t.Bind(section);
        return t;
    }
}
