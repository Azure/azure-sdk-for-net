# Event Hub Stress Tests
This is a preliminary README. It demonstrates how to use the stress tests in the current state.

In order to run the stress tests locally, the necessary resource connections need to be input through the command line interface. Test runs can call any of the following tests:
- EventProducerTest : "EventProd"
- EventBufferedProducerTest : "EventBuffProd"
- BurstBufferedProducerTest : "BurstBuffProd"
- ConcurrentBufferedProducerTest : "ConcurBuffProd"

## Local Stress Test Runs
### Setting up resources and packages
```cmd
(env) ~/stress/src> dotnet clean
(env) ~/stress/src> dotnet build
```

### Running Tests
When tests are run locally, Azure resources need to be created prior to running the test. This can be done through the Azure CLI, an ARM template or bicep file, or the Azure Portal. The user is required to input the connection strings upon request on the command line when the test is being run. For more information about what resources are needed for each test, see the "Scenario Information" section below. 

The recommended approach is to run tests one at a time when running locally.
To run any one test, run the following:
```cmd
(env) ~/stress/src> dotnet run -f netcoreapp3.1 BasicPublishReadTest local
```

## Deploy a stress test
In order to deploy stress tests to be run in kubernetes clusters, run:
```cmd 
(env) ~/azure-sdk-for-net/eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```
This command requires Azure login credentials.

## Seeing Metrics and Logging in App Insights
All metrics and logging are sent to App Insights via the Instrumentation Key provided during the initialization of the test. A brief explanation of the metrics collection approach is described below.
- Any exceptions that occur are tracked by the telemetry client as exception telemetry. They can be accessed through the logs by filtering for exceptions, or through the application insights portal in the "Exceptions" blade. If an exception occured during send, the exception telemetry will include a "process" property containing "send"
- Successful enqueues and sends are tracked through Metrics. For the buffered producer, the total number of enqueues is tracked, and the sends are tracked as both total and number of sends to each partition.
- Events 
