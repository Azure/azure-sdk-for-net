## Metrics Advisor Grow Up Story Experiment

This is an experiment project which describes Data plane Codegen(DPG) grow up story, it uses Metrics Advisor as an example. For this experiment, we follow the steps below:
- Generate DPG of Metrics Advisor.
- Grow the SDK to feature equivalence to the current SDK. 
- To confirm feature equivalence, run the existing live tests.

In this experiment, we have updated configurations in autorest.md, manually added customized codes such as models, customized authentication, convenient methods to convert input model to RequestContent and Response to output model. In this tutorial, we will explain the step by step process of this experiment.

### 1. Update autorest.md

We have updated the following configurations in the autorest.md:
* In order to generate DPG, we have added `data-plane: true` flag.
* For AAD authentication, we have defined `security` and `security-scopes` configurations.
* There are two clients, i.e. `MetricsAdvisorAdministrationClient` and `MetricsAdvisorClient` in the released Metrics Advisor library but Swagger spec doesn't define operation group in `operationId`, so only one client `MetricsAdvisorClient` is generated. In order to generate `MetricsAdvisorAdministrationClient` client, we have added [Generate MetricsAdvisorAdministration client and move methods](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/autorest.md#generate-metricsadvisoradministration-client-and-move-methods) configuration.

For more details, please refer to [`autorest.md`](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/autorest.md) for the configuration.

### 2. Gaps between generated code and released code

In order to add grow up methods on the top of DPG generated code, we first need to see the gaps between generated code and [released code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src). The gaps are:

