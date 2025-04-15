# Sample using Datasets in Azure.AI.Projects.

In this example, we will demonstrate how to upload files and folders to create new dataset versions, list and retrieve dataset versions, and delete them.

1. Create the AIProjectClient and read the environment variables.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_CreateClient
// ...existing code...
#endregion
```

2. Upload a single file to create a Dataset version.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_UploadSingleFile
// ...existing code...
#endregion
```

3. Upload all files in a folder to create another Dataset version.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_UploadFolder
// ...existing code...
#endregion
```

4. Upload a single file without explicitly specifying a version so the service increments it.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_UploadFileNoVersion
// ...existing code...
#endregion
```

5. Retrieve an existing Dataset version.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_GetDatasetVersion
// ...existing code...
#endregion
```

6. List all versions of the Dataset.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_ListVersions
// ...existing code...
#endregion
```

7. List the latest versions of all Datasets.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_ListLatest
// ...existing code...
#endregion
```

8. Finally, delete all Dataset versions that were created.

Synchronous sample:
```csharp
#region Snippet:DatasetsExampleSync_DeleteVersions
// ...existing code...
#endregion
```