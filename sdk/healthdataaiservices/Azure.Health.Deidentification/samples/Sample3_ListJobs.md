# List Jobs

This sample demonstrates how to list jobs an iterate over in a for loop.


## List Jobs and iterate over in a for loop

```C# Snippet:AzHealthDeidSample3_ListJobs
Pageable<DeidentificationJob> jobs = client.GetJobs();

foreach (DeidentificationJob job in jobs)
{
    Console.WriteLine($"Job Name: {job.JobName}");
    Console.WriteLine($"Job Status: {job.Status}");
}
```
