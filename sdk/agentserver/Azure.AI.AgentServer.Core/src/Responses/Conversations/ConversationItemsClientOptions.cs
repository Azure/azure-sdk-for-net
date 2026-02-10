// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.AgentServer.Core.Responses.Conversations;

/// <summary>
/// Options for configuring <see cref="ConversationItemsClient"/>.
/// </summary>
internal sealed class ConversationItemsClientOptions : ClientOptions
{
    /// <summary>
    /// Gets or sets the API version for conversation items operations.
    /// </summary>
    public string ApiVersion { get; set; } = "2025-11-15-preview";

    /// <summary>
    /// Gets or sets credential scopes used for authentication.
    /// </summary>
    public IList<string> CredentialScopes { get; set; } = new List<string>
    {
        "https://ai.azure.com/.default"
    };
}
