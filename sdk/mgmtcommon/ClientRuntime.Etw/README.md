# ETW Logger for Microsoft AutoRest Generated Clients

Exposes AutoRest Generated Libraries events via ETW (Event Tracing for Windows). ETW events can be captured by subscribing to Microsoft.Rest event source. Requires .NET Framework 4.5 or newer.

# Getting started

1. Register the logger by having this line called at the start of the application
```csharp
ServiceClientInterceptor.AddTracingInterceptor(new EtwTracingInterceptor());
```
2. Use a tool such as [PerfView](https://www.microsoft.com/download/details.aspx?id=28567) to capture events under the ```Microsoft.Rest``` provider.


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmgmtcommon%2FClientRuntime.Etw%2FREADME.png)
