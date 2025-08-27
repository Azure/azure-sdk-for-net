// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class StandaloneTrycep : IDisposable
{
    public AzureLocation ResourceLocation { get; set; } = AzureLocation.WestUS2;
    public ProvisioningBuildOptions BuildOptions { get; set; } = new();
    public ProvisioningDeploymentOptions DeploymentOptions { get; set; } = new();
    public Infrastructure? Infra { get; set; }
    public ProvisioningPlan? Plan { get; set; }
    public IDictionary<string, string>? BicepModules { get; set; }
    public string? Bicep => BicepModules?.TryGetValue("main.bicep", out string? b) == true ? b : null;
    public string? TempDir { get; set; }
    public IList<string>? SavedBicepModules { get; set; }

    public StandaloneTrycep Define(ProvisionableConstruct resource)
    {
        Infra = new Infrastructure();
        Infra.Add(resource);
        Plan = Infra.Build(BuildOptions);
        return this;
    }

    public StandaloneTrycep Define(Func<StandaloneTrycep, Infrastructure> action)
    {
        Infra = action(this);
        Plan = Infra.Build(BuildOptions);
        return this;
    }

    public StandaloneTrycep Define(Func<StandaloneTrycep, ProvisioningBuildOptions, Infrastructure> action)
    {
        Infra = action(this, BuildOptions);
        Plan = Infra.Build(BuildOptions);
        return this;
    }

    private ProvisioningPlan GetPlan() =>
        Plan ?? throw new InvalidOperationException("No ProvisioningPlan was provided.  Did you call Define?");

    // TODO: I like the Bicep inline right now, but if that gets tiring we
    // should add a CompareFile([Caller...]) that diffs against a test specific
    // file (or writes it if not found).

    // TODO: How much work would it be to get a [StringSyntax] working with Bicep?
    public StandaloneTrycep Compare(string expectedBicep)
    {
        BicepModules = GetPlan().Compile();
        Assert.AreEqual(1, BicepModules.Count, $"Expected exactly one bicep module, not <{string.Join(", ", BicepModules.Keys)}>");

        Assert.IsNotNull(Bicep, "The produced Bicep module was null!");
        if (!CompareBicepContent(expectedBicep, Bicep!, "main.bicep"))
        {
            Assert.Fail("Bicep content comparison failed. See output above for details.");
        }

        return this;
    }

    public StandaloneTrycep Compare(IDictionary<string, string> expectedBicepModules)
    {
        BicepModules = GetPlan().Compile();
        Assert.AreEqual(
            expectedBicepModules.Count,
            BicepModules.Count,
            $"Expected {expectedBicepModules.Count} modules but found {BicepModules.Count}.  " +
                $"Expected: <{string.Join(", ", expectedBicepModules.Keys)}>  " +
                $"Actual: <{string.Join(", ", BicepModules.Keys)}>");

        bool allMatched = true;
        foreach (string name in expectedBicepModules.Keys)
        {
            string expected = expectedBicepModules[name];
            string? actual = BicepModules.TryGetValue(name, out string? b) ? b : null;
            Assert.IsNotNull(actual, $"Did not find expected module {name} in the actual modules!");

            if (!CompareBicepContent(expected, actual!, name))
            {
                allMatched = false;
            }
        }

        if (!allMatched)
        {
            Assert.Fail("One or more Bicep module comparisons failed. See output above for details.");
        }

        return this;
    }
    private bool CompareBicepContent(string expected, string actual, string moduleName)
    {
        // Normalize line endings for consistent comparison
        string normalizedExpected = NormalizeLineEndings(expected);
        string normalizedActual = NormalizeLineEndings(actual);

        if (normalizedExpected == normalizedActual)
        {
            return true;
        }

        // Enhanced debugging output with line-by-line comparison
        Console.WriteLine($"=== Bicep comparison failed for module: {moduleName} ===");
        Console.WriteLine();

        // Show side-by-side comparison for better debugging
        var expectedLines = normalizedExpected.Split('\n');
        var actualLines = normalizedActual.Split('\n');

        Console.WriteLine("Expected vs Actual (line by line):");
        Console.WriteLine("=====================================");

        int maxLines = Math.Max(expectedLines.Length, actualLines.Length);
        bool foundDifference = false;

        for (int i = 0; i < maxLines; i++)
        {
            string expectedLine = i < expectedLines.Length ? expectedLines[i] : "<EOF>";
            string actualLine = i < actualLines.Length ? actualLines[i] : "<EOF>";

            if (expectedLine != actualLine && !foundDifference)
            {
                foundDifference = true;
                Console.WriteLine($"First difference at line {i + 1}:");
                Console.WriteLine($"  Expected: {expectedLine}");
                Console.WriteLine($"  Actual:   {actualLine}");
                Console.WriteLine();
            }
        }

        // Always show the full actual output for easy copy-paste
        Console.WriteLine($"=== Full Actual {moduleName} Output ===");
        Console.WriteLine(actual);
        Console.WriteLine($"=== End of {moduleName} Output ===");
        Console.WriteLine();

        // Provide helpful statistics
        Console.WriteLine($"Expected length: {normalizedExpected.Length} characters, {expectedLines.Length} lines");
        Console.WriteLine($"Actual length:   {normalizedActual.Length} characters, {actualLines.Length} lines");

        return false;
    }

    private static string NormalizeLineEndings(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input ?? string.Empty;

        // Convert all line endings to LF for consistent comparison
        return input.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    private void SaveBicep()
    {
        if (TempDir is null)
        {
            string? path;
            do
            { path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); }
            while (Directory.Exists(path) || File.Exists(path));
            Directory.CreateDirectory(path);
            TempDir = path;
            SavedBicepModules = [.. Plan!.Save(TempDir)];
        }
    }

    public StandaloneTrycep Lint(Action<IReadOnlyList<BicepErrorMessage>>? check = default, IList<string>? ignore = default)
    {
        SaveBicep();
        string mainPath = SavedBicepModules![0];
        IReadOnlyList<BicepErrorMessage> messages = GetPlan().Lint(mainPath);
        if (check is not null)
        {
            check(messages);
        }
        else if (messages.Count > 0)
        {
            List<BicepErrorMessage> remaining = [.. messages];
            if (ignore is not null)
            {
                remaining = [.. remaining.Where(m => !ignore.Contains(m.Code ?? ""))];
            }
            Assert.Zero(remaining.Count,
                $"Found {remaining.Count} unexpected warnings:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, remaining.Select(s => s.ToString()))}");
        }
        return this;
    }

    public void Dispose()
    {
        if (TempDir is not null)
        {
            Directory.Delete(TempDir, recursive: true);
            TempDir = null;
        }
        GC.SuppressFinalize(this);
    }
}
