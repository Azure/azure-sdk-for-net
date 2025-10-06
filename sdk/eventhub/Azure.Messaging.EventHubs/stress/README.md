# Azure Event Hubs client library for .NET
The scenarios in this directory provide a suite of stress tests that test the Event Hubs producer and buffered producer client types for long-term durability and reliability. For more in-depth information about the Azure SDK stress test tools, see the [stress test readme](https://github.com/Azure/azure-sdk-tools/blob/main/tools/stress-cluster/chaos/README.md).

Test runs can call any of the following tests:
- "EventProducerTest"
- "BufferedProducerTest"
- "BurstBufferedProducerTest"
- "ProcessorTest"
- "ConsumerTest"

Or, you can run all tests with the "--all" flag.

## Getting started

### Install the package

```cmd
(env) <git root>/sdk/eventhub/Azure.Messaging.EventHubs/stress/src> dotnet clean
(env) <git root>/sdk/eventhub/Azure.Messaging.EventHubs/stress/src> dotnet publish
```

### Prerequisites

When tests are run locally, Azure resources need to be created prior to running the test. This can be done through the Azure CLI, an ARM pr bicep file, or the Azure Portal. The bicep file included in this directory can be used to [deploy all resources](https://learn.microsoft.com/azure/azure-resource-manager/bicep/deploy-to-resource-group?tabs=azure-cli) aside from the application insights portal.

To run the compiled .dll file, navigate to the `<git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0` directory.

### Authenticate the client

The user is required to input the connection strings upon request on the command line when the test is being run, or include them in a .env file. To use the CLI input, add the `-i` or `--interactive` flag to the call:


#### Running stress tests locally
```cmd
(env) <git root>/sdk/eventhub/Azure.Messaging.EventHubs/stress/src> dotnet build './sdk/eventhub/Azure.Messaging.EventHubs/stress/src/' --configuration Release
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests <test/s-to-run> --interactive
```

To see the variable names for the environment file, see `EnvironmentVariables.cs`, The path to the environment file needs to be stored in the environment variable `$ENV_FILE`. In this case, do not include the `--interactive flag`. For more information about what specific resources are needed for each test, see the "Scenario Information" section below.

The recommended approach is to run tests one at a time when running locally.
To run any one test, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests <test/s-to-run> --interactive
```
If running all tests is desired, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --all --interactive
```

## Key concepts

### Scenario: Event Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. Note that an event hub may experience throttling if too few partitions are used. This test creates 2 producers and has 5 concurrent processes per producer sending batches of events. This is a long-running, consistent volume test. To run this test in interactive mode, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests EventProducerTest --interactive
```

### Scenario: Event Buffered Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. This test creates 2 producers and continuously sends to each producer separately. This is a long-running, consistent volume test. To run this test in interactive mode, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests BufferedProducerTest --interactive
```

### Scenario: Burst Buffered Producer Test
This test requires an event hub namespace, an event hub, and an application insights resource. This test creates 2 producers and sends sets of events to each producer separately every 15 minutes. This is a long-running, variable volume test. To run this test in interactive mode, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests BurstBufferedProducerTest --interactive
```

### Scenario: Processor Test
This test requires an event hub namespace, an event hub, a storage account, a storage blob and an application insights resource. This test creates a producer for each partition. Events are augmented with properties to help the processor independently validate ordering and delivery. This test creates two processors to do this. To run this test in interactive mode, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests ProcessorTest --interactive
```

### Scenario: Consumer Test
This test requires an event hub namespace, an event hub, and an application insights resource. This test creates a producer for each partition. Events are augmented with properties to help the consumers independently validate ordering and delivery. This test creates a consumer for each partition within the same process to do this. To run this test in interactive mode, run the following:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --tests ConsumerTest --interactive
```

### Seeing Metrics and Logging in App Insights
All metrics and logging are sent to App Insights via the Instrumentation Key provided during the initialization of the test. A brief explanation of the metrics collection approach is described below.
- Any exceptions that occur are tracked by the telemetry client as exception telemetry. They can be accessed through the logs by filtering for exceptions, or through the application insights portal in the "Exceptions" blade. If an exception occured during send, the exception telemetry will include a "process" property containing "send"
- Successful enqueues and sends are tracked through Metrics. For the buffered producer, the total number of enqueues is tracked, and the actual sends include the ability to separate counts into partition Ids.

See the `Metrics.cs` file for more information about individual metrics and what they mean.

## Examples

#### Local Stress Test Run

With a .env file:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --all
```

Without a .env file:
```cmd
(env) <git root>/artifacts/bin/Azure.Messaging.EventHubs.Stress/Release/net6.0> dotnet Azure.Messaging.EventHubs.Stress.dll --all --interactive
```

## Troubleshooting

- Ensure that all connection strings, instrumentation keys, and event hub names are correct. If using an environment file, make sure they are properly defined and set in the correct variables as defined in `EnvironmentVariables.cs`

## Next steps

### Deploying a stress test
In order to deploy stress tests to be run in kubernetes clusters, run:
```cmd
(env) <git root>/eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```
This command requires Azure login credentials.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
