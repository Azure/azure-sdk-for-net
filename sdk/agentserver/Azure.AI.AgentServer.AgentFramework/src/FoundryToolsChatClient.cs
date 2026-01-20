// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.AI;
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.AgentFramework;

internal sealed class FoundryToolsChatClient : DelegatingChatClient, IAsyncDisposable
{
    private readonly ToolClient _toolClient;

    public FoundryToolsChatClient(
        IChatClient innerClient,
        Uri projectEndpoint,
        TokenCredential credential,
        IReadOnlyList<FoundryTool> foundryTools,
        FoundryToolClientOptions? clientOptions = null)
        : base(innerClient)
    {
        ArgumentNullException.ThrowIfNull(projectEndpoint);
        ArgumentNullException.ThrowIfNull(credential);
        ArgumentNullException.ThrowIfNull(foundryTools);

        var options = clientOptions ?? new FoundryToolClientOptions();
        options.Tools = new List<FoundryTool>(foundryTools);

        _toolClient = new ToolClient(new FoundryToolClient(projectEndpoint, credential, options));
    }

    public override async Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var updatedOptions = await CreateOptionsAsync(options, cancellationToken).ConfigureAwait(false);
        return await InnerClient.GetResponseAsync(messages, updatedOptions, cancellationToken).ConfigureAwait(false);
    }

    public override async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages,
        ChatOptions? options = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var updatedOptions = await CreateOptionsAsync(options, cancellationToken).ConfigureAwait(false);
        await foreach (var update in InnerClient.GetStreamingResponseAsync(messages, updatedOptions, cancellationToken)
                           .ConfigureAwait(false))
        {
            yield return update;
        }
    }

    public async ValueTask DisposeAsync() => await _toolClient.DisposeAsync().ConfigureAwait(false);

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            _toolClient.DisposeAsync().AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        base.Dispose(disposing);
    }

    private async Task<ChatOptions?> CreateOptionsAsync(
        ChatOptions? options,
        CancellationToken cancellationToken)
    {
        var foundryTools = await _toolClient.ListToolsAsync(cancellationToken).ConfigureAwait(false);
        if (foundryTools.Count == 0)
        {
            return options;
        }

        var updatedOptions = options?.Clone() ?? new ChatOptions();
        var mergedTools = MergeTools(updatedOptions.Tools, foundryTools);
        updatedOptions.Tools = mergedTools;

        return updatedOptions;
    }

    private static IList<AITool> MergeTools(
        IList<AITool>? requestTools,
        IReadOnlyList<AIFunction> foundryTools)
    {
        List<AITool> merged = [];
        HashSet<string> names = new(StringComparer.OrdinalIgnoreCase);

        AddUnique(merged, names, requestTools);
        AddUnique(merged, names, foundryTools);

        return merged;
    }

    private static void AddUnique(ICollection<AITool> target, ISet<string> names, IEnumerable<AITool>? tools)
    {
        if (tools is null)
        {
            return;
        }

        foreach (var tool in tools)
        {
            if (tool is null)
            {
                continue;
            }

            if (names.Add(tool.Name))
            {
                target.Add(tool);
            }
        }
    }
}
