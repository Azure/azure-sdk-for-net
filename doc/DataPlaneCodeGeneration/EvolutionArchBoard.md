# DPG .NET Arch Board Review

## Evolving the API

### Basic REST Calls

#### Takes RequestContent and returns Response

**MetricsAdvisorAdministrationClient.CreateDataFeed**

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Response CreateDataFeed(RequestContent content, RequestContext context = null);
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Response<DataFeed> CreateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
```
</td>
</tr>
</table>

[APIView](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Administration.MetricsAdvisorAdministrationClient), Lines 205-208.

##### Customer UX: Calling CreateDataFeed

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>
  
```c#
MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
  
var body = new
{
    dataFeedName = "dataFeedName",
    dataSourceType = "AzureApplicationInsights"
    dataStartFrom = "2021-11-17T16:29:56.5770502+00:00"
    granularityName = "Weekly"
    metrics = new [] {new {metricName="metricNme"}}
};   
Response response = await adminClient.CreateDataFeedAsync( RequestContent.Create(body), new RequestContext());

JsonElement createBodyJson = JsonDocument.Parse(response.Content).RootElement;
var name = createBodyJson.GetProperty("dataFeedName").GetString();

```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>
  
```c#
MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
  
var dataFeed = new DataFeed()
{
    Name = "dataFeedName",
    DataSource = new AzureTableDataFeedSource("connectionString", "table", "query"),
    Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
    Schema = new DataFeedSchema() { MetricColumns = { new("metricName") } },
    IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.UtcNow)
};

using var cancellationSource = new CancellationTokenSource();
cancellationSource.Cancel();
DataFeed dataFeed = await adminClient.CreateDataFeedAsync(dataFeed, cancellationSource.Token);
var name = dataFeed.Name;
```
</td>
</tr>
</table>

#### Other variants

##### Ambiguous method site: Protocol API fixed

**ConfidentialLedger.GetConstitution**

Note: add suffix to grow-up method name to disambiguate methods.

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Response GetConstitution(RequestContext context = null)
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Response<LedgerConstitution> GetConstitutionValue(CancellationToken cancellationToken = default)
```
</td>
</tr>
</table>

##### Ambiguous method site: Convenience API fixed

**MetricsAdvisorAdministrationClient.GetDataFeed**

Note: make RequestContext required to disambiguate methods.

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Response GetDataFeed(string dataFeedId, RequestContext context)
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Response<DataFeed> GetDataFeed(string dataFeedId, CancellationToken cancellationToken = default)
```
</td>
</tr>
</table>



##### ETag parameter

**DeviceUpdateClient.GetOperation**

Note: `ETag` type is used in protocol method.

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Response GetOperation(string operationId, ETag? ifNoneMatch = null, RequestContext context = null);
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Response<UpdateOperation> GetOperationValue(string operationId, ETag? ifNoneMatch = null, CancellationToken cancellationToken = default)
```
</td>
</tr>
</table>

### Paging Calls

#### MetricsAdvisorClient.GetAllFeedback

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
// Without swagger transform
public virtual Pageable<BinaryData> GetMetricFeedbacks(RequestContent content, int? skip = null, int? maxpagesize = null, RequestContext context = null);
  
// With swagger transform to rename method
public virtual Pageable<BinaryData> GetAllFeedback(RequestContent content, int? skip = null, int? maxpagesize = null, RequestContext context = null);
```
  
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Pageable<MetricFeedback> GetAllFeedback(string metricId, GetAllFeedbackOptions options = null, CancellationToken cancellationToken = default);
```
</td>
</tr>
</table>

##### Customer UX: Calling GetAllFeedback

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
MetricsAdvisorClient client = GetMetricsAdvisorClient();
var filter = new
{
  metricId: "642e1139-98fb-45af-b831-8d5ad61df42",
  feedbackType = "Anomaly",
  startTime = "2020-01-01T00:00:00Z",
  endTime = "2020-01-01T00:00:00Z",
  timeMode = "MetricTimestamp"
}

RequestContent content = RequestContent.Create(filter);
  
