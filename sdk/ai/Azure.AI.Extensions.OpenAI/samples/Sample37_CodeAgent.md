# Sample on getting the responses from hosted code Agent in Azure.AI.Extensions.OpenAI.

**Note:** This feature is in the preview, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents). `Azure.AI.Projects` allow interactions with hosted agents using `HostedAgentDefinition`. In this example we will deploy the hosted agent and use it from the `Azure.AI.Extensions.OpenAI`.

## Hosted Code Agent Deployment prerequisites

In this example we will build the docker image for hosted Agent based of the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Run the sample
`Azure.AI.Projects` can be used only to create an `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder, containing agent code and dependencies. In our example, it is `Assets/AgentsCode` folder. **If you are using folder from the example, please go to step 4.**
2. Copy the contents of a [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py) to the file main.py in the `Assets` folder.
3. Create the `requirements.txt` in `Assets` folder with the next contents.

```
azure-ai-agentserver-core
azure-ai-agentserver-invocations
azure-ai-agentserver-responses
```

4. Change directory to `AgentsCode` folder and install all the required python dependencies.

```bash
pip install -r requirements.txt --target packages --platform manylinux2014_x86_64 --python-version 3.11 --implementation cp --only-binary=:all:
```

# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_CodeAgent
```

2. For brevity we will create the method, returning the `CreateAgentVersionFromCodeMetadata` object.

```C# Snippet:Sample_CodeAgentMetadata_CodeAgent
```

3. Create the hosted agent object from code.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Sync
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Async
```

4. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Sync
```

Asynchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Async
```

5. Create the response client to communicate with an Agent and get the response.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Sync
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Async
```

6. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Sync
```

Asynchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Async
```
