// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives.Tests;

/// <summary>
/// Test implementation of ClientPipelineOptions with additional custom properties.
/// </summary>
internal class TestClientOptions : ClientPipelineOptions
{
    public string? ApiVersion { get; set; }

    internal TestClientOptions(IConfigurationSection section) : base(section)
    {
        // Bind custom TestClientOptions properties
        ApiVersion = section["ApiVersion"];
    }
}
