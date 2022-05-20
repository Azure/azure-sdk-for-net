using Azure.IoT.DeviceUpdate;
using Azure.Identity;
using Azure;
using Azure.Core;

#region LRO

string endpoint = "https://example.iot.com";
string instanceId = "<instance>";
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation operation = await client.ImportDevicesAsync(WaitUntil.Started, "<action>", new BinaryData("<deviceInfo>"));
string operationId = operation.Id;

// TODO: Get this from operation
//string statusUpdateEndpoint = "https:///example.iot.com/importDeviceStatus/22";
string continuationToken = operation.ContinuationToken;

// Coming back later
//Operation rehydratedOperation = new ProtocolOperation(new Uri(statusUpdateEndpoint), "<api-version>", client.Pipeline, ClientOptions.Default, new RequestContext());

ProtocolOperation rehydratedOperation = new ProtocolOperation(continuationToken, "<api-version>", client.Pipeline, ClientOptions.Default, new RequestContext());
rehydratedOperation.WaitForCompletionResponse();

#endregion

//#region Samples
//// APIView: https://apiview.dev/Assemblies/Review/d8425ea2f8bd4d9eb58b27062f0b0a50

//string endpoint = "https://example.iot.com";
//string instanceId = "<instance>";

//DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());

//#endregion



MetricsAdvisorClient client = GetMetricsAdvisorClient();

var data = new
{
  feedbackType = "Anomaly",
  feedbackId: "390d1139-98fb-45af-b831-8d5ad61b150a",
  createdTime: "2021-10-01T00:00:00Z",
  "userPrincipal": "string",
  "metricId": "string",
  dimensionFilter = new
  {
      dimension = new 
      { 
          region = "Karachi"
      }
  }
}

    kind = "AzureSubscriptionCredential",
    properties = new
    {
        credential = new
        {
            referenceName = "test-credential-s3",
            credentialType = "AmazonARN"
        }
    }
};

// TODO: Format JSON
var filter = new MetricFeedbackFilter(new Guid("390d1139-98fb-45af-b831-8d5ad61b150a"))
{
    DimensionFilter = new FeedbackFilter()
    {
        DimensionKey = new DimensionKey(new Dictionary<string, string>() { { "region", "Karachi" } }),
    },
    StartTime = DateTimeOffset.Parse("2021-10-01T00:00:00Z"),
    EndTime = DateTimeOffset.Parse("2021-11-20T00:00:00Z"),
    TimeMode = FeedbackQueryTimeMode.FeedbackCreatedOn,
    FeedbackType = MetricFeedbackKind.Anomaly
};
RequestContent content = MetricFeedbackFilter.ToRequestContent(options);

RequestContext context = new RequestContext()
{
    CancellationToken = cancellationToken,
};

AsyncPageable<BinaryData> feedback = client.GetAllFeedbackAsync(content, 1, 30, context);
await foreach (BinaryData item in feedback)
{
    // TODO: Parse BinaryData
}
