# Azure client configuration samples

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
using HttpClient client = new HttpClient(
    new HttpClientHandler()
    {
        Proxy = new WebProxy(new Uri("http://example.com"))
    });

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```

## Enabling content logging

By default only URI and headers are logged to enable content logging set the `Diagnostics.IsLoggingContentEnabled` client option:

```C# Snippet:LoggingContent
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        IsLoggingContentEnabled = true
    }
};
```

## Logging redacted headers and query parameters

Some sensetive headers and query parameters are not logged by default and are displayed as `REDACTED`, to include them in logs use the `Diagnostics.LoggedHeaderNames` and `Diagnostics.LoggedQueryParameters` client options.

```C# Snippet:LoggingRedactedHeader
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "x-ms-request-id" },
        LoggedQueryParameters = { "api-version" }
    }
};
```

You can also disable redaction completely by adding a `"*"` to collections mentioned above.

```C# Snippet:LoggingRedactedHeaderAll
SecretClientOptions options = new SecretClientOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "*" },
        LoggedQueryParameters = { "*" }
    }
};
```