AsyncPageable<BinaryData> feedback = client.GetAllFeedbackAsync(content, 1, 30);  
await foreach (BinaryData item in feedback)
{
    JsonElement jsonResponse = JsonDocument.Parse(GetContentFromResponse(response)).RootElement;
    Console.WriteLine(jsonResponse.GetProperty("feedBackType").GetString());
    Console.WriteLine(jsonResponse.GetProperty("feedbackId").GetString());
    Console.WriteLine(jsonResponse.GetProperty("dimensionFilter").GetProperty("dimension"));
}
```

</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
MetricsAdvisorClient client = new MetricsAdvisorClient(endpoint, credential);

GetAllFeedbackOptions options = new GetAllFeedbackOptions()
{
    Filter = new FeedbackFilter()
    {
        DimensionKey = new DimensionKey(new Dictionary<string, string>() { { "region", "Karachi" } }),
        TimeMode = FeedbackQueryTimeMode.FeedbackCreatedOn,
        StartsOn = DateTimeOffset.Parse("2021-10-01T00:00:00Z"),
        EndsOn = DateTimeOffset.Parse("2021-11-20T00:00:00Z"),
        FeedbackKind = MetricFeedbackKind.Anomaly
    },
    Skip = 1,
    MaxPageSize = 30,
};

AsyncPageable<MetricFeedback> feedback = client.GetAllFeedbackAsync("390d1139-98fb-45af-b831-8d5ad61b150a", options, cancellationToken)
await foreach (MetricFeedback item in feedback)
{
    Console.WriteLine(feedback.Type);
    Console.WriteLine(feedback.Id);
    Console.WriteLine(feedback.DimensionFilter.Dimension);
}
```
</td>
</tr>
</table>



#### Other variants

##### Ambiguous method site: Protocol API fixed
  
<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>
  
```csharp
public virtual Pageable<BinaryData> GetLedgerEntries(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, RequestContext context = null);
```
  
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Pageable<LedgerEntry> GetLedgerEntryValues(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, CancellationToken cancellationToken = default);
```

</td>
</tr>
</table>
  
##### Ambiguous method site: Convenience API fixed



##### Many required parameters

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>
  
```csharp
public virtual Pageable<BinaryData> GetDataFeeds(string dataFeedName, string dataSourceType, string granularityName, string status, string creator, int? skip, int? maxpagesize, RequestContext context);
```
  
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Pageable<DataFeed> GetDataFeeds(GetDataFeedsOptions options = null, CancellationToken cancellationToken = default);
```

</td>
</tr>
</table>


##### Many optional parameters

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>
  
```csharp
public virtual Pageable<BinaryData> GetCrops(IEnumerable<string> phenotypes = null, IEnumerable<string> ids = null, IEnumerable<string> names = null, IEnumerable<string> propertyFilters = null, IEnumerable<string> statuses = null, DateTimeOffset? minCreatedDateTime = null, DateTimeOffset? maxCreatedDateTime = null, DateTimeOffset? minLastModifiedDateTime = null, DateTimeOffset? maxLastModifiedDateTime = null, int? maxPageSize = null, string skipToken = null, RequestContext context = null);
```
  
</td>
</tr>
<tr>
<td> Convenience Method</td>
</tr>
<td>

```csharp
public virtual Pageable<FoodCrop> GetCropsValues(GetCropsOptions options = null, CancellationToken cancellationToken = default);
```

</td>
</tr>
</table>
 
  
### LRO Calls

#### DeviceManagementClient.ImportDevices

**MetricsAdvisorAdministrationClient.GetDataFeed**

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Operation ImportDevices(WaitUntil waitUntil, string action, RequestContent content, RequestContext context = null)
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
public virtual Operation ImportDevices(WaitUntil waitUntil, ImportAction action, ImportType type, CancellationToken cancellationToken = default)
```
</td>
</tr>
</table>

##### Customer UX: Calling ImportDevicesAsync

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation operation = await client.ImportDevicesAsync(WaitUntil.Started, "import", new BinaryData("modules"));
await operation.WaitForCompletionResponseAsync();
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
ImportDevicesOperation operation = await client.ImportDevicesAsync(WaitUntil.Started, ImportAction.Import, ImportType.Modules);
await operation.WaitForCompletionAsync();
```
</td>
</tr>
</table>

