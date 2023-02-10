# Azure.Core pipeline samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

Before request is sent to the service it travels through the pipeline which consists of a set of policies that get to modify the request before it's being sent and observe the response after it's received and a transport that is responsible for sending request and receiving the response.

## Adding custom policy to the pipeline

Azure SDKs provides a way to add policies to the pipeline at two positions:

- per-call policies get executed once per request

```C# Snippet:AddPerCallPolicy
SecretClientOptions options = new SecretClientOptions();
options.AddPolicy(new CustomRequestPolicy(), HttpPipelinePosition.PerCall);
```

- per-retry policies get executed every time request is retried, see [Retries samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md#configuring-retry-options) for how to configure retries.

```C# Snippet:AddPerRetryPolicy
options.AddPolicy(new StopwatchPolicy(), HttpPipelinePosition.PerRetry);
```

## Implementing a policy

To implement a policy create a class deriving from `HttpPipelinePolicy` and overide `ProcessAsync` and `Process` methods. Request can be accessed via `message.Request`. Response is accessible via `message.Response` but only after `ProcessNextAsync`/`ProcessNext` was called.

```C# Snippet:StopwatchPolicy
public class StopwatchPolicy : HttpPipelinePolicy
{
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await ProcessNextAsync(message, pipeline);

        stopwatch.Stop();

        Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
    }

    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        ProcessNext(message, pipeline);

        stopwatch.Stop();

        Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
    }
}
```

## Implementing a synchronous policy

If your policy doesn't do any asynchronous operations you can derive from `HttpPipelineSynchronousPolicy` and override `OnSendingRequest` or `OnResponseReceived` method.

Below is an example on how to modify request before sending it to back-end.

```C# Snippet:SyncPolicy
public class CustomRequestPolicy : HttpPipelineSynchronousPolicy
{
    public override void OnSendingRequest(HttpMessage message)
    {
        message.Request.Uri.AppendQuery("additional-query-parameter", "42");
        message.Request.Headers.Add("Custom-Header", "Value");
    }
}
```

## Customizing error formatting

The pipeline can be configured to utilize a custom error response parser. This is typically needed when a service does not always conform to the standard Azure error format, or when additional information needs to be added to an error.

To configure custom error formatting, a client must implement a `RequestFailedDetailsParser` and provide it to the `HttpPipelineOptions` when building the pipeline.

### Create an implementation

An example implementation can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/02ca346fdff349be0d9181955f36c60497fa5c60/sdk/tables/Azure.Data.Tables/src/TablesRequestFailedDetailsParser.cs)

### Configure the pipeline with a custom `RequestFailedDetailsParser`

Below is an example of how clients would specify their custom parser in the `HttpPiplineOptions`

```C# Snippet:RequestFailedDetailsParser
var pipelineOptions = new HttpPipelineOptions(options)
{
    RequestFailedDetailsParser = new FooClientRequestFailedDetailsParser()
};

_pipeline = HttpPipelineBuilder.Build(pipelineOptions);
```
