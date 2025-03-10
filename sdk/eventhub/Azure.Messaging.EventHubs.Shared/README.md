# Azure Event Hubs code sharing library

This library is intended to serve as a common location for non-public code that is shared amongst the packages that comprise the [Azure Event Hubs client library for .NET](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs) development ecosystem.  The artifacts in this library are intended to be small and cohesive units of work with minimal dependencies, which offer common building blocks for internal implementation.  These artifacts should be accompanied by their suite of unit tests, allowing the `Shared` library to have sole responsibility for them.

The other libraries within the Azure Event Hubs ecosystem are expected to include these artifacts by shared links to enable them to be loosely hosted within those projects rather than consumed by direct project or package reference.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
