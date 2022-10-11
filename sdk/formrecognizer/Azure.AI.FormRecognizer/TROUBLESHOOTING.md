# Troubleshoot Azure Form Recognizer client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure Form Recognizer client library for .NET.

## Table of Contents
* [Troubleshooting errors and exceptions](#troubleshooting-errors-and-exceptions)
    * [Build model error](#build-model-error)
       * [Invalid training data set](#invalid-training-data-set)
       * [Invalid SAS URL](#invalid-sas-url)
    * [Generic error](#generic-error)
    * [The modelId must be a valid GUID](#the-modelid-must-be-a-valid-guid)
* [Unexpected time to build a custom model](#unexpected-time-to-build-a-custom-model)
* [Enable HTTP request/response logging](#enable-http-requestresponse-logging)

## Troubleshooting errors and exceptions
The [RequestFailedException](https://learn.microsoft.com/dotnet/api/azure.requestfailedexception) class, defined in the Azure.Core library, is the `Exception` type thrown by the Azure.AI.FormRecognizer clients on a service request failure. Its `Message` property provides detailed information about what went wrong and includes corrective actions to fix common issues.

For example, if you submit a receipt image with an invalid `Uri`, a 400 error is returned, indicating "Bad Request":
```C# Snippet:DocumentAnalysisBadRequest
try
{
    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-receipt", new Uri("http://invalid.uri"));
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation:
```
Message:
    Azure.RequestFailedException: Service request failed.
    Status: 400 (Bad Request)
    ErrorCode: InvalidRequest

Content:
    {"error":{"code":"InvalidRequest","message":"Invalid request.","innererror":{"code":"InvalidContent","message":"The file is corrupted or format is unsupported. Refer to documentation for the list of supported formats."}}}

Headers:
    Transfer-Encoding: chunked
    x-envoy-upstream-service-time: REDACTED
    apim-request-id: REDACTED
    Strict-Transport-Security: REDACTED
    X-Content-Type-Options: REDACTED
    Date: Fri, 01 Oct 2021 02:55:44 GMT
    Content-Type: application/json; charset=utf-8
```

Error codes and messages raised by the Form Recognizer service can be found in the [service documentation](https://learn.microsoft.com/azure/applied-ai-services/form-recognizer/v3-error-guide).

### Build model error
Build model errors may occur when trying to build a custom model. Usually they are caused by attempting to build the model with an [invalid data set](#invalid-training-data-set) or an [invalid SAS URL](#invalid-sas-url).

#### Invalid training data set
This error indicates that the provided data set does not match the training data requirements. Learn more about building a training data set [here](https://aka.ms/customModelV3).

Example error output:
```
Azure.RequestFailedException : Invalid request.
Status: 400 (Bad Request)
ErrorCode: InvalidRequest

Content:
{
  "error": {
    "code": "InvalidRequest",
    "message": "Invalid request.",
    "innererror": {
      "code": "TrainingContentMissing",
      "message": "Training data is missing: Could not find any training data at the given path."
    }
  }
}

Headers:
Transfer-Encoding: chunked
x-envoy-upstream-service-time: 950
apim-request-id: 07838543-04d2-4427-be99-4d52bb834450
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
x-content-type-options: nosniff
Content-Type: application/json
Date: Tue, 04 Oct 2022 09:04:12 GMT
```

#### Invalid SAS URL
This error points to missing permissions on the blob storage SAS URL for the Form Recognizer service to access the training data set resource. For more information about SAS tokens for Form Recognizer, see [here](https://learn.microsoft.com/azure/applied-ai-services/form-recognizer/create-sas-tokens).

Example error output:
```
Azure.RequestFailedException : Invalid argument.
Status: 400 (Bad Request)
ErrorCode: InvalidArgument

Content:
{
  "error": {
    "code": "InvalidArgument",
    "message": "Invalid argument.",
    "innererror": {
      "code": "InvalidSasToken",
      "message": "The shared access signature (SAS) is invalid: SAS 'list' authorization is missing. Permissions: r"
    }
  }
}

Headers:
Transfer-Encoding: chunked
x-envoy-upstream-service-time: 20
apim-request-id: c3ab3235-3857-4485-85a7-5f6b11b6610b
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
x-content-type-options: nosniff
Content-Type: application/json
Date: Tue, 04 Oct 2022 09:19:33 GMT
```

### Generic error
Seeing a "Generic error" returned from the SDK is most often caused by a heavy load on the service. For troubleshooting issues related to service limits, see related information [here](https://learn.microsoft.com/azure/applied-ai-services/form-recognizer/service-limits?tabs=v30).

Example error output:
```
Azure.RequestFailedException : Invalid model created with ID 046c569a-8a2a-43d0-b934-8bad2d6e7127
Status: 200 (OK)
ErrorCode: 3014

Additional Information:
error-0: 3014: Generic error during training.

Content:


Headers:
ms-azure-ai-errorcode: REDACTED
x-envoy-upstream-service-time: 30
apim-request-id: eda4204c-3432-4ea2-a056-990b795bd631
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
X-Content-Type-Options: nosniff
Date: Fri, 23 Sep 2022 04:20:08 GMT
Content-Length: 282
Content-Type: application/json; charset=utf-8
```

### The modelId must be a valid GUID
This error may occur when you use a `FormRecognizerClient` instance with a custom model built in Form Recognizer Studio. Form Recognizer Studio targets the latest version of the service, while the `FormRecognizerClient` class only supports older service versions.

See [Analyze a document with a custom model
](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithCustomModel.md) for a sample on how to use the new `DocumentAnalysisClient`. This new client supports newer service versions and can be used with models created in Form Recognizer Studio.

Example error output:
```
System.ArgumentException : The modelId must be a valid GUID.
Parameter name: modelId
  ----> System.FormatException : Guid should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).
```

### Unexpected time to build a custom model
It is common to have a long completion time when building a custom model using the `Neural` build mode with `DocumentBuildMode.Neural`.

For simpler use-cases, you can use `DocumentBuildMode.Template` which uses a different model building algorithm that takes less time. See more about `Template` custom models [here](https://aka.ms/custom-template-models). To see more information about `Neural` custom models, see the documentation [here](https://aka.ms/custom-neural-models).

### Enable HTTP request/response logging
Reviewing the HTTP request sent or response received over the wire to/from the Azure Form Recognizer service can be useful when troubleshooting issues.

The simplest way to enable logs is by using the console logger.

To create an Azure SDK log listener that outputs messages to console use the `AzureEventSourceListener.CreateConsoleLogger` method:

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md).

**NOTE**: When logging the body of the request and the response, please ensure that they do not contain confidential information.
