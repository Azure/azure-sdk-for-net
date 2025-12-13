// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Client that integrates AzureAIToolClient with Agent Framework.
/// </summary>
internal sealed class ToolClient : IAsyncDisposable
{
    private readonly AzureAIToolClientAsync _toolClient;
    private IReadOnlyList<AIFunction>? _aiFunctionCache;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolClient"/> class.
    /// </summary>
    /// <param name="toolClient">The Azure AI tool client.</param>
    public ToolClient(AzureAIToolClientAsync toolClient)
    {
        _toolClient = toolClient ?? throw new ArgumentNullException(nameof(toolClient));
    }

    /// <summary>
    /// Lists all available tools as Agent Framework AIFunction instances.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of AIFunction tools.</returns>
    public async Task<IReadOnlyList<AIFunction>> ListToolsAsync(CancellationToken cancellationToken = default)
    {
        if (_aiFunctionCache != null)
        {
            return _aiFunctionCache;
        }

        var azureTools = await _toolClient.ListToolsAsync(cancellationToken).ConfigureAwait(false);
        var aiFunctions = new List<AIFunction>();

        foreach (var azureTool in azureTools)
        {
            var aiFunction = ConvertToAgentFrameworkTool(azureTool);
            aiFunctions.Add(aiFunction);
        }

        _aiFunctionCache = aiFunctions;
        return _aiFunctionCache;
    }

    private AIFunction ConvertToAgentFrameworkTool(FoundryTool azureTool)
    {
        // Create wrapper function that invokes the Azure tool
        var toolName = azureTool.Name;
        var toolDescription = azureTool.Description ?? string.Empty;

        // Use a simple delegate-based approach
        [Description("")]
        async Task<string> InvokeToolAsync(Dictionary<string, object?> arguments)
        {
            var result = await azureTool.InvokeAsync(arguments).ConfigureAwait(false);
            return result?.ToString() ?? string.Empty;
        }

        // Create the AIFunction using the factory with name and description
        return AIFunctionFactory.Create(
            method: (Dictionary<string, object?> arguments) => InvokeToolAsync(arguments),
            name: toolName,
            description: toolDescription);
    }

    /// <summary>
    /// Disposes the tool client and releases resources.
    /// </summary>
    /// <returns>A task representing the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (_toolClient != null)
        {
            await _toolClient.DisposeAsync().ConfigureAwait(false);
        }
    }
}
