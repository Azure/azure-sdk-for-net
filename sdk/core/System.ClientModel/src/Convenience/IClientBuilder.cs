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
    /// <param name="credential"></param>
    void SetCredentialObject(object credential);

    /// <summary>
    /// .
    /// </summary>
    IConfigurationSection ConfigurationSection { get; }
}
