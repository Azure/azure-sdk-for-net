# Detect Last Point Anomaly
This sample shows how to detect the anomaly status of the latest data point.

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

## Load time series and create DetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `DetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `TimeSeriesPoint` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `TimeSeriesPoint` object.

Make a `DetectRequest` object with the series of points, and `TimeGranularity.Daily` for the granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesData
//read data
string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "samples", "data", "request-data.csv");

List<TimeSeriesPoint> list = File.ReadAllLines(datapath, Encoding.UTF8)
    .Where(e => e.Trim().Length != 0)
    .Select(e => e.Split(','))
    .Where(e => e.Length == 2)
    .Select(e => new TimeSeriesPoint(float.Parse(e[1])){ Timestamp = DateTime.Parse(e[0])}).ToList();

//create request
UnivariateDetectionOptions request = new UnivariateDetectionOptions(list)
{
    Granularity = TimeGranularity.Daily
};
```

## Detect anomaly status of the latest data point
Call the client's `DetectUnivariateLastPoint` method with the `DetectRequest` object and await the response as a `LastDetectResponse` object. Check the response's `IsAnomaly` attribute to determine if the latest data point sent was an anomaly or not.

```C# Snippet:DetectLastPointAnomaly
//detect
Console.WriteLine("Detecting the anomaly status of the latest point in the series.");

try
{
    UnivariateLastDetectionResult result = client.GetUnivariateClient().DetectUnivariateLastPoint(request);

    if (result.IsAnomaly)
    {
        Console.WriteLine("The latest point was detected as an anomaly.");
    }
    else
    {
        Console.WriteLine("The latest point was not detected as an anomaly.");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Last detection failed: {ex.Message}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Detection error. {ex.Message}");
    throw;
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/request-data.csv
