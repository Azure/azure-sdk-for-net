# DPG .NET Arch Board Review

## Evolving the API

### Basic REST Calls

We add a set of convenience APIs to DPG code. Those methods are convenient to users, e.g. it can accept model as input value or return value, and also it keeps consistent with released APIs.

#### Overview

| API  | Method | Parameter |  Return Type        | API View | Code Reference |
|------|--------|----------|----------------|--------------|-------------------|
|ConfidentialLedger.GetConstitution|GET| no required parameters| Single Object | [API](https://apiview.dev/Assemblies/Review/6c11d7337755493bbe6942126b633be1) L24|[Code](https://github.com/archerzz/azure-sdk-for-net/blob/278ee0568bcbcb71f3cd1a9c3b6a1d585060fa9f/sdk/confidentialledger/Azure.Security.ConfidentialLedger/src/Customizations/ConfidentialLedgerClient.cs#L69)|
|ConfidentialLedger.GetReceipt| GET| one required parameter| Single Object | [API](https://apiview.dev/Assemblies/Review/6c11d7337755493bbe6942126b633be1) L36 | [Code](https://github.com/archerzz/azure-sdk-for-net/blob/278ee0568bcbcb71f3cd1a9c3b6a1d585060fa9f/sdk/confidentialledger/Azure.Security.ConfidentialLedger/src/Customizations/ConfidentialLedgerClient.cs#L83)
|MetricsAdvisorAdministrationClient.CreateDataFeed| POST| only request body parameter| Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b) L205, 207| [code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L356)|
|MetricsAdvisorAdministrationClient.CreateDataFeed| POST | addition of manually-written models | Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Models.DataFeed) L205, 207 | [Code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L356)|
|MetricsAdvisorAdministrationClient.UpdateDataFeed | PATCH| request body parameter and one required parameter | Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Models.DataFeed) L259, 261 | [Code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L433)|
|MetricsAdvisorClient.GetFeedback| GET | one required parameter | Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Models.DataFeed) L26, 27 | [Code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L314)|
|MetricsAdvisorClient.AddFeedback| POST | one required parameter | Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Models.DataFeed) L12, 13| [Code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L220)|
|MetricsAdvisorAdministrationClient.GetDataFeed| GET | one required paramter | Single Object | [API](https://apiview.dev/Assemblies/Review/a9812a1691e54ab4bf52540c4e54d433?diffRevisionId=9260bdbf10e346b9ba8dac7399ea885b&doc=False&diffOnly=False&revisionId=66cd7343ae6c47988e3f8b3caf52617b#Azure.AI.MetricsAdvisor.Models.DataFeed) L231, 232 | [Code](https://github.com/ShivangiReja/azure-sdk-for-net/blob/812720991ec401f51f8bdb958781d48d6edd24e4/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L78)|
|DeviceUpdateClient.GetOperation| GET | ETag parameter | Single Object | [API](https://apiview.dev/Assemblies/Review/4d7d53c6581245759f465e12c8d9e5c5) L86, 88| [Code](https://github.com/chunyu3/azure-sdk-for-net/blob/10765f008e541992e1f20fc72d46a5165bc59a3a/sdk/deviceupdate/Azure.IoT.DeviceUpdate/src/DeviceUpdateClient.cs#L69)|

#### Scenario: no required parameters

If your convenience method has the same parameter list as that of the protocol method, the initial version of convenience method could have ambiguity with the protocol method. To resolve that issue we will append suffix (such as `Value` or `Values`) to the initial method name as the convenience method name.

- Protocol Method

```c#
public virtual Response GetConstitution(RequestContext context = null)
{
    using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetConstitution");
    scope.Start();
    try
    {
        using HttpMessage message = CreateGetConstitutionRequest(context);
        return _pipeline.ProcessMessage(message, context);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
public virtual async Task<Response> GetConstitutionAsync(RequestContext context = null)
{
    using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetConstitution");
    scope.Start();
    try
    {
        using HttpMessage message = CreateGetConstitutionRequest(context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

```

- Convenience Method

```c#
public virtual Response<LedgerConstitution> GetConstitutionValue(CancellationToken cancellationToken = default)
{
    Response response = GetConstitution(new RequestContext { CancellationToken = cancellationToken });

    LedgerConstitution constitution = LedgerConstitution.FromResponse(response);

    return Response.FromValue(constitution, response);
}

public virtual async Task<Response<LedgerConstitution>> GetConstitutionValueAsync(CancellationToken cancellationToken = default)
{
    Response response = await GetConstitutionAsync(new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);

    LedgerConstitution constitution = LedgerConstitution.FromResponse(response);

    return Response.FromValue(constitution, response);
}

```

#### Scenario: one required parameter

If your convenience method has the same parameter list as that of the protocol method, the initial version of convenience method could have ambiguity with the protocol method. To resolve that issue we will append suffix (such as `Value` or `Values`) to the initial method name as the convenience method name.

- Protocol Method

```c#
public virtual Response GetReceipt(string transactionId, RequestContext context = null);
public virtual Task<Response> GetReceiptAsync(string transactionId, RequestContext context = null);
```

- Convenience Method

```c#

public virtual Response<TransactionReceipt> GetReceiptValue(string transactionId, CancellationToken cancellationToken = default)
{
    Response response = GetReceipt(transactionId, new RequestContext { CancellationToken = cancellationToken });

    TransactionReceipt value = TransactionReceipt.FromResponse(response);

    return Response.FromValue(value, response);
}
public virtual async Task<Response<TransactionReceipt>> GetReceiptValueAsync(string transactionId, CancellationToken cancellationToken = default)
{
    Response response = await GetReceiptAsync(transactionId, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);

    TransactionReceipt value = TransactionReceipt.FromResponse(response);

    return Response.FromValue(value, response);
}
```

#### Scenario: takes only request body parameter

- Protocol Method

```c#
public virtual Response CreateDataFeed(RequestContent content, RequestContext context = null);
public virtual Task<Response> CreateDataFeedAsync(RequestContent content, RequestContext context = null);
```

- Convenience Method

```c#

public virtual Response<DataFeed> CreateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
{
    ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

    DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
    RequestContent content = DataFeedDetail.ToRequestContent(dataFeedDetail);
    RequestContext context = new RequestContext()
    {
        CancellationToken = cancellationToken,
    };
    Response response = CreateDataFeed(content, context);

    var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
    string dataFeedId = ClientCommon.GetDataFeedId(location);

    try
    {
        var createdDataFeed = GetDataFeed(dataFeedId, cancellationToken);

        return Response.FromValue(createdDataFeed, response);
    }
    catch (Exception ex)
    {
        throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
    }
}

public virtual async Task<Response<DataFeed>> CreateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default)
{
    ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

    DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
    RequestContent content = DataFeedDetail.ToRequestContent(dataFeedDetail);
    RequestContext context = new RequestContext()
    {
        CancellationToken = cancellationToken,
    };

    Response response = await CreateDataFeedAsync(content, context).ConfigureAwait(false);

    var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
    string dataFeedId = ClientCommon.GetDataFeedId(location);

    try
    {
        var createdDataFeed = await GetDataFeedAsync(dataFeedId, cancellationToken).ConfigureAwait(false);

        return Response.FromValue(createdDataFeed, response);
    }
    catch (Exception ex)
    {
        throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
    }
}
```

#### Scenario: addition of manually-written models

You can define your own models for your convenience method. In swagger, the model schema is `DataFeedDetail`, users define a new model `DataFeed` for their convenience method.

- Protocol Method

```c#
public virtual Response CreateDataFeed(RequestContent content, RequestContext context = null);
public virtual Task<Response> CreateDataFeedAsync(RequestContent content, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<DataFeed> CreateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default);
public virtual Task<Response<DataFeed>> CreateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default);
```

#### Scenario: takes request body parameter and one required parameter

Users define a new model `DataFeed` to merge the request body parameter together with the required parameter.

- Protocol Method

```c#
public virtual Response UpdateDataFeed(string dataFeedId, RequestContent content, RequestContext context = null);
public virtual Task<Response> UpdateDataFeedAsync(string dataFeedId, RequestContent content, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<DataFeed> UpdateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNull(dataFeed, nameof(dataFeed));

    if (dataFeed.Id == null)
    {
        throw new ArgumentNullException(nameof(dataFeed), $"{nameof(dataFeed)}.Id not available. Call {nameof(GetDataFeed)} and update the returned model before calling this method.");
    }

    DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
    RequestContent content = DataFeedDetailPatch.ToRequestContent(patchModel);
    RequestContext context = new RequestContext()
    {
        CancellationToken = cancellationToken,
    };
    Response response = UpdateDataFeed(dataFeed.Id, content, context);
    DataFeedDetail dataFeedDetail = DataFeedDetail.FromResponse(response);
    return Response.FromValue(new DataFeed(dataFeedDetail), response);
}
public virtual async Task<Response<DataFeed>> UpdateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNull(dataFeed, nameof(dataFeed));

    if (dataFeed.Id == null)
    {
        throw new ArgumentNullException(nameof(dataFeed), $"{nameof(dataFeed)}.Id not available. Call {nameof(GetDataFeedAsync)} and update the returned model before calling this method.");
    }

    DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
    RequestContent content = DataFeedDetailPatch.ToRequestContent(patchModel);
    RequestContext context = new RequestContext()
    {
        CancellationToken = cancellationToken,
    };
    Response response = await UpdateDataFeedAsync(dataFeed.Id, content, context).ConfigureAwait(false);
    DataFeedDetail dataFeedDetail = DataFeedDetail.FromResponse(response);
    return Response.FromValue(new DataFeed(dataFeedDetail), response);
}
```

#### Scenario: ETag parameter

In protocol method, the request condition head parameter is `ETag`, but in Generation1-convience-Client, it will use type `AccessCondition`, user can write convenience method to consistent the API.

- Protocol Method

```c#
public virtual Response GetOperation(string operationId, ETag? ifNoneMatch = null, RequestContext context = null);
public virtual Task<Response> GetOperationAsync(string operationId, ETag? ifNoneMatch = null, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<UpdateOperation> GetOperation(string operationId, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
{
    var requestContext = new RequestContext { CancellationToken = cancellationToken };
    var ifNoneMatch = new ETag(accessCondition.IfNoneMatch);
    using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.GetOperationAsync");
    scope.Start();
    try
    {
        var response = GetOperation(operationId, ifNoneMatch, requestContext);
        UpdateOperation value = UpdateOperation.FromResponse(response);
        return Response.FromValue(value, response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
public virtual async Task<Response<UpdateOperation>> GetOperationAsync(string operationId, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
{
    var requestContext = new RequestContext { CancellationToken = cancellationToken };
    var ifNoneMatch = new ETag(accessCondition.IfNoneMatch);
    using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.GetOperationAsync");
    scope.Start();
    try
    {
        var response = await GetOperationAsync(operationId, ifNoneMatch, requestContext).ConfigureAwait(false);;
        UpdateOperation value = UpdateOperation.FromResponse(response);
        return Response.FromValue(value, response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

#### Scenario: name changes in Convenience API

Modify the convenience method name to keep API consistent with previous released package.

##### GetFeedback

- Protocol Method

```c#
public virtual Response GetMetricFeedback(string feedbackId, RequestContext context = null);
public virtual Task<Response> GetMetricFeedbackAsync(string feedbackId, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<MetricFeedback> GetFeedback(string feedbackId, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNullOrEmpty(feedbackId, nameof(feedbackId));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
    scope.Start();

    try
    {
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = GetMetricFeedback(feedbackId, context);
        MetricFeedback value = MetricFeedback.FromResponse(response);
        return Response.FromValue(value, response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

public virtual async Task<Response<MetricFeedback>> GetFeedbackAsync(string feedbackId, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNullOrEmpty(feedbackId, nameof(feedbackId));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
    scope.Start();

    try
    {
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = await GetMetricFeedbackAsync(feedbackId, context).ConfigureAwait(false);
        MetricFeedback value = MetricFeedback.FromResponse(response);
        return Response.FromValue(value, response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

##### GetDataFeed

- Protocol Method

```c#
public virtual Response GetDataFeedById(string dataFeedId, RequestContext context = null);
public virtual Task<Response> GetDataFeedByIdAsync(string dataFeedId, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<DataFeed> GetDataFeed(string dataFeedId, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
    scope.Start();

    try
    {
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = GetDataFeedById(dataFeedId, context);
        DataFeedDetail value = DataFeedDetail.FromResponse(response);
        return Response.FromValue(new DataFeed(value), response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

public virtual async Task<Response<DataFeed>> GetDataFeedAsync(string dataFeedId, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
    scope.Start();

    try
    {
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = await GetDataFeedByIdAsync(dataFeedId, context).ConfigureAwait(false);
        DataFeedDetail value = DataFeedDetail.FromResponse(response);
        return Response.FromValue(new DataFeed(value), response);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

##### AddFeedback

- Protocol Method

```c#
public virtual Response CreateMetricFeedback(RequestContent content, RequestContext context = null);
public virtual Task<Response> CreateMetricFeedbackAsync(RequestContent content, RequestContext context = null);
```

- Convenience Method

```c#
public virtual Response<MetricFeedback> AddFeedback(MetricFeedback feedback, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNull(feedback, nameof(feedback));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
    scope.Start();

    try
    {
        RequestContent content = MetricFeedback.ToRequestContent(feedback);
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = CreateMetricFeedback(content, context);

        var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
        string feedbackId = ClientCommon.GetFeedbackId(location);

        try
        {
            var addedFeedback = GetFeedback(feedbackId, cancellationToken);

            return Response.FromValue(addedFeedback, response);
        }
        catch (Exception ex)
        {
            throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
        }
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

public virtual async Task<Response<MetricFeedback>> AddFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
{
    Argument.AssertNotNull(feedback, nameof(feedback));

    using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
    scope.Start();

    try
    {
        RequestContent content = MetricFeedback.ToRequestContent(feedback);
        RequestContext context = new RequestContext()
        {
            CancellationToken = cancellationToken,
        };
        Response response = await CreateMetricFeedbackAsync(content, context).ConfigureAwait(false);

        var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
        string feedbackId = ClientCommon.GetFeedbackId(location);

        try
        {
            var addedFeedback = await GetFeedbackAsync(feedbackId, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(addedFeedback, response);
        }
        catch (Exception ex)
        {
            throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
        }
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

### Comparison between calling Protocol method and Convenience method

#### createDataFeed

- Protocol Method
  
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

- Convenience Method
  
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