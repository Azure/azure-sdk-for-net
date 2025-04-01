# Azure Service Bus client library for .NET

The scenarios in this directory provide a suite of stress tests that test the Service Bus clients for long-term durability and reliability. For more in-depth information about the Azure SDK stress test tools, see the [stress test readme](https://github.com/Azure/azure-sdk-tools/blob/main/tools/stress-cluster/chaos/README.md).

## Getting started

### Install the package

```cmd
(env) <git root>/sdk/servicebus/Azure.Messaging.ServiceBus/stress/src> dotnet clean
(env) <git root>/sdk/servicebus/Azure.Messaging.ServiceBus/stress/src> dotnet publish
```

### Prerequisites

When tests are run locally, Azure resources need to be created prior to running the test. This can be done through the Azure CLI, an ARM pr bicep file, or the Azure Portal. The bicep file included in this directory can be used to [deploy all resources](https://learn.microsoft.com/azure/azure-resource-manager/bicep/deploy-to-resource-group?tabs=azure-cli) aside from the application insights portal.

To run the compiled .dll file, navigate to the `<git root>/artifacts/bin/Azure.Messaging.ServiceBus.Stress/Release/net7.0` directory.

### Authenticate the client

The user is required to input the connection strings upon request on the command line when the test is being run, or include them in a .env file. To use the CLI input, add the `-i` or `--interactive` flag to the call:

#### Running stress tests locally

To deploy stress tests from the command line, run the following command:
```cmd
(env) <git root>/sdk/servicebus/Azure.Messaging.ServiceBus/stress> ../../../../eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```

## Key concepts

### Scenario: Send and receive test
Uses `ServiceBusSender` and `ServiceBusReceiver` to send and receive messages, each in their own container.

### Scenario: Send and receive batch test
Uses `ServiceBusSender` and `ServiceBusReceiver` to send and receive batches of messages, each in their own container.

### Scenario: Send and receive session test
Uses `ServiceBusSender` and `ServiceBusSessionReceiver` to send and receive session messages, each in their own container.

### Scenario: Send and process test
Uses `ServiceBusSender` and `ServiceBusProcessor` to send and process messages, each in their own container.

### Scenario: Send and process session test
Uses `ServiceBusSender` and `ServiceBusSessionProcessor` to send and process messages, each in their own container.

### Seeing Metrics and Logging in App Insights
All metrics and logging are sent to App Insights via the Instrumentation Key provided during the initialization of the test. A brief explanation of the metrics collection approach is described below.
- Any exceptions that occur are tracked by the telemetry client as exception telemetry. They can be accessed through the logs by filtering for exceptions, or through the application insights portal in the "Exceptions" blade. If an exception occured during send, the exception telemetry will include a "process" property containing "send"
- Successful enqueues and sends are tracked through Metrics. For the buffered producer, the total number of enqueues is tracked, and the actual sends include the ability to separate counts into partition Ids.

See the `Metrics.cs` file for more information about individual metrics and what they mean.

## Examples

### Deploying a stress test
In order to deploy stress tests to be run in kubernetes clusters, run:
```cmd
(env) <git root>/eng/common/scripts/stress-testing/deploy-stress-tests.ps1 `
>>     -Login `
>>     -PushImages
```
This command requires Azure login credentials.

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
