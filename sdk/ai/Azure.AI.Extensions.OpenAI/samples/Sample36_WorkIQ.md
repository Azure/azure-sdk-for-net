# Sample for use of an Agent with Work IQ in Azure.AI.Projets.OpenAI.

Work IQ tool allows Agent to access data from [Microsoft 365 Copilot](https://learn.microsoft.com/microsoft-agent-365/tooling-servers-overview). In this example we will create the connection to teams and ask Agent to list all meetings for today.

**Note:** This feature is in the preview.

## Create a Work IQ connection in Microsoft Foundry

1. In the **Microsoft Foundry** you are using for the experimentation, on the top panel select **Build**.
2. Choose **Tools** on the left panel and switch to the **Tools** tab on the top.
3. Create a new connection of type **Work IQ Teams** using catalog tab.


## Run the sample

To enable your Agent to access Microsoft 365 Copilot, use `WorkIQPreviewTool`.

1. First, create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_WorkIQ
```

2. Use the Work IQ Teams connection name as it is shown in the Tools section of Microsoft Foundry to get the connection. Get the connection ID to create the `WorkIQPreviewTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_WorkIQ_Sync
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_WorkIQ_Async
```

3. Create the response and make sure we are always using tools.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_WorkIQ_Sync
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_WorkIQ_Async
```

4. Print the Agent output.

```C# Snippet:Sample_GetResponse_WorkIQ
```

5. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_WorkIQ_Sync
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_WorkIQ_Async
```
