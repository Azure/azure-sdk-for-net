// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.Primitives;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

[AsyncOnly]
[LiveOnly] // Ignore tests in the CI for now
public class ProvisioningTestBase : ManagementRecordedTestBase<ProvisioningTestEnvironment>
{
    public bool SkipTools { get; set; }
    public bool SkipLiveCalls { get; set; }

    public Trycep CreateBicepTest() => new(this);

    public ProvisioningTestBase(bool async, bool skipTools = true, bool skipLiveCalls = true)
        : base(async, RecordedTestMode.Live)
    {
        // Ignore the version of the AZ CLI used to generate the ARM template as this will differ based on the environment
        JsonPathSanitizers.Add("$.._generator.version");
        JsonPathSanitizers.Add("$.._generator.templateHash");

        // Dial how long we spend waiting during iterative development since
        // we're not saving any of the recordings by default (yet)
        SkipTools = skipTools && skipLiveCalls; // We can't skip tools during live calls
        SkipLiveCalls = skipLiveCalls;
    }

    public override void GlobalTimeoutTearDown()
    {
        // Turn off global timeout errors because these tests can be much slower
        // base.GlobalTimeoutTearDown();
    }
}

public class Trycep(ProvisioningTestBase test) : IAsyncDisposable
{
    public AzureLocation ResourceLocation { get; set; } = AzureLocation.WestUS2;
    public ProvisioningTestBase Test { get; set; } = test;
    public ProvisioningBuildOptions BuildOptions { get; set; } =
        new()
        {
            // TODO: Add back when we reenable test recording
            Random = test.Recording.Random
        };
    public ProvisioningDeploymentOptions DeploymentOptions { get; set; } =
        new()
        {
            ArmClient = test.InstrumentClient(
                new ArmClient(
                    test.TestEnvironment.Credential,
                    test.TestEnvironment.SubscriptionId,
                    test.InstrumentClientOptions(new ArmClientOptions()))),
            DefaultCredential = test.TestEnvironment.Credential,
            DefaultSubscriptionId = test.TestEnvironment.SubscriptionId
        };
    public Infrastructure? Infra { get; set; }
    public ProvisioningPlan? Plan { get; set; }
    public IDictionary<string, string>? BicepModules { get; set; }
    public string? Bicep => BicepModules?.TryGetValue("main.bicep", out string? b) == true ? b : null;
    public string? TempDir { get; set; }
    public IList<string>? SavedBicepModules { get; set; }
    public string? ArmTemplate { get; set; }
    public SubscriptionResource? ArmSubscription { get; set; }
    public ResourceGroupResource? ArmResourceGroup { get; set; }
    public ProvisioningDeployment? Deployment { get; set; }
    public CancellationToken Cancellation { get; set; }

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
        if (Bicep != expectedBicep)
        {
            // printing for easier comparison/getting started
            Console.WriteLine("Actual:");
            Console.WriteLine(Bicep);
        }
        Assert.AreEqual(expectedBicep, Bicep);
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
        foreach (string name in expectedBicepModules.Keys)
        {
            string expected = expectedBicepModules[name];
            string? actual = BicepModules.TryGetValue(name, out string? b) ? b : null;
            Assert.IsNotNull(actual, $"Did not find expected module {name} in the actual modules!");
            if (actual != expected)
            {
                // printing for easier comparison/getting started
                Console.WriteLine($"Actual {name}:");
                Console.WriteLine(actual);
            }
            Assert.AreEqual(expected, actual, $"Expected Bicep for module {name} did not match actual Bicep.");
        }
        return this;
    }

    private void SaveBicep()
    {
        if (TempDir is null)
        {
            string? path;
            do { path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); }
            while (Directory.Exists(path) || File.Exists(path));
            Directory.CreateDirectory(path);
            TempDir = path;
            SavedBicepModules = [.. Plan!.Save(TempDir)];
        }
    }

    private string GetArmTemplate()
    {
        if (Test.SkipTools) { return ""; }
        if (ArmTemplate is null)
        {
            SaveBicep();
            ArmTemplate = GetPlan().CompileArmTemplate(TempDir);
        }
        return ArmTemplate;
    }

    public Trycep CompareArm(string expectedArm)
    {
        if (Test.SkipTools) { return this; }
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
        if (Test.SkipTools) { return this; }
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
        if (Test.SkipLiveCalls) { return; }
        if (ArmResourceGroup is not null) { return; }

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
        if (Test.SkipLiveCalls) { return; }
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
        if (Test.SkipLiveCalls) { return; }
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
        if (Test.SkipLiveCalls) { return; }
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
