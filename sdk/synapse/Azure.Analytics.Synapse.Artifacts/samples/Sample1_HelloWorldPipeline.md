# Create, Retrieve and Delete a Synapse Pipelines

This sample demonstrates basic operations with two core classes in this library: PipelineClient and PipelineResource. PipelineClient is used to call the Azure Synapse Pipeline service - each method call sends a request to the service's REST API. PipelineResource is an entity that represents a pipeline within Synapse. The sample walks through the basics of adding, retrieving, and pipeline. To get started, you'll need a connection endpoint to Azure Synapse. See the README for links and instructions.

## Create pipeline client

To interact with Azure Synapse's Pipelines, you need to instantiate a `PipelineClient`. It requires an endpoint URL and a TokenCredential.

```C# Snippet:CreatePipelineClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

string pipelineName = "Test-Pipeline";
```

```C# Snippet:CreatePipelineClient
var client = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

## Create a pipeline

To create an empty pipeline, pass an empty instance of `PipelineResource` to `StartCreateOrUpdatePipeline`.

```C# Snippet:CreatePipeline
PipelineCreateOrUpdatePipelineOperation operation = client.StartCreateOrUpdatePipeline(pipelineName, new PipelineResource());
Response<PipelineResource> createdPipeline = await operation.WaitForCompletionAsync();
```

Additional activities such as `SynapseSparkJobDefinitionActivity` can be added to the resources as necessary.

## Retrieve a pipeline

You can retrieve the details of pipeline by calling `GetPipeline`, passing in the pipeline name.

```C# Snippet:RetrievePipeline
PipelineResource retrievedPipeline = client.GetPipeline(pipelineName);
Console.WriteLine("Pipeline ID: {0}", retrievedPipeline.Id);
```

## Running a pipeline

You can start the execution of a pipeline by calling `CreatePipelineRunAsync`, passing in the pipeline name.

```C# Snippet:RunPipeline
Console.WriteLine("Running pipeline.");
CreateRunResponse runOperation = await client.CreatePipelineRunAsync(pipelineName);
Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
```

## List pipelines

To enumerate all pipelines in the Synapse workspace you can call `GetPipelinesByWorkspace`.

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
