// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tools;

/// <summary>
/// Options for configuring the Azure AI Tool Client.
/// </summary>
public class FoundryToolClientOptions : ClientOptions
{
    /// <summary>
    /// Gets or sets the name of the agent. Defaults to "$default".
    /// </summary>
    public string AgentName { get; set; } = "$default";

    /// <summary>
    /// Service version.
    /// </summary>
    public enum ServiceVersion
    {
        /// <summary>
        /// Default version.
        /// </summary>
        V1 = 1,
    }

    /// <summary>
    /// Gets or sets the list of tool definitions.
    /// </summary>
    public IList<FoundryTool> Tools { get; set; } = new List<FoundryTool>();

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
    /// Initializes a new instance of the <see cref="FoundryToolClientOptions"/> class.
    /// </summary>
    public FoundryToolClientOptions(ServiceVersion version = ServiceVersion.V1)
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
