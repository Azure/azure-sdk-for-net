// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Configuration-bindable settings for hosted resilient-task storage.
/// The inherited credential and <see cref="Endpoint"/> are resolved from one configuration
/// section so task-storage identity and location cannot be configured independently.
/// </summary>
[Experimental("SCME0002")]
public class ResilientTaskSettings : ClientSettings
{
    /// <summary>Gets or sets the Azure AI Foundry project endpoint used for task storage.</summary>
    public Uri? Endpoint { get; set; }

    /// <summary>Binds the task-storage endpoint from the named configuration section.</summary>
    /// <param name="section">The configuration section.</param>
    protected override void BindCore(IConfigurationSection section)
    {
        string? value = section["Endpoint"];
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        if (!Uri.TryCreate(value, UriKind.Absolute, out Uri? endpoint))
        {
            throw new InvalidOperationException(
                $"Configuration value '{section.Path}:Endpoint' must be an absolute URI; received '{value}'.");
        }

        Endpoint = endpoint;
    }
}
