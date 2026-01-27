// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives.Tests;

/// <summary>
/// Test implementation of ClientSettings for testing configuration loading.
/// </summary>
internal class TestClientSettings : ClientSettings
{
    public Uri? Endpoint { get; set; }

    public TimeSpan? Timeout { get; set; }

    public string? CustomProperty { get; set; }

    public TestClientOptions? Options { get; set; }

    protected override void BindCore(IConfigurationSection section)
    {
        string? endpointValue = section["Endpoint"];
        if (!string.IsNullOrEmpty(endpointValue))
        {
            Endpoint = new Uri(endpointValue);
        }

        if (TimeSpan.TryParse(section["Timeout"], out TimeSpan timeout))
        {
            Timeout = timeout;
        }

        CustomProperty = section["CustomProperty"];

        IConfigurationSection optionsSection = section.GetSection("Options");
        if (optionsSection.Exists())
        {
            Options = new TestClientOptions(optionsSection);
        }
    }
}
