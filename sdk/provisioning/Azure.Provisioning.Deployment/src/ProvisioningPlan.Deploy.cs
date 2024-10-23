// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Provisioning.Primitives;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Provisioning;

// This is a draft of validation/deployment.  It's currently scoped to resource
// groups to help feel out whether we want to offer this experience, but we'd
// also want to expand to subscriptions, management groups, tenants, etc.

public static class ProvisioningPlanExtensions
{
    private static Lazy<ExternalBicepTool> BicepTool { get; } = new(ExternalBicepTool.FindBestTool);

    internal static async Task<SubscriptionResource> GetSubscriptionInternal(ProvisioningDeploymentOptions options, bool async, CancellationToken cancellationToken)
    {
        // Resolve the client
        ArmClient client = options.ArmClient;

        // Try a specific subscription if specified
        if (options.DefaultSubscriptionId is not null)
        {
            SubscriptionCollection subs = client.GetSubscriptions();
            return async ?
                await subs.GetAsync(options.DefaultSubscriptionId, cancellationToken).ConfigureAwait(false) :
                subs.Get(options.DefaultSubscriptionId, cancellationToken);
        }

        // Otherwise use the logic in ArmClient to select it
        return async ?
            await client.GetDefaultSubscriptionAsync(cancellationToken).ConfigureAwait(false) :
            client.GetDefaultSubscription(cancellationToken);
    }

    // TODO: Take a dictionary of params
    // TODO: Take a param file
    // TODO: Take an optional Bicep path
    // TODO: Take an ARM template directly

    public static ProvisioningDeployment DeployToNewResourceGroup(
        this ProvisioningPlan plan,
        string resourceGroupName,
        AzureLocation location,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            DeployToNewResourceGroupInternal(
                plan,
                resourceGroupName,
                location,
                options,
                async: false,
                cancellationToken)
            .EnsureCompleted();

    public static async Task<ProvisioningDeployment> DeployToNewResourceGroupAsync(
        this ProvisioningPlan plan,
        string resourceGroupName,
        AzureLocation location,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            await DeployToNewResourceGroupInternal(
                plan,
                resourceGroupName,
                location,
                options,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

    private static async Task<ProvisioningDeployment> DeployToNewResourceGroupInternal(
        ProvisioningPlan plan,
        string resourceGroupName,
        AzureLocation location,
        ProvisioningDeploymentOptions? options,
        bool async,
        CancellationToken cancellationToken)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = CompileArmTemplate(plan);

        // Default the options
        options ??= new ProvisioningDeploymentOptions();

        // Create a resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(options, async, cancellationToken).ConfigureAwait(false);
        ResourceGroupCollection rgs = sub.GetResourceGroups();
        ResourceGroupData rgData = new(location);
        ArmOperation<ResourceGroupResource> rgCreation = async ?
            await rgs.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, rgData, cancellationToken).ConfigureAwait(false) :
            rgs.CreateOrUpdate(WaitUntil.Completed, resourceGroupName, rgData, cancellationToken);
        ResourceGroupResource rg = rgCreation.Value;
        ArmDeploymentCollection deployments = rg.GetArmDeployments();

        // DeployToNewResourceGroup the ARM template
        ArmDeploymentResource deployment = await CreateDeploymentInternal(resourceGroupName, deployments, armTemplate, async, cancellationToken).ConfigureAwait(false);

        // Create the result
        return ProcessDeploymentInternal(plan, options, deployment);
    }

    public static ProvisioningDeployment DeployToResourceGroup(
        this ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            DeployToResourceGroupInternal(
                plan,
                resourceGroupName,
                options,
                async: false,
                cancellationToken)
            .EnsureCompleted();

    public static async Task<ProvisioningDeployment> DeployToResourceGroupAsync(
        this ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            await DeployToResourceGroupInternal(
                plan,
                resourceGroupName,
                options,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

    private static async Task<ProvisioningDeployment> DeployToResourceGroupInternal(
        ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options,
        bool async = true,
        CancellationToken cancellationToken = default)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = plan.CompileArmTemplate();

        // Default the options
        options ??= new ProvisioningDeploymentOptions();

        // Get the resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(options, async, cancellationToken).ConfigureAwait(false);
        ResourceGroupResource rg = async ?
            await sub.GetResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false) :
            sub.GetResourceGroup(resourceGroupName, cancellationToken);
        ArmDeploymentCollection deployments = rg.GetArmDeployments();

        // Deploy the ARM template
        ArmDeploymentResource deployment = await CreateDeploymentInternal(resourceGroupName, deployments, armTemplate, async, cancellationToken).ConfigureAwait(false);

        // Create the result
        return ProcessDeploymentInternal(plan, options, deployment);
    }

    private static async Task<ArmDeploymentResource> CreateDeploymentInternal(string resourceGroupName, ArmDeploymentCollection deployments, string armTemplate, bool async, CancellationToken cancellationToken)
    {
        // Create a deployment
        string deploymentName = $"{resourceGroupName}-deployment";
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent deploymentContent =
            new(
                new Azure.ResourceManager.Resources.Models.ArmDeploymentProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental)
                {
                    Template = BinaryData.FromString(armTemplate)
                });
        try
        {
            ArmOperation<ArmDeploymentResource> deploymentCreation = async ?
                await deployments.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, deploymentContent, cancellationToken).ConfigureAwait(false) :
                deployments.CreateOrUpdate(WaitUntil.Completed, deploymentName, deploymentContent, cancellationToken);
            return deploymentCreation.Value;
        }
        catch (RequestFailedException ex) when (ex.ErrorCode == "DeploymentFailed")
        {
            // If something goes wrong, fetch the deployment info which will
            // contain the error, etc.
            return async ?
                await deployments.GetAsync(deploymentName, cancellationToken).ConfigureAwait(false) :
                deployments.Get(deploymentName, cancellationToken);
        }
    }

