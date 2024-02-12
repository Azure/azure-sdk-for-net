# System.ClientModel library for .NET

`System.ClientModel` contains building blocks for communicating with cloud services.  It provides shared primitives, abstractions, and helpers for .NET service client libraries.

`System.ClientModel` allows client libraries built from its components to expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you'll know how to use them in other client libraries as well.

[Source code][source] | [Package (NuGet)][package]

## Getting started

Typically, you will not need to install `System.ClientModel`.
it will be installed for you when you install one of the client libraries using it.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/packages/System.ClientModel).

```dotnetcli
dotnet add package System.ClientModel
```

### Prerequisites

None needed for `System.ClientModel`.

### Authenticate the client

The `System.ClientModel` package provides a `KeyCredential` type for authentication.

## Key concepts

The main shared concepts of `System.ClientModel` include:

- Configuring service clients (`ClientPipelineOptions`).
- Accessing HTTP response details (`ClientResult`, `ClientResult<T>`).
- Exceptions for reporting errors from service requests in a consistent fashion (`ClientResultException`).
- Customizing requests (`RequestOptions`).
- Providing APIs to read and write models in different formats (`ModelReaderWriter`).

## Examples

### Send a message using the MessagePipeline

A very basic client implementation might use the following approach:

```csharp
ApiKeyCredential credential = new ApiKeyCredential(key);
ApiKeyAuthenticationPolicy authenticationPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);
ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions, authenticationPolicy);

PipelineMessage message = pipeline.CreateMessage();
message.Apply(requestOptions);
message.MessageClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

PipelineRequest request = message.Request;
request.Method = "GET";
request.Uri = new Uri("https://www.example.com/");
request.Headers.Add("Accept", "application/json");

pipeline.Send(message);
Console.WriteLine(message.Response.Status);
```

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

You can troubleshoot `System.ClientModel`-based clients by inspecting the result of any `ClientResultException` thrown from a pipeline's `Send` method.

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
