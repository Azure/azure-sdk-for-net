# Detect Change Point
This sample shows how to detect the change point in time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint, apiVersion, and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClient
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;
Uri dataSource = new Uri(TestEnvironment.DataSource);

Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(apiKey);

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, credential);
```

## Load time series and create ChangePointDetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `ChangePointDetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `TimeSeriesPoint` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `TimeSeriesPoint` object.

Make a `ChangePointDetectRequest` object with the series of points, and `TimeGranularity.Daily` for the granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesDataForChangePoint
//read data
string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "samples", "data", "request-data.csv");

List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
    .Where(e => e.Trim().Length != 0)
    .Select(e => e.Split(','))
    .Where(e => e.Length == 2)
    .Select(e => new TimeSeriesPoint(float.Parse(e[1])){ Timestamp = DateTime.Parse(e[0])}).ToList();

//create request
UnivariateChangePointDetectionOptions request = new UnivariateChangePointDetectionOptions(list, TimeGranularity.Daily);
```

## Detect change point
Call the client's `DetectUnivariateChangePoint` method with the `ChangePointDetectRequest` object and await the response as a `ChangePointDetectResponse` object. Iterate through the response's `IsChangePoint` values and print any that are true. These values correspond to the index of change points, if any were found.

```C# Snippet:DetectChangePoint
//detect
Console.WriteLine("Detecting the change point in the series.");

UnivariateChangePointDetectionResult result = client.GetUnivariateClient().DetectUnivariateChangePoint(request);

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
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/request-data.csv
