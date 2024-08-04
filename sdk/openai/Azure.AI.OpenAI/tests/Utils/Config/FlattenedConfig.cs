// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests.Utils.Config;

/// <summary>
/// Represents a flattened configuration that reads from one or more configurations in order. It will also
/// record the values read from each configuration.
/// </summary>
public class FlattenedConfig : IConfiguration
{
    private IReadOnlyList<INamedConfiguration?> _configs;
    private IDictionary<string, SanitizedJsonConfig>? _recordedConfig;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="configs">The configurations to read from in order.</param>
    /// <param name="recordedConfig">Where to store the recorded configuration.</param>
    /// <exception cref="ArgumentNullException">The configs passed was null.</exception>
    public FlattenedConfig(INamedConfiguration?[] configs, IDictionary<string, SanitizedJsonConfig> recordedConfig)
    {
        _configs = configs ?? throw new ArgumentNullException(nameof(configs));
        _recordedConfig = recordedConfig ?? throw new ArgumentNullException(nameof(recordedConfig));

        Endpoint = GetAndRecordProperty(c => c.Endpoint, (c, v) => c.Endpoint = v);
        Key = GetAndRecordProperty(c => c.Key, (c, v) => c.Key = v);
        Deployment = GetAndRecordProperty(c => c.Deployment, (c, v) => c.Deployment = v);
    }

    /// <inheritdoc />
    public Uri? Endpoint { get; }
    /// <inheritdoc />
    public string? Key { get; }
    /// <inheritdoc />
    public string? Deployment { get; }

    /// <inheritdoc />
    public TVal? GetValue<TVal>(string key)
    {
        TVal? value = default;
        INamedConfiguration? selected = _configs
            .Where(config => config != null)
            .FirstOrDefault(config => (value = config!.GetValue<TVal>(key)) != null);

        if (_recordedConfig != null && selected != null && value != null)
        {
            string configName = selected.Name ?? JsonConfig.DEFAULT_CONFIG_NAME;
            SanitizedJsonConfig recorded = _recordedConfig.GetOrAdd(configName, _ => new SanitizedJsonConfig());
            recorded.SetValue(key, value);
        }

        return value;
    }

    private TVal? GetAndRecordProperty<TVal>(Func<IConfiguration, TVal?> getter, Action<SanitizedJsonConfig, TVal> setter)
    {
        TVal? value = default;
        INamedConfiguration? selected = _configs
            .Where(config => config != null)
            .FirstOrDefault(config => (value = getter(config!)) != null);

        if (_recordedConfig != null && selected != null && value != null)
        {
            string configName = selected.Name ?? JsonConfig.DEFAULT_CONFIG_NAME;
            SanitizedJsonConfig recorded = _recordedConfig.GetOrAdd(configName, _ => new SanitizedJsonConfig());
            setter(recorded, value);
        }

        return value;
    }


}
