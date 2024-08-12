# HTTP Retry

For the **transient** mode, this SDK provides the capability to automatically resend requests when transient errors occur, as long as the requests are idempotent.

## Which kinds of requests are tried

In particular, the following types of requests are retried:

* For message requests that send messages to SignalR clients, the SDK retries the request if the HTTP response status code is greater than 500. Note that when the HTTP response code is equal to 500, it may indicate a timeout on the service side, and retrying the request could result in duplicate messages.

* For other types of requests, such as adding a connection to a group, the SDK retries the request under the following conditions:
    1. The HTTP response status code is in the 5xx range, or the request timed out with a status code of 408 (Request Timeout).
    2. The request timed out.

Please note that the SDK can only retry idempotent requests, which are requests that have no additional effect if they are repeated. If your requests are not idempotent, you may need to handle retries manually.

## Retry options

### Retry modes
The SDK provides two retry modes, `Exponential` and `Fixed`. The default retry mode is `FixedRetryPolicy`, which retries requests with a fixed interval. The`ExponentialRetryPolicy` retries requests with an exponential backoff.

### Max retry counts
The maximum number of retry attempts before giving up. The default value is 3.

### Delay timespan
The delay between retry attempts for a fixed approach or the delay on which to base calculations for a backoff-based approach. The default value is 0.8 seconds.

### Max delay timespan
The maximum permissible delay between retry attempts. The default value is 1 minute.


## How to enable retry

You have two options to enable retry.

1. Update application settings
2. Update .NET code

### Option 1: Update application settings

For your Azure functions app, add the following app settings to your Azure functions:

The settings set the mode to `Fixed`, max retries to 3 and the delay timespan to 2 seconds.
```
AzureSignalRRetry__MaxRetries = 2
AzureSignalRRetry__Delay = 00:00:02
AzureSignalRRetry__Mode = Fixed
```

The settings set the mode to `Exponential`, max retries to 3 and the initial delay timespan to 1 seconds.

```
AzureSignalRRetry__MaxRetries = 3
AzureSignalRRetry__Delay = 00:00:01
AzureSignalRRetry__Mode = Exponential
```


If you run the app locally, you should add the setting to your `local.settings.json` file and replace the `__` with `:` in the key name.

```json
{
    "Values": {
        "AzureSignalRRetry:MaxRetries": "3",
    }
}

```

## Option 2: Update .NET code

```C# Snippet:RetryCustomization
public class RetryStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.Configure<SignalROptions>(o => o.RetryOptions = new ServiceManagerRetryOptions
        {
            Mode = ServiceManagerRetryMode.Exponential,
            MaxDelay = TimeSpan.FromSeconds(30),
            MaxRetries = 5,
            Delay = TimeSpan.FromSeconds(1),
        });
    }
}
```
