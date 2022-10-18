# Detect Entire Series Anomaly
This sample shows how to detect all the anomalies in the entire time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClientEntire
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;

var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);
String apiVersion = "v1.1";

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, apiVersion, credential);
```

## Load time series and create DetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `DetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `TimeSeriesPoint` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `TimeSeriesPoint` object.

Make a `DetectRequest` object with the series of points, and `TimeGranularity.Daily` for the granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesDataEntire
//read data
List<JsonElement> data_points = new List<JsonElement>();
using (StreamReader reader = new StreamReader("./samples/data/request-data.csv"))
{
    while (!reader.EndOfStream)
    {
        var values = reader.ReadLine().Split(',');
        if (values.Length == 2)
        {
            dynamic obj = new JObject();
            obj.timestamp = values[0];
            obj.value = values[1];
            data_points.Add(JsonDocument.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(obj)).RootElement);
        }
    }
}
```

## Detect anomalies of the entire series
Call the client's `DetectEntireSeriesAsync` method with the `DetectRequest` object and await the response as an `EntireDetectResponse` object. Iterate through the response's `IsAnomaly` values and print any that are true. These values correspond to the index of anomalous data points, if any were found.

```C# Snippet:DetectEntireSeriesAnomaly
//detect
Console.WriteLine("Detecting anomalies in the entire time series.");

try
{
    var data = new
    {
        series = data_points,
        granularity = "daily"
    };
    Response response = client.DetectEntireSeries(RequestContent.Create(data));
    JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
    bool hasAnomaly = false;
    for (int i = 0; i < result.GetProperty("isAnomaly").GetArrayLength(); ++i)
    {
        if (bool.Parse(result.GetProperty("isAnomaly")[i].ToString()))
        {
            Console.WriteLine("An anomaly was detected at index: {0}.", i);
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
    Console.WriteLine(String.Format("Entire detection failed: {0}", ex.Message));
    throw;
}
catch (Exception ex)
{
    Console.WriteLine(String.Format("Detection error. {0}", ex.Message));
    throw;
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/README.md
[SampleData]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/data/request-data.csv
