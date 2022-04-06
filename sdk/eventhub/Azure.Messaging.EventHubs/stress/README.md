# Event Hub Stress Tests
This is a preliminary README. It demonstrates how to use the stress tests in the current state, and will be updated as the files are updated.

In order to run the stress tests locally, the necessary resource connections need to be input through the command line interface. Test runs can call any of the following tests:
- Basic Publish Read Test ("BasicPublishReadTest")
- Basic Event Processor Test  ("EventProcessorTest")
- Event Producer Test ("EventProducerTest")
- Processor Empty Read Test ("ProcessorEmptyReadTest")

The publish test and producer test require any event hub and namespace. Processor Tests require their own empty dedicated event hub in order to properly verify publishing. They also require a namespace, storage account, and blob container.

## Local Stress Test Runs
### Setting up resources and packages
```cmd
(env) ~/stress/src> dotnet clean 
(env) ~/stress/src> dotnet restore
(env) ~/stress/src> dotnet build
```

### Running Tests
To run all tests, run the following from the /stress/src directory. The "local" flag tells the tests to request azure resources directly. 
```cmd
(env) ~/stress/src> dotnet run -f netcoreapp3.1 BasicPublishReadTest EventProcessorTest EventProducerTest ProcessorEmptyReadTest local
```
To run any one test, run the following:
```cmd
(env) ~/stress/src> dotnet run -f netcoreapp3.1 BasicPublishReadTest local
```
TODO: there is an issue when running locally using net6.0 that needs to be debugged

## Deploy a stress test
TODO: In order to deploy a stress test, the preliminary docker image containing the build information needs to be created. This can be done by running the following command from the /stress directory:
```cmd
(env) ./buildstress.ps1
```

Once this is done, the test can be deployed by running:
```cmd 
(env) ~/azure-sdk-for-net/eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```

## Seeing Metrics and Logging in App Insights
TODO: look at other app insights options that might be easier

Status reports are sent to app insights as trace messages. To see these navigate to your App Insights instance within the azure portal. In the side panel, navigate to Monitoring > Logs. Input the query "traces" and press run. Sort the results by time to see the test outputs as they progress. Errors, exceptions, and failures are tracked through metrics. If any are reported, they will be populated in Monitoring > Metrics. The aggregation of these metrics is customizable within the portal.
