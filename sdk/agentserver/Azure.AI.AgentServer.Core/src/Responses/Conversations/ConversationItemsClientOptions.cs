// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.AgentServer.Core.Responses.Conversations;

/// <summary>
/// Options for configuring <see cref="ConversationItemsClient"/>.
/// </summary>
public sealed class ConversationItemsClientOptions : ClientOptions
{
    /// <summary>
    /// Service API versions supported by <see cref="ConversationItemsClient"/>.
    /// </summary>
    public enum ServiceVersion
    {
        /// <summary>
        /// Service version <c>2025-11-15-preview</c>.
        /// </summary>
        V2025_11_15_Preview = 1
    }

    internal const ServiceVersion LatestVersion = ServiceVersion.V2025_11_15_Preview;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationItemsClientOptions"/> class.
    /// </summary>
    /// <param name="version">The service API version.</param>
    public ConversationItemsClientOptions(ServiceVersion version = LatestVersion)
    {
        ApiVersion = version switch
        {
            ServiceVersion.V2025_11_15_Preview => "2025-11-15-preview",
            _ => throw new NotSupportedException($"The service version '{version}' is not supported.")
        };
    }

    internal string ApiVersion { get; }

    internal IList<string> CredentialScopes { get; } = new List<string>
    {
        "https://ai.azure.com/.default"
    };
}
