---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-voicelive
- azure-ai-foundry
name: Azure VoiceLive samples for .NET
description: Samples demonstrating how to use the Azure VoiceLive SDK for .NET.
---

# Azure VoiceLive Samples for .NET

This folder contains samples demonstrating how to use the [Azure VoiceLive SDK for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/voicelive/Azure.AI.VoiceLive).

## Samples

### [Agent Voice Assistant](./agent-voice-assistant/)

Demonstrates connecting to an **Azure AI Foundry agent** with voice interaction using the VoiceLive Agent V2 API. This sample shows how to:

- Connect to a pre-configured agent with tools and knowledge bases
- Enable full duplex voice conversation
- Handle agent responses and tool usage
- Manage session lifecycle

**Prerequisites:**
- Azure subscription with VoiceLive access
- Azure AI Foundry project with a deployed agent
- Azure CLI authentication or managed identity

### [MCP Voice Assistant](./mcp-voice-assistant/)

Demonstrates using the Azure VoiceLive SDK with **MCP (Model Context Protocol) servers** to augment the voice assistant with external tools and data sources. This sample shows how to:

- Configure MCP servers for tool integration
- Discover and use tools from MCP servers
- Handle tool calls during voice conversations
- Manage complex multi-tool workflows

**Prerequisites:**
- Azure subscription with VoiceLive access
- VoiceLive endpoint and API key (or Azure credentials)
- API version 2026-01-01-preview or later

## Getting Started

1. Choose the sample that matches your use case:
   - **Agent V2**: Use if you want to talk to a pre-built agent from Azure AI Foundry
   - **MCP**: Use if you want to extend the voice assistant with external MCP tools

2. Follow the setup instructions in each sample's README

3. Run the sample with appropriate credentials and configuration

## More Information

- [Azure VoiceLive Documentation](https://learn.microsoft.com/en-us/azure/ai-services/voicelive/overview)
- [Azure AI Foundry Documentation](https://learn.microsoft.com/en-us/azure/ai-studio/what-is-ai-studio)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)
- [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net)
