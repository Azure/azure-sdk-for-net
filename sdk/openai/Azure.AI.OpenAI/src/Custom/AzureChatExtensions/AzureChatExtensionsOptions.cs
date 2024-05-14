// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   These changes facilitate the consolidation and re-exposure of Azure-specific extensions to chat requests
//   like data sources and enhancements.

/// <summary>
/// An abstraction of additional settings used by chat completions to supplement standard behavior with
/// capabilities from configured Azure OpenAI extensions. These capabilities are specific to Azure OpenAI
/// and chat completions requests configured to use them will require use with with that service endpoint.
/// </summary>
public partial class AzureChatExtensionsOptions
{
    // CUSTOM CODE NOTE: this wrapper type for /extensions/chat/completions data sources is currently "client
    //                      only" and not yet reflected in the REST wire format. This will likely converge in
    //                      future versions but for exists outside of code generation.

    /// <summary>
    /// Gets the collection of data source configurations to use with Azure OpenAI extensions for chat
    /// completions.
    /// </summary>
    public IList<AzureChatExtensionConfiguration> Extensions { get; }

    /// <summary>
    /// Instantiates a new instance of AzureChatExtensionsOptions.
    /// </summary>
    public AzureChatExtensionsOptions()
    {
        Extensions = new List<AzureChatExtensionConfiguration>();
    }

    /// <summary> If provided, the configuration options for available Azure OpenAI chat enhancements. </summary>
    public AzureChatEnhancementConfiguration EnhancementOptions { get; }
}
