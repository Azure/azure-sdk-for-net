# Azure SDK MCP Servers

This document details how to author, publish and use [MCP servers](https://github.com/modelcontextprotocol) for azure sdk team usage.

## Using Azure SDK MCP Servers

Run the below command to download and run the default set mcp servers. It will overwrite your .vscode/mcp.json config file so back it up if you already have one.

```
<repo root>/eng/common/mcp/azure-sdk-mcp-runner.ps1 -Run -CreateVSCodeConfig ./.vscode/mcp.json
```

If you want to use a custom set of MCP servers, copy and edit `eng/common/mcp/mcp-servers.json` and run:

```
<repo root>/eng/common/mcp/azure-sdk-mcp-runner.ps1 -Run -CreateVSCodeConfig ./.vscode/mcp.json -Config <your mcp-servers.json config>
```

## Authoring an MCP server

MCP server code should be placed in [azure-sdk-tools/tools/mcp/&lt;language&gt;](https://github.com/Azure/azure-sdk-tools/tree/main/tools/mcp).

Azure SDK MCP servers should support [SSE transport](https://modelcontextprotocol.io/docs/concepts/transports#server-sent-events-sse).
This allows the mcp runner script to start up and manage all mcp servers.

The SSE transport should run on a port dictated by the `MCP_SSE_PORT` environment variable. This will be passed in when the server is started.

### Python

See the [Python MCP SDK](https://github.com/modelcontextprotocol/python-sdk)

Add an [SSE transport](https://github.com/modelcontextprotocol/python-sdk?tab=readme-ov-file#mounting-to-an-existing-asgi-server)

### Typescript

See the [Typescript MCP SDK](https://github.com/modelcontextprotocol/typescript-sdk)

Add an [SSE transport](https://github.com/modelcontextprotocol/typescript-sdk?tab=readme-ov-file#http-with-sse)

### C#

See the [C# MCP SDK](https://github.com/modelcontextprotocol/csharp-sdk)

Add an [SSE transport](https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples/AspNetCoreSseServer)

C# servers should be built as static executables and published as an azure artifacts universal package containing the executable and a `start.ps1` script.
The `start.ps1` script should invoke the executable in the package.

## Publishing an MCP server

The mcp servers are hosted on two feeds, one public and one private:

https://dev.azure.com/azure-sdk/public/_artifacts/feed/azure-sdk-mcp

https://dev.azure.com/azure-sdk/internal/_artifacts/feed/azure-sdk-mcp-private

Run the &lt;pipeline TODO&gt; to publish your mcp package to either feed, then update `mcp-servers.json` with the details (package name, version, type, feed) and pick a port that is unused in the config.
