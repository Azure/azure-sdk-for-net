# List Completed Files

This sample demonstrates how to list files that were completed by a job.


## List Completed Files and iterate over in a for loop

```C# Snippet:AzHealthDeidSample4_ListCompletedFiles
Pageable<HealthFileDetails> files = client.GetJobFiles("job-name-1");

foreach (HealthFileDetails file in files)
{
    Console.WriteLine($"File Name: {file.Input.Path}");
    Console.WriteLine($"File Status: {file.Status}");
    Console.WriteLine($"File Output Path: {file.Output.Path}");
}
```
