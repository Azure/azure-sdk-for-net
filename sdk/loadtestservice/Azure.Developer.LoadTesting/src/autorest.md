# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: https://github.com/Azure/azure-rest-api-specs/blob/af1be2677e619e483210064ff658e62ec25053aa/specification/loadtestservice/data-plane/Microsoft.LoadTestService/preview/2022-06-01-preview/loadtestservice.json
namespace: Azure.Developer.LoadTesting
security: AADToken
security-scopes: https://loadtest.azure-dev.com/.default
skip-csproj-packagereference: true
directive:
  - from: swagger-document
    where: $["paths"]["/appcomponents/{name}"].patch
    transform: $["operationId"] = "AppComponent_CreateOrUpdate"
  - from: swagger-document
    where: $["paths"]["/appcomponents/{name}"].delete
    transform: $["operationId"] = "AppComponent_Delete"
  - from: swagger-document
    where: $["paths"]["/appcomponents/{name}"].get
    transform: $["operationId"] = "AppComponent_GetByName"
  - from: swagger-document
    where: $["paths"]["/appcomponents"].get
    transform: $["operationId"] = "AppComponent_Get"
  - from: swagger-document
    where: $["paths"]["/serverMetricsConfig/{name}"].patch
    transform: $["operationId"] = "ServerMetrics_CreateOrUpdate"
  - from: swagger-document
    where: $["paths"]["/serverMetricsConfig/{name}"].get
    transform: $["operationId"] = "ServerMetrics_GetByName"
  - from: swagger-document
    where: $["paths"]["/serverMetricsConfig/{name}"].delete
    transform: $["operationId"] = "ServerMetrics_Delete"
  - from: swagger-document
    where: $["paths"]["/serverMetricsConfig"].delete
    transform: $["operationId"] = "ServerMetrics_Get"
  - from: swagger-document
    where: $["paths"]["/serverMetricsConfig/default"].get
    transform: $["operationId"] = "ServerMetrics_GetDefault"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}"].patch
    transform: $["operationId"] = "Test_CreateOrUpdate"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}"].delete
    transform: $["operationId"] = "Test_Delete"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}"].get
    transform: $["operationId"] = "Test_Get"
  - from: swagger-document
    where: $["paths"]["/loadtests/sortAndFilter"].get
    transform: $["operationId"] = "Test_Search"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}/files/{fileId}"].put
    transform: $["operationId"] = "Test_UploadFile"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}/files/{fileId}"].get
    transform: $["operationId"] = "Test_GetFile"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}/files/{fileId}"].delete
    transform: $["operationId"] = "Test_DeleteFile"
  - from: swagger-document
    where: $["paths"]["/loadtests/{testId}/files"].get
    transform: $["operationId"] = "Test_GetAllFiles"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}"].delete
    transform: $["operationId"] = "TestRun_Delete"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}"].patch
    transform: $["operationId"] = "TestRun_CreateAndUpdate"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}"].get
    transform: $["operationId"] = "TestRun_Get"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}/files/{fileId}"].get
    transform: $["operationId"] = "TestRun_GetFile"
  - from: swagger-document
    where: $["paths"]["/testruns/sortAndFilter"].get
    transform: $["operationId"] = "TestRun_Search"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}:stop"].post
    transform: $["operationId"] = "TestRun_Stop"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}/clientMetrics"].post
    transform: $["operationId"] = "TestRun_GetClientMetrics"
  - from: swagger-document
    where: $["paths"]["/testruns/{testRunId}/clientMetricsFilters"].get
    transform: $["operationId"] = "TestRun_GetClientMetricsFilters"
```
