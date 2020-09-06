# Detect Last Point Anomaly
This sample shows how to detect the anomaly status of the latest data point.

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

## Load time series and create DetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `DetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `TimeSeriesPoint` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `TimeSeriesPoint` object.

Make a `DetectRequest` object with the series of points, and `TimeGranularity.Daily` for the granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesData
string datapath = "<dataPath>";

List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
    .Where(e => e.Trim().Length != 0)
    .Select(e => e.Split(','))
    .Where(e => e.Length == 2)
    .Select(e => new TimeSeriesPoint(DateTime.Parse(e[0]), float.Parse(e[1]))).ToList();

DetectRequest request = new DetectRequest(list, TimeGranularity.Daily);
```

## Detect anomaly status of the latest data point
Call the client's `DetectLastPointAsync` method with the `DetectRequest` object and await the response as a `LastDetectResponse` object. Check the response's `IsAnomaly` attribute to determine if the latest data point sent was an anomaly or not.

```C# Snippet:DetectLastPointAnomaly
Console.WriteLine("Detecting the anomaly status of the latest point in the series.");

LastDetectResponse result = await client.DetectLastPointAsync(request).ConfigureAwait(false);

if (result.IsAnomaly)
{
    Console.WriteLine("The latest point was detected as an anomaly.");
}
else
{
    Console.WriteLine("The latest point was not detected as an anomaly.");
}
```
To see the full example source files, see:

* [Detect Last Point Anomaly](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample2_DetectLastPointAnomaly.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/request-data.csv