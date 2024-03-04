# System.ClientModel library for .NET

`System.ClientModel` contains building blocks for communicating with cloud services.  It provides shared primitives, abstractions, and helpers for .NET service client libraries.

`System.ClientModel` allows client libraries built from its components to expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you'll know how to use them in other client libraries as well.

[Source code][source] | [Package (NuGet)][package]

## Getting started

Typically, you will not need to install `System.ClientModel`.  It will be installed for you when you install a client library that uses it.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/packages/System.ClientModel).

```dotnetcli
dotnet add package System.ClientModel
```

### Prerequisites

None needed for `System.ClientModel`.

### Authenticate the client

The `System.ClientModel` package provides an `ApiKeyCredential` type for authentication.

## Key concepts

The main concepts used by types in `System.ClientModel` include:

- Configuring service clients (`ClientPipelineOptions`).
- Accessing HTTP response details (`ClientResult`, `ClientResult<T>`).
- Handling exceptions that result from failed requests (`ClientResultException`).
- Customizing HTTP requests (`RequestOptions`).
- Reading and writing models in different formats (`ModelReaderWriter`).

Below, you will find sections explaining these shared concepts in more detail.

## Examples

### Configuring service clients

`System.ClientModel`-based clients provide a constructor that takes a service endpoint and a credential used to authenticate with the service.  They also provide a constructor overload that takes an endpoint, a credential, and an instance of `ClientPipelineOptions` that can be used to configure the pipeline the client uses to send and receive HTTP requests and responses.

`ClientPipelineOptions` allows overriding default client values for things like the network timeout used when sending a request or the maximum number of retries to send when a request fails.

```C# Snippet:ClientModelConfigurationReadme
```

For more information on client configuration, see [Client configuration samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/Configuration.md)

### Accessing HTTP response details

_Service clients_ have methods that are used to call cloud services to invoke service operations. These methods on a client are called _service methods_.

`System.ClientModel`-based clients expose two types of service methods: _convenience methods_ and _protocol methods_.

**Convenience methods** provide a convenient way to invoke a service operation.  They are methods that take a strongly-typed model as input and return a `ClientResult<T>` that holds a strongly-typed representation of the service response.  Details from the HTTP response can be obtained from the return value.

**Protocol method** are low-level methods that take parameters that correspond to the service HTTP API and return a `ClientResult` holding only the raw HTTP response details.  These methods also take an optional `RequestOptions` value that allows the client pipeline and the request to be configured for the duration of the call.

```C# Snippet:ClientResultTReadme
```

For more information on client service methods, see [Client service method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md)

// TODO: move the below to the detailed sample file

**Convenience methods** are service methods that take a strongly-typed model representing schematized data needed to communicate with the service as input, and return a strongly-typed model representing the payload from the service response as output. Having strongly-typed models that represent service concepts provides a layer of convenience over working with the raw payload format. This is because these models unify the client user experience when cloud services differ in payload formats.  That is, a client-user can learn the patterns for strongly-typed models that `System.ClientModel`-based clients provide, and use them together without having to reason about whether a cloud service represents resources using, for example, JSON or XML formats.

**Protocol methods** are service methods that provide very little convenience over the raw HTTP APIs a cloud service exposes. They represent request and response message bodies using types that are very thin layers over raw JSON/binary/other formats. Users of client protocol methods must reference a service's API documentation directly, rather than relying on the client to provide developer conveniences via strongly-typing service schemas.

### Handling exceptions that result from failed requests

When a service call fails, `System.ClientModel`-based clients throw a `ClientResultException`.  The exception exposes the HTTP status code and the details of the service response if available.

```C# Snippet:ClientResultExceptionReadme
```

### Customizing HTTP requests

`System.ClientModel`-based clients expose low-level _protocol methods_ that allow callers to customize the details of HTTP requests.  Protocol methods take an optional `RequestOptions` value that allows callers to add a header to the request, or to add a policy to the client pipeline that can modify the request in any way before sending it to the service.  `RequestOptions` also allows passing a `CancellationToken` to the method.

```C# Snippet:RequestOptionsReadme
```

For more information on customizing request, see [Protocol method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods)

### Read and write persistable models

As a library author you can implement `IPersistableModel<T>` or `IJsonModel<T>` which will give library users the ability to read and write your models.

Example writing an instance of a model.

```C# Snippet:Readme_Write_Simple
InputModel model = new InputModel();
BinaryData data = ModelReaderWriter.Write(model);
```

Example reading a model from json

```C# Snippet:Readme_Read_Simple
string json = @"{
  ""x"": 1,
  ""y"": 2,
  ""z"": 3
}";
OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json));
```

## Troubleshooting

You can troubleshoot `System.ClientModel`-based clients by inspecting the result of any `ClientResultException` thrown from a client's service method.

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcore%2FAzure.Core%2FREADME.png)

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/System.ClientModel/src
[package]: https://www.nuget.org/packages/System.ClientModel
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
