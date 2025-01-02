# System.ClientModel-based client logging samples

## Introduction

Clients built on `System.ClientModel` emit log messages by default. These log messages include information about HTTP message requests and responses as well as retries.

Clients can be configured to completely disable logs, or enable additional logs.

By default, logs are written to Event Source. Clients can be configured to write logs to ILogger instead by providing an ILoggerFactory to the client in `ClientLoggingOptions`.

## Using ILoggerFactory to capture logs

```C# Snippet:UseILoggerFactoryToCaptureLogs
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
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

string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
ApiKeyCredential credential = new(key!);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```

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

```C# Snippet:NotLoggingHeadersILogger
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

ClientLoggingOptions loggingOptions = new()
{
    LoggerFactory = factory
};
loggingOptions.AllowedHeaderNames.Clear();
loggingOptions.AllowedQueryParameters.Clear();

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

```C# Snippet:EnableContentLoggingILogger
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
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

```C# Snippet:UseEventSourceToCaptureLogs
// In order for an event listener to collect logs, it must be in scope and active
// while the client library is in use.  If the listener is disposed or otherwise
// out of scope, logs cannot be collected.
using ConsoleWriterEventListener listener = new();

// Create and use client as usual

string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
ApiKeyCredential credential = new(key!);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);
```

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

```C# Snippet:NotLoggingHeadersEventSource
using ConsoleWriterEventListener listener = new();

ClientLoggingOptions loggingOptions = new();
loggingOptions.AllowedHeaderNames.Clear();
loggingOptions.AllowedQueryParameters.Clear();

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

```C# Snippet:EnableContentLoggingEventSource
using ConsoleWriterEventListener listener = new();

ClientLoggingOptions loggingOptions = new();
loggingOptions.AllowedHeaderNames.Clear();
loggingOptions.AllowedQueryParameters.Clear();

MapsClientOptions options = new()
{
    ClientLoggingOptions = loggingOptions
};
```

## Configuring logs

### Logging redacted headers and query paremeters

### 
