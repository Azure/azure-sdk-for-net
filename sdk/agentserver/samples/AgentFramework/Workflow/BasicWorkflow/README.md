# Agent Framework Simple Workflow Sample

This sample introduces the use of AI agents as executors within a workflow, then runs the workflow with agent adapter using AIAgent exposed from it.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
- Access to github packages for nightly builds, see [FAQs](../../../README.md#faqs) below.
- Azure OpenAI endpoint with a deployment (e.g., gpt-4o-mini)
- Azure CLI (for Docker authentication)

## Running with Docker

### Prerequisites for Docker

- Docker Desktop or Docker Engine installed
- Azure OpenAI service endpoint and deployment
- Azure CLI installed and logged in (`az login`)

### Build the Docker Image

From the repository root directory (`azure-sdk-for-net/`), run:

```bash
docker build \
  -f sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/Dockerfile \
  -t basicworkflow:latest \
  .
```

**Note**: The build context must be the repository root directory, not the `sdk/agentserver/` or BasicWorkflow directory, because the Dockerfile needs to access the Directory.Build.props chain and source code of the project references (AgentFramework, Core, Contracts).

### Run the Container

```bash
docker run -d \
  --name basicworkflow \
  -p 8088:8088 \
  -e AZURE_OPENAI_ENDPOINT="https://lixiaoli-hosted-agents-resource.cognitiveservices.azure.com" \
  -e AZURE_OPENAI_DEPLOYMENT_NAME="gpt-5.1" \
  -v ~/.azure:/root/.azure:ro \
  basicworkflow:latest
```

**Configuration**:

- `-p 8088:8088`: Maps port 8088 from the container to your host machine
- `-e AZURE_OPENAI_ENDPOINT`: **Required** - Your Azure OpenAI service endpoint
- `-e AZURE_OPENAI_DEPLOYMENT_NAME`: Optional (defaults to "gpt-4o-mini" if not specified)
- `-v ~/.azure:/root/.azure:ro`: Mounts your Azure credentials for DefaultAzureCredential authentication

**Important Note**: Environment variables defined in your shell (like in `.zshrc` or `.bashrc`) are **not** automatically passed to Docker containers. You must explicitly specify them using the `-e` flag in the `docker run` command.

**Alternative Authentication**: Instead of mounting ~/.azure, you can use service principal environment variables:

```bash
docker run -d \
  --name basicworkflow \
  -p 8088:8088 \
  -e AZURE_OPENAI_ENDPOINT="https://your-resource.openai.azure.com/" \
  -e AZURE_OPENAI_DEPLOYMENT_NAME="gpt-4o-mini" \
  -e AZURE_CLIENT_ID="your-client-id" \
  -e AZURE_CLIENT_SECRET="your-client-secret" \
  -e AZURE_TENANT_ID="your-tenant-id" \
  basicworkflow:latest
```

### Test the Running Container

#### 1. Verify the container is running

```bash
docker ps | grep basicworkflow
docker logs basicworkflow
```

#### 2. Test the translation workflow

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"input": "Hello world!"}'
```

The workflow translates the input through a chain: English → French → Spanish → English

#### 3. Test with streaming enabled

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"stream": true, "input": "Hello world!"}'
```

This returns a server-sent events (SSE) stream with incremental response chunks.

### Troubleshooting

**Issue: "AZURE_OPENAI_ENDPOINT is not set" error**

```bash
# Solution: Ensure the environment variable is set in docker run
docker run -e AZURE_OPENAI_ENDPOINT="https://your-resource.openai.azure.com/" ...
```

**Issue: Authentication fails despite credentials mount**

```bash
# Solution: Verify Azure CLI login on host
az account show

# Re-login if needed
az login
```

**Issue: Build fails with "project file not found" or "Invalid framework identifier"**

```bash
# Solution: Ensure you're running docker build from repository root directory
cd /path/to/azure-sdk-for-net/
docker build -f sdk/agentserver/dist/samples/AgentFramework/Workflow/BasicWorkflow/Dockerfile -t basicworkflow:latest .
```

**Issue: Permission denied on Azure credentials**

```bash
# Solution: Ensure the mount is read-only and credentials directory exists
ls -la ~/.azure
docker run -v ~/.azure:/root/.azure:ro ...
```

### Managing the Container

```bash
# View logs in real-time
docker logs -f basicworkflow

# Stop the container
docker stop basicworkflow

# Remove the container
docker rm basicworkflow

# Check resource usage
docker stats basicworkflow
```
