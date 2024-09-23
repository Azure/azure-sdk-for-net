// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

// This is a draft to explore convenience APIs to make it easier to build tooling
// around Azure infrastructure.  It's likely going to change a fair bit in the near future.

/// <summary>
/// Represents a composed collection of resources that can be compiled to bicep
/// source, saved to disk, compiled to an ARM template, linted, validated, and
/// deployed.
/// </summary>
public partial class ProvisioningPlan
{
    private static Lazy<ExternalBicepTool> BicepTool { get; } = new(ExternalBicepTool.FindBestTool);

    private readonly ProvisioningContext _context;
    private readonly Infrastructure _infrastructure;
    // TODO: Expose the "composed" version of things for tools to walk

    internal ProvisioningPlan(Infrastructure infrastructure, ProvisioningContext context)
    {
        _infrastructure = infrastructure;
        _context = context;
    }

    // This is a placeholder until we get proper module splitting in place
    public IDictionary<string, string> Compile()
    {
        Dictionary<string, string> source = [];
        foreach (KeyValuePair<string, IEnumerable<Statement>> pair in _infrastructure.CompileModules(_context))
        {
            source[$"{pair.Key}.bicep"] = string.Join(Environment.NewLine, pair.Value).Trim();
        }
        return source;
    }

    // TODO: Support overloads taking callbacks for writing to arbitrary streams
    public IEnumerable<string> Save(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException($"Directory {directoryPath} does not exist", nameof(directoryPath));
        }
        List<string> paths = [];
        foreach (KeyValuePair<string, string> pair in Compile())
        {
            string path = Path.Combine(directoryPath, pair.Key);
            File.WriteAllText(path, pair.Value);
            paths.Add(path);
        }
        return paths;
    }

    /// <summary>
    /// Use the CLI to lint your generated Bicep.
    /// </summary>
    public IReadOnlyList<BicepErrorMessage> Lint(string? optionalDirectoryPath = null) =>
        WithOptionalTempBicep(optionalDirectoryPath, path => BicepTool.Value.Lint(path));

    /// <summary>
    /// Use the CLI to generate an ARM template that can be validated or deployed.
    /// </summary>
    public string CompileArmTemplate(string? optionalDirectoryPath = null) =>
        WithOptionalTempBicep(optionalDirectoryPath, path => BicepTool.Value.GetArmTemplate(path));

    // TODO: Dump out az/ps scripts
    // TODO: Dump out azd template
    // TODO: Dump out Github actions
    // TODO: WhatIf Deployments

    // TODO: Warn in docs that this will write to disk if you don't give me a dirToCleanup
    // (i.e., you haven't already saved) and we'll try to clean it up but ignore failures
    // and potentially leave infra definitions on disk.  You should save it yourself
    // somewhere if there's anything you'd consider secure that's easier to clean up
    // outside of your dirToCleanup directory.
    private T WithOptionalTempBicep<T>(string? optionalPath, Func<string, T> action)
    {
        string? dirToCleanup = null;
        try
        {
            string? path = optionalPath;
            if (path is null)
            {
                // Create a temp directory and save the bicep there
                dirToCleanup = CreateTempDirectory();

                // The "main" module is always first
                path = Save(dirToCleanup).FirstOrDefault();
            }

            // Run the action on the generated bicep
            return action(path!);
        }
        finally
        {
            // Try to clean things up, but don't swallow any failures
            if (dirToCleanup is not null)
            {
                try { Directory.Delete(dirToCleanup, recursive: true); }
                catch { }
            }
        }

        // TODO: Inline if we don't need this elsewhere
        static string CreateTempDirectory()
        {
            string? path;
            do
            { path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); }
            while (Directory.Exists(path) || File.Exists(path));
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
