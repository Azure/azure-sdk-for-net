```C# Snippet:CreateSparkBatchClient
SparkBatchClient client = new SparkBatchClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
```
```C# Snippet:SubmitSparkBatchJob
string name = $"batch-{Guid.NewGuid()}";
string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/wordcount.jar", fileSystem, storageAccount);
SparkBatchJobOptions request = new SparkBatchJobOptions(name, file)
{
    ClassName = "WordCount",
    Arguments =
    {
        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/shakespeare.txt", fileSystem, storageAccount),
        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/result/", fileSystem, storageAccount),
    },
    DriverMemory = "28g",
    DriverCores = 4,
    ExecutorMemory = "28g",
    ExecutorCores = 4,
    ExecutorCount = 2
};

SparkBatchJob jobCreated = client.CreateSparkBatchJob(request);
```
```C# Snippet:ListSparkBatchJobs
Response<SparkBatchJobCollection> jobs = client.GetSparkBatchJobs();
foreach (SparkBatchJob job in jobs.Value.Sessions)
{
    Console.WriteLine(job.Name);
}
```
```C# Snippet:GetSparkBatchJob
SparkBatchJob retrievedJob = client.GetSparkBatchJob(jobCreated.Id);
Debug.WriteLine($"Job is returned with name {retrievedJob.Name} and state {retrievedJob.State}");
```
```C# Snippet:DeleteSparkBatchJob
Response operation = client.CancelSparkBatchJob(jobCreated.Id);
```