// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;

namespace Azure.AI.AgentServer.Core.Tools;

/// <summary>
/// Options for configuring the Azure AI Tool Client.
/// </summary>
public class AzureAIToolClientOptions
{
    /// <summary>
    /// Gets or sets the name of the agent. Defaults to "$default".
    /// </summary>
    public string AgentName { get; set; } = "$default";

    /// <summary>
    /// Gets or sets the list of tool definitions.
    /// </summary>
    public IList<ToolDefinition> Tools { get; set; } = new List<ToolDefinition>();

    /// <summary>
    /// Gets or sets the user information for tool invocations.
    /// </summary>
    public UserInfo? User { get; set; }

    /// <summary>
    /// Gets or sets the API version to use. Defaults to "2025-05-15-preview".
    /// </summary>
    public string ApiVersion { get; set; } = "2025-05-15-preview";

    /// <summary>
    /// Gets or sets the credential scopes for authentication.
    /// </summary>
    public IList<string> CredentialScopes { get; set; } = new List<string>
    {
        "https://ai.azure.com/.default"
    };

    /// <summary>
    /// Gets the internal tool configuration parser.
    /// </summary>
    internal ToolConfigurationParser ToolConfig { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureAIToolClientOptions"/> class.
    /// </summary>
    public AzureAIToolClientOptions()
    {
        ToolConfig = new ToolConfigurationParser(Tools);
    }

    /// <summary>
    /// Validates and parses the tool configuration.
    /// </summary>
    internal void ValidateAndParse()
    {
        ToolConfig = new ToolConfigurationParser(Tools);
    }
}
