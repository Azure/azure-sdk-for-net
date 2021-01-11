# Create, Run and Cancel Synapse Spark jobs

This sample demonstrates basic asynchronous operations with two core classes in this library: `SparkBatchClient` and `SparkBatchJob`. `SparkBatchClient` is used to interact with Spark jobs running on Azure Synapse - each method call sends a request to the service's REST API. `SparkBatchJob` is an entity that represents a batched Spark job within Synapse. The sample walks through the basics of creating, running, and canceling job requests. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Spark/README.md) for links and instructions.

## Create Spark batch client

To interact with Spark jobs running on Azure Synapse, you need to instantiate a `SparkBatchClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateSparkBatchClientAsync
// Replace the strings below with the spark, endpoint, and file system information
string sparkPoolName = "<my-spark-pool-name>";

string endpoint = "<my-endpoint-url>";

string storageAccount = "<my-storage-account-name>";

string fileSystem = "<my-storage-filesystem-name>";

SparkBatchClient client = new SparkBatchClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
```

## Submitting Spark jobs

To submit a Spark job, first create a `SparkBatchJob`, passing in an instance of `SparkBatchJobOptions` describing the job's parameters. Calling `StartCreateSparkBatchJobAsync` with that job will submit it to Synapse.

```C# Snippet:SubmitSparkBatchJobAsync
string name = $"batch-{Guid.NewGuid()}";
string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/wordcount.zip", fileSystem, storageAccount);
SparkBatchJobOptions request = new SparkBatchJobOptions(name, file)
{
    ClassName = "WordCount",
    Arguments =
    {
        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/shakespeare.txt", fileSystem, storageAccount),
        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/result/", fileSystem, storageAccount),
    },
    DriverMemory = "28g",
    DriverCores = 4,
    ExecutorMemory = "28g",
    ExecutorCores = 4,
    ExecutorCount = 2
};

SparkBatchOperation createOperation = await client.StartCreateSparkBatchJobAsync(request);
SparkBatchJob jobCreated = await createOperation.WaitForCompletionAsync();
```

## Retrieve a Spark job

To retrieve the details of a Spark job call `StartGetSparkBatchJobAsync`, passing in the Spark job ID.

```C# Snippet:GetSparkBatchJobAsync
SparkBatchJob retrievedJob = await client.GetSparkBatchJobAsync (jobCreated.Id);
Debug.WriteLine($"Job is returned with name {retrievedJob.Name} and state {retrievedJob.State}");
```

## List Spark jobs

To enumerate all Spark jobs in the Synapse workspace call `GetSparkBatchJobs`.

```C# Snippet:ListSparkBatchJobsAsync
Response<SparkBatchJobCollection> jobs = client.GetSparkBatchJobs();
foreach (SparkBatchJob job in jobs.Value.Sessions)
{
    Console.WriteLine(job.Name);
}
```

## Canceling a Spark job

To cancel a submitted Spark job call `CancelSparkBatchJob`, passing in the Spark job ID.

```C# Snippet:CancelSparkBatchJobAsync
Response operation = client.CancelSparkBatchJob(jobCreated.Id);
```
