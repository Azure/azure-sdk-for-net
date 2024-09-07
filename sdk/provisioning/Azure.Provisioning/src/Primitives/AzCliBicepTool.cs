// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ToolResult = (int ExitCode, string? Output, string? Error);

namespace Azure.Provisioning.Primitives;

// We're going to use external tools for bicep rather than referencing Azure.Bicep.Core
// (see https://github.com/Azure/bicep/discussions/8505).  This is tightly related
// to whatever we pursue with ProvisioningPlan and ProvisioningDeployment.

internal class AzCliBicepTool : ExternalBicepTool
{
    private static string AzCliName =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
            "az.cmd" :
            "az";

    private static Lazy<string> AzCliPath { get; } =
        new(() => FindPath(AzCliName) ?? throw new InvalidOperationException($"Azure CLI `{AzCliName}` not found on PATH."));

    public override string ToolFullPath => AzCliPath.Value;

    protected override string GetLinterArguments(string bicepPath) =>
        $"bicep lint --file {bicepPath}";

    protected override string GetArmBuildArguments(string bicepPath) =>
        $"bicep build --file {bicepPath} --stdout";
}

internal abstract class ExternalBicepTool
{
    public abstract string ToolFullPath { get; }
    protected abstract string GetLinterArguments(string bicepPath);
    protected abstract string GetArmBuildArguments(string bicepPath);

    public static ExternalBicepTool FindBestTool() =>
        // TODO: Also add version for PS Cmdlets, bicep CLI, and maybe
        // eventually azd? so we can then look for each of them in turn rather
        // than failing if you can't find az on the path?
        new AzCliBicepTool();

    public IReadOnlyList<BicepErrorMessage> Lint(string bicepPath)
    {
        ToolResult result = RunAndBlock(ToolFullPath, GetLinterArguments(bicepPath));
        if (result.ExitCode != 0 && result.ExitCode != 1)
        {
            throw new InvalidOperationException($"Linting failed with exit code {result.ExitCode} and error: {result.Error}");
        }

        // Parse and collect any error messages
        List<BicepErrorMessage> messages = [];
        foreach (string line in (result.Error ?? "").Split('\n').Select(l => l.Trim()))
        {
            if (string.IsNullOrEmpty(line)) { continue; }
            messages.Add(new BicepErrorMessage(line.Trim()));
        }
        return messages;
    }

    public string GetArmTemplate(string bicepPath)
    {
        ToolResult result = RunAndBlock(ToolFullPath, GetArmBuildArguments(bicepPath));
        if (result.ExitCode != 0 || result.Output is null)
        {
            // Throw it all as one error
            throw new InvalidOperationException($"Building ARM Template failed with exit code {result.ExitCode} and error: {result.Error}");
        }
        return result.Output;
    }

    // TODO: Make an async version with TCS if we decided to keep this
    private static ToolResult RunAndBlock(string path, string arguments)
    {
        using Process process = new()
        {
            StartInfo = new()
            {
                FileName = path,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        process.WaitForExit();
        return (process.ExitCode, process.StandardOutput.ReadToEnd(), process.StandardError.ReadToEnd());
    }

    protected static string? FindPath(string toolName, string pathVariableName = "PATH")
    {
        string[] paths = Environment.GetEnvironmentVariable(pathVariableName)?.Split(Path.PathSeparator) ?? [];
        foreach (string path in paths)
        {
            string fullPath = Path.Combine(path, toolName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
        }
        return null;
    }
}
