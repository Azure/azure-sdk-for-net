# Azure Service Bus performance tests

The assets in this area comprise a set of performance tests for the [Azure Service Bus client library for .NET](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/servicebus/Azure.Messaging.ServiceBus) and its associated ecosystem.  The artifacts in this library are intended to be used primarily with the Azure SDK engineering system's testing infrastructure, but may also be run as stand-alone applications from the command line.

## Running performance tests

The Service Bus client library performance are run via a console app. In order to run, specify either via command line or within IDE build arguments the test and set of arguments to use. For example, to run the `SendMessages` test, you can add `SendMessages` to the Application arguments within Visual Studio.
The performance tests rely on the same set of environment variables used by the Service Bus client library's test suite.  Full details can be found in the [Running tests](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/CONTRIBUTING.md#running-tests) section of the contributing guide.
  
## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/servicebus/Azure.Messaging.ServiceBus/CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fservicebus%2FAzure.Messaging.ServiceBus.Perf%2FREADME.png)
