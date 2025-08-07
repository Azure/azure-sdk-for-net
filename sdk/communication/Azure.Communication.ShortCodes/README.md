# Azure Communication Short Code client library for .NET

The phone numbers library provides capabilities for short codes administration.

## Getting started

### Install the package
Install the Azure Communication Server Calling client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.ShortCodes --prerelease
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Authenticate the client
SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

## Key concepts
The short codes package exposes the `ShortCodesClient` which provides methods to manage short codes.

### Short Code types
Short Codes come in two types; shortCode and alphaId. ShortCode = 5 digit number | alphaId = alphanumeric 5 digit combination.

### Short Codes
Short codes are a type of number that are available to enterprise customers. They come in the form of a 5 or 6 digit number and can be used to send sms similar to how a toll-free or geographic number is used. In order to acquire a short code it is necessary to submit an application, or program brief.

### Program Briefs
A program brief tracks the application for a short code and contains all the information necessary to process the application as well as information on the status of the application and any updates that may be needed. It can take 8-12 weeks for a program brief to be approved and a short code to be issued once the program brief is submitted.

```C# Snippet:CreateShortCodesClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new ShortCodesClient(connectionString);
```

## Examples
### Getting the list of short codes for the current resource

```C# Snippet:GetShortCodes
var pageable = client.GetShortCodesAsync();
await foreach (var shortCode in pageable)
{
    Console.WriteLine($"Short Code Number: {shortCode.Number}");
}
```

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[nuget]: https://www.nuget.org/

## Next steps
[Read more about Short Codes in Azure Communication Services][apply_for_short_code].

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[nuget]: https://www.nuget.org/
[apply_for_short_code]: https://learn.microsoft.com/azure/communication-services/quickstarts/sms/apply-for-short-code
