Using ETW for Windows Azure SDK:
------------------------------------
1- Register the logger into the CloudContext by having this line called at the start of your application
	CloudContext.Configuration.Tracing.AddTracingInterceptor(new EtwTracingInterceptor());
2- Use tool such as PerfView (http://www.microsoft.com/en-us/download/details.aspx?id=28567) to capture events under Microsoft-WindowsAzure provider.