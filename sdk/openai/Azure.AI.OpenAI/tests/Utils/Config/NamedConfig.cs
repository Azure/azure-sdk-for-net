// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Text.Json;

namespace Azure.AI.OpenAI.Tests.Utils.Config;

/// <summary>
/// A wrapper around a test configuration to associate an optional name.
/// </summary>
public class NamedConfig : INamedConfiguration
{
    private readonly IConfiguration? _config;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="config">The configuration instance.</param>
    /// <param name="name">The name of the config.</param>
    public NamedConfig(IConfiguration? config, string? name)
    {
        _config = config;
        Name = name;
    }

    /// <inheritdoc />
    public string? Name { get; }
    /// <inheritdoc />
    public Uri? Endpoint => _config?.Endpoint;
    /// <inheritdoc />
    public string? Key => _config?.Key;
    /// <inheritdoc />
    public string? Deployment => _config?.Deployment;
    /// <inheritdoc />
    public TVal? GetValue<TVal>(string key) => _config == null ? default : _config.GetValue<TVal>(key);
}
