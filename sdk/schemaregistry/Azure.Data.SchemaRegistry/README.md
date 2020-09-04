# Azure Schema Registry client library for .NET

The Azure Schema Registry service allows developers to provide and retrieve data schemas from a centralized repository for use in messaging systems.

## Getting started

### Install the package

Install the Azure Schema Registry client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Data.SchemaRegistry
```

### Prerequisites

* An [Azure subscription][azure_sub].
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

Once you have the Azure resource credentials and the Event Hubs namespace hostname, you can create the [SchemaRegistryClient][schema_registry_client]:

```C# Snippet:CreateSchemaRegistryClient
string connectionString = "<connection_string>";
var client = new ConfigurationClient(connectionString);
```

## Key concepts

### Schemas

A schema has 6 components:
- Group Name
- Schema Name
- Schema ID
- Serialization Type
- Schema Content
- Schema Version

These components play different roles. Some are used as input into the operations and some are outputs. Currently, [SchemaProperties][schema_properties] only exposes those properties that are potential outputs that are used in SchemaRegistry operations. Those exposed properties are `Content` and `Id`.

## Examples

* [Register a schema](#create-the-thing)
* [Retrieve a schema ID](#get-the-thing)
* [Retrieve a schema](#list-the-things)




Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `examples.py` that Sphinx ingests via its [literalinclude](https://www.sphinx-doc.org/en/1.5/markup/code.html?highlight=code%20examples#includes) directive. The `examples.py` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

* [Create the thing](#create-the-thing)
* [Get the thing](#get-the-thing)
* [List the things](#list-the-things)

### Create the thing

Use the [create_thing](not-valid-link) method to create a Thing reference; this method does not make a network call. To persist the Thing in the service, call [Thing.save](not-valid-link).

```Python
thing = client.create_thing(id, name)
thing.save()
```

### Get the thing

The [get_thing](not-valid-link) method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

```C# Snippet:GetSecret
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = client.GetSecret("TestSecret");

Console.WriteLine(secret.Value);
```Python
things = client.list_things()
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about
[azure_powershell]: https://docs.microsoft.com/en-us/powershell/azure/
[create_event_hubs_namespace]: https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quickstart-powershell#create-an-event-hubs-namespace
[quickstart_guide]: https://github.com/Azure/azure-sdk-for-net/blob/master/doc/mgmt_preview_quickstart.md
[schema_registry_client]: src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[schema_properties]: src/SchemaProperties.cs
