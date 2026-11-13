// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a builder interface for configuring client applications.
/// </summary>
[Experimental("SCME0002")]
public interface IClientBuilder
{
    // TODO (Phase 5a removal): Remove this method. Replaced by ConfigureCredential
    // for credential overrides; settings overrides happen via the existing
    // Action<TSettings> configureSettings parameter on AddClient.
    /// <summary>
    /// Adds a configuration action to be executed after the initial configuration of <see cref="ClientSettings"/>.
    /// </summary>
    /// <param name="configure">Factory method to modify the <see cref="ClientSettings"/>.</param>
    IClientBuilder PostConfigure(Action<ClientSettings> configure);

    /// <summary>
    /// Adds a configuration action that mutates the <c>Credential</c>
    /// configuration section before it is handed to the registered
    /// <see cref="CredentialResolver"/> chain. Use this to override values
    /// such as <c>TenantId</c> or <c>ClientId</c> at registration time.
    /// </summary>
    /// <param name="configureOverrides">Callback that receives a writable
    /// view of the credential section.</param>
    IClientBuilder ConfigureCredential(Action<IConfigurationSection> configureOverrides);
}
