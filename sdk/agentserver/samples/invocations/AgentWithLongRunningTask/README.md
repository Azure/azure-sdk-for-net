<!-- Begin standard disclaimer — do not modify -->
**IMPORTANT!** All samples and other resources made available in this GitHub repository ("samples") are designed to assist in accelerating development of agents, solutions, and agent workflows for various scenarios. Review all provided resources and carefully test output behavior in the context of your use case. AI responses may be inaccurate and AI actions should be monitored with human oversight. Learn more in the transparency documents for [Agent Service](https://learn.microsoft.com/en-us/azure/ai-foundry/responsible-ai/agents/transparency-note) and [Agent Framework](https://github.com/microsoft/agent-framework/blob/main/TRANSPARENCY_FAQ.md).

Agents, solutions, or other output you create may be subject to legal and regulatory requirements, may require licenses, or may not be suitable for all industries, scenarios, or use cases. By using any sample, you are acknowledging that any output created using those samples are solely your responsibility, and that you will comply with all applicable laws, regulations, and relevant safety standards, terms of service, and codes of conduct.

Third-party samples contained in this folder are subject to their own designated terms, and they have not been tested or verified by Microsoft or its affiliates.

Microsoft has no responsibility to you or others with respect to any of these samples or any resulting output.
<!-- End standard disclaimer -->

# What this sample demonstrates

Demonstrates the **long-running operations (LRO)** pattern with the Invocations protocol. The handler accepts a document submission, simulates background processing, and supports polling for status and cancellation. This is the standard pattern for operations that take more than a few seconds to complete.

## How It Works

### LRO Lifecycle

1. **Submit** (`POST /invocations`) — Accepts the document and returns `202 Accepted` with an invocation ID
2. **Poll** (`GET /invocations/{id}`) — Returns `running` (202) or `completed` (200) with results
3. **Cancel** (`DELETE /invocations/{id}`) — Cancels the running operation

### Agent Hosting

The agent is hosted using the [Azure AI AgentServer SDK](https://www.nuget.org/packages/Azure.AI.AgentServer.Invocations). Note that the handler is registered as a **singleton** to preserve job state across requests. See [Program.cs](Program.cs) for the full implementation.

### Agent Deployment

The hosted agent can be deployed to Microsoft Foundry using the Azure Developer CLI [ai agent](https://learn.microsoft.com/en-us/azure/ai-foundry/agents/concepts/hosted-agents?view=foundry&tabs=cli#create-a-hosted-agent) extension.

## Running the Agent Locally

### Prerequisites

1. **Azure AI Foundry Project**
   - Project created in [Azure AI Foundry](https://learn.microsoft.com/en-us/azure/ai-foundry/what-is-foundry?view=foundry#microsoft-foundry-portals)
   - Note your project endpoint URL

2. **Azure CLI** — `az login`

3. **.NET 10.0 SDK or later** — `dotnet --version`

### Environment Variables

| Variable | Required | Description |
|----------|----------|-------------|
| `AZURE_AI_PROJECT_ENDPOINT` | Yes | Your Azure AI Foundry project endpoint URL |

### Running the Sample

```bash
dotnet run
```

### Interacting with the Agent

**Step 1 — Submit a document:**

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: text/plain" \
  -d "The quick brown fox jumps over the lazy dog"
```

Response: `202 Accepted` with `Location` header containing the invocation ID.

**Step 2 — Poll for status:**

```bash
curl http://localhost:8088/invocations/{invocation-id}
```

Returns `202` while processing, then `200` with results when complete.

**Step 3 — (Optional) Cancel:**

```bash
curl -X DELETE http://localhost:8088/invocations/{invocation-id}
```

### Deploying the Agent to Microsoft Foundry

To deploy your agent to Microsoft Foundry, follow the comprehensive deployment guide at https://aka.ms/azdaiagent/docs

## Troubleshooting

### Images built on Apple Silicon or other ARM64 machines do not work on our service

We **recommend using `azd` cloud build**, which always builds images with the correct architecture.

If you choose to **build locally**, use:

```shell
docker build --platform=linux/amd64 -t image .
```
