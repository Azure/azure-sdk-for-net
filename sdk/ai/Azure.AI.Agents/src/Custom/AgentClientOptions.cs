// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Agents;

/// <summary> Client options for <see cref="AgentClient"/>. </summary>
public partial class AgentClientOptions : ClientPipelineOptions
{
    private string _userAgentApplicationId;
    /// <summary>
    /// An optional application ID to use as part of the request User-Agent header.
    /// </summary>
    public string UserAgentApplicationId
    {
        get => _userAgentApplicationId;
        set
        {
            AssertNotFrozen();
            _userAgentApplicationId = value;
        }
    }

    private const ServiceVersion LatestVersion = ServiceVersion.V2025_11_15_Preview;

    /// <summary> Initializes a new instance of AgentClientOptions. </summary>
    /// <param name="version"> The service version. </param>
    public AgentClientOptions(ServiceVersion version = LatestVersion)
    {
        Version = version switch
        {
            ServiceVersion.V2025_11_01 => "2025-11-01",
            ServiceVersion.V2025_11_15_Preview => "2025-11-15-preview",
            _ => throw new NotSupportedException()
        };
    }

    /// <summary> Gets the Version. </summary>
    internal string Version { get; }

    /// <summary> The version of the service to use. </summary>
    public enum ServiceVersion
    {
        /// <summary> Azure AI API version 2025-11-01. </summary>
        V2025_11_01 = 1,
        /// <summary> Azure AI API version 2025-11-15-preview. </summary>
        V2025_11_15_Preview = 2
    }
}
