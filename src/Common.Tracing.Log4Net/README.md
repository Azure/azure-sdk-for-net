Using Log4Net for Microsoft Azure SDK:
------------------------------------
1- Configure the log4net in your app.config/web.config (or your preferred way).
   For more example on the available configurations check [config examples](http://logging.apache.org/log4net/release/config-examples.html)
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
	
	    <logger name="Microsoft.WindowsAzure.Common.Tracing.Log4Net.Log4NetTracingInterceptor">
	      <level value="DEBUG" />
	      <appender-ref ref="ConsoleAppender"/>
	    </logger>
	  </log4net>
	</configuration>

2- Configure log4net and start watching. This can be done by
	A) Adding this line to ```AssemblyInfo.cs```:
```csharp 
[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "FileName.ext")]
```
	B) Pass the config file name to ```Log4NetTracingInterceptor``` constructor.

3- Last step is to register the logger into the CloudContext by having this line called at the start of your application
```csharp
	CloudContext.Configuration.Tracing.AddTracingInterceptor(new Log4NetTracingInterceptor());
```