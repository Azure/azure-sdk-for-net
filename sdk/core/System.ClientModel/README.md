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

The main concepts in `System.ClientModel` include:

- Configuring service clients (`ClientPipelineOptions`).
- Accessing HTTP response details (`ClientResult`, `ClientResult<T>`).
- Handling exceptions that result from failed requests (`ClientResultException`).
- Customizing HTTP requests (`RequestOptions`).
- Reading and writing models in different formats (`ModelReaderWriter`).

Below, you will find sections explaining these shared concepts in more detail.

## Examples

### Configuring service clients

`System.ClientModel`-based clients, or **service clients**, provide a constructor that takes a service endpoint and a credential used to authenticate with the service.  They also provide a constructor overload that takes an endpoint, a credential, and an instance of `ClientPipelineOptions`.
Passing `ClientPipelineOptions` when a client is created will configure the pipeline that the client uses to send and receive HTTP requests and responses.  Client pipeline options can be used to override default values such as the network timeout used to send or retry a request.

```C# Snippet:ClientModelConfigurationReadme
MapsClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromSeconds(120),
};

string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
ApiKeyCredential credential = new(key);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```

For more information on client configuration, see [Client configuration samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/Configuration.md)

### Accessing HTTP response details

Service clients have methods that are used to call cloud services to invoke service operations. These methods on a client are called **service methods**. Service clients expose two types of service methods: _convenience methods_ and _protocol methods_.

**Convenience methods** provide a convenient way to invoke a service operation.  They are methods that take a strongly-typed model as input and return a `ClientResult<T>` that holds a strongly-typed representation of the service response.  Details from the HTTP response can be obtained from the return value.

**Protocol method** are low-level methods that take parameters that correspond to the service HTTP API and return a `ClientResult` holding only the raw HTTP response details.  These methods also take an optional `RequestOptions` value that allows the client pipeline and the request to be configured for the duration of the call.

The following sample illustrates how to call a convenience method and access both the strongly-typed output model and the details of the HTTP response.

```C# Snippet:ClientResultTReadme
// Create a client
string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
ApiKeyCredential credential = new(key);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

// Call a service method, which returns ClientResult<T>
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);

// ClientResult<T> has two members:
//
// (1) A Value property to access the strongly-typed output
IPAddressCountryPair value = result.Value;
Console.WriteLine($"Country is {value.CountryRegion.IsoCode}.");

// (2) A GetRawResponse method for accessing the details of the HTTP response
PipelineResponse response = result.GetRawResponse();

Console.WriteLine($"Response status code: '{response.Status}'.");
Console.WriteLine("Response headers:");
foreach (KeyValuePair<string, string> header in response.Headers)
{
    Console.WriteLine($"Name: '{header.Key}', Value: '{header.Value}'.");
}
```

For more information on client service methods, see [Client service method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md).

### Handling exceptions that result from failed requests

When a service call fails, service clients throw a `ClientResultException`.  The exception exposes the HTTP status code and the details of the service response if available.

```C# Snippet:ClientResultExceptionReadme
try
{
    IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
    ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);
}
// Handle exception with status code 404
catch (ClientResultException e) when (e.Status == 404)
{
    // Handle not found error
    Console.Error.WriteLine($"Error: Response failed with status code: '{e.Status}'");
}
```

### Customizing HTTP requests

Service clients expose low-level _protocol methods_ that allow callers to customize the details of HTTP requests.  Protocol methods take an optional `RequestOptions` value that allows callers to add a header to the request, or to add a policy to the client pipeline that can modify the request in any way before sending it to the service.  `RequestOptions` also allows passing a `CancellationToken` to the method.

```C# Snippet:RequestOptionsReadme
// Create RequestOptions instance
RequestOptions options = new();

// Set CancellationToken
options.CancellationToken = cancellationToken;

// Add a header to the request
options.AddHeader("CustomHeader", "CustomHeaderValue");

// Call protocol method to pass RequestOptions
ClientResult output = await client.GetCountryCodeAsync(ipAddress.ToString(), options);
```

For more information on customizing requests, see [Protocol method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods)

### Read and write persistable models

Client library authors can implement the `IPersistableModel<T>` or `IJsonModel<T>` interfaces on strongly-typed model implementations.  If they do, end-users of service clients can then read and write those models in cases where they need to persist them to a backing store.

The example below shows how to write a persistable model to `BinaryData`.

```C# Snippet:Readme_Write_Simple
InputModel model = new InputModel();
BinaryData data = ModelReaderWriter.Write(model);
```

The example below shows how to read JSON to create a strongly-typed model instance.

```C# Snippet:Readme_Read_Simple
string json = @"{
      ""x"": 1,
      ""y"": 2,
      ""z"": 3
    }";
OutputModel? model = ModelReaderWriter.Read<OutputModel>(BinaryData.FromString(json));
```

## Troubleshooting

You can troubleshoot service clients by inspecting the result of any `ClientResultException` thrown from a client's service method.

For more information on client service method errors, see [Handling exceptions that result from failed requests](#handling-exceptions-that-result-from-failed-requests).

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
