// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.AI.AgentServer.Optimization.Configuration;

internal class AgentConfigurationSource : IConfigurationSource
{
    private readonly string _agentKey;
    private readonly string _sectionName;
#pragma warning disable SCME0002 // Type is for evaluation purposes only
    private readonly Action<AgentOptimizationClientSettings>? _configureSettings;
#pragma warning restore SCME0002

#pragma warning disable SCME0002 // Type is for evaluation purposes only
    internal AgentConfigurationSource(string agentKey, string sectionName, Action<AgentOptimizationClientSettings>? configureSettings)
#pragma warning restore SCME0002
    {
        _agentKey = agentKey ?? throw new ArgumentNullException(nameof(agentKey));
        _sectionName = sectionName ?? throw new ArgumentNullException(nameof(sectionName));
        _configureSettings = configureSettings;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var tempBuilder = new ConfigurationBuilder();
        foreach (IConfigurationSource source in builder.Sources)
        {
            if (ReferenceEquals(source, this))
            {
                break;
            }

            tempBuilder.Add(source);
        }

        IConfigurationRoot config = tempBuilder.Build();
#pragma warning disable SCME0002 // Type is for evaluation purposes only
        var settings = new AgentOptimizationClientSettings();
        settings.Bind(config.GetSection(_sectionName));
        _configureSettings?.Invoke(settings);
#pragma warning restore SCME0002
        return new AgentConfigurationProvider(_agentKey, settings);
    }
}
