```C# Snippet:CreateMonitoringClient
string endpoint = TestEnvironment.EndpointUrl;
MonitoringClient client = new MonitoringClient(new Uri(endpoint), new DefaultAzureCredential());
```

```C# Snippet:GetSparkJobList
SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
foreach (var sparkJob in sparkJobList.SparkJobs)
{
    if (sparkJob.State == "Running")
    {
        Console.WriteLine ($"{sparkJob.Name} has been running for {sparkJob.RunningDuration}");
    }
    else
    {
        Console.WriteLine ($"{sparkJob.Name} has been in {sparkJob.State} for {sparkJob.QueuedDuration}");
    }
}
```

```C# Snippet:GetSqlJobQueryString
SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
```
