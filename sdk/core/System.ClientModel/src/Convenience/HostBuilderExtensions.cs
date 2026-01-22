// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel;

/// <summary>
/// Provides extension methods for the <see cref="IHostApplicationBuilder"/> interface.
/// </summary>
[Experimental("SCME0002")]
public static class HostBuilderExtensions
{
    /// <summary>
    /// Adds a keyed singleton client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
    /// </summary>
    /// <remarks>
    /// The <typeparamref name="TClient"/> must have a constructor that takes one parameter of type <typeparamref name="TSettings"/>.
    /// </remarks>
    /// <typeparam name="TClient">The type of client.</typeparam>
    /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
    /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
    /// <param name="key">The unique key to register as.</param>
    /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
    /// <seealso href="https://learn.microsoft.com/dotnet/core/extensions/dependency-injection">Dependency injection in .NET</seealso>
    public static IClientBuilder AddKeyedClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
        this IHostApplicationBuilder host,
        string key,
        string sectionName)
            where TClient : class
            where TSettings : ClientSettings, new()
        => host.AddKeyedClient<TClient, TSettings>(key, sectionName, null!);

    /// <summary>
    /// Adds a keyed singleton client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
    /// </summary>
    /// <remarks>
    /// The <typeparamref name="TClient"/> must have a constructor that takes one parameter of type <typeparamref name="TSettings"/>.
    /// </remarks>
    /// <typeparam name="TClient">The type of client.</typeparam>
    /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
    /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
    /// <param name="key">The unique key to register as.</param>
    /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
    /// <param name="configureSettings">Factory method to modify the <typeparamref name="TSettings"/> after they are created.</param>
    public static IClientBuilder AddKeyedClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
        this IHostApplicationBuilder host,
        string key,
        string sectionName,
        Action<TSettings> configureSettings)
            where TClient : class
            where TSettings : ClientSettings, new()
    {
        IConfigurationSection section = host.Configuration.GetSection(sectionName);
        ClientBuilder builder = new(host, section);
        host.Services.AddKeyedSingleton(key, (sp, key) =>
        {
            return CreateSettings(configureSettings, builder);
        });
        host.Services.AddKeyedSingleton(key, (sp, key) => ActivatorUtilities.CreateInstance<TClient>(sp, sp.GetRequiredKeyedService<TSettings>(key)));
        return builder;
    }

    /// <summary>
    /// Adds a singleton client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
    /// </summary>
    /// <remarks>
    /// The <typeparamref name="TClient"/> must have a constructor that takes one parameter of type <typeparamref name="TSettings"/>.
    /// </remarks>
    /// <typeparam name="TClient">The type of client.</typeparam>
    /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
    /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
    /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
    public static IClientBuilder AddClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
        this IHostApplicationBuilder host,
        string sectionName)
            where TClient : class
            where TSettings : ClientSettings, new()
        => host.AddClient<TClient, TSettings>(sectionName, null!);

    /// <summary>
    /// Adds a singleton client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
    /// </summary>
    /// <remarks>
    /// The <typeparamref name="TClient"/> must have a constructor that takes one parameter of type <typeparamref name="TSettings"/>.
    /// </remarks>
    /// <typeparam name="TClient">The type of client.</typeparam>
    /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
    /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
    /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
    /// <param name="configureSettings">Factory method to modify the <typeparamref name="TSettings"/> after they are created.</param>
    public static IClientBuilder AddClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
        this IHostApplicationBuilder host,
        string sectionName,
        Action<TSettings> configureSettings)
            where TClient : class
            where TSettings : ClientSettings, new()
    {
        IConfigurationSection section = host.Configuration.GetSection(sectionName);
        ClientBuilder builder = new(host, section);
        host.Services.AddSingleton(sp =>
        {
            return CreateSettings(configureSettings, builder);
        });
        host.Services.AddSingleton(sp => ActivatorUtilities.CreateInstance<TClient>(sp, sp.GetRequiredService<TSettings>()));
        return builder;
    }

    private static TSettings CreateSettings<TSettings>(Action<TSettings> configureSettings, ClientBuilder builder) where TSettings : ClientSettings, new()
    {
        TSettings settings = builder.ConfigurationSection.GetClientSettings<TSettings>();
        configureSettings?.Invoke(settings);
        builder.PostConfigureAction?.Invoke(settings);
        return settings;
    }
}
