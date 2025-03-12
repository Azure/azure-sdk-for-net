# Azure Core Expressions DataFactory shared client library for .NET

Azure.Core.Expressions.DataFactory provides classes that represent [Expressions](https://learn.microsoft.com/azure/data-factory/control-flow-expression-language-functions#expressions).

## Getting started

Typically, you will not need to install Azure.Core.Expressions.DataFactory;
it will be installed for you when you install one of the client libraries using it.
In case you want to install it explicitly (to implement your own client library, for example),
you can find the NuGet package.

## Key concepts

In the datafactory API many of the properties have the ability to either be a constant value, an expression which will be evaluated at runtime, a secure string, or a reference to a key vault secret.
The structure of the JSON payload is different depending on which of these concepts the value maps to. As an example, the [FolderPath](https://github.com/Azure/azure-rest-api-specs/blob/main/specification/datafactory/resource-manager/Microsoft.DataFactory/stable/2018-06-01/entityTypes/Dataset.json#L1353)
property of an AzureBlobDataset can either be a "string (or Expression with resultType string)". Implicit in this definition is the fact that it can also be a secure string or a key vault secret reference. This is true for any property that can be expressed as a string or an expression with a result type of string.

### Json representation

#### Literal

```json
"folderPath": "foo/bar"
```

#### Expression

```json
"folderpath": {
  "type": "Expression",
  "value": "foo/bar-@{pipeline().TriggerTime}"
}
```

In this example when the pipeline is run in the first case the folder is always `foo/bar`, but in the second case the service will append the time the pipeline kicked off to the folder name.

#### Secure String

```json
"folderpath": {
  "type": "SecureString",
  "value": "some/secret/path"
}
```

When a secure string is used, the value is return masked with '*' characters when the resource is retrieved from the service.

#### Key Vault Secret Reference

```json
"folderpath": {
  "type": "AzureKeyVaultSecret",
  "store": {
    "type": "LinkedServiceReference",
    "referenceName": "someReferenceName"
  },
  "secretName": "someSecretName",
  "secretVersion": "someSecretVersion"
}
```

A Key Vault Reference can be used to specify a Key Vault where the value of the property is stored.

### DataFactoryElement<T>

The `DataFactoryElement<T>` class allows us to model the literal value expected by this property using strongly typed practices.
If the expression should evaluate to an `int` then a literal value that is assigned to the same property must also be an int.

With the FolderPath example above we could set the property using either case below.

#### Literal

```C# Snippet:DataFactoryElementLiteral
blobDataSet.FolderPath = "foo/bar";
```

#### Expression

```C# Snippet:DataFactoryElementFromExpression
blobDataSet.FolderPath = DataFactoryElement<string>.FromExpression("foo/bar-@{pipeline().TriggerTime}");
```

#### Secret String

```C# Snippet:DataFactoryElementSecretString
blobDataSet.FolderPath = DataFactoryElement<string>.FromSecretString("some/secret/path");
```

#### Key Vault Secret Reference

```C# Snippet:DataFactoryElementKeyVaultSecretReference
var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference,
    "referenceName");
var keyVaultReference = new DataFactoryKeyVaultSecret(store, "secretName");
blobDataSet.FolderPath = DataFactoryElement<string>.FromKeyVaultSecret(keyVaultReference);
```

In each case the library will be able to serialize and deserialize all scenarios appropriately allowing you to seamlessly use either according to your application's needs.

## Troubleshooting

Three main ways of troubleshooting failures are [inspecting exceptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Response.md#handling-exceptions), enabling [logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#Logging), and [distributed tracing](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#Distributed-tracing)

## Next steps

Explore and install [available Azure SDK libraries](https://azure.github.io/azure-sdk/releases/latest/dotnet.html).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src
[package]: https://www.nuget.org/packages/Azure.Core/
[docs]: https://learn.microsoft.com/dotnet/api/azure.core
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
