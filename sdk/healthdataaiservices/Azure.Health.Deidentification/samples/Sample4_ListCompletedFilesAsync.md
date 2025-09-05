# List Completed Files Async

This sample demonstrates how to list files that were completed by a job.


## List Completed Files and iterate over in a for loop

```C# Snippet:AzHealthDeidSample4Async_ListCompletedFiles
AsyncPageable<DeidentificationDocumentDetails> files = client.GetJobDocumentsAsync("job-name-1");

await foreach (DeidentificationDocumentDetails file in files)
{
    Console.WriteLine($"File Name: {file.InputLocation.Location}");
    Console.WriteLine($"File Status: {file.Status}");
    Console.WriteLine($"File Output Path: {file.OutputLocation.Location}");
}
```
