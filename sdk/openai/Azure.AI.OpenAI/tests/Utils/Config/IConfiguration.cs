// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.TestFramework.AutoSyncAsync;

namespace Azure.AI.OpenAI.Tests.Utils.Config;

/// <summary>
/// A test configuration for an Azure resource.
/// </summary>
public interface IConfiguration
{
    /// <summary>
    /// The endpoint to use for sending requests to the Azure resource.
    /// </summary>
    Uri? Endpoint { get; }

    /// <summary>
    /// The API key to use for authenticating requests to the Azure resource.
    /// </summary>
    string? Key { get; }

    /// <summary>
    /// The deployment to use for this  Azure resource.
    /// </summary>
    string? Deployment { get; }

    /// <summary>
    /// Gets additional values from the test configuration for the Azure resource.
    /// </summary>
    /// <typeparam name="TVal">The type of the value.</typeparam>
    /// <param name="key">The name of the value (usually snake cased). For example: fine_tuned_model.</param>
    /// <returns>The parsed value for that key, or null of the key was not found, or failed to be parsed.</returns>
    TVal? GetValue<TVal>(string key);
}

/// <summary>
/// A named test configuration for an Azure resource.
/// </summary>
public interface INamedConfiguration : IConfiguration
{
    /// <summary>
    /// The name of the configuration.
    /// </summary>
    string? Name { get; }
}

/// <summary>
/// Extensions methods for <see cref="IConfiguration"/>.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    ///  Gets additional values from the test configuration for the Azure resource, but throws exceptions if the key is not found.
    /// </summary>
    /// <typeparam name="TVal">The type of the value.</typeparam>
    /// <param name="config">The configuration to get a value from.</param>
    /// <param name="key">The name of the value (usually snake cased). For example: fine_tuned_model.</param>
    /// <returns>The successfully parsed value for that key.</returns>
    /// <exception cref="ArgumentNullException">If the configuration passed was null</exception>
    /// <exception cref="KeyNotFoundException">If the key could not be found</exception>
    public static TVal GetValueOrThrow<TVal>(this IConfiguration? config, string key)
    {
        if (config == null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        return config.GetValue<TVal>(key)
            ?? throw new KeyNotFoundException($"Could not find a value for '{key}' in the test configuration");
    }

    /// <summary>
    /// Gets the configuration that was used when creating the client instance.
    /// </summary>
    /// <typeparam name="TExplicitClient">The type of the client.</typeparam>
    /// <param name="client">The client instance.</param>
    /// <returns>The configuration.</returns>
    /// <exception cref="KeyNotFoundException">The client did not have a config associated with it.</exception>
    public static IConfiguration GetConfigOrThrow<TExplicitClient>(this TExplicitClient client) where TExplicitClient : class
    {
        var instrumented = GetTopLevelClientInfo(client);
        return instrumented.Config ?? throw new ArgumentException("The client was instrumented with a null configuration");
    }

    /// <summary>
    /// Gets the deployment to use from the configuration, or throws if none was found.
    /// </summary>
    /// <param name="config">The config.</param>
    /// <param name="clientName">(Optional) The client name to include in th exception message.</param>
    /// <returns>The deployment.</returns>
    /// <exception cref="KeyNotFoundException">The deployment was not set or found.</exception>
    public static string DeploymentOrThrow(this IConfiguration? config, string? clientName = null)
    {
        string str = clientName == null ? string.Empty : clientName + " ";
        return config?.Deployment
            ?? throw new KeyNotFoundException($"Could not find a {str}deployment in the test configuration");
    }

    /// <summary>
    /// Gets the deployment from the specified client.
    /// </summary>
    /// <typeparam name="TExplicitClient">The type of the client.</typeparam>
    /// <param name="client">The client instance.</param>
    /// <returns>The deployment name used for that client instance.</returns>
    /// <exception cref="ArgumentException">The client either was not properly instrumented.</exception>
    /// <exception cref="KeyNotFoundException">The client did not have a deployment configured.</exception>
    public static string DeploymentOrThrow<TExplicitClient>(this TExplicitClient client) where TExplicitClient : class
    {
        var instrumented = GetTopLevelClientInfo(client);
        return instrumented.Config.DeploymentOrThrow(client!.GetType().Name);
    }

    private static AoaiTestBase<TExplicitClient>.TopLevelInfo GetTopLevelClientInfo<TExplicitClient>(TExplicitClient? client)
        where TExplicitClient : class
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return ((AoaiTestBase<TExplicitClient>.TopLevelInfo?)(client as IAutoSyncAsync)?.Context)
            ?? throw new ArgumentException(
                $"The client was not properly wrapped for automatic sync/async ({client.GetType().Name})",
                nameof(client));
    }
}
