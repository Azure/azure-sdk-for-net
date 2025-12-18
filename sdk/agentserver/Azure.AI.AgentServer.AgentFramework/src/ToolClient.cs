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
internal sealed class ToolClient : IAIFunctionProvider, IAsyncDisposable
{
    private readonly AzureAIToolClient _toolClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolClient"/> class.
    /// </summary>
    /// <param name="toolClient">The Azure AI tool client.</param>
    public ToolClient(AzureAIToolClient toolClient)
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
        var azureTools = await _toolClient.ListToolsAsync(cancellationToken).ConfigureAwait(false);
        // Console.WriteLine($"[ToolClient] Converting {azureTools.Count} Azure tools to Agent Framework AIFunctions");

        var aiFunctions = new List<AIFunction>();

        foreach (var azureTool in azureTools)
        {
            var aiFunction = ConvertToAgentFrameworkTool(azureTool);
            aiFunctions.Add(aiFunction);
        }

        return aiFunctions;
    }

    private AIFunction ConvertToAgentFrameworkTool(FoundryTool azureTool)
    {
        // Create wrapper function that invokes the Azure tool
        var toolName = azureTool.Name;
        var toolDescription = azureTool.Description ?? string.Empty;
        var toolSource = azureTool.Source;

        var descriptionPreview = toolDescription.Length > 50
            ? toolDescription.Substring(0, 50) + "..."
            : toolDescription;
        // Console.WriteLine($"[ToolClient] Converting tool '{toolName}' (source: {toolSource}, description: {descriptionPreview}) to AIFunction");

        // Use a simple delegate-based approach
        [Description("")]
        async Task<string> InvokeToolAsync(AIFunctionArguments aiArgs, CancellationToken cancellationToken = default)
        {
            var arguments = aiArgs?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value) ?? new Dictionary<string, object?>();

            // Console.WriteLine($"[AIFunction] Wrapper invoking tool '{toolName}' with {arguments.Count} arguments");
            // Console.WriteLine($"[AIFunction] Arguments: {System.Text.Json.JsonSerializer.Serialize(arguments, new System.Text.Json.JsonSerializerOptions { WriteIndented = false })}");

            var result = await azureTool.InvokeAsync(arguments).ConfigureAwait(false);

            var resultLength = result?.ToString()?.Length ?? 0;
            // Console.WriteLine($"[AIFunction] Wrapper received result from tool '{toolName}' (length: {resultLength} chars)");

            // if (result == null || string.IsNullOrEmpty(result.ToString()))
            // {
            //     Console.WriteLine($"[AIFunction] WARNING: Tool '{toolName}' returned null or empty result!");
            // }

            return result?.ToString() ?? string.Empty;
        }

        // Create the AIFunction using the factory with name and description
        var options = new AIFunctionFactoryOptions
        {
            Name = toolName,
            Description = toolDescription,
            AdditionalProperties = azureTool.InputSchema != null
                ? new Dictionary<string, object?>
                {
                    // Preserve remote tool parameter schema for the LLM to know how to call it
                    ["parameters"] = azureTool.InputSchema
                }
                : null,
            ConfigureParameterBinding = _ => new AIFunctionFactoryOptions.ParameterBindingOptions
            {
                // Bind the entire arguments bag to our single AIFunctionArguments parameter and keep it out of schema generation
                BindParameter = (_, args) => args,
                ExcludeFromSchema = true
            }
        };

        return AIFunctionFactory.Create(
            method: (AIFunctionArguments arguments, CancellationToken ct) => InvokeToolAsync(arguments, ct),
            options: options);
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
