# List Jobs Async

This sample demonstrates how to list jobs an iterate over in a for loop.


## List Jobs and iterate over in a for loop

```C# Snippet:AzHealthDeidSample3Async_ListJobs
AsyncPageable<DeidentificationJob> jobs = client.GetJobsAsync();

await foreach (DeidentificationJob job in jobs)
{
    Console.WriteLine($"Job Name: {job.JobName}");
    Console.WriteLine($"Job Status: {job.Status}");
}
```
