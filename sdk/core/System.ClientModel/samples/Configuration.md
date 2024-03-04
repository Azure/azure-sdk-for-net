# System.ClientModel-based client configuration samples

## Configuring retries

To modify the retry policy, create a new instance of `ClientRetryPolicy` and set it on the `ClientPipelineOptions` passed to the client constructor.

By default, clients are setup to retry 3 times using an exponential retry strategy with an initial delay of 0.8 sec, and a max delay of 1 minute.

```C# Snippet:ConfigurationCustomizeRetries
MapsClientOptions options = new()
{
    RetryPolicy = new ClientRetryPolicy(maxRetries: 5),
};

string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
ApiKeyCredential credential = new(key);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```

## Add a custom policy to the pipeline

Azure SDKs provides a way to add policies to the pipeline at three positions:

- per-call policies are run once per request

```C# Snippet:ConfigurationAddPerCallPolicy
MapsClientOptions options = new();
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerCall);
```

- per-try policies are run each time the request is tried

```C# Snippet:ConfigurationAddPerTryPolicy
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerTry);
```

- before-transport policies are run after other policies and before the request is sent

Adding policies at this position should be done with care since changes made to the request by a before-transport policy will not be visible to any logging policies that come before it in the  pipeline.

```C# Snippet:ConfigurationAddBeforeTransportPolicy
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.BeforeTransport);
```

## Implement a custom policy

To implement a policy create a class deriving from `HttpPipelinePolicy` and overide `ProcessAsync` and `Process` methods. Request can be accessed via `message.Request`. Response is accessible via `message.Response` but only after `ProcessNextAsync`/`ProcessNext` was called.

```C# Snippet:ConfigurationCustomPolicy
public class StopwatchPolicy : PipelinePolicy
{
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        await ProcessNextAsync(message, pipeline, currentIndex);

        stopwatch.Stop();

        Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        ProcessNext(message, pipeline, currentIndex);

        stopwatch.Stop();

        Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
    }
}
```

## Provide a custom HttpClient instance

In some cases, users may want to provide a custom instance of the `HttpClient` used by a client's transport to send and receive HTTP messages.  To provide a custom `HttpClient`, create a new instance of `HttpClientPipelineTransport` and create the custom `HttpClient` instance to its constructor.

```C# Snippet:ConfigurationCustomHttpClient
using HttpClient client = new();

MapsClientOptions options = new()
{
    Transport = new HttpClientPipelineTransport(client)
};
```
