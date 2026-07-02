// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for configuring a project responses client. </summary>
public partial class ProjectOAIResponsesClientOptions : ResponsesClientOptions
{
    private string _apiVersion;
    private string _agentName;

    /// <summary> Initializes a new instance of <see cref="ProjectOAIResponsesClientOptions"/>. </summary>
    public ProjectOAIResponsesClientOptions() : base()
    {
        _apiVersion = "v1";
    }

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

    /// <summary> Gets or sets the agent name used when building an agent endpoint. </summary>
    public string AgentName
    {
        get => _agentName;
        set
        {
            AssertNotFrozen();
            _agentName = value;
        }
    }

    internal AuthenticationTokenProvider TokenProvider { get; set; }

    /// <summary>
    /// Implicitly converts a <see cref="ProjectOpenAIClientOptions"/> instance to a new
    /// <see cref="ProjectOAIResponsesClientOptions"/> instance.
    /// </summary>
    /// <remarks>
    /// The conversion produces a fresh, unfrozen snapshot copy of the source's public and
    /// project-specific properties. It does not carry internal pipeline policy lists
    /// (<c>PerCallPolicies</c>, <c>PerTryPolicies</c>, <c>BeforeTransportPolicies</c>) because the
    /// HTTP pipeline is built from the source instance before this conversion is needed; the
    /// destination instance is only consulted by <see cref="ResponsesClient"/> for its own
    /// properties such as <see cref="ResponsesClientOptions.Endpoint"/>.
    /// </remarks>
    /// <param name="source"> The source options instance to convert. </param>
    public static implicit operator ProjectOAIResponsesClientOptions(ProjectOpenAIClientOptions source)
    {
        if (source is null)
        {
            return null;
        }

        ProjectOAIResponsesClientOptions destination = new()
        {
            // OpenAIClientOptions / ResponsesClientOptions shared surface
            Endpoint = source.Endpoint,
            OrganizationId = source.OrganizationId,
            ProjectId = source.ProjectId,
            UserAgentApplicationId = source.UserAgentApplicationId,
            // ClientPipelineOptions base surface
            RetryPolicy = source.RetryPolicy,
            MessageLoggingPolicy = source.MessageLoggingPolicy,
            Transport = source.Transport,
            NetworkTimeout = source.NetworkTimeout,
            ClientLoggingOptions = source.ClientLoggingOptions,
            EnableDistributedTracing = source.EnableDistributedTracing,
            // Project-specific surface
            ApiVersion = source.ApiVersion,
            AgentName = source.AgentName,
            TokenProvider = source.TokenProvider,
        };

        return destination;
    }
}
