// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for configuring a project responses client. </summary>
public partial class ProjectResponsesClientOptions : ProjectOpenAIClientOptions
{
    /// <summary> Initializes a new instance of <see cref="ProjectResponsesClientOptions"/>. </summary>
    public ProjectResponsesClientOptions() : base()
    {
    }

    /// <summary>
    /// Convert a <see cref="ProjectOpenAIClientOptions"/> instance to a new
    /// <see cref="ProjectResponsesClientOptions"/> instance.
    /// </summary>
    /// <remarks>
    /// The conversion produces a fresh, unfrozen snapshot copy of the source's public and
    /// project-specific properties. It does not carry internal pipeline policy lists
    /// (<c>PerCallPolicies</c>, <c>PerTryPolicies</c>, <c>BeforeTransportPolicies</c>) because the
    /// HTTP pipeline is built from the source instance before this conversion is needed; the
    /// destination instance is only consulted by <see cref="ResponsesClient"/> for its own
    /// properties such as <see cref="ResponsesClientOptions.Endpoint"/>.
    /// </remarks>
    internal static ProjectResponsesClientOptions ToProjectResponsesClientOptions(ProjectOpenAIClientOptions source)
    {
        if (source is null)
        {
            return null;
        }

        ProjectResponsesClientOptions destination = new()
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

    // The supplied pipeline has already captured all policy lists. Only the
    // native client's option values need translating across the sibling types.
    [Experimental("OPENAI001")]
    internal ResponsesClientOptions ToNativeOptions() => new()
    {
        Endpoint = Endpoint,
        OrganizationId = OrganizationId,
        ProjectId = ProjectId,
        UserAgentApplicationId = UserAgentApplicationId,
        RetryPolicy = RetryPolicy,
        MessageLoggingPolicy = MessageLoggingPolicy,
        Transport = Transport,
        NetworkTimeout = NetworkTimeout,
        ClientLoggingOptions = ClientLoggingOptions,
        EnableDistributedTracing = EnableDistributedTracing
    };
}
