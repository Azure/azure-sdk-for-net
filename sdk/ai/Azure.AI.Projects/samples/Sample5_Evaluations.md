# Sample using `Evaluations` in Azure.AI.Projects

In this example, we will demonstrate creating, listing and retrieving evaluations using the `Evaluations` client in `Azure.AI.Projects`. This uses a Dataset as the input data for the evaluation and an Evaluator ID for the evaluation type.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The model deployment to be used in the evaluation.
  - `DATASET_NAME`: The name of the dataset to use as input data.
  - `DATASET_VERSION`: The version of the dataset to use as input data.
  - `CONNECTION_NAME`: The name of the Azure Storage Account connection to use for uploading files.
  - `DATA_FOLDER`: The file path where a data file for upload is located.

## Synchronous sample:
```C# Snippet:AI_Projects_EvaluationsExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var datasetName = Environment.GetEnvironmentVariable("DATASET_NAME") ?? "dataset-test";
var datasetVersion = Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME") ?? "default-connection";
var dataFile = Path.Combine(Environment.GetEnvironmentVariable("DATA_FOLDER") ?? ".", "sample_data_evaluation.jsonl");
var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFile(
       name: datasetName,
       version: "1",
       filePath: dataFile,
        connectionName: connectionName
       );
Console.WriteLine(dataset);

Console.WriteLine("Create an evaluation");
Evaluations evaluations = projectClient.GetEvaluationsClient();

var relevanceConfig = new EvaluatorConfiguration(EvaluatorIDs.Relevance);
relevanceConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson(modelDeploymentName));
relevanceConfig.DataMapping.Add("query", "${data.query}");
relevanceConfig.DataMapping.Add("response", "${data.response}");

var violenceConfig = new EvaluatorConfiguration(EvaluatorIDs.Violence);
violenceConfig.InitParams.Add("azure_ai_project", BinaryData.FromObjectAsJson(endpoint));

var bleuConfig = new EvaluatorConfiguration(EvaluatorIDs.BleuScore);

var evaluators = new Dictionary<string, EvaluatorConfiguration>
{
    { "relevance", relevanceConfig },
    { "violence", violenceConfig },
    { "bleu_score", bleuConfig }
};

Evaluation evaluation = new Evaluation(
    data: new InputDataset(dataset.Id),
    evaluators: evaluators
)
{
    DisplayName = "Sample Evaluation Test",
    Description = "Sample evaluation for testing"
};

Console.WriteLine("Create the evaluation run");
Evaluation evaluationResponse = evaluations.Create(evaluation);
Console.WriteLine(evaluationResponse);

Console.WriteLine("Get evaluation");
Evaluation getEvaluationResponse = evaluations.GetEvaluation(evaluation.DisplayName);
Console.WriteLine(getEvaluationResponse);

Console.WriteLine("List evaluations");
foreach (Evaluation eval in evaluations.GetEvaluations())
{
    Console.WriteLine(eval);
    Console.WriteLine(eval.Name);
}
```

## Asynchronous sample:
```C# Snippet:AI_Projects_EvaluationsExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var datasetName = Environment.GetEnvironmentVariable("DATASET_NAME") ?? "dataset-test";
var datasetVersion = Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME") ?? "default-connection";
var dataFile = Path.Combine(Environment.GetEnvironmentVariable("DATA_FOLDER") ?? ".", "sample_data_evaluation.jsonl");
var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
DatasetVersion dataset = await projectClient.GetDatasetsClient().UploadFileAsync(
       name: datasetName,
       version: "1",
       filePath: dataFile,
        connectionName: connectionName
       );
Console.WriteLine(dataset);

Console.WriteLine("Create an evaluation");
Evaluations evaluations = projectClient.GetEvaluationsClient();

var relevanceConfig = new EvaluatorConfiguration(EvaluatorIDs.Relevance);
relevanceConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson(modelDeploymentName));
relevanceConfig.DataMapping.Add("query", "${data.query}");
relevanceConfig.DataMapping.Add("response", "${data.response}");

var violenceConfig = new EvaluatorConfiguration(EvaluatorIDs.Violence);
violenceConfig.InitParams.Add("azure_ai_project", BinaryData.FromObjectAsJson(endpoint));

var bleuConfig = new EvaluatorConfiguration(EvaluatorIDs.BleuScore);

var evaluators = new Dictionary<string, EvaluatorConfiguration>
{
    { "relevance", relevanceConfig },
    { "violence", violenceConfig },
    { "bleu_score", bleuConfig }
};

Evaluation evaluation = new Evaluation(
    data: new InputDataset(dataset.Id),
    evaluators: evaluators
)
{
    DisplayName = "Sample Evaluation Test",
    Description = "Sample evaluation for testing"
};

Console.WriteLine("Create the evaluation run");
Evaluation evaluationResponse = await evaluations.CreateAsync(evaluation);
Console.WriteLine(evaluationResponse);

Console.WriteLine("Get evaluation");
Evaluation getEvaluationResponse = await evaluations.GetEvaluationAsync(evaluation.DisplayName);
Console.WriteLine(getEvaluationResponse);

Console.WriteLine("List evaluations");
await foreach (Evaluation eval in evaluations.GetEvaluationsAsync())
{
    Console.WriteLine(eval);
    Console.WriteLine(eval.Name);
}
```
