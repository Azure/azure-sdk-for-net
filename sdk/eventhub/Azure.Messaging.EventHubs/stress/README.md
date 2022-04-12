# Event Hub Stress Tests
This is a preliminary README. It demonstrates how to use the stress tests in the current state.

In order to run the stress tests locally, the necessary resource connections need to be input through the command line interface. Test runs can call any of the following tests:
- Basic Publish Read Test ("BasicPublishReadTest")
- Basic Event Processor Test  ("EventProcessorTest")
- Event Producer Test ("EventProducerTest")
- Processor Empty Read Test ("ProcessorEmptyReadTest")
- Basic Buffered Producer Test ("BasicBufferedProducerTest")
- Buffered Producer Test ("BufferedProducerTest")

## Local Stress Test Runs
### Setting up resources and packages
```cmd
(env) ~/stress/src> dotnet clean
(env) ~/stress/src> dotnet build
```

### Running Tests
When tests are run locally, Azure resources need to be created prior to running the test. This can be done through the Azure CLI, an ARM template or bicep file, or the Azure Portal. The user is required to input the connection strings upon request on the command line when the test is being run. For more information about what resources are needed for each test, see the "Scenario Information" section below. 

The recommended approach is to run tests one at a time. The default for all individual tests are multi-day test runs.
To run any one test, run the following:
```cmd
(env) ~/stress/src> dotnet run -f netcoreapp3.1 BasicPublishReadTest local
```
TODO: there is an issue when running locally using net6.0 that needs to be debugged (need to see if this is true in the cluster as well)

## Deploy a stress test
In order to deploy stress tests to be run in kubernetes clusters, run:
```cmd 
(env) ~/azure-sdk-for-net/eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```
This command requires Azure login credentials.

## Scenario Information
### Basic Publish Read Test
The basic publish read test is a single process, stable throughput, producer client test, that simply sends batches, and then checks that the consumer properly ingests them. This test just requires any existing Event Hub within an Event Hub Namespace. Unlike other tests, Event Hubs instances with previous use are okay here. It also requires an Application Insights instance. Metrics and traces are sent to the application insights portal.



## Seeing Metrics and Logging in App Insights
TODO: look at other app insights options that might be easier

Status reports are sent to app insights as trace messages. To see these navigate to your App Insights instance within the azure portal. In the side panel, navigate to Monitoring > Logs. Input the query "traces" and press run. Sort the results by time to see the test outputs as they progress. Errors, exceptions, and failures are tracked through metrics. If any are reported, they will be populated in Monitoring > Metrics. The aggregation of these metrics is customizable within the portal.
