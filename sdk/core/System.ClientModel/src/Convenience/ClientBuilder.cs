// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel.Primitives;

[Experimental("SCME0002")]
internal class ClientBuilder : IClientBuilder
{
    private readonly ReferenceConfigurationSection _section;

    public ClientBuilder(IHostApplicationBuilder host, IConfigurationSection section)
    {
        _section = new(host.Configuration, section.Path);
    }

    internal ReferenceConfigurationSection ConfigurationSection => _section;

    // TODO (Phase 5a removal): Remove PostConfigure + PostConfigureAction.
    // Superseded by ConfigureCredential (credential overrides) and the
    // configureSettings callback on AddClient (settings overrides).
    public IClientBuilder PostConfigure(Action<ClientSettings> configure)
    {
        PostConfigureAction = configure;
        return this;
    }

    public IClientBuilder ConfigureCredential(Action<IConfigurationSection> configureOverrides)
    {
        ConfigureCredentialAction = configureOverrides;
        return this;
    }

    // TODO (Phase 5a removal): Remove with PostConfigure.
    internal Action<ClientSettings>? PostConfigureAction { get; private set; }

    internal Action<IConfigurationSection>? ConfigureCredentialAction { get; private set; }
}
