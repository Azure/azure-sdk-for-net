# Sample of managing model weights in Azure.AI.Projects.

**Note:** Model weights is an experimental feature, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

In this example we will demonstrate how to create, update, list and delete model weights.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_Createclient_Models
```

2. Create a toy model weights and upload them to Blob store.

Synchronous sample:
```C# Snippet:Sample_UploadData_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_UploadData_Models_Async
```

3. Use the uploaded BLOB URI to create new `ModelVersion` object.

Synchronous sample:
```C# Snippet:Sample_CreateModel_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_CreateModel_Models_Async
```

4. Wait for model deployment by trying to get it for a period of time. After the model is deployed, display its name, version and SAS URI.

Synchronous sample:
```C# Snippet:Sample_GetModel_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_GetModel_Models_Async
```

5. Update the model with new tags and description.

Synchronous sample:
```C# Snippet:Sample_UpdateModel_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_UpdateModel_Models_Async
```

6. List all versions of the model, we have created.

Synchronous sample:
```C# Snippet:Sample_ListModelVersions_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_ListModelVersions_Models_Async
```

7. List all models in Microsoft Foundry along with their latest versions.

Synchronous sample:
```C# Snippet:Sample_ListLatestVersions_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_ListLatestVersions_Models_Async
```

8. Finally, delete `ModelVersion` we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Models_Sync
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Models_Async
```

