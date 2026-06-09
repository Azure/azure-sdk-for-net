// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Options for <see cref="OptimizationConfigLoader.LoadConfigAsync"/>.
/// </summary>
public class ConfigLoaderOptions
{
    /// <summary>
    /// Override the local config directory path. Defaults to <c>OPTIMIZATION_LOCAL_DIR</c>
    /// environment variable or <c>.agent_configs/</c>.
    /// </summary>
    public string ConfigDirectory { get; set; }

    /// <summary>
    /// Credential used for authenticating to the resolver API.
    /// A <c>DefaultAzureCredential</c> or other <c>AuthenticationTokenProvider</c> must be provided
    /// when using the resolver API (Priority 2).
    /// </summary>
    public AuthenticationTokenProvider Credential { get; set; }
}
