# Azure Digital Twins management client library for .NET

Azure Digital Twins is a developer platform for next-generation IoT solutions that lets you create, run, and manage digital representations of your business environment, securely and efficiently in the cloud.

Use the client library for Digital Twins to:

- Digital twins instances
- Digital twins endpoints

[Source code][source] | [Package (NuGet)][adt_nuget] | [API reference documentation][TODO] | [Product documentation][digital_twins_documentation]

## Getting started

### Install the package

Install the Azure Digital Twins management library for .NET with NuGet:

```console
Install-Package Azure.ResourceMnager.DigitalTwins
```

### Prerequisites

- A Microsoft Azure Subscription
  - To call Microsoft Azure services, create an [Azure subscription][azure_sub].

### Authenticate the client

In order to interact with the Azure Digital Twins service, you will need to create an instance of a [TokenCredential class][token_credential] and pass it to the constructor of your [DigitalTwinsClient][digital_twins_client].

## Key concepts

Azure Digital Twins Preview is an Azure IoT service that creates comprehensive models of the physical environment.
It can create spatial intelligence graphs to model the relationships and interactions between people, spaces, and devices.

You can learn more about Azure Digital Twins by visiting [Azure Digital Twins Documentation][digital_twins_documentation]

## Examples

TODO

* [Create the thing](#create-the-thing)
* [Get the thing](#get-the-thing)
* [List the things](#list-the-things)

### Create the thing

Use the `create_thing` method to create a Thing reference; this method does not make a network call. To persist the Thing in the service, call `Thing.save`.

### Get the thing

The `get_thing` method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

## Troubleshooting

All service operations will throw RequestFailedException on failure reported by the service, with helpful error codes and other information.

## Next steps

TODO

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct].
For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.ResourceManager.DigitalTwins
[package]: https://www.nuget.org/packages/Azure.DigitalTwins.Core
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[token_credential]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet
[digital_twins_documentation]: https://docs.microsoft.com/en-us/azure/digital-twins/
[adt_nuget]: https://www.nuget.org/packages/Azure.ResourceManager.DigitalTwins

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fdigitaltwins%2FAzure.ResourceManager.DigitalTwins%2FREADME.md)
