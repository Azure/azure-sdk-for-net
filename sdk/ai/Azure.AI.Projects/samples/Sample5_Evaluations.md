# Sample for Azure.AI.Projects with `Evaluations`

In this example, we will demonstrate creating, listing and retrieving evaluations using the `Evaluations` client in `Azure.AI.Projects`. This uses a Dataset as the input data for the evaluation and an Evaluator ID for the evaluation type.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DATASET_NAME`: The name of the dataset to use as input data.

## Synchronous sample:
```C# Snippet:EvaluationsExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

// TODO: Uncomment once datasets are supported, will need to replace UploadFileAndCreate with new function name
//Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
//DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFileAndCreate(
//        name: datasetName,
//        version: "1",
//        filePath: "./sample_folder/sample_data_evaluation.jsonl"
//        );
//Console.WriteLine(dataset);

Console.WriteLine("Create an evaluation");
Evaluations evaluations = projectClient.GetEvaluationsClient();

var evaluatorConfig = new EvaluatorConfiguration(
    id: EvaluatorIDs.Relevance // TODO: Update this to use the preferred evaluator ID
);
evaluatorConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson("gpt-4o"));

Evaluation evaluation = new Evaluation(
    data: new InputDataset("<dataset_id>"), // TODO: Update this to use the correct dataset ID
    evaluators: new Dictionary<string, EvaluatorConfiguration> { { "relevance", evaluatorConfig } }
);
evaluation.DisplayName = "Sample Evaluation";
evaluation.Description = "Sample evaluation for testing";

Console.WriteLine("Create the evaluation run");
Evaluation evaluationResponse = evaluations.CreateRun(evaluation);
Console.WriteLine(evaluationResponse);

Console.WriteLine("Get evaluation");
Evaluation getEvaluationResponse = evaluations.GetEvaluation(evaluationResponse.Id);
Console.WriteLine(getEvaluationResponse);

Console.WriteLine("List evaluations");
foreach (var eval in evaluations.GetEvaluations())
{
    Console.WriteLine(eval);
}
```

## Asynchronous sample:
```C# Snippet:EvaluationsExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

// TODO: Uncomment once datasets are supported, will need to replace UploadFileAndCreate with new function name
//Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
//DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFileAndCreate(
//        name: datasetName,
//        version: "1",
//        filePath: "./sample_folder/sample_data_evaluation.jsonl"
//        );
//Console.WriteLine(dataset);

Console.WriteLine("Create an evaluation");
Evaluations evaluations = projectClient.GetEvaluationsClient();

var evaluatorConfig = new EvaluatorConfiguration(
    id: EvaluatorIDs.Relevance // TODO: Update this to use the preferred evaluator ID
);
evaluatorConfig.InitParams.Add("deploymentName", BinaryData.FromObjectAsJson("gpt-4o"));

Evaluation evaluation = new Evaluation(
    data: new InputDataset("<dataset_id>"), // TODO: Update this to use the correct dataset ID
    evaluators: new Dictionary<string, EvaluatorConfiguration> { { "relevance", evaluatorConfig } }
);
evaluation.DisplayName = "Sample Evaluation";
evaluation.Description = "Sample evaluation for testing";

Console.WriteLine("Create the evaluation run");
Evaluation evaluationResponse = await evaluations.CreateRunAsync(evaluation);
Console.WriteLine(evaluationResponse);

Console.WriteLine("Get evaluation");
Evaluation getEvaluationResponse = await evaluations.GetEvaluationAsync(evaluationResponse.Id);
Console.WriteLine(getEvaluationResponse);

Console.WriteLine("List evaluations");
await foreach (var eval in evaluations.GetEvaluationsAsync())
{
    Console.WriteLine(eval);
}
```
