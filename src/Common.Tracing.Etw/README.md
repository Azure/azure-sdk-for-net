# Microsoft Azure Common Library ETW Logger

Exposes Microsoft Azure Libraries events via ETW (Event Tracing for Windows). ETW events can be captured by subscribing to Microsoft-WindowsAzure event source. Requires .NET Framework 4.5 or newer.

# Getting started

1. Register the logger into the ```CloudContext``` by having this line called at the start of your application
```csharp
CloudContext.Configuration.Tracing.AddTracingInterceptor(new EtwTracingInterceptor());
```
2. Use tool such as PerfView (http://www.microsoft.com/en-us/download/details.aspx?id=28567) to capture events under ```Microsoft-WindowsAzure``` provider.
