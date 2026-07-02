// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure;
using Azure.Core;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.AI.AgentServer.Optimization.Configuration;

internal class AgentConfigurationProvider : ConfigurationProvider
{
    private readonly string _agentKey;
#pragma warning disable SCME0002 // Type is for evaluation purposes only
    private readonly AgentOptimizationClientSettings _settings;
#pragma warning restore SCME0002

#pragma warning disable SCME0002 // Type is for evaluation purposes only
    internal AgentConfigurationProvider(string agentKey, AgentOptimizationClientSettings settings)
#pragma warning restore SCME0002
    {
        _agentKey = agentKey ?? throw new ArgumentNullException(nameof(agentKey));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    internal CandidateDeployConfig? ResolvedConfig { get; private set; }

    internal string SectionName => _agentKey;

    public override void Load()
    {
        string? candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
        AgentOptimizationClient client = CreateClient();
        Response<CandidateDeployConfig>? response = client.ResolveOptions(candidateId);
        CandidateDeployConfig? options = response?.Value;

        if (options is null)
        {
            Data = CreateEmptyDataDictionary();
            ResolvedConfig = null;
            return;
        }

        var newData = CreateEmptyDataDictionary();
        Flatten(options, _agentKey, newData);
        Data = newData;
        ResolvedConfig = options;
    }

    private AgentOptimizationClient CreateClient()
    {
#pragma warning disable SCME0002 // Type is for evaluation purposes only
        if (_settings.Endpoint != null && _settings.CredentialProvider is TokenCredential)
        {
            return new AgentOptimizationClient(_settings);
        }
#pragma warning restore SCME0002

        return new LocalFallbackAgentOptimizationClient();
    }

    private static Dictionary<string, string?> CreateEmptyDataDictionary()
        => new(StringComparer.OrdinalIgnoreCase);

    private static void Flatten(CandidateDeployConfig options, string section, IDictionary<string, string?> data)
    {
        Set(data, section, nameof(CandidateDeployConfig.Instructions), options.Instructions);
        Set(data, section, nameof(CandidateDeployConfig.Model), options.Model);

        if (options.Temperature.HasValue)
        {
            Set(data, section, nameof(CandidateDeployConfig.Temperature),
                options.Temperature.Value.ToString(CultureInfo.InvariantCulture));
        }

        for (int i = 0; i < options.Skills.Count; i++)
        {
            var skill = options.Skills[i];
            if (skill is null)
            {
                continue;
            }

            string skillPrefix = ConfigurationPath.Combine(section, nameof(CandidateDeployConfig.Skills), i.ToString(CultureInfo.InvariantCulture));
            Set(data, skillPrefix, nameof(OptimizationAgentSkill.Name), skill.Name);
            Set(data, skillPrefix, nameof(OptimizationAgentSkill.Description), skill.Description);
        }
    }

    private static void Set(IDictionary<string, string?> data, string prefix, string key, string? value)
    {
        if (value is null)
        {
            return;
        }

        data[ConfigurationPath.Combine(prefix, key)] = value;
    }

    private sealed class LocalFallbackAgentOptimizationClient : AgentOptimizationClient
    {
    }
}
