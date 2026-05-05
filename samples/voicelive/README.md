---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-voicelive
name: Azure VoiceLive samples for .NET
description: Samples demonstrating how to use the Azure VoiceLive SDK for .NET.
---

# Azure VoiceLive Samples for .NET

This folder contains samples demonstrating how to use the [Azure VoiceLive SDK for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/voicelive/Azure.AI.VoiceLive).

## Samples

### [Basic Voice Assistant](./basic-voice-assistant/)

Demonstrates the fundamental capabilities of the Azure VoiceLive SDK with a basic voice assistant that engages in natural conversation with proper interruption handling. This serves as the foundational example that showcases the core value proposition of unified speech-to-speech interaction. This sample shows how to:

- Create a simple voice assistant with speech-to-speech capability
- Handle user speech input with server-side voice activity detection
- Implement conversation interruption handling
- Use convenience methods like `ClearStreamingAudioAsync()` and `CancelResponseAsync()`
- Manage real-time audio capture and playback

**Prerequisites:**
- Azure subscription with VoiceLive access
- VoiceLive endpoint and API key (or Azure credentials)
- Microphone and speakers for audio I/O

### [Customer Service Bot](./customer-service-bot/)

Demonstrates how to build a sophisticated customer service voice bot using the Azure VoiceLive SDK with function calling capabilities. This sample provides real-time voice interaction for common customer service scenarios including order tracking, account management, returns processing, and technical support scheduling. This sample shows how to:

- Implement function calling within voice conversations
- Handle multiple business functions (order tracking, account management, returns, support)
- Manage complex conversation flows
- Implement structured data handling and responses
- Create a production-ready voice service bot

**Prerequisites:**
- Azure subscription with VoiceLive access
- VoiceLive endpoint and API key (or Azure credentials)
- Microphone and speakers for audio I/O

## Getting Started

1. Choose the sample that matches your use case:
   - **Basic Voice Assistant**: Start here if you're new to VoiceLive and want to learn the fundamentals
   - **Customer Service Bot**: Use if you want to build a production-ready voice bot with function calling

2. Follow the setup instructions in each sample's README

3. Run the sample with appropriate credentials and configuration

## More Information

- [Azure VoiceLive Documentation](https://learn.microsoft.com/en-us/azure/ai-services/voicelive/overview)
- [Azure AI Foundry Documentation](https://learn.microsoft.com/en-us/azure/ai-studio/what-is-ai-studio)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)
- [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net)
