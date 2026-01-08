# System.ClientModel-based client configuration samples

## Configuring retries

To modify the retry policy, create a new instance of `ClientRetryPolicy` and set it on the `ClientPipelineOptions` passed to the client constructor.

By default, clients will retry a request three times using an exponential retry strategy with an initial delay of 0.8 seconds and a maximum delay of one minute.

```C# Snippet:ConfigurationCustomizeRetries
MapsClientOptions options = new()
{
    RetryPolicy = new ClientRetryPolicy(maxRetries: 5),
};

string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
ApiKeyCredential credential = new(key!);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```

## Implement a custom policy

To implement a custom policy that can be added to the client's pipeline, create a class that derives from `PipelinePolicy` and overide its `ProcessAsync` and `Process` methods. The request can be accessed via `message.Request`. The response is accessible via `message.Response`, but will have a value only after `ProcessNextAsync`/`ProcessNext` has been called.

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

## Add a custom policy to the pipeline

Azure SDKs provides a way to add policies to the pipeline at three positions, `PerCall`, `PerTry`, and `BeforeTransport`.

- `PerCall` policies run once per request

```C# Snippet:ConfigurationAddPerCallPolicy
MapsClientOptions options = new();
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerCall);
```

- `PerTry` policies run each time a request is tried

```C# Snippet:ConfigurationAddPerTryPolicy
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerTry);
```

- `BeforeTransport` policies run after all other policies in the pipeline and before the request is sent by the transport.

Adding policies at the `BeforeTransport` position should be done with care since changes made to the request by a before-transport policy will not be visible to any logging policies that come before it in the pipeline.

```C# Snippet:ConfigurationAddBeforeTransportPolicy
options.AddPolicy(new StopwatchPolicy(), PipelinePosition.BeforeTransport);
```

## Provide a custom HttpClient instance

In some cases, users may want to provide a custom instance of the `HttpClient` used by a client's transport to send and receive HTTP messages.  To provide a custom `HttpClient`, create a new instance of `HttpClientPipelineTransport` and pass the custom `HttpClient` instance to its constructor.

```C# Snippet:ConfigurationCustomHttpClient
using HttpClientHandler handler = new()
{
    // Reduce the max connections per server, which defaults to 50.
    MaxConnectionsPerServer = 25,

    // Preserve default System.ClientModel redirect behavior.
    AllowAutoRedirect = false,
};

using HttpClient httpClient = new(handler);

MapsClientOptions options = new()
{
    Transport = new HttpClientPipelineTransport(httpClient)
};
```

## Configure User-Agent headers

Library authors can add User-Agent headers to their client requests by including a `UserAgentPolicy` in the client pipeline. This policy automatically generates headers containing the client library name, version, and platform information.

```C# Snippet:ConfigurationUserAgent
MapsClientOptions options = new();

// In a library's client class constructor:
var userAgentPolicy = new UserAgentPolicy(Assembly.GetExecutingAssembly());
ClientPipeline pipeline = ClientPipeline.Create(
    options,
    perCallPolicies: new[] { userAgentPolicy },
    perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
    beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

// With custom application ID:
var customUserAgent = new UserAgentPolicy(Assembly.GetExecutingAssembly(), "MyApp/1.0");
ClientPipeline pipeline2 = ClientPipeline.Create(
    options,
    perCallPolicies: new[] { customUserAgent },
    perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
    beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
```

The generated User-Agent header follows the format: `"LibraryName/Version (.NET Framework; OS Information)"` or `"ApplicationId LibraryName/Version (.NET Framework; OS Information)"` when an application ID is provided.

## Configure a custom network timeout duration

Some services have operations that can take more than the duration of the default timeout value to complete. The `NetworkTimeout` property in `ClientPipelineOptions` can be configured to override the default.

```C# Snippet:ConfigurationCustomNetworkTimeout
MapsClientOptions options = new()
{
    // Increase the default network timeout.
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```