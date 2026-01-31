// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

internal class ClientBuilder : IClientBuilder
{
    private readonly IHostApplicationBuilder _host;
    private readonly ReferenceConfigurationSection _section;

    public ClientBuilder(IHostApplicationBuilder host, IConfigurationSection section)
    {
        _host = host;
        _section = new(host.Configuration, section.Path);
    }

    public IDictionary<object, object> Properties => _host.Properties;

    public IConfigurationManager Configuration => _host.Configuration;

    public IHostEnvironment Environment => _host.Environment;

    public ILoggingBuilder Logging => _host.Logging;

    public IMetricsBuilder Metrics => _host.Metrics;

    public IServiceCollection Services => _host.Services;

    internal ReferenceConfigurationSection ConfigurationSection => _section;

    public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null)
        where TContainerBuilder : notnull
    {
        _host.ConfigureContainer(factory, configure);
    }

    public IHostApplicationBuilder PostConfigure(Action<ClientSettings> configure)
    {
        PostConfigureAction = configure;
        return this;
    }

    internal Action<ClientSettings>? PostConfigureAction { get; private set; }
}
