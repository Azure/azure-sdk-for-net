# Azure.Core pipeline samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

Before request is sent to the service it travels through the pipeline which consists of a set of policies that get to modify the request before it's being sent and observe the response after it's received and a transport that is responsible for sending request and receiving the response.

## Adding custom policy to the pipeline

Azure SDKs provides a way to add policies to the pipeline at two positions:

 - per-call policies get executed once per request
 - per-retry policies get executed every time request is retried, see [Retries samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md#configuring-retry-options) for how to configure retries.

```C# Snippet:AddingPerCallPolicy
SecretClientOptions options = new SecretClientOptions();
options.AddPolicy(new CustomRequestPolicy(), HttpPipelinePosition.PerCall);

options.AddPolicy(new StopwatchPolicy(), HttpPipelinePosition.PerRetry);
```

## Implementing a policy

To implement a policy create a class deriving from `HttpPipelinePolicy` and overide `ProcessAsync` and `Process` methods. Request can be acessed via `message.Request`. Response is accessible via `message.Response` but only after `ProcessNextAsync`/`ProcessNext` was called.

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

## Implementing a syncronous policy

If your policy doesn't do any asyncronous operations you can derive from `HttpPipelineSynchronousPolicy` and override `OnSendingRequest` or `OnResponseReceived` method.

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
