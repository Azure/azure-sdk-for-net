// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.OpenAI.Tests.Utils.Config;

/// <summary>
/// Represents a flattened configuration that reads from one or more configurations in order.
/// </summary>
public class FlattenedConfig : IConfiguration
{
    private IReadOnlyList<IConfiguration?> _configs;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="configs">The configurations to read from in order.</param>
    /// <exception cref="ArgumentNullException">The configs passed was null</exception>
    public FlattenedConfig(params IConfiguration?[] configs)
    {
        _configs = configs ?? throw new ArgumentNullException(nameof(configs));
        Endpoint = _configs
            .Select(config => config?.Endpoint)
            .FirstOrDefault(endpoint => endpoint != null);
        Key = _configs
            .Select(config => config?.Key)
            .FirstOrDefault(key => key != null);
        Deployment = _configs
            .Select(config => config?.Deployment)
            .FirstOrDefault(deployment => deployment != null);
    }

    /// <inheritdoc />
    public Uri? Endpoint { get; }
    /// <inheritdoc />
    public string? Key { get; }
    /// <inheritdoc />
    public string? Deployment { get; }

    /// <inheritdoc />
    public TVal? GetValue<TVal>(string key) => _configs
        .Where(config => config != null)
        .Select(config => config!.GetValue<TVal>(key))
        .FirstOrDefault(value => value != null);
}
