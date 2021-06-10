# Face preview client library for .NET

## Getting started

### Install the package

Install the Face client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Microsoft.Azure.CognitiveServices.Vision.Face.Preview --version  2.7.0-preview.2
```

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Face resource.

### Authenticate the client

To authenticate the FaceClient, you will need to provide the endpoint and API key for your Face resource.
You can obtain the endpoint and API key from the resource information in the [Azure Portal][azure_portal].
Instantiate the FaceClient with ApiKeyServiceClientCredentials as follows:

```
IFaceClient client = new FaceClient(new ApiKeyServiceClientCredentials({YourAPIKey}), handlers: handler)
{
    Endpoint = {YourEndpoint}
};
```

## Key concepts

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

## Examples

## Troubleshooting

## Next steps

## Contributing



<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com/