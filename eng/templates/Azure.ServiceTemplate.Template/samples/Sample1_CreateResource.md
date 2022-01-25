# Sample readme template

Use the guidelines in each section of this template to write samples, for an example following this template.

This sample shows how to detect all the anomalies in the entire time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

**write the sample code snippets as following example**

## Detect anomalies of the entire series

Call the client's `DetectEntireSeriesAsync` method with the `DetectRequest` object and await the response as an `EntireDetectResponse` object. Iterate through the response's `IsAnomaly` values and print any that are true. These values correspond to the index of anomalous data points, if any were found.

```C# Snippet:DetectEntireSeriesAnomaly
//detect
Console.WriteLine("Detecting anomalies in the entire time series.");

EntireDetectResponse result = await client.DetectEntireSeriesAsync(request).ConfigureAwait(false);

if (result.IsAnomaly.Contains(true))
{
    Console.WriteLine("An anomaly was detected at index:");
    for (int i = 0; i < request.Series.Count; ++i)
    {
        if (result.IsAnomaly[i])
        {
            Console.Write(i);
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine(" No anomalies detected in the series.");
}
```

// **list the links to the full example source files as following**\
To see the full example source files, see:

* [Detect Entire Series Anomaly](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample1_DetectEntireSeriesAnomaly.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/request-data.csv
