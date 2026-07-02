// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Extensions.Plugin;

internal class SupportedPackages
{
    private readonly string _name;
    private HashSet<string> _experimentalEntity;

    private static string GetDirectory(string package, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";

        return Path.Combine([dirName, package]);
    }

    private SupportedPackages(string name) {
        _name = name;
        _experimentalEntity = [];
        LoadExperimentalTypes(_name);
        //throw new InvalidOperationException(GetDirectory(name));
    }

    private static SupportedPackages s_cachedAzureAIProjects;
    private static SupportedPackages s_cachedAzureAIExtensionsOpenAI;
    private static SupportedPackages s_cachedAzureAIProjectsAgents;

    public static SupportedPackages AzureAIProjects { get => Volatile.Read(ref s_cachedAzureAIProjects) ?? Interlocked.CompareExchange(ref s_cachedAzureAIProjects, new SupportedPackages("Azure.AI.Projects"), null) ?? s_cachedAzureAIProjects; }
    public static SupportedPackages AzureAIExtensionsOpenAI { get => Volatile.Read(ref s_cachedAzureAIExtensionsOpenAI) ?? Interlocked.CompareExchange(ref s_cachedAzureAIExtensionsOpenAI, new SupportedPackages("Azure.AI.Extensions.OpenAI"), null) ?? s_cachedAzureAIExtensionsOpenAI; }
    public static SupportedPackages AzureAIProjectsAgents { get => Volatile.Read(ref s_cachedAzureAIProjectsAgents) ?? Interlocked.CompareExchange(ref s_cachedAzureAIProjectsAgents, new SupportedPackages("Azure.AI.Projects.Agents"), null) ?? s_cachedAzureAIProjectsAgents; }

    private static string FixNamespace(string fullyQualifiedName)
    {
        if (fullyQualifiedName.StartsWith("Azure.AI.Projects.Memory."))
        {
            return fullyQualifiedName.Replace("Azure.AI.Projects.Memory.", "Azure.AI.Projects.");
        }
        else if (fullyQualifiedName.StartsWith("Azure.AI.Projects.Evaluation."))
        {
            return fullyQualifiedName.Replace("Azure.AI.Projects.Evaluation.", "Azure.AI.Projects.");
        }
        return fullyQualifiedName;
    }

    public static bool IsExperimental(string type)
    {
        if (type is null)
        {
            return false;
        }
        type = FixNamespace(type);
        if (type.StartsWith(AzureAIProjectsAgents.ToString()))
        {
            return AzureAIProjectsAgents._experimentalEntity.Contains(type);
        }
        if (type.StartsWith(AzureAIExtensionsOpenAI.ToString()))
        {
            return AzureAIExtensionsOpenAI._experimentalEntity.Contains(type);
        }
        if (type.StartsWith(AzureAIProjects.ToString()))
        {
            return AzureAIProjects._experimentalEntity.Contains(type);
        }
        return false;
    }

    public override string ToString() => _name;

    private void LoadExperimentalTypes(string package)
    {
        string csv = $"{package}_experimental.csv";
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(csv)
            ?? throw new InvalidOperationException($"Embedded resource '{csv}' not found.");
        using StreamReader reader = new(stream);
        var stableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] row = line.Trim().Split(';');
            string trimmed = row[1].Trim();
            if (row.Length != 2 || trimmed.Length == 0 || string.Equals(row[0], "type"))
            {
                continue;
            }
            switch (row[0])
            {
                case "class":
                   _experimentalEntity.Add(trimmed);
                    break;
                case "field":
                    _experimentalEntity.Add(ToCapitalizedCamelCase(trimmed));
                    break;
                default:
                    break;
            }
        }
    }

    private static string ToCapitalizedCamelCase(string value)
    {
        string[] parts = value.Split('_');
        StringBuilder sb = new();
        foreach (string part in parts)
        {
            sb.Append(part.Substring(0, 1).ToUpper());
            sb.Append(part.Substring(1, part.Length - 1));
        }
        return sb.ToString();
    }
}
