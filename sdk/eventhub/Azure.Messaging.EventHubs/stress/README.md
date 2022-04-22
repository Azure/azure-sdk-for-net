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

## Scenario Information
### Event Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. Note that an event hub may experience throttling if too few partitions are used. This test creates 2 producers and has 5 concurrent processes per producer sending batches of events. This is a long-running, consistent volume test.

### Event Buffered Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. High CPU usage may be experienced if too few partitions are used. This test creates 2 producers and continuously sends to each producer separately. This is a long-running, consistent volume test.

### Concurrent Buffered Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. High CPU usage may be experienced if too few partitions are used. This test creates 2 producers and has 5 concurrent processes per producer continuously sending events. This is a long-running, consistent volume test.

### Burst Buffered Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. Note that this test may have a high CPU usage. This test creates 2 producers and sends sets of events to each producer separately every 15 minutes. This is a long-running, variable volume test.

## Seeing Metrics and Logging in App Insights
All metrics and logging are sent to App Insights via the Instrumentation Key provided during the initialization of the test. A brief explanation of the metrics collection approach is described below.
- Any exceptions that occur are tracked by the telemetry client as exception telemetry. They can be accessed through the logs by filtering for exceptions, or through the application insights portal in the "Exceptions" blade. If an exception occured during send, the exception telemetry will include a "process" property containing "send"
- Successful enqueues and sends are tracked through Metrics. For the buffered producer, the total number of enqueues is tracked, and the actual sends include the ability to separate counts into partition Ids.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs%2stress%2FREADME.png)
