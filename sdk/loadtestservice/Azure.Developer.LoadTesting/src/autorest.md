# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: https://github.com/Azure/azure-rest-api-specs/blob/7a54c1a83d14da431c0ae48c4315cba143084bce/specification/loadtestservice/data-plane/Microsoft.LoadTestService/stable/2022-11-01/loadtestservice.json
namespace: Azure.Developer.LoadTesting
security: AADToken
security-scopes: https://cnt-prod.loadtesting.azure.com/.default
skip-csproj-packagereference: true
directive:
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}"].patch
      transform: $["operationId"] = "Test_CreateOrUpdateTest";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}"].delete
      transform: $["operationId"] = "Test_DeleteTest";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}"].get
      transform: $["operationId"] = "Test_GetTest";
    - from: swagger-document 
      where: $["paths"]["/tests"].get
      transform: $["operationId"] = "Test_ListTests";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}/app-components"].patch
      transform: $["operationId"] = "Test_CreateOrUpdateAppComponents";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}/metric-dimension/{name}/values"].get
      transform: $["operationId"] = "TestRun_ListMetricDimensionValues";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}/files/{fileName}"].put
      transform: $["operationId"] = "Test_UploadTestFile";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}/files/{fileName}"].get
      transform: $["operationId"] = "Test_GetTestFile";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}/files/{fileName}"].delete
      transform: $["operationId"] = "Test_DeleteTestFile";
    - from: swagger-document 
      where: $["paths"]["/tests/{testId}/files"].get
      transform: $["operationId"] = "Test_ListTestFiles";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}"].delete
      transform: $["operationId"] = "TestRun_DeleteTestRun";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}"].patch
      transform: $["operationId"] = "TestRun_CreateOrUpdateTestRun";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}"].get
      transform: $["operationId"] = "TestRun_GetTestRun";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}/files/{fileName}"].get
      transform: $["operationId"] = "TestRun_GetTestRunFile";
    - from: swagger-document 
      where: $["paths"]["/test-runs"].get
      transform: $["operationId"] = "TestRun_ListTestRuns";
    - from: swagger-document 
      where: $["paths"]["/test-runs/{testRunId}:stop"].post
      transform: $["operationId"] = "TestRun_StopTestRun";
      
    - from: swagger-document
      where: '$.paths.*[?(@.tags=="Test")]'
      transform: $["operationId"] = $["operationId"].replace("Test_", "LoadTestAdministration_");
    - from: swagger-document
      where: '$.paths.*[?(@.tags=="TestRun")]'
      transform: $["operationId"] = $["operationId"].replace("TestRun_", "LoadTestRun_");
```
