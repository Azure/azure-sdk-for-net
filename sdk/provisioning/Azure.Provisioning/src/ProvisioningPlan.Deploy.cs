// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Provisioning;

// This is a draft of validation/deployment.  It's currently scoped to resource
// groups to help feel out whether we want to offer this experience, but we'd
// also want to expand to subscriptions, management groups, tenants, etc.

public partial class ProvisioningPlan
{
    private async Task<SubscriptionResource> GetSubscriptionInternal(ArmClient? client, bool async, CancellationToken cancellationToken)
    {
        // Resolve the client
        client ??= _context.ArmClient;

        // Try a specific subscription if specified
        if (_context.DefaultSubscriptionId is not null)
        {
            SubscriptionCollection subs = client.GetSubscriptions();
            return async ?
                await subs.GetAsync(_context.DefaultSubscriptionId, cancellationToken).ConfigureAwait(false) :
                subs.Get(_context.DefaultSubscriptionId, cancellationToken);
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
    public ProvisioningDeployment DeployToNewResourceGroup(string resourceGroupName, AzureLocation location, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        DeployToNewResourceGroupInternal(
            resourceGroupName,
            location,
            client,
            async: false,
            cancellationToken)
        .EnsureCompleted();

    public async Task<ProvisioningDeployment> DeployToNewResourceGroupAsync(string resourceGroupName, AzureLocation location, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        await DeployToNewResourceGroupInternal(
            resourceGroupName,
            location,
            client,
            async: true,
            cancellationToken)
        .ConfigureAwait(false);

    private async Task<ProvisioningDeployment> DeployToNewResourceGroupInternal(string resourceGroupName, AzureLocation location, ArmClient? client, bool async, CancellationToken cancellationToken)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = CompileArmTemplate();

        // Create a resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(client, async, cancellationToken).ConfigureAwait(false);
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
        return ProcessDeploymentInternal(deployment);
    }

    public ProvisioningDeployment DeployToResourceGroup(string resourceGroupName, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        DeployToResourceGroupInternal(
            resourceGroupName,
            client,
            async: false,
            cancellationToken)
        .EnsureCompleted();

    public async Task<ProvisioningDeployment> DeployToResourceGroupAsync(string resourceGroupName, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        await DeployToResourceGroupInternal(
            resourceGroupName,
            client,
            async: true,
            cancellationToken)
        .ConfigureAwait(false);

    private async Task<ProvisioningDeployment> DeployToResourceGroupInternal(string resourceGroupName, ArmClient? client = default, bool async = true, CancellationToken cancellationToken = default)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = CompileArmTemplate();

        // Get the resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(client, async, cancellationToken).ConfigureAwait(false);
        ResourceGroupResource rg = async ?
            await sub.GetResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false) :
            sub.GetResourceGroup(resourceGroupName, cancellationToken);
        ArmDeploymentCollection deployments = rg.GetArmDeployments();

        // Deploy the ARM template
        ArmDeploymentResource deployment = await CreateDeploymentInternal(resourceGroupName, deployments, armTemplate, async, cancellationToken).ConfigureAwait(false);

        // Create the result
        return ProcessDeploymentInternal(deployment);
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

    private ProvisioningDeployment ProcessDeploymentInternal(ArmDeploymentResource deployment)
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
        foreach (BicepOutput output in _infrastructure.GetResources().OfType<BicepOutput>())
        {
            if (outputs.TryGetValue(output.ResourceName, out object? value) &&
                value is not null)
            {
                output.Value = value;
            }
        }

        return new ProvisioningDeployment(_context, deployment, outputs);
    }

    public ArmDeploymentValidateResult ValidateInResourceGroup(string resourceGroupName, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        ValidateInResourceGroupInternal(
            resourceGroupName,
            client,
            async: false,
            cancellationToken)
        .EnsureCompleted();

    public async Task<ArmDeploymentValidateResult> ValidateInResourceGroupAsync(string resourceGroupName, ArmClient? client = default, CancellationToken cancellationToken = default) =>
        await ValidateInResourceGroupInternal(
            resourceGroupName,
            client,
            async: true,
            cancellationToken)
        .ConfigureAwait(false);

    private async Task<ArmDeploymentValidateResult> ValidateInResourceGroupInternal(string resourceGroupName, ArmClient? client = default, bool async = true, CancellationToken cancellationToken = default)
    {
        // Get the ARM template ready first because there's no point proceeding
        // if anything goes wrong there
        string armTemplate = CompileArmTemplate();

        // Get the resource group to deploy into
        SubscriptionResource sub = await GetSubscriptionInternal(client, async, cancellationToken).ConfigureAwait(false);
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
        ArmDeploymentResource deployment = client.GetArmDeploymentResource(ArmDeploymentResource.CreateResourceIdentifier(rg.Id, deploymentName));
        ArmOperation<ArmDeploymentValidateResult> deploymentValidation = async ?
            await deployment.ValidateAsync(WaitUntil.Completed, deploymentContent, cancellationToken).ConfigureAwait(false) :
            deployment.Validate(WaitUntil.Completed, deploymentContent, cancellationToken);

        return deploymentValidation.Value;
    }
}
