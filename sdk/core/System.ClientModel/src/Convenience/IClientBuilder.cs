// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public interface IClientBuilder : IHostApplicationBuilder
{
    /// <summary>
    /// .
    /// </summary>
    Func<IConfigurationSection, object> CredentialFactory { get; set; }
}
