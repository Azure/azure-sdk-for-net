# Detect Change Point
This sample shows how to detect the change point in time series.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClient
//read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;

var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);
String apiVersion = "v1.1";

//create client
AnomalyDetectorClient client = new AnomalyDetectorClient(endpointUri, apiVersion, credential);
```

## Load time series and create ChangePointDetectRequest

You could download our [sample data][SampleData], read in the time series data and add it to a `ChangePointDetectRequest` object.

Call `File.ReadAllLines` with the file path and create a list of `TimeSeriesPoint` objects, and strip any new line characters. Extract the values and separate the timestamp from its numerical value, and add them to a new `TimeSeriesPoint` object.

Make a `ChangePointDetectRequest` object with the series of points, and `TimeGranularity.Daily` for the granularity (or periodicity) of the data points.

```C# Snippet:ReadSeriesDataForChangePoint
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

## Detect change point
Call the client's `DetectChangePointAsync` method with the `ChangePointDetectRequest` object and await the response as a `ChangePointDetectResponse` object. Iterate through the response's `IsChangePoint` values and print any that are true. These values correspond to the index of change points, if any were found.

```C# Snippet:DetectChangePoint
//detect
Console.WriteLine("Detecting the change point in the series.");
var data = new
{
    series = data_points,
    granularity = "daily"
};
Response response = client.DetectChangePoint(RequestContent.Create(data));
JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

List<int> change_point_indexs = new List<int>();
for (int i = 0; i < result.GetProperty("isChangePoint").GetArrayLength(); ++i)
{
    if (bool.Parse(result.GetProperty("isChangePoint")[i].ToString().ToLower()))
    {
        change_point_indexs.Add(i);
    }
}
if (change_point_indexs.Count > 0)
{
    Console.WriteLine("A change point was detected at index:");
    foreach (var index in change_point_indexs) {
        Console.Write(index);
        Console.Write(", ");
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
