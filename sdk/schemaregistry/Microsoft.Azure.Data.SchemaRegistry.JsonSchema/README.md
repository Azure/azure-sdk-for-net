# Azure Schema Registry Json Schema client library for .NET

Azure Schema Registry is a schema repository service hosted by Azure Event Hubs, providing schema storage, versioning, and management. This package provides a Json Schema serializer capable of serializing and deserializing payloads containing Schema Registry schema identifiers and Json-serialized data.

## Getting started

### Install the package

Install the Azure Schema Registry Json Schema library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.Data.SchemaRegistry.JsonSchema
```

### Prerequisites

* An [Azure subscription][azure_sub]
* An [Event Hubs namespace][event_hubs_namespace]

If you need to [create an Event Hubs namespace][create_event_hubs_namespace], you can use the Azure Portal or [Azure PowerShell][azure_powershell].

You can use Azure PowerShell to create the Event Hubs namespace with the following command:

```PowerShell
New-AzEventHubNamespace -ResourceGroupName myResourceGroup -NamespaceName namespace_name -Location eastus
```

### Authenticate the client

In order to interact with the Azure Schema Registry service, you'll need to create an instance of the [Schema Registry Client][schema_registry_client] class. To create this client, you'll need Azure resource credentials and the Event Hubs namespace hostname.

#### Get credentials

To acquire authenicated credentials and start interacting with Azure resources, please see the [quickstart guide here][quickstart_guide].

#### Get Event Hubs namespace hostname

The simpliest way is to use the [Azure portal][azure_portal] and navigate to your Event Hubs namespace. From the Overview tab, you'll see `Host name`. Copy the value from this field.

#### Create SchemaRegistryClient

Once you have the Azure resource credentials and the Event Hubs namespace hostname, you can create the [SchemaRegistryClient][schema_registry_client]. You'll also need the [Azure.Identity][azure_identity] package to create the credential.

## Key concepts

### Serializer

This library provides a serializer, that interacts with `EventData` events. The SchemaRegistryJsonSerializer utilizes a SchemaRegistryClient to enrich the `EventData` events with the schema ID for the schema used to serialize the data.


### Examples

### Serialize and deserialize data using the Event Hub EventData model

In order to serialize an `EventData` instance with Json information, you can do the following:

To deserialize an `EventData` event that you are consuming:

You can also use generic methods to serialize and deserialize the data. This may be more convenient if you are not building a library on top of the Json Schema serializer, as you won't have to worry about the virality of generics:

Similarly, to deserialize:

### Serialize and deserialize data using `MessageContent` directly

It is also possible to serialize and deserialize using `MessageContent`. Use this option if you are not integrating with any of the messaging libraries that work with `MessageContent`.

## Troubleshooting

If you encounter errors when communicating with the Schema Registry service, these errors will be thrown as a [RequestFailedException][request_failed_exception]. The serializer will only communicate with the service the first time it encounters a schema (when serializing) or a schema ID (when deserializing). Any errors related to invalid Content-Types will be thrown as a `FormatException`. Errors related to invalid schemas will be thrown as an `Exception`, and the `InnerException` property will contain the underlying exception that was thrown from the Apache Avro library. This type of error would typically be caught during testing and should not be handled in code. Any errors related to incompatible schemas will be thrown as an `Exception` with the `InnerException` property set to the underlying exception from the Apache Avro library.

## Next steps

See Azure Schema Registry for additional information.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-about
[azure_powershell]: https://docs.microsoft.com/powershell/azure/
[create_event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-quickstart-powershell#create-an-event-hubs-namespace
[quickstart_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md
[schema_registry_client]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[schema_properties]: src/SchemaProperties.cs
[azure_identity]: https://www.nuget.org/packages/Azure.Identity
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[request_failed_exception]: https://docs.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
