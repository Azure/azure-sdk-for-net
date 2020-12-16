```C# Snippet:CreatePipelineClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

string pipelineName = "Test-Pipeline";
```

```C# Snippet:CreatePipelineClient
var client = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

```C# Snippet:CreatePipeline
PipelineCreateOrUpdatePipelineOperation operation = client.StartCreateOrUpdatePipeline(pipelineName, new PipelineResource());
Response<PipelineResource> createdPipeline = await operation.WaitForCompletionAsync();
```

```C# Snippet:RetrievePipeline
PipelineResource retrievedPipeline = client.GetPipeline(pipelineName);
Console.WriteLine("Pipeline ID: {0}", retrievedPipeline.Id);
```

```C# Snippet:RunPipeline
Console.WriteLine("Running pipeline.");
CreateRunResponse runOperation = await client.CreatePipelineRunAsync(pipelineName);
Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
```

```C# Snippet:ListPipelines
Pageable<PipelineResource> pipelines = client.GetPipelinesByWorkspace();
foreach (PipelineResource pipeline in pipelines)
{
    Console.WriteLine(pipeline.Name);
}
```

```C# Snippet:DeletePipeline
client.StartDeletePipeline(pipelineName);
```
