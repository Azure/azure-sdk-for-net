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
    /// Configures the <see cref="IClientBuilder"/> to use the specified factory function to create the credential object.
    /// </summary>
    /// <param name="factory">A method that creates a credential object from the specified <see cref="IConfigurationSection"/>.</param>
    IHostApplicationBuilder WithCredential(Func<IConfigurationSection, AuthenticationTokenProvider>? factory = default);
}
