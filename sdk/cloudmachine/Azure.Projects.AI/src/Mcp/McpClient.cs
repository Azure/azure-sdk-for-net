// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

internal class McpClient
{
    private McpSession _session;
    private ClientPipeline _pipeline = ClientPipeline.Create();

    public Uri ServerEndpoint {get;}

    public McpClient(Uri endpoint)
    {
        _session = new McpSession(endpoint, _pipeline);
        ServerEndpoint = endpoint;
    }

    public async Task StartAsync()
    {
        await _session.EnsureInitializedAsync().ConfigureAwait(false);
    }

    public void Stop()
    {
        _session.Stop();
    }

    public async Task<BinaryData> ListToolsAsync()
    {
        if (_session == null)
            throw new InvalidOperationException("Session is not initialized. Call StartAsync() first.");

        return await _session.SendMethod("tools/list").ConfigureAwait(false);
    }

    public async Task<BinaryData> CallToolAsync(string toolName, BinaryData parameters)
    {
        if (_session == null)
            throw new InvalidOperationException("Session is not initialized. Call StartAsync() first.");

        Console.WriteLine($"Calling tool {toolName}...");
        return await _session.CallTool(toolName, parameters).ConfigureAwait(false);
    }
}
