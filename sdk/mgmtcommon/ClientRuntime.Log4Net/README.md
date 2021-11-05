Using Log4Net for AutoRest Generated Clients:
---------------------------------------------
1- Configure the log4net in your app.config/web.config (or your preferred way).
   For more examples on the available configurations check [config examples](https://logging.apache.org/log4net/release/config-examples.html)
   Here's an example of app.config for the logger used with ConsoleAppender:


	<?xml version="1.0" encoding="utf-8" ?>
	<configuration>
	  <configSections>
	    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
	  </configSections>
	
	  <log4net>
	    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
	      <layout type="log4net.Layout.SimpleLayout" />
	    </appender>
	
	    <root>
	      <level value="ALL" />
	      <appender-ref ref="ConsoleAppender" />
	    </root>
	
	    <logger name="Microsoft.Rest.Tracing.Log4Net.Log4NetTracingInterceptor">
	      <level value="DEBUG" />
	      <appender-ref ref="ConsoleAppender"/>
	    </logger>
	  </log4net>
	</configuration>

2- Configure log4net in the application that is using a generated client library. This can be done by
	A) Adding this line to ```AssemblyInfo.cs``` of the application:
```csharp 
[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "FileName.ext")]
```
	B) Passing the config file name to ```Log4NetTracingInterceptor``` constructor.

3- Last step is to register the logger into the ServiceClientTracing and enable tracing by having these lines called at the start of the application:
```csharp
	ServiceClientTracing.AddTracingInterceptor(new Log4NetTracingInterceptor());
	ServiceClientTracing.IsEnabled = true;
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmgmtcommon%2FClientRuntime.Log4Net%2FREADME.png)