#### Other variants

##### No body, no return type

We would not add the convenience API in this case, since it doesn't add anything.

<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
public virtual Operation DeleteUpdate(WaitUntil waitUntil, string provider, string name, string version, RequestContext context = null);
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
// In this case, we wouldn't add the grow-up method
public virtual DeleteUpdateOperation DeleteUpdateValue(WaitUntil waitUntil, string provider, string name, string version, CancellationToken cancellationToken = default);
```
</td>
</tr>
</table>

##### Operation Rehydration


<table>
<tr>
<td> Protocol Method </td>
</tr>
<tr>
<td>

```csharp
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation operation = await client.ImportDevicesAsync(WaitUntil.Started, "import", new BinaryData("modules"));

string continuationToken = operation.ContinuationToken;
ProtocolOperation rehydratedOperation = new ProtocolOperation(continuationToken, client.Pipeline, new RequestContext());
rehydratedOperation.WaitForCompletionResponse();  
```
</td>
</tr>
<tr>
<td> Convenience Method </td>
</tr>
<td>

```csharp
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
ImportDevicesOperation operation = await client.ImportDevicesAsync(WaitUntil.Started, ImportAction.Import, ImportType.Modules);
  
string id = operation.Id;
ImportDevicesOperation rehydratedOperation = new ImportDevicesOperation(id, client);
rehydratedOperation.WaitForCompletion();  
```
</td>
</tr>
</table>

## Service-Driven Evolution 
The Azure REST API Guidelines for [API Versioning](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#api-versioning) allow several types of changes to service APIs that are non-breaking, but must be added in a new service version. But these non-breaking changes will lead to breaking changes in generated SDKs. Cases are:
- [A method gets a new optional parameter](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/ServiceDrivenEvolution.md#a-method-gets-a-new-optional-parameter)
- [A method changes a required parameter to optional](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/ServiceDrivenEvolution.md#a-method-changes-a-required-parameter-to-optional)
- [A new body type is added](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/ServiceDrivenEvolution.md#a-new-body-type-is-added)
### Case 1: A method gets a new optional parameter
Service adds an optional input from v<sub>i</sub> to v<sub>i+1</sub>.
#### Case 1.1: Optional input is added to a method with no other parameters ([APIView](https://apiview.dev/Assemblies/Review/0119b110f8404179b86a98e68e6c99e3?diffRevisionId=fdd4def091fb4c5a84cf2ad8e12d966c&doc=False&diffOnly=False&revisionId=6c146034ea50497f9eadde3594b1af58) Lines 21-23)
Generated code in v<sub>i</sub>
```C#
public virtual Response GetActiveSeriesCount(RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after adding new parameter `optional`
```C#
public virtual Response GetActiveSeriesCount(string optional = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>
```C#
Response response = GetActiveSeriesCount(new RequestContext());
```
Solution in v<sub>i+1</sub>
```C#
public virtual Response GetActiveSeriesCount(RequestContext context);
public virtual Response GetActiveSeriesCount(string optional = null, RequestContext context = null);
```
#### Case 1.2: Optional input is added to a method with only required parameters ([APIView](https://apiview.dev/Assemblies/Review/0119b110f8404179b86a98e68e6c99e3?diffRevisionId=fdd4def091fb4c5a84cf2ad8e12d966c&doc=False&diffOnly=False&revisionId=6c146034ea50497f9eadde3594b1af58) Lines 65-67)
Generated code in v<sub>i</sub>
```C#
public virtual Response GetMetricFeedback(string feedbackId, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after adding new parameter `optional`
```C#
public virtual Response GetMetricFeedback(string feedbackId, string optional = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>
```C#
Response response = GetMetricFeedback(feedbackId, new RequestContext());
```
Solution in v<sub>i+1</sub>
```C#
public virtual Response GetMetricFeedback(string feedbackId, RequestContext context);
public virtual Response GetMetricFeedback(string feedbackId, string optional = null, RequestContext context = null);
```
#### Case 1.3: Optional input is added to a method with required and optional parameters ([APIView](https://apiview.dev/Assemblies/Review/0119b110f8404179b86a98e68e6c99e3?diffRevisionId=fdd4def091fb4c5a84cf2ad8e12d966c&doc=False&diffOnly=False&revisionId=6c146034ea50497f9eadde3594b1af58) Lines 57-59)
Generated code in v<sub>i</sub>
```C#
public virtual Pageable<BinaryData> GetMetricDimension(string metricId, RequestContent content, int? skip = null, int? maxpagesize = null, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after adding new parameter `optional`
```C#
public virtual Pageable<BinaryData> GetMetricDimension(string metricId, RequestContent content, int? skip = null, int? maxpagesize = null, string optional = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>
```C#
Pageable<BinaryData> = GetMetricDimension(metricId, RequestContent.Create(content), skip, maxpagesize, new RequestContext());
```
Solution in v<sub>i+1</sub>
```C#
public virtual Pageable<BinaryData> GetMetricDimension(string metricId, RequestContent content, int? skip, int? maxpagesize, RequestContext context);
public virtual Pageable<BinaryData> GetMetricDimension(string metricId, RequestContent content, int? skip = null, int? maxpagesize = null, string optional = null, RequestContext context = null);
```
### Case 2: A method changes a required parameter to optional
Service changes a required parameter to optional.
#### Case 2.1: Required input is changed to an optional input in a method with no other parameters ([APIView](https://apiview.dev/Assemblies/Review/c8b0b44916bb4517ac0c9fa49d9a7f37?diffRevisionId=f6c400a77e8d407e994b477c5bdb6efa&doc=False&diffOnly=False&revisionId=735fa276d20e458384447336226467b7) Lines 22-23)
Generated code in v<sub>i</sub>
```C#
public virtual Response DeleteGroup(string groupId, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after changing `groupId` to optional
```C#
public virtual Response DeleteGroup(string groupId = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>

No. Safe to go.
#### Case 2.2: Required input is changed to an optional input when it is in the last position in the path parameter ([APIView](https://apiview.dev/Assemblies/Review/c8b0b44916bb4517ac0c9fa49d9a7f37?diffRevisionId=f6c400a77e8d407e994b477c5bdb6efa&doc=False&diffOnly=False&revisionId=735fa276d20e458384447336226467b7) Lines19-20)
Generated code in v<sub>i</sub>
```C#
public virtual Response DeleteDeployment(string groupId, string deploymentId, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after changing `deploymentId` to optional
```C#
public virtual Response DeleteDeployment(string groupId, string deploymentId = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>

No. Safe to go.
#### Case 2.3: Required input is changed to an optional input when it is in a non-last position
Generated code in v<sub>i</sub>
```C#
public virtual Response DeleteDeployment(string groupId, string deploymentId, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after changing `groupId` to optional
```C#
public virtual Response DeleteDeployment(string deploymentId, string groupId = null, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>
```C#
Response response = DeleteDeployment(groupId, deploymentId);
```
Solution in v<sub>i+1</sub>

Solve it manually.
### Case 3: A new body type is added
Service supports more content types
#### Case 3.1: Original content type has only one option ([APIView](https://apiview.dev/Assemblies/Review/49bcc1eeda464418b63ec20865888be8?diffRevisionId=bc4287a83b2248e29c6be176cdc6ab05&doc=False&diffOnly=False&revisionId=ea489e03bdbe42c4b453041677a5b990) Lines 12-13)
Generated code in v<sub>i</sub>
```C#
public virtual Response CheckPrincipalAccess(RequestContent content, RequestContext context = null);
```
Generated code in v<sub>i+1</sub> after adding a new content type
```C#
public virtual Response CheckPrincipalAccess(RequestContent content, ContentType contentType, RequestContext context = null);
```
Breaking scenario in v<sub>i+1</sub>
```C#
Response response = CheckPrincipalAccess(RequestContent.Create(content), new RequestContext());
```
Solution in v<sub>i+1</sub>
```C#
public virtual Response CheckPrincipalAccess(RequestContent content, RequestContext context = null);
public virtual Response CheckPrincipalAccess(RequestContent content, ContentType contentType, RequestContext context = null);
```