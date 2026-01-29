// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.Primitives;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class Trycep : IAsyncDisposable
{
    public bool SkipTools { get; private set; } = true;
    public bool SkipLiveCalls { get; private set; } = true;
    public ProvisioningTestBase? Test { get; private set; }
    public ProvisioningBuildOptions BuildOptions { get; init; } = new();
    public ProvisioningDeploymentOptions DeploymentOptions { get; init; } = new();
    public Infrastructure? Infra { get; private set; }
    public ProvisioningPlan? Plan { get; private set; }
    public IDictionary<string, string>? BicepModules { get; private set; }
    public string? Bicep => BicepModules?.TryGetValue("main.bicep", out string? b) == true ? b : null;
    public string? TempDir { get; private set; }
    public IList<string>? SavedBicepModules { get; private set; }
    public string? ArmTemplate { get; private set; }
    public AzureLocation ResourceLocation { get; init; } = AzureLocation.WestUS2;
    public SubscriptionResource? ArmSubscription { get; private set; }
    public ResourceGroupResource? ArmResourceGroup { get; private set; }
    public ProvisioningDeployment? Deployment { get; private set; }
    public CancellationToken Cancellation { get; private set; }

    /// <summary>
    /// Setup how the bicep tests in this class would interact with Azure.
    /// </summary>
    /// <param name="test"></param>
    /// <returns></returns>
    public Trycep SetupLiveCalls(ProvisioningTestBase test)
    {
        Test = test;
        SkipTools = test.SkipTools;
        SkipLiveCalls = test.SkipLiveCalls;
        BuildOptions.Random = test.Recording.Random;
        DeploymentOptions.ArmClient = test.InstrumentClient(
                new ArmClient(
                    test.TestEnvironment.Credential,
                    test.TestEnvironment.SubscriptionId,
                    test.InstrumentClientOptions(new ArmClientOptions())));
        DeploymentOptions.DefaultCredential = test.TestEnvironment.Credential;
        DeploymentOptions.DefaultSubscriptionId = test.TestEnvironment.SubscriptionId;

        return this;
    }

    public Trycep Define(ProvisionableConstruct resource)
    {
        Infra = new Infrastructure();
        Infra.Add(resource);
        Plan = Infra.Build(BuildOptions);
        return this;
    }

    public Trycep Define(Func<Trycep, Infrastructure> action)
    {
        Infra = action(this);
        Plan = Infra.Build(BuildOptions);
        return this;
    }

    public Trycep Define(Func<Trycep, ProvisioningBuildOptions, Infrastructure> action)
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
    public Trycep Compare(string expectedBicep)
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

    public Trycep Compare(IDictionary<string, string> expectedBicepModules)
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

    private string GetArmTemplate()
    {
        if (SkipTools)
        { return ""; }
        if (ArmTemplate is null)
        {
            SaveBicep();
            ArmTemplate = GetPlan().CompileArmTemplate(TempDir);
        }
        return ArmTemplate;
    }

    public Trycep CompareArm(string expectedArm)
    {
        if (SkipTools)
        { return this; }
        string arm = GetArmTemplate();
        if (arm != expectedArm)
        {
            // printing for easier comparison/getting started
            Console.WriteLine("Actual:");
            Console.WriteLine(arm);
        }
        Assert.AreEqual(expectedArm, arm);
        return this;
    }

    public Trycep Lint(Action<IReadOnlyList<BicepErrorMessage>>? check = default, IList<string>? ignore = default)
    {
        if (SkipTools)
        {
            return this;
        }
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

    private async Task CreateResourceGroupAsync(string? name = default)
    {
        if (SkipLiveCalls)
        {
            return;
        }
        if (ArmResourceGroup is not null)
        {
            return;
        }

        string? subId = DeploymentOptions.DefaultSubscriptionId;
        ArmClient client = DeploymentOptions.ArmClient;

        // Try a specific subscription if specified
        ArmSubscription = (subId is not null) ?
            await client.GetSubscriptions().GetAsync(subId, Cancellation).ConfigureAwait(false) :
            await client.GetDefaultSubscriptionAsync(Cancellation).ConfigureAwait(false);

        // Generate a random name
        name ??= "rg-test-can-delete-" + BuildOptions.Random.NewGuid().ToString("N");

        // Create a resource group to deploy into
        ResourceGroupCollection rgs = ArmSubscription.GetResourceGroups();
        ArmOperation<ResourceGroupResource> rgCreation =
            await rgs.CreateOrUpdateAsync(
                WaitUntil.Completed,
                name,
                new ResourceGroupData(ResourceLocation),
                Cancellation)
            .ConfigureAwait(false);
        ArmResourceGroup = rgCreation.Value;
    }

    public async Task ValidateAsync(Action<ArmDeploymentValidateResult>? validate = default)
    {
        if (SkipLiveCalls)
        {
            return;
        }
        ProvisioningPlan plan = GetPlan();
        await CreateResourceGroupAsync().ConfigureAwait(false);
        ArmDeploymentValidateResult result =
            await plan.ValidateInResourceGroupAsync(
                ArmResourceGroup!.Data.Name,
                DeploymentOptions,
                Cancellation)
                .ConfigureAwait(false);
        if (validate is not null)
        {
            validate(result);
        }
        else if (result.Error is not null)
        {
            Assert.Fail($"Validation failed: {result.Error}");
        }
    }

    public async Task DeployAsync(Action<ProvisioningDeployment>? validate = default)
    {
        if (SkipLiveCalls)
        {
            return;
        }
        ProvisioningPlan plan = GetPlan();
        await CreateResourceGroupAsync().ConfigureAwait(false);
        Deployment =
            await plan.DeployToResourceGroupAsync(
                ArmResourceGroup!.Data.Name,
                DeploymentOptions,
                Cancellation)
                .ConfigureAwait(false);
        if (validate is not null)
        {
            validate(Deployment);
        }
        else if (Deployment.Error is not null)
        {
            Assert.Fail($"Deployment failed: {Deployment.Error}");
        }
    }

    public async Task VerifyLiveResource(Func<ProvisioningDeployment, Task> validate)
    {
        if (SkipLiveCalls)
        {
            return;
        }
        if (Deployment is null)
        {
            await DeployAsync().ConfigureAwait(false);
        }
        await validate(Deployment!).ConfigureAwait(false);
    }

    public async Task ValidateAndDeployAsync(Func<ProvisioningDeployment, Task>? validate = null)
    {
        await ValidateAsync();
        await DeployAsync();
        if (validate is not null)
        {
            await VerifyLiveResource(validate);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (ArmResourceGroup is not null)
        {
            // Generally safe enough to just start deleting and let the
            // resources get purged in the background - this can backfire if
            // you're trying to re-run and recreate the same resource group
            // again though.
            await ArmResourceGroup.DeleteAsync(WaitUntil.Started);
            ArmResourceGroup = null;
        }
        if (TempDir is not null)
        {
            Directory.Delete(TempDir, recursive: true);
            TempDir = null;
        }
        GC.SuppressFinalize(this);
    }
}
