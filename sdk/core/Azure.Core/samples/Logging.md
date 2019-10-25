# Azure.Core logging samples

## Enabling console logging

To enable console logging in you app use the `AzureEventSourceListener.CreateConsoleLogger` method

```C# Snippet:ConsoleLogging
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
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