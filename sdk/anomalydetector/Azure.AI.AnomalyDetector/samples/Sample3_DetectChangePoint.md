# Detect Change Point
This sample shows how to detect the change point in time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";

var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);

AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
```

## Load time series and create ChangePointDetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `ChangePointDetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `Point` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `Point` object.

Make a `ChangePointDetectRequest` object with the series of points, and `Granularity.Daily` for the Granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesData
string datapath = "<dataPath>";

List<Point> list = File.ReadAllLines(datapath, Encoding.UTF8)
    .Where(e => e.Trim().Length != 0)
    .Select(e => e.Split(','))
    .Where(e => e.Length == 2)
    .Select(e => new Point(DateTime.Parse(e[0]), float.Parse(e[1]))).ToList();

ChangePointDetectRequest request = new ChangePointDetectRequest(list, Granularity.Daily);
```

## Detect Change Point
Call the client's `ChangePointDetectAsync` method with the `ChangePointDetectRequest` object and await the response as a `ChangePointDetectResponse` object. Iterate through the response's `IsChangePoint` values and print any that are true. These values correspond to the index of change points, if any were found.

```C# Snippet:DetectChangePoint
Console.WriteLine("Detecting the change point in the series.");
try
{
    ChangePointDetectResponse result = await client.ChangePointDetectAsync(request).ConfigureAwait(false);

    if (result.IsChangePoint.Contains(true))
    {
        Console.WriteLine("A change point was detected at index:");
        for (int i = 0; i < request.Series.Count; ++i)
        {
            if (result.IsChangePoint[i])
            {
                Console.Write(i);
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("No change point detected in the series.");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine("Error code: " + ex.ErrorCode);
    Console.WriteLine("Error message: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
To see the full example source files, see:

* [Detect Change Point](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample3_DetectChangePoint.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/samples/data/request-data.csv