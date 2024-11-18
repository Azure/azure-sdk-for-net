// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.ResourceManager.Resources;

// This needs to go, but we should discuss whether to directly translate or
// we should just simplify it here and let you drop down to ARM if you need more.
using ArmProvisioningState = Azure.ResourceManager.Resources.Models.ResourcesProvisioningState;

namespace Azure.Provisioning;

// This is a draft to explore convenience APIs to make it easier to deploy
// and immediately make use of Azure resources.  It's likely going to change
// a fair bit in the near future.

/// <summary>
/// Represents the result of a live deployment including any errors and outputs.
/// </summary>
public class ProvisioningDeployment
{
    /// <summary>
    /// Gets the provisioning context that was used to deploy the resources.
    /// </summary>
    internal ProvisioningBuildOptions BuildOptions { get; }

    /// <summary>
    /// Gets the options that were used to deploy the resources.
    /// </summary>
    internal ProvisioningDeploymentOptions DeploymentOptions { get; }

    /// <summary>
    /// Gets the <see cref="ArmDeploymentResource"/> that was used to deploy
    /// the infrastructure template.
    /// </summary>
    public ArmDeploymentResource Deployment { get; }

    /// <summary>
    /// Gets the <see cref="ArmProvisioningState"/> of the deployment.
    /// </summary>
    public ArmProvisioningState? ProvisioningState => Deployment.Data.Properties.ProvisioningState;

    /// <summary>
    /// Gets any optional errors that occurred during the deployment.
    /// </summary>
    public ResponseError? Error => Deployment.Data.Properties.Error;

    /// <summary>
    /// Gets a dictionary of template outputs from the deployment.  This is a
    /// simple name/value mapping.  You can also get the values directly from
    /// any <see cref="ProvisioningOutput"/> instances as they'll have been updated
    /// after a successful deployment and carry additional information - like
    /// whether the value is considered secure.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Outputs { get; }
    // TODO: Do we want to replace this with IReadOnlyDict<string, ProvisioningOutput>
    // to make it harder to misuse?

    /// <summary>
    /// Creates a new <see cref="ProvisioningDeployment"/>.
    /// </summary>
    /// <param name="plan">
    /// The provisioning plan that was used to deploy the resources.
    /// </param>
    /// <param name="options">
    /// The options used to deploy the resources.
    /// </param>
    /// <param name="deployment">
    /// The <see cref="ArmDeploymentResource"/> that was used to deploy
    /// the infrastructure template.
    /// </param>
    /// <param name="outputs">
    /// A dictionary of template outputs from the deployment.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when the deployment resource doesn't have its Data populated.
    /// </exception>
    internal ProvisioningDeployment(ProvisioningPlan plan, ProvisioningDeploymentOptions options, ArmDeploymentResource deployment, IReadOnlyDictionary<string, object?> outputs)
    {
        BuildOptions = plan.BuildOptions;
        DeploymentOptions = options;
        Deployment = deployment.HasData ? deployment :
            throw new ArgumentException($"The {nameof(deployment)} must have its {nameof(ArmDeploymentResource.Data)} property set.", nameof(deployment));
        Outputs = outputs;
    }

#if EXPERIMENTAL_PROVISIONING
    /// <summary>
    /// Create a data-plane client for a specific Azure resource.
    /// </summary>
    /// <typeparam name="TClient">
    /// The type of client to create.  This can be inferred automatically from
    /// a resource implementing <see cref="IClientCreator{TClient, TOptions}"/>.
    /// </typeparam>
    /// <typeparam name="TOptions">
    /// The type of <see cref="ClientOptions"/> used to customize creation.
    /// This can be inferred automatically from a resource implementing
    /// <see cref="IClientCreator{TClient, TOptions}"/>.
    /// </typeparam>
    /// <param name="resource">
    /// A resource that was provisioned as part of this deployment.
    /// </param>
    /// <param name="credential"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Throw when trying to create a client from a failed deployment.
    /// </exception>
    public TClient CreateClient<TClient, TOptions>(IClientCreator<TClient, TOptions> resource, TokenCredential? credential = default, TOptions? options = default)
        where TOptions : ClientOptions
    {
        if (ProvisioningState != ArmProvisioningState.Succeeded)
        {
            throw new InvalidOperationException($"Cannot create a client because the deployment did not succeed: {Error}");
        }
        credential ??= DeploymentOptions.DefaultClientCredential;
        if (options is not null) { DeploymentOptions.ConfigureClientOptionsCallback?.Invoke(options); }
        return resource.CreateClient(Outputs, credential, options);
    }
#endif
}
