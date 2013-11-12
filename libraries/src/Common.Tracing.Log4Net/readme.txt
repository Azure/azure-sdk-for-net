Using Log4Net for Windows Azure SDK:
------------------------------------
1- Configure the log4net in your app.config/web.config (or your preferred way). For more example on the available configurations check: http://logging.apache.org/log4net/release/config-examples.html

2- Add this line of code in your assembly
	[assembly: log4net.Config.XmlConfigurator(Watch = true)]
   In case you are using configuration file other than app.config you need to specify it here
    [assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "FileName.ext")]

3- Last step is to register the logger into the CloudContext by having this line called at the start of your application
	CloudContext.Configuration.Tracing.AddTracingInterceptor(new Log4NetTracingInterceptor());