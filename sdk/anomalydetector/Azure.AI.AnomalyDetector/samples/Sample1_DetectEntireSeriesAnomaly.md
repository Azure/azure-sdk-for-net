# Detect Entire Series Anomaly
This sample shows how to detect all the anomalies in the entire time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint, apiVersion, and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClientEntire
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;

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

## Detect anomalies of the entire series
Call the client's `DetectUnivariateEntireSeries` method with the `DetectRequest` object and await the response as an `EntireDetectResponse` object. Iterate through the response's `IsAnomaly` values and print any that are true. These values correspond to the index of anomalous data points, if any were found.

```C# Snippet:DetectEntireSeriesAnomaly
//detect
Console.WriteLine("Detecting anomalies in the entire time series.");

try
{
    Response response = client.GetUnivariateClient().DetectUnivariateEntireSeries(request.ToRequestContent());
    JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

    bool hasAnomaly = false;
    for (int i = 0; i < request.Series.Count; ++i)
    {
        if (result.GetProperty("isAnomaly")[i].GetBoolean())
        {
            Console.WriteLine($"An anomaly was detected at index: {i}.");
            hasAnomaly = true;
        }
    }
    if (!hasAnomaly)
    {
        Console.WriteLine("No anomalies detected in the series.");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Entire detection failed: {ex.Message}");
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
