// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

// TODO: Decide if we want to make the name of this interface specific to Entra
// in case we ever decide we want to support other mechanisms in the future (i.e.
// an interface that could use named keys via a `resource.listKeys()` method).
// I don't want to support a less secure auth mechanism in v1 and I also think
// secretless APIs deserve the best names, so I'm planning to leave this unless
// we hear complaints and/or it confuses folks.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Allows easy creation of a data-plane client for a specific Azure resource.
/// </summary>
/// <typeparam name="TClient">
/// The type of client that can be created for this Azure resource.
/// </typeparam>
/// <typeparam name="TOptions">
/// The type of <see cref="ClientOptions"/> used to configure the client.
/// </typeparam>
/// <remarks>
/// This will be implemented explicitly by individual resources and you should
/// prefer calling <see cref="ProvisioningDeployment.CreateClient"/> instead
/// to construct data-plane client resources.
/// </remarks>
public interface IClientCreator<TClient, TOptions>
    where TOptions : ClientOptions
{
    // TODO: API to declare the outputs required for client creation so we can
    // automatically include them with a ResourceResolver

    /// <summary>
    /// Construct a <typeparamref name="TClient"/> instance for this resource
    /// that was deployed as part of this <paramref name="deployment"/>.  This
    /// is intended to be called from the
    /// <see cref="ProvisioningDeployment.CreateClient"/> user facing method.
    /// </summary>
    /// <param name="deployment">The deployment for this resource.</param>
    /// <param name="credential">A credential to use for creating the client.</param>
    /// <param name="options">Optional ClientOptions to use for creating the client.</param>
    /// <returns>A data-plane client for the provisioned resource.</returns>
    public TClient CreateClient(
        ProvisioningDeployment deployment,
        TokenCredential credential,
        TOptions? options = default);
}
