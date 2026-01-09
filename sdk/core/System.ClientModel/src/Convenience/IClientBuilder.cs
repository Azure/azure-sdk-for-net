// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a builder interface for configuring client applications.
/// </summary>
public interface IClientBuilder : IHostApplicationBuilder
{
    /// <summary>
    /// Gets or sets a factory function to create credential objects based on the provided <see cref="IConfigurationSection"/>.
    /// </summary>
    Func<IConfigurationSection, object> CredentialFactory { get; set; }
}
