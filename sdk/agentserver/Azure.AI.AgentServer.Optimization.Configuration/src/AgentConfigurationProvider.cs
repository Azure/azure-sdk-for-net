// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace Azure.AI.AgentServer.Optimization.Configuration;

/// <summary>
/// Runs the optimization config waterfall at <see cref="Load"/> time and projects the
/// resulting <see cref="OptimizationOptions"/> into the <see cref="IConfiguration"/> tree.
/// </summary>
/// <remarks>
/// <para>
/// Keys are emitted under <see cref="AgentConfigurationOptions.SectionName"/> (or the
/// derived default — <c>Agent</c> for single-agent, <c>Agents:&lt;AgentKey&gt;</c> for
/// multi-agent), using the standard colon separator and indexed array element notation
/// used by <see cref="Microsoft.Extensions.Configuration.ConfigurationBinder"/>:
/// </para>
/// <code>
/// Agent:Instructions             = "..."
/// Agent:Model                    = "gpt-4o"
/// Agent:Temperature              = "0.7"
/// Agent:Skills:0:Name            = "..."
/// Agent:Skills:0:Description     = "..."
/// Agent:ToolDefinitions:0:Name   = "..."
/// </code>
/// <para>
/// Reload is supported via <see cref="ConfigurationProvider.Load"/>. The provider
/// builds the new key/value set in a local dictionary and only swaps <see cref="ConfigurationProvider.Data"/>
/// after the load succeeds so a failed reload never wipes the previously-loaded values.
/// </para>
/// </remarks>
public class AgentConfigurationProvider : ConfigurationProvider
{
    private readonly AgentConfigurationOptions _options;

    /// <summary>
    /// Creates a new <see cref="AgentConfigurationProvider"/>.
    /// </summary>
    /// <param name="options">Options controlling resolution and projection. Required.</param>
    public AgentConfigurationProvider(AgentConfigurationOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Resolves the optimization configuration and projects it into <see cref="ConfigurationProvider.Data"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <see cref="AgentConfigurationOptions.SectionName"/> is invalid, or when
    /// <see cref="AgentConfigurationOptions.FailOnEmpty"/> is <c>true</c> and no config
    /// source was resolved.
    /// </exception>
    public override void Load()
    {
        string section = ResolveSectionName(_options);

        var loadOptions = new LoadOptions
        {
            AgentKey = _options.AgentKey,
            Credential = _options.Credential,
            ResolverTimeout = _options.ResolverTimeout,
            StrictMode = _options.StrictMode,
            FallbackToUnsuffixedEnvVars = _options.FallbackToUnsuffixedEnvVars,
        };

        OptimizationOptions? options = new LocalFallbackAgentOptimizationClient().ResolveOptions(loadOptions);

        if (options is null)
        {
            if (_options.FailOnEmpty)
            {
                string agentScope = _options.AgentKey is null
                    ? string.Empty
                    : $" for agent '{_options.AgentKey}'";

                throw new InvalidOperationException(
                    $"AgentConfigurationProvider could not resolve an optimization config{agentScope}. " +
                    "No source matched (resolver API, OPTIMIZATION_CONFIG, local candidate dir, local baseline dir).");
            }

            // Non-failing empty result: clear any previously-loaded data so a stale
            // reload does not keep zombie values around.
            Data = CreateEmptyDataDictionary();
            return;
        }

        // Build into a local dictionary first so a partial / failing load does not
        // mutate Data. Only swap on success.
        var newData = CreateEmptyDataDictionary();
        Flatten(options, section, newData);
        Data = newData;
    }

    /// <summary>
    /// Resolves the configuration section that this provider writes into. Exposed
    /// internally so the <see cref="OptimizationConfigurationExtensions"/> helpers
    /// can stay in sync with provider behavior.
    /// </summary>
    internal static string ResolveSectionName(AgentConfigurationOptions options)
    {
        if (!string.IsNullOrEmpty(options.SectionName))
        {
            ValidateSectionName(options.SectionName!);
            return options.SectionName!;
        }

        if (string.IsNullOrEmpty(options.AgentKey))
        {
            return "Agent";
        }

        // Validate the key with the canonicalizer rules — same charset, fail fast.
        // We use the raw (non-canonical) key in the section path for readability;
        // M.E.Configuration's case-insensitive key comparison guarantees that
        // "Agents:Triage-Agent" and "Agents:triage-agent" resolve to the same node.
        _ = AgentKeyCanonicalizer.Canonicalize(options.AgentKey!, nameof(options.AgentKey));
        return "Agents:" + options.AgentKey;
    }

    private static void ValidateSectionName(string sectionName)
    {
        if (sectionName.StartsWith(":", StringComparison.Ordinal) ||
            sectionName.EndsWith(":", StringComparison.Ordinal))
        {
            throw new ArgumentException(
                $"{nameof(AgentConfigurationOptions.SectionName)} '{sectionName}' must not start or end with ':'.",
                nameof(sectionName));
        }
    }

    private static Dictionary<string, string?> CreateEmptyDataDictionary()
        => new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Flattens <paramref name="options"/> into <paramref name="data"/> under
    /// <paramref name="section"/> using the standard <see cref="ConfigurationPath.KeyDelimiter"/>
    /// for nested sections and indexed array element notation for collections.
    /// </summary>
    private static void Flatten(OptimizationOptions options, string section, IDictionary<string, string?> data)
    {
        Set(data, section, nameof(OptimizationOptions.Instructions), options.Instructions);
        Set(data, section, nameof(OptimizationOptions.Model), options.Model);

        if (options.Temperature.HasValue)
        {
            Set(data, section, nameof(OptimizationOptions.Temperature),
                options.Temperature.Value.ToString(CultureInfo.InvariantCulture));
        }

        Set(data, section, nameof(OptimizationOptions.SkillsDirectory), options.SkillsDirectory);
        Set(data, section, nameof(OptimizationOptions.Source), options.Source);
        Set(data, section, nameof(OptimizationOptions.CandidateId), options.CandidateId);

        for (int i = 0; i < options.Skills.Count; i++)
        {
            var skill = options.Skills[i];
            if (skill is null)
            {
                continue;
            }
            string skillPrefix = ConfigurationPath.Combine(section, nameof(OptimizationOptions.Skills), i.ToString(CultureInfo.InvariantCulture));
            Set(data, skillPrefix, nameof(OptimizationSkill.Name), skill.Name);
            Set(data, skillPrefix, nameof(OptimizationSkill.Description), skill.Description);
            Set(data, skillPrefix, nameof(OptimizationSkill.Body), skill.Body);
        }

        for (int i = 0; i < options.ToolDefinitions.Count; i++)
        {
            var tool = options.ToolDefinitions[i];
            if (tool is null)
            {
                continue;
            }
            string toolPrefix = ConfigurationPath.Combine(section, nameof(OptimizationOptions.ToolDefinitions), i.ToString(CultureInfo.InvariantCulture));
            Set(data, toolPrefix, nameof(ToolDefinition.Type), tool.Type);
            Set(data, toolPrefix, nameof(ToolDefinition.Name), tool.Name);
            Set(data, toolPrefix, nameof(ToolDefinition.Description), tool.Description);
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
