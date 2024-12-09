# Azure client configuration samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

## Configuring retry options

To modify the retry options, use the `Retry` property of the `ClientOptions` class.

By default, clients are setup to retry 3 times using an exponential retry strategy with an initial delay of 0.8 sec, and a max delay of 1 minute.

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

## Setting a custom retry policy

Using `RetryOptions` to configure retry behavior is sufficient for the vast majority of scenarios. For more advanced scenarios, it's possible to use a custom retry policy by setting the `RetryPolicy` property of client options class. This can be accomplished by implementing a retry policy that derives from the `RetryPolicy` class, or by passing in a `DelayStrategy` into the existing `RetryPolicy` constructor. The `RetryPolicy` class contains hooks to determine if a request should be retried and how long to wait before retrying.

In the following example, we implement a policy that will prevent retries from taking place if the overall processing time has exceeded a configured threshold. Notice that the policy takes in `RetryOptions` as one of the constructor parameters and passes it to the base constructor. By doing this, we are able to delegate to the base `RetryPolicy` as needed (either by explicitly invoking the base methods, or by not overriding methods that we do not need to customize) which will respect the `RetryOptions`.

```C# Snippet:GlobalTimeoutRetryPolicy
internal class GlobalTimeoutRetryPolicy : RetryPolicy
{
    private readonly TimeSpan _timeout;

    public GlobalTimeoutRetryPolicy(int maxRetries, DelayStrategy delayStrategy, TimeSpan timeout) : base(maxRetries, delayStrategy)
    {
        _timeout = timeout;
    }

    protected internal override bool ShouldRetry(HttpMessage message, Exception exception)
    {
        return ShouldRetryInternalAsync(message, exception, false).EnsureCompleted();
    }
    protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
    {
        return ShouldRetryInternalAsync(message, exception, true);
    }

    private ValueTask<bool> ShouldRetryInternalAsync(HttpMessage message, Exception exception, bool async)
    {
        TimeSpan elapsedTime = message.ProcessingContext.StartTime - DateTimeOffset.UtcNow;
        if (elapsedTime > _timeout)
        {
            return new ValueTask<bool>(false);
        }

        return async ? base.ShouldRetryAsync(message, exception) : new ValueTask<bool>(base.ShouldRetry(message, exception));
    }
}
```

Here is how we would configure the client to use the policy we just created.

```C# Snippet:SetGlobalTimeoutRetryPolicy
var delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromSeconds(2));
SecretClientOptions options = new SecretClientOptions()
{
    RetryPolicy = new GlobalTimeoutRetryPolicy(maxRetries: 4, delayStrategy: delay, timeout: TimeSpan.FromSeconds(30))
};
```

Another scenario where it may be helpful to use a custom retry policy is when you need to customize the delay behavior, but don't need to adjust the logic used to determine whether a request should be retried or not. In this case, it isn't necessary to create a custom `RetryPolicy` class - instead, you can pass in a `DelayStrategy` into the `RetryPolicy` constructor.

In the below example, we create a customized delay strategy that uses a fixed sequence of delays that are iterated through as the number of retries increases. We then pass the strategy into the `RetryPolicy` constructor and set the constructed policy in our options.
```C# Snippet:SequentialDelayStrategy
public class SequentialDelayStrategy : DelayStrategy
{
    private static readonly TimeSpan[] PollingSequence = new TimeSpan[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(4),
        TimeSpan.FromSeconds(8),
        TimeSpan.FromSeconds(16),
        TimeSpan.FromSeconds(32)
    };
    private static readonly TimeSpan MaxDelay = PollingSequence[PollingSequence.Length - 1];

    protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
    {
        int index = retryNumber - 1;
        return index >= PollingSequence.Length ? MaxDelay : PollingSequence[index];
    }
}
```

Here is how the custom delay would be used in the client options.
```C# Snippet:CustomizedDelay
SecretClientOptions options = new SecretClientOptions()
{
    RetryPolicy = new RetryPolicy(delayStrategy: new SequentialDelayStrategy())
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
                    // Since we are overriding the RetryPolicy, it is our responsibility to increment the RetryNumber
                    // that other policies in the pipeline may be depending on.
                    var context = message.ProcessingContext;
                    context.RetryNumber++;
                }
            )
            .Execute(() =>
            {
                ProcessNext(message, pipeline);
                return message.Response;
            });
    }

    public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        // async version omitted for brevity
        throw new NotImplementedException();
    }
}
```

To set the policy, use the `RetryPolicy` property of client options class.
```C# Snippet:SetPollyRetryPolicy
SecretClientOptions options = new SecretClientOptions()
{
    RetryPolicy = new PollyPolicy()
};
```

> **_A note to library authors:_**
Library-specific response classifiers _will_ be respected if a user sets a custom policy deriving from `RetryPolicy` as long as they call into the base `ShouldRetry` method. If a user doesn't call the base method, or sets a `HttpPipelinePolicy` in the `RetryPolicy` property, then the library-specific response classifiers _will not_ be respected.

## User provided HttpClient instance

```C# Snippet:SettingHttpClient
using HttpClient client = new HttpClient();

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```

## Configuring a proxy

This guidance has moved to [Configure a proxy when using the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/configure-proxy).
