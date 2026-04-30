// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel.Primitives;

internal class ClientBuilder : IClientBuilder
{
    private readonly ReferenceConfigurationSection _section;

    public ClientBuilder(IHostApplicationBuilder host, IConfigurationSection section)
    {
        _section = new(host.Configuration, section.Path);
    }

    internal ReferenceConfigurationSection ConfigurationSection => _section;

    public IClientBuilder PostConfigure(Action<ClientSettings> configure)
    {
        PostConfigureAction = configure;
        return this;
    }

    internal Action<ClientSettings>? PostConfigureAction { get; private set; }
}
