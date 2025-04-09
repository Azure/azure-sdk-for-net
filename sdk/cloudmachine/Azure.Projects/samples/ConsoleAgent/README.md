# OFXRAG Sample Application

## Overview
A command-line chat application demonstrating Azure OpenAI services with RAG (Retrieval-Augmented Generation) capabilities and MCP Servers.

## Features
* Interactive chat with GPT-4 Mini model
* Vector database for storing and retrieving facts
* MCP server integration
* Built-in tools including time retrieval

## Prerequisites
* An Azure subscription

## Getting Started

1. Open a terminal
1. Clone the repository
1. cd into the Azure.Projects\samples\OFXRAG\README.md directory
1. run `dotnet run -init` to provision resources and prepare for deployment`
1. run `azd init` to initialize the Azure Developer CLI`
   1. You may be prompted to login to your Azure subscription with 'azd auth'
1. Choose any name for the environment
1. run `azd up` to deploy the resources

## Usage

### Basic Chat
Type your message at the prompt and press Enter:
```
> What time is it?
```

### Available Commands

| Command | Description | Example |
|---------|-------------|---------|
| `bye` | Exit the application | `> bye` |
| `fact:` | Add a fact to the vector database | `> fact: The Earth completes one rotation every 24 hours` |
| `addmcp:` | Add an MCP server connection | `> addmcp: http://your-mcp-server/sse` |

### MCP Server Connection
To programmatically add an MCP server connection, add this code before the main chat loop:

```csharp
await tools.AddMcpServerAsync(new Uri("http://your-mcp-server/sse"));
```

## Built-in Tools
* `GetCurrentTime`: Returns the current system time in short time format
