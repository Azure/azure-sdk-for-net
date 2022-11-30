# Azure Core Expressions DataFactory shared client library for .NET

Azure.Core.Expressions.DataFactory provides shared classes that represent [Expression](https://learn.microsoft.com/azure/data-factory/control-flow-expression-language-functions#expressions). 

## Getting started

Typically, you will not need to install Azure.Core.Expressions.DataFActory; 
it will be installed for you when you install one of the client libraries using it. 
In case you want to install it explicitly (to implement your own client library, for example), 
you can find the NuGet package.

## Key concepts

In the datafactory API many of the properties have the ability to either be a constant value or an expression which will be evaluated at runtime.
The structure of an expression is different than a constant value for example the [FolderPath](https://github.com/Azure/azure-rest-api-specs/blob/main/specification/datafactory/resource-manager/Microsoft.DataFactory/stable/2018-06-01/entityTypes/Dataset.json#L1353)
property of an AzureBlobDataset can either be a "string (or Expression with resultType string)".

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

### DataFactoryExpressoin<T>

The `DataFactoryExpression<T>` class allows us to model the literal value expected by this property using strongly typed practices.
If the expression should evaluate to an `int` then a literal value that is assigned to the same property must also be an int.

With the FolderPath example above we could set the property using either case below.

#### Literal

```c#
  azureBlobDataset.FolderPath = "foo/bar";
```

#### Expresion

```c#
  azureBlobDataset.FolderPath = DataFactoryExpression<string>.FromExpression("foo/bar-@{pipeline().TriggerTime}");
```

In each case the library will be able to serialize and deserialize both scenarios appropriately allowing you to seemlessly use either according to your applications needs.

## Troubleshooting

Three main ways of troubleshooting failures are [inspecting exceptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Response.md#handling-exceptions), enabling [logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#Logging), and [distributed tracing](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#Distributed-tracing)

## Next steps

Explore and install [available Azure SDK libraries](https://azure.github.io/azure-sdk/releases/latest/dotnet.html).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcore%2FAzure.Core%2FREADME.png)

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src
[package]: https://www.nuget.org/packages/Azure.Core/
[docs]: https://docs.microsoft.com/dotnet/api/azure.core
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
