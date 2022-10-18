# Detect Last Point Anomaly
This sample shows how to detect the anomaly status of the latest data point.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create an AnomalyDetectorClient

To create a new `AnomalyDetectorClient` you need the endpoint and credentials from your resource. In the sample below you'll use an Anomaly Detector API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateAnomalyDetectorClientLast
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

You could download our [sample data][SampleData], read in the time series data and construct a list of JsonElement.

```C# Snippet:ReadSeriesDataLast
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

## Detect anomaly status of the latest data point
Call the client's `DetectLastPoint` method with the data and get the response. Check the response's `isAnomaly` attribute to determine if the latest data point sent was an anomaly or not.

```C# Snippet:DetectLastPointAnomaly
//detect
Console.WriteLine("Detecting the anomaly status of the latest point in the series.");
try
{
    var data = new
    {
        series = data_points,
        granularity = "daily"
    };
    Response response = client.DetectLastPoint(RequestContent.Create(data));
    JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

    if (bool.Parse(result.GetProperty("isAnomaly").ToString()))
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
    Console.WriteLine(String.Format("Last detection failed: {0}", ex.Message));
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
