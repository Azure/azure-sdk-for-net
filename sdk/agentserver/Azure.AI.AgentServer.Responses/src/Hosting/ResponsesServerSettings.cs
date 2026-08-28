// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Configuration-bindable settings for the Responses API server, loaded from an
/// <see cref="IConfigurationSection"/> via
/// <see cref="ResponsesServerHostExtensions.AddResponsesServer(Microsoft.Extensions.Hosting.IHostApplicationBuilder, string)"/>.
/// <para>
/// The inherited <see cref="ClientSettings.Credential"/> / <see cref="ClientSettings.CredentialProvider"/>
/// bind the identity used for BOTH Foundry response storage and resilient-task storage from the same
/// section, so the two can never diverge. <see cref="Endpoint"/> replaces the
/// <c>FOUNDRY_PROJECT_ENDPOINT</c> environment-variable read, and the option flags below replace the
/// <see cref="ResponsesServerOptions"/> shape when the host binds from configuration.
/// </para>
/// </summary>
[Experimental("SCME0002")]
public class ResponsesServerSettings : ClientSettings
{
    /// <summary>
    /// Gets or sets the Azure AI Foundry project endpoint used for response and task storage.
    /// Replaces the <c>FOUNDRY_PROJECT_ENDPOINT</c> environment variable. Required in hosted
    /// environments.
    /// </summary>
    public Uri? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the default model to use when <c>model</c> is omitted from a
    /// <c>CreateResponse</c> request. Mirrors <see cref="ResponsesServerOptions.DefaultModel"/>.
    /// </summary>
    public string? DefaultModel { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of conversation history items fetched by
    /// <see cref="ResponseContext.GetHistoryAsync"/>. Replaces the
    /// <c>DEFAULT_FETCH_HISTORY_ITEM_COUNT</c> environment variable. Default: 100.
    /// </summary>
    public int DefaultFetchHistoryCount { get; set; } = ResponsesServerOptions.DefaultFetchHistoryCountValue;

    /// <summary>
    /// Gets or sets whether background responses are resilient to process crashes and graceful
    /// shutdown. Mirrors <see cref="ResponsesServerOptions.ResilientBackground"/>.
    /// </summary>
    public bool ResilientBackground { get; set; }

    /// <summary>
    /// Gets or sets whether in-flight conversations accept steering (mid-turn additional input).
    /// Mirrors <see cref="ResponsesServerOptions.SteerableConversations"/>.
    /// </summary>
    public bool SteerableConversations { get; set; }

    /// <summary>
    /// Gets or sets an optional hook that customizes the <c>queued</c> envelope returned to the
    /// caller when a new turn is queued behind an active steerable conversation. Mirrors
    /// <see cref="ResponsesServerOptions.ResponseAcceptor"/>. Not configuration-bindable; set it
    /// via the <c>configureSettings</c> callback.
    /// </summary>
    public Func<Models.CreateResponse, ResponseContext, Models.ResponseObject>? ResponseAcceptor { get; set; }

    /// <summary>
    /// Binds the configuration values above from the given section. The inherited credential
    /// binding is applied by the base <see cref="ClientSettings.Bind(IConfigurationSection)"/>.
    /// </summary>
    /// <param name="section">The configuration section.</param>
    protected override void BindCore(IConfigurationSection section)
    {
        string? endpointValue = section["Endpoint"];
        if (!string.IsNullOrWhiteSpace(endpointValue))
        {
            if (!Uri.TryCreate(endpointValue, UriKind.Absolute, out Uri? endpoint))
            {
                throw InvalidConfiguration(section, "Endpoint", endpointValue, "an absolute URI");
            }

            Endpoint = endpoint;
        }

        string? defaultModel = section["DefaultModel"];
        if (!string.IsNullOrEmpty(defaultModel))
        {
            DefaultModel = defaultModel;
        }

        string? fetchCountValue = section["DefaultFetchHistoryCount"];
        if (!string.IsNullOrWhiteSpace(fetchCountValue))
        {
            if (!int.TryParse(
                fetchCountValue,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int fetchCount)
                || fetchCount <= 0)
            {
                throw InvalidConfiguration(
                    section,
                    "DefaultFetchHistoryCount",
                    fetchCountValue,
                    "a positive integer");
            }

            DefaultFetchHistoryCount = fetchCount;
        }

        string? resilientValue = section["ResilientBackground"];
        if (!string.IsNullOrWhiteSpace(resilientValue))
        {
            if (!bool.TryParse(resilientValue, out bool resilient))
            {
                throw InvalidConfiguration(
                    section,
                    "ResilientBackground",
                    resilientValue,
                    "true or false");
            }

            ResilientBackground = resilient;
        }

        string? steerableValue = section["SteerableConversations"];
        if (!string.IsNullOrWhiteSpace(steerableValue))
        {
            if (!bool.TryParse(steerableValue, out bool steerable))
            {
                throw InvalidConfiguration(
                    section,
                    "SteerableConversations",
                    steerableValue,
                    "true or false");
            }

            SteerableConversations = steerable;
        }
    }

    private static InvalidOperationException InvalidConfiguration(
        IConfigurationSection section,
        string key,
        string value,
        string expected)
        => new(
            $"Configuration value '{section.Path}:{key}' must be {expected}; received '{value}'.");

    /// <summary>
    /// Copies the option-shaped values into a <see cref="ResponsesServerOptions"/> so the rest of
    /// the registration pipeline (which is driven by <c>IOptions&lt;ResponsesServerOptions&gt;</c>)
    /// observes the configuration-bound values.
    /// </summary>
    internal void ApplyTo(ResponsesServerOptions options)
    {
        options.DefaultModel = DefaultModel;
        options.DefaultFetchHistoryCount = DefaultFetchHistoryCount;
        options.ResilientBackground = ResilientBackground;
        options.SteerableConversations = SteerableConversations;
        options.ResponseAcceptor = ResponseAcceptor;
    }
}
