# System.Net.ClientModel shared client library for .NET

`System.Net.ClientModel` provides shared primitives, abstractions, and helpers for .NET service client libraries.

`System.Net.ClientModel` allows client libraries built from its components to expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you'll know how to use them in other client libraries as well.

## Getting started

Typically, you will not need to install `System.Net.ClientModel`.
it will be installed for you when you install one of the client libraries using it.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/).

### Prerequisites

None needed for `System.Net.ClientModel`.

### Authenticate the client

The `System.Net.ClientModel` preview package provides a `KeyCredential` type for authentication.

## Key concepts

The main shared concepts of `System.Net.ClientModel` include:

- Configuring service clients (`RequestOptions`).
- Accessing HTTP response details (`Result`, `Result<T>`).
- Exceptions for reporting errors from service requests in a consistent fashion (`MessageFailedException`).
- Providing APIs to read and write models in different formats.

## Examples

### Send a message using the MessagePipeline

A rudimentary client implementation is as follows:

```csharp
KeyCredential credential = new KeyCredential(key);
MessagePipeline pipeline = MessagePipeline.Create(options, new KeyCredentialAuthenticationPolicy(credential, "Authorization", "Bearer"));
ClientMessage message = pipeline.CreateMessage(options, new ResponseStatusClassifier(stackalloc ushort[] { 200 }));
MessageRequest request = message.Request;
request.SetMethod("POST");
var uri = new RequestUri();
uri.Reset(new Uri("https://www.example.com/"));
request.Uri = uri.ToUri();
pipeline.Send(message);
Console.WriteLine(message.Response.Status);
```

## Troubleshooting

You can troubleshoot `System.Net.ClientModel`-based clients by inspecting the result of any `MessageFailedException` thrown from a pipeline's `Send` method.

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcore%2FAzure.Core%2FREADME.png)

[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
