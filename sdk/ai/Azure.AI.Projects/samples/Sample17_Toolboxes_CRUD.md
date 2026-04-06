# Sample for Toolboxes Administration (creation, retrieval, update, deletion) in Azure.AI.Projects

In this example we will demonstrate how .

1. First, we need to create `AgentToolboxes` client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_ToolboxesCRUD
```

2. Use the client to create versioned toolbox object.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesCRUD_Sync
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesCRUD_Async
```

3. Retrieve the toolbox object.

Synchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesCRUD_Sync
```

Asynchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesCRUD_Async
```

4. Update the toolbox object.

Synchronous sample:
```C# Snippet:Sample_UpdateToolbox_ToolboxesCRUD_Sync
```

Asynchronous sample:
```C# Snippet:Sample_UpdateToolbox_ToolboxesCRUD_Async
```

5. List all toolboxes.

Synchronous sample:
```C# Snippet:Sample_ListToolbox_ToolboxesCRUD_Async
```

Asynchronous sample:
```C# Snippet:Sample_ListToolbox_ToolboxesCRUD_Sync
```

6. Finally, remove toolbox we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Async
```

Asynchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Sync
```
