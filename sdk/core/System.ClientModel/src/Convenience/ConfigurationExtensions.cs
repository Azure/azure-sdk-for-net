// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel;

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

    /// <summary>
    /// Creates an instance of <typeparamref name="T"/> and sets its properties
    /// from the specified <see cref="IConfiguration"/>, additionally
    /// resolving <see cref="ClientSettings.CredentialProvider"/> from the
    /// supplied <see cref="CredentialResolver"/> chain.
    /// </summary>
    public static T GetClientSettings<T>(
        this IConfiguration configuration,
        string sectionName,
        params CredentialResolver[] resolvers)
        where T : ClientSettings, new()
    {
        T settings = configuration.GetClientSettings<T>(sectionName);
        if (settings.CredentialProvider is null)
        {
            settings.CredentialProvider = configuration.GetCredential($"{sectionName}:Credential", resolvers);
        }
        return settings;
    }

    /// <summary>
    /// Creates an instance of <typeparamref name="T"/> and sets its properties
    /// from the specified <see cref="IConfiguration"/>, additionally
    /// resolving <see cref="ClientSettings.CredentialProvider"/> from the
    /// supplied <see cref="CredentialResolver"/> chain after applying
    /// <paramref name="configureOverrides"/> to the credential section.
    /// </summary>
    public static T GetClientSettings<T>(
        this IConfiguration configuration,
        string sectionName,
        IEnumerable<CredentialResolver> resolvers,
        Action<IConfigurationSection> configureOverrides)
        where T : ClientSettings, new()
    {
        T settings = configuration.GetClientSettings<T>(sectionName);
        if (settings.CredentialProvider is null)
        {
            settings.CredentialProvider = configuration.GetCredential($"{sectionName}:Credential", resolvers, configureOverrides);
        }
        return settings;
    }

    internal static T GetClientSettings<T>(this ReferenceConfigurationSection section)
        where T : ClientSettings, new()
    {
        T t = new();
        t.Bind(section);
        return t;
    }

    /// <summary>
    /// Resolves an <see cref="AuthenticationTokenProvider"/> for the named
    /// credential section. The supplied <paramref name="sectionName"/> is
    /// treated as the credential section itself (not a parent client
    /// section). This overload always returns <see langword="null"/>
    /// because no <see cref="CredentialResolver"/> chain has been supplied —
    /// use the overload that accepts resolvers to participate in resolution.
    /// Never throws.
    /// </summary>
    public static AuthenticationTokenProvider? GetCredential(
        this IConfiguration configuration,
        string sectionName)
        => configuration.GetCredential(sectionName, Array.Empty<CredentialResolver>());

    /// <summary>
    /// Walks the supplied <see cref="CredentialResolver"/> chain in order
    /// (first match wins) against the named credential section and returns
    /// the produced <see cref="AuthenticationTokenProvider"/>, or
    /// <see langword="null"/> if no resolver claimed the section. The
    /// supplied <paramref name="sectionName"/> is treated as the credential
    /// section itself. Never throws.
    /// </summary>
    public static AuthenticationTokenProvider? GetCredential(
        this IConfiguration configuration,
        string sectionName,
        params CredentialResolver[] resolvers)
    {
        if (configuration is null || sectionName is null)
        {
            return null;
        }

        IConfigurationSection section = new ReferenceConfigurationSection(configuration, sectionName);
        return CredentialResolverEngine.Resolve(section, resolvers, configureOverrides: null);
    }

    /// <summary>
    /// Applies <paramref name="configureOverrides"/> to a writable overlay of
    /// the named credential section, then walks the supplied
    /// <see cref="CredentialResolver"/> chain. The supplied
    /// <paramref name="sectionName"/> is treated as the credential section
    /// itself. Never throws.
    /// </summary>
    public static AuthenticationTokenProvider? GetCredential(
        this IConfiguration configuration,
        string sectionName,
        IEnumerable<CredentialResolver> resolvers,
        Action<IConfigurationSection> configureOverrides)
    {
        if (configuration is null || sectionName is null)
        {
            return null;
        }

        IConfigurationSection section = new ReferenceConfigurationSection(configuration, sectionName);
        return CredentialResolverEngine.Resolve(section, resolvers, configureOverrides);
    }

    /// <summary>
    /// Registers <typeparamref name="T"/> as a <see cref="CredentialResolver"/>
    /// service. Idempotent by implementation type — calling twice with the
    /// same <typeparamref name="T"/> registers a single instance.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> is null.</exception>
    public static IServiceCollection AddCredentialResolver<T>(this IServiceCollection services)
        where T : CredentialResolver, new()
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAddEnumerable(ServiceDescriptor.Singleton<CredentialResolver, T>(_ => new T()));
        return services;
    }

    /// <summary>
    /// Registers <typeparamref name="T"/> as a <see cref="CredentialResolver"/>
    /// service on the host's service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is null.</exception>
    public static IHostApplicationBuilder AddCredentialResolver<T>(this IHostApplicationBuilder builder)
        where T : CredentialResolver, new()
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Services.AddCredentialResolver<T>();
        return builder;
    }

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
        host.Services.AddKeyedSingleton(key, (sp, _) =>
        {
            return CreateSettings(configureSettings, builder, sp);
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
            return CreateSettings(configureSettings, builder, sp);
        });
        host.Services.AddSingleton(sp => ActivatorUtilities.CreateInstance<TClient>(sp, sp.GetRequiredService<TSettings>()));
        return builder;
    }

    private static TSettings CreateSettings<TSettings>(
        Action<TSettings>? configureSettings,
        ClientBuilder builder,
        IServiceProvider serviceProvider)
        where TSettings : ClientSettings, new()
    {
        TSettings settings = builder.ConfigurationSection.GetClientSettings<TSettings>();
        configureSettings?.Invoke(settings);
        // TODO (Phase 5a removal): Remove this line when PostConfigure is removed.
        builder.PostConfigureAction?.Invoke(settings);

        if (settings.CredentialProvider is null)
        {
            IEnumerable<CredentialResolver> resolvers = serviceProvider.GetServices<CredentialResolver>();
            IConfigurationSection credentialSection = builder.ConfigurationSection.GetSection("Credential");
            settings.CredentialProvider = CredentialResolverEngine.Resolve(
                credentialSection,
                resolvers,
                builder.ConfigureCredentialAction);
        }

        return settings;
    }
}
