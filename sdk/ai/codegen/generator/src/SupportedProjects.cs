// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading;

namespace Extensions.Plugin;

internal class SupportedPackages
{
    private readonly string _name;
    private Lazy<HashSet<string>> _stableTypes;
    private SupportedPackages(string name) {
        _name = name;
        _stableTypes = new(LoadStableTypes(_name));
    }

    private static SupportedPackages? s_cahcedAzureAIProjects;
    private static SupportedPackages? s_cahcedAzureAIExtensionsOpenAI;
    private static SupportedPackages? s_cahcedAzureAIProjectsAgents;

    public static SupportedPackages AzureAIProjects { get => Volatile.Read(ref s_cahcedAzureAIProjects) ?? Interlocked.CompareExchange(ref s_cahcedAzureAIProjects, new SupportedPackages("Azure.AI.Projects"), null) ?? s_cahcedAzureAIProjects; }
    public static SupportedPackages AzureAIProjectsAgents { get => Volatile.Read(ref s_cahcedAzureAIExtensionsOpenAI) ?? Interlocked.CompareExchange(ref s_cahcedAzureAIExtensionsOpenAI, new SupportedPackages("Azure.AI.Extensions.OpenAI"), null) ?? s_cahcedAzureAIExtensionsOpenAI; }
    public static SupportedPackages AzureAIExtensionsOpenAI { get => Volatile.Read(ref s_cahcedAzureAIProjectsAgents) ?? Interlocked.CompareExchange(ref s_cahcedAzureAIProjectsAgents, new SupportedPackages("Azure.AI.Projects.Agents"), null) ?? s_cahcedAzureAIProjectsAgents; }

    public static bool IsStable(string type)
    {
        if (type.StartsWith(AzureAIProjectsAgents.ToString()))
        {
            return AzureAIProjectsAgents._stableTypes.Value.Contains(type);
        }
        if (type.StartsWith(AzureAIExtensionsOpenAI.ToString()))
        {
            return AzureAIExtensionsOpenAI._stableTypes.Value.Contains(type);
        }
        return AzureAIProjects._stableTypes.Value.Contains(type);
    }

    public override string ToString() => _name;

    private static HashSet<string> LoadStableTypes(string package)
    {
        string yaml = $"stable-types_{package}.yaml";
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(yaml)
            ?? throw new InvalidOperationException($"Embedded resource '{yaml}' not found.");
        using StreamReader reader = new(stream);
        var stableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        string? line;
        bool inSection = false;
        while ((line = reader.ReadLine()) != null)
        {
            string trimmed = line.Trim();
            if (trimmed.Length == 0 || trimmed.StartsWith("#"))
                continue;

            if (trimmed == "stableTypes:")
            {
                inSection = true;
                continue;
            }

            if (inSection && trimmed.StartsWith("- "))
            {
                stableTypes.Add(trimmed.Substring(2).Trim());
            }
        }

        return stableTypes;
    }
}
