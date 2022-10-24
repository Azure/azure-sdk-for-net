# Azure client configuration samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

## Configuring retry options

To modify the retry options use the `Retry` property of client options class.

Be default clients are setup to retry 3 times with exponential retry kind and initial delay of 0.8 sec.

```C# Snippet:RetryOptions
SecretClientOptions options = new SecretClientOptions()
{
    Retry =
    {
        Delay = TimeSpan.FromSeconds(2),
        MaxRetries = 10,
        Mode = RetryMode.Fixed
    }
};
```

## Setting a retry policy

Using `RetryOptions` to configure retry behavior is sufficient for the vast majority of scenarios. For more advanced scenarios, it is possible to create a custom retry policy and set it to the `RetryPolicy` property of client options class. This can be accomplished by implementing a retry policy that derives from the abstract `RetryPolicy` class. The `RetryPolicy` class contains hooks to determine if a request should be retried and how long to wait before retrying. In the following example, we implement a policy that will prevent retries from taking place if the overall processing time has exceeded some threshold. Notice that the policy takes in `RetryOptions` as one of the constructor parameters and passes it to the base constructor. By doing this, we are able to delegate to the base `RetryPolicy` as needed (either by explicitly invoking the base methods, or by not overriding methods that we do not need to customize) which will respect the `RetryOptions`.

```C# Snippet:GlobalTimeoutRetryPolicy
internal class GlobalTimeoutRetryPolicy : RetryPolicy
{
    private readonly TimeSpan _timeout;

    public GlobalTimeoutRetryPolicy(RetryOptions options, TimeSpan timeout) : base(options)
    {
        _timeout = timeout;
    }

    protected internal override bool ShouldRetry(HttpMessage message)
    {
        return ShouldRetryInternalAsync(message, false).EnsureCompleted();
    }
    protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message)
    {
        return ShouldRetryInternalAsync(message, true);
    }

    private ValueTask<bool> ShouldRetryInternalAsync(HttpMessage message, bool async)
    {
        TimeSpan elapsedTime = message.ProcessingContext.StartTime - DateTimeOffset.UtcNow;
        if (elapsedTime > _timeout)
        {
            return new ValueTask<bool>(false);
        }

        return async ? base.ShouldRetryAsync(message) : new ValueTask<bool>(base.ShouldRetry(message));
    }
}
```

Here is how we would configure the client to use the policy we just created.

```C# Snippet:SetGlobalTimeoutRetryPolicy
var retryOptions = new RetryOptions
{
    Delay = TimeSpan.FromSeconds(2),
    MaxRetries = 10,
    Mode = RetryMode.Fixed
};
SecretClientOptions options = new SecretClientOptions()
{
    RetryPolicy = new GlobalTimeoutRetryPolicy(retryOptions, timeout: TimeSpan.FromSeconds(30))
};
```

It's also possible to have full control over the retry logic by setting the `RetryPolicy` property to an implementation of `HttpPipelinePolicy` where you would need to implement the retry loop yourself. One use case for this is if you want to implement your own retry policy with Polly. Note that if you replace the `RetryPolicy` with a `HttpPipelinePolicy`, you will need to make sure to update the `HttpMessage.ProcessingContext` that other pipeline policies may be relying on.

```C# Snippet:PollyPolicy
internal class PollyPolicy : HttpPipelinePolicy
{
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        Policy.Handle<IOException>()
            .Or<RequestFailedException>(ex => ex.Status == 0)
            .OrResult<Response>(r => r.Status >= 400)
            .WaitAndRetry(
                new[]
                {
                    // some custom retry delay pattern
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                },
                onRetry: (result, _) =>
                {
                    // Since we are overriding the RetryPolicy, it is our responsibility to maintain the ProcessingContext
                    // that other policies in the pipeline may be depending on.
                    var context = message.ProcessingContext;
                    if (result.Exception != null)
                    {
                        context.LastException = result.Exception;
                    }
                    context.RetryNumber++;
                }
            )
            .Execute(() =>
            {
                ProcessNext(message, pipeline);
                return message.Response;
            });
    }
    // async version omitted for brevity
}
```

To set the policy, use the `RetryPolicy` property of client options class.
```C# Snippet:SetPollyRetryPolicy
SecretClientOptions options = new SecretClientOptions()
{
    RetryPolicy = new PollyPolicy()
};
```

## User provided HttpClient instance

```C# Snippet:SettingHttpClient
using HttpClient client = new HttpClient();

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```

## Configuring a proxy

```C# Snippet:HttpClientProxyConfiguration
using HttpClientHandler handler = new HttpClientHandler()
{
    Proxy = new WebProxy(new Uri("http://example.com"))
};

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(handler)
};
```

## Configuring a proxy using environment variables

You can also configure a proxy using the following environment variables:

* `HTTP_PROXY`: the proxy server used on HTTP requests.
* `HTTPS_PROXY`: the proxy server used on HTTPS requests.
* `ALL_PROXY`: the proxy server used on HTTP and HTTPS requests in case `HTTP_PROXY` or `HTTPS_PROXY` are not defined.
* `NO_PROXY`: a comma-separated list of hostnames that should be excluded from proxying.

**Warning:** setting these environment variables will affect every new client created within the current process.