* Models and Headers are not generated in the generated folder.
* In released library, `MetricsAdvisorAdministrationClient` is in the `Azure.AI.MetricsAdvisor.Administration` namespace. So we have added customization [here](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L20) to move `MetricsAdvisorAdministrationClient` into `Azure.AI.MetricsAdvisor.Administration` namespace.
* Released code supports customized authentication using `MetricsAdvisorKeyCredential`.
* Released clients have APIs which take `CancellationToken` but DPG generated APIs take [RequestContext](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/RequestContext.cs#L15) and `CancellationToken` is one of the property of it.
* Released clients have APIs which take input model and return output model but DPG APIs take [RequestContent](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/RequestContent.cs#L18) instead of input model and return [Response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/Response.cs) instead of output model.

  For this experiment we will add convenient method with the same method signature as released client API. In the convenient method implementation we will convert input model to `RequestContent`, call underline generated protocol method and convert `Response` to Output model.

  In order to convert input model to RequestContent and Response to output model, we have to added internal [ToRequestContent(InputModel model)](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Models/DataFeedDetail.Serialization.cs#L493) and [FromResponse(Response response)](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Models/DataFeedDetail.Serialization.cs#L487) methods.


### 3. Pick a list of Metrics Advisor APIs to do the experiment

As there are many APIs, working on the full list of APIs and adding convenient methods can be time-consuming. To prove the concept of grow up story, we have selected a list of APIs to test based on the following criteria:

* APIs exposed from both MetricsAdvisorAdministrationClient and MetricsAdvisorClient
* Contains a mixture of all four http methods:  GET, POST, DELETE, PATCH
* Contains create, delete, update and get operations.
* Contains a mixture of input/output models.
* Contains both paging and non-paging operation. (There is no LRO operation in MetricsAdvisor）


| Method Name                                     | OperationId                                   | Client                                 | HTTP Method | Return type| Parameters
|-----------------------------------------|-----------------------------------------|-----------------------------------------|-------------------------------------------------------------------------------|--------------|--------------|
| GetAllFeedback | listMetricFeedbacks | MetricsAdvisorClient               | POST   | `Pageable<MetricFeedback>`    | `string`, `GetAllFeedbackOptions`|
| AddFeedback | createMetricFeedback | MetricsAdvisorClient               | POST   | `<Response<MetricFeedback>`    | `MetricFeedback` |
| GetFeedback | getMetricFeedback | MetricsAdvisorClient               | GET   | `Response<MetricFeedback>`    | `string` |
| GetMetricDimensionValues | getMetricDimension       | MetricsAdvisorClient               | POST    | `Pageable<string>`   | `string`, `string`, `GetMetricDimensionValuesOptions`|
| GetDataFeed   | getDataFeedById     | MetricsAdvisorAdministrationClient       | GET  | `Response<DataFeed>`         | `string` |
| GetDataFeeds | listDataFeeds     | MetricsAdvisorAdministrationClient              | GET  | `Pageable<DataFeed>`   | `GetDataFeedsOptions` |
| CreateDataFeed | createDataFeed     | MetricsAdvisorAdministrationClient          | POST | `Response<DataFeed>`   | `DataFeed` |
| UpdateDataFeed | updateDataFeed     | MetricsAdvisorAdministrationClient        | PATCH   | `Response<DataFeed>`  | `DataFeed` |
| DeleteDataFeed | deleteDataFeed     | MetricsAdvisorAdministrationClient         | DELETE    | `Response`  |    `string` |

### 4. Add models and other customized files to the project

We have manually added models [here](https://github.com/ShivangiReja/azure-sdk-for-net/tree/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Models) and other customized files [here](https://github.com/ShivangiReja/azure-sdk-for-net/tree/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src) outside of generated folder.

### 5. Customize Authentication

In the released library, customized `MetricsAdvisorKeyCredential` authentication is supported for `MetricsAdvisorClient` and `MetricsAdvisorAdministrationClient`. So for this expermient, we have added a constructor in [MetricsAdvisorClient](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L36) and [MetricsAdvisorAdministrationClient](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L41) partial classes which takes  `MetricsAdvisorKeyCredential`.

### 6. Update `MetricsAdvisorAdministrationClient` namespace

In the released library `MetricsAdvisorAdministrationClient` is in the `Azure.AI.MetricsAdvisor.Administration` namespace. So for this expermient, we have added partial `MetricsAdvisorAdministrationClient` class with `[CodeGenClient("MetricsAdvisorAdministrationClient")]` customization [here](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L20) to move `MetricsAdvisorAdministrationClient` into `Azure.AI.MetricsAdvisor.Administration` namespace.

### 7. Run the autorest.csharp generator

Generate DPG SDK by running `dotnet build /t:GenerateCode` under `sdk\metricsadvisor\Azure.AI.MetricsAdvisor\src` directory.

### 8. Add Convenient methods

We have selected a set of APIs to add convenient methods as explained above. The table below shows the APIs we have selected, and the corresponding convenient methods.

| Convenient method                                     | DPG method                                   | Client                                 | HTTP Method | Return type| Parameters
|-----------------------------------------|-----------------------------------------|-----------------------------------------|-------------------------------------------------------------------------------|--------------|--------------|
| [GetAllFeedback](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L73-L166) | [GetMetricFeedbacks](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorClient.cs#L1507-L1587) | MetricsAdvisorClient               | POST   | `Pageable<MetricFeedback>`    | `string`, `GetAllFeedbackOptions`|
| [AddFeedback](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L178-L260) | [CreateMetricFeedback](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorClient.cs#L448-L507) | MetricsAdvisorClient               | POST   | `<Response<MetricFeedback>`    | `MetricFeedback` |
| [GetFeedback](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L272-L328) | [GetMetricFeedback](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorClient.cs#L1507-L1587) | MetricsAdvisorClient               | GET   | `Response<MetricFeedback>`    | `string` |
| [GetMetricDimensionValues](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs#L345-L418) | [GetMetricDimension](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorClient.cs#L1721-L1785)       | MetricsAdvisorClient               | POST    | `Pageable<string>`   | `string`, `string`, `GetMetricDimensionValuesOptions`|
| [GetDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L77-L134)   | [GetDataFeedById](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorAdministrationClient.cs#L1842-L1930)     | MetricsAdvisorAdministrationClient       | GET  | `Response<DataFeed>`         | `string` |
| [GetDataFeeds](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L143-L190) | [GetDataFeeds](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorAdministrationClient.cs#L2967-L3068)     | MetricsAdvisorAdministrationClient              | GET  | `Pageable<DataFeed>`   | `GetDataFeedsOptions` |
| [CreateDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L203-L267) | [CreateDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorAdministrationClient.cs#L1689-L1782)     | MetricsAdvisorAdministrationClient          | POST | `Response<DataFeed>`   | `DataFeed` |
| [UpdateDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L280-L333) | [UpdateDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorAdministrationClient.cs#L2018-L2138)     | MetricsAdvisorAdministrationClient        | PATCH   | `Response<DataFeed>`  | `DataFeed` |
| [DeleteDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs#L345-L375) | [DeleteDataFeed](https://github.com/ShivangiReja/azure-sdk-for-net/blob/MetricsAdvisor-Experiment/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/Generated/MetricsAdvisorAdministrationClient.cs#L2152-L2194)     | MetricsAdvisorAdministrationClient         | DELETE    | `Response`  |    `string` |


### 9. Test

Since we keep the public method signature same as released one, we can reuse the existing [tests](https://github.com/haolingdong-msft/metrics-advisor-poc/blob/master/src/test/java/com/azure/ai/metricsadvisor) to verify our grow-up methods. This allows us to run the existing tests in PLAYBACK as well as in LIVE mode.