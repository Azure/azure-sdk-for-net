# System.ClientModel-based client logging samples

## Introduction

Clients built on `System.ClientModel` emit log messages by default. These log messages include information about HTTP message requests and responses, retries, exceptions thrown in the transport, and delays in receiving responses.

Clients can be configured to completely disable logging, or enable additional log messages.

By default, logs are written to Event Source. Clients can be configured to write logs to ILogger instead by providing an ILoggerFactory to the client in `ClientLoggingOptions`.

## Using ILoggerFactory to capture logs

Here is an example of how a client can be configured to use `ILogger`. Information about acquiring or defining an `ILoggerFactory` can be found in the documentation for [`Microsoft.Extensions.Logging`](https://learn.microsoft.com/dotnet/core/extensions/logging?tabs=command-line).

This method of creating an `ILoggerFactory` is a trivial example and is only suitable for simple console apps.

```C# Snippet:UseILoggerFactoryToCaptureLogs
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Information);
});

ClientLoggingOptions loggingOptions = new()
{
    LoggerFactory = factory
};

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};

// Create and use client as usual
```

Some sensitive headers and query parameters are not logged by default and are displayed as "REDACTED". To include them in logs add them to `ClientLoggingOptions.AllowedHeaderNames` or `ClientLoggingOptions.AllowedQueryParameters`.

```C# Snippet:LoggingRedactedHeaderILogger
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

ClientLoggingOptions loggingOptions = new()
{
    LoggerFactory = factory
};
loggingOptions.AllowedHeaderNames.Add("Request-Id");
loggingOptions.AllowedQueryParameters.Add("api-version");

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

You can also disable redaction completely by adding a `"*"` to `ClientLoggingOptions.AllowedHeaderNames` or `ClientLoggingOptions.AllowedQueryParameters`.

```C# Snippet:LoggingAllRedactedHeadersILogger
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

ClientLoggingOptions loggingOptions = new()
{
    LoggerFactory = factory
};
loggingOptions.AllowedHeaderNames.Add("*");
loggingOptions.AllowedQueryParameters.Add("*");

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

By default, only URI and header names are logged. To enable content logging, set the logging level to `LogLevel.Debug` and set the `ClientLoggingOptions.EnableMessageContentLogging` client option:


```C# Snippet:EnableContentLoggingILogger
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Debug);
});

ClientLoggingOptions loggingOptions = new()
{
    LoggerFactory = factory,
    EnableMessageContentLogging = true
};

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

## Using Event Source to capture logs

If an `ILoggerFactory` is not provided to the client, and logging is enabled, logs will be written to Event Source. The name of the Event Source is "System.ClientModel". Event Source logs can be collected in a few ways, as described in the [Event Source documentation for collecting traces](https://learn.microsoft.com/dotnet/core/diagnostics/eventsource-collect-and-view-traces).

This sample uses an Event Listener to collect logs. It uses the `ConsoleWriterEventListener` as defined in the [EventListener section](https://learn.microsoft.com/dotnet/core/diagnostics/eventsource-collect-and-view-traces#eventlistener) of the Event Source documentation above.

```C# Snippet:UseEventSourceToCaptureLogs
// In order for an event listener to collect logs, it must be in scope and active
// while the client library is in use.  If the listener is disposed or otherwise
// out of scope, logs cannot be collected.
using ConsoleWriterEventListener listener = new();

// Create and use client as usual
```

Some sensitive headers and query parameters are not logged by default and are displayed as "REDACTED". To include them in logs add them to `ClientLoggingOptions.AllowedHeaderNames` or `ClientLoggingOptions.AllowedQueryParameters`.

```C# Snippet:LoggingRedactedHeaderEventSource
using ConsoleWriterEventListener listener = new();

ClientLoggingOptions loggingOptions = new();
loggingOptions.AllowedHeaderNames.Add("Request-Id");
loggingOptions.AllowedQueryParameters.Add("api-version");

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

You can also disable redaction completely by adding a `"*"` to `ClientLoggingOptions.AllowedHeaderNames` or `ClientLoggingOptions.AllowedQueryParameters`.

```C# Snippet:LoggingAllRedactedHeadersEventSource
using ConsoleWriterEventListener listener = new();

ClientLoggingOptions loggingOptions = new();
loggingOptions.AllowedHeaderNames.Add("*");
loggingOptions.AllowedQueryParameters.Add("*");

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

By default only URI and headers are logged. To enable content logging, set the logging level to `EventLevel.Verbose` and set the `ClientLoggingOptions.EnableMessageContentLogging` client option:

```C# Snippet:EnableContentLoggingEventSource
using ConsoleWriterEventListener listener = new();

ClientLoggingOptions loggingOptions = new()
{
    EnableMessageContentLogging = true
};

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```
