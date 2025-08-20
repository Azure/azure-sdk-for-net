# Azure SDK MCP Servers

This document details how to author, publish and use [MCP servers](https://github.com/modelcontextprotocol) for azure sdk team usage.

## Using the Azure SDK MCP Server

Run the below command to download and run the azure sdk engsys mcp server manually:

```
<repo root>/eng/common/mcp/azure-sdk-mcp.ps1 -Run
```

To install the mcp server for use within vscode copilot agent mode, run the following then launch vscode from the repository root.

```
<repo root>/eng/common/mcp/azure-sdk-mcp.ps1 -UpdateVsCodeConfig
```

*When updating the config the script will not overwrite any other server configs.*

The script will install the latest version of the azsdk cli executable from [tools releases](https://github.com/Azure/azure-sdk-tools/releases) and install it to `$HOME/.azure-sdk-mcp/azsdk`.

## Authoring an MCP server

Azure SDK MCP server code is in [azure-sdk-tools/tools/azsdk-cli/Azure.Sdk.Tools.Cli](https://github.com/Azure/azure-sdk-tools/tree/main/tools/azsdk-cli/Azure.Sdk.Tools.Cli).

Azure SDK MCP servers should support [stdio and sse transports](https://modelcontextprotocol.io/docs/concepts/transports#server-sent-events-sse).

When running in copilot the default is stdio mode, but SSE is useful to support for external debugging.

### Developing MCP servers in C#

See the [C# MCP SDK](https://github.com/modelcontextprotocol/csharp-sdk)

Add an [SSE transport](https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples/AspNetCoreSseServer)

TODO: Add the azsdk-cli project to pull in MCP server dependencies from the repo

