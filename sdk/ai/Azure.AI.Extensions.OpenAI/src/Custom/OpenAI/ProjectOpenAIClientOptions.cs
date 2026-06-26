// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using OpenAI;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for configuring a project OpenAI client. </summary>
public partial class ProjectOpenAIClientOptions : OpenAIClientOptions
{
    private string _apiVersion;

    /// <summary> Gets or sets the API version used for project OpenAI requests. </summary>
    public string ApiVersion
    {
        get => _apiVersion;
        set
        {
            AssertNotFrozen();
            _apiVersion = value;
        }
    }

    /// <summary> Initializes a new instance of <see cref="ProjectOpenAIClientOptions"/>. </summary>
    public ProjectOpenAIClientOptions() : base()
    {
        _apiVersion = "v1";
    }

    /// <summary> Gets or sets the agent name used when building an agent endpoint. </summary>
    public string AgentName { get; set; } = null;
    internal AuthenticationTokenProvider TokenProvider { get; set; }
}