    private static ProvisioningDeployment ProcessDeploymentInternal(ProvisioningPlan plan, ProvisioningDeploymentOptions options, ArmDeploymentResource deployment)
    {
        // Pull outputs from the results that are structured like
        // {"name":{"type":"String","value":"xyz"}}
        Dictionary<string, object?> outputs = [];
        if (deployment.Data.Properties.Outputs is not null)
        {
            JsonElement doc = JsonDocument.Parse(deployment.Data.Properties.Outputs.ToMemory()).RootElement;
            foreach (JsonProperty prop in doc.EnumerateObject())
            {
                try
                {
                    JsonElement value = prop.Value.GetProperty("value");
                    // TODO: Should we just copy the source here so we don't need to rewrap it in BinaryData?
                    // Use Azure.Core's ToObjectFromJson that does all the reasonable
                    // things and also turns objects into Dictionary<string, object> and
                    // arrays into List<object>
                    object? parsed = BinaryData.FromString(value.GetRawText()).ToObjectFromJson();
                    outputs[prop.Name] = parsed;
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException($"Failed to parse output {prop}", e);
                }
            }
        }

        // Patch up output references
        foreach (ProvisioningOutput output in plan.Infrastructure.GetProvisionableResources().OfType<ProvisioningOutput>())
        {
            if (outputs.TryGetValue(output.BicepIdentifier, out object? value) &&
                value is not null)
            {
                output.Value = value;
            }
        }

        return new ProvisioningDeployment(plan, options, deployment, outputs);
    }

    public static ArmDeploymentValidateResult ValidateInResourceGroup(
        this ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            ValidateInResourceGroupInternal(
                plan,
                resourceGroupName,
                options,
                async: false,
                cancellationToken)
            .EnsureCompleted();

    public static async Task<ArmDeploymentValidateResult> ValidateInResourceGroupAsync(
        this ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options = default,
        CancellationToken cancellationToken = default) =>
            await ValidateInResourceGroupInternal(
                plan,
                resourceGroupName,
                options,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

    private static async Task<ArmDeploymentValidateResult> ValidateInResourceGroupInternal(
        ProvisioningPlan plan,
        string resourceGroupName,
        ProvisioningDeploymentOptions? options,
        bool async = true,
        CancellationToken cancellationToken = default)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = plan.CompileArmTemplate();

        // Default the options
        options ??= new ProvisioningDeploymentOptions();

        // Get the resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(options, async, cancellationToken).ConfigureAwait(false);
        ResourceGroupResource rg = async ?
            await sub.GetResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false) :
            sub.GetResourceGroup(resourceGroupName, cancellationToken);

        // Create a deployment to validate
        string deploymentName = $"{resourceGroupName}-validation";
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent deploymentContent =
            new(
                new Azure.ResourceManager.Resources.Models.ArmDeploymentProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental)
                {
                    Template = BinaryData.FromString(armTemplate)
                });

        // Validate the deployment
        ArmDeploymentResource deployment = options.ArmClient.GetArmDeploymentResource(ArmDeploymentResource.CreateResourceIdentifier(rg.Id, deploymentName));
        ArmOperation<ArmDeploymentValidateResult> deploymentValidation = async ?
            await deployment.ValidateAsync(WaitUntil.Completed, deploymentContent, cancellationToken).ConfigureAwait(false) :
            deployment.Validate(WaitUntil.Completed, deploymentContent, cancellationToken);

        return deploymentValidation.Value;
    }

    /// <summary>
    /// Use the CLI to lint your generated Bicep.
    /// </summary>
    public static IReadOnlyList<BicepErrorMessage> Lint(this ProvisioningPlan plan, string? optionalDirectoryPath = null) =>
        WithOptionalTempBicep(plan, optionalDirectoryPath, path => BicepTool.Value.Lint(path));

    /// <summary>
    /// Use the CLI to generate an ARM template that can be validated or deployed.
    /// </summary>
    public static string CompileArmTemplate(this ProvisioningPlan plan, string? optionalDirectoryPath = null) =>
        WithOptionalTempBicep(plan, optionalDirectoryPath, path => BicepTool.Value.GetArmTemplate(path));

    // TODO: Warn in docs that this will write to disk if you don't give me a dirToCleanup
    // (i.e., you haven't already saved) and we'll try to clean it up but ignore failures
    // and potentially leave infra definitions on disk.  You should save it yourself
    // somewhere if there's anything you'd consider secure that's easier to clean up
    // outside of your dirToCleanup directory.
    private static T WithOptionalTempBicep<T>(ProvisioningPlan plan, string? optionalPath, Func<string, T> action)
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
                path = plan.Save(dirToCleanup).FirstOrDefault();
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
            do { path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); }
            while (Directory.Exists(path) || File.Exists(path));
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
