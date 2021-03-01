# Azure Communication SMS client library for .NET
> Server Version: 
Sms client: 2021-03-07

This package contains a C# SDK for Azure Communication Services for SMS and Telephony.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication SMS client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Sms --version 1.0.0-beta.4
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`SmsClient` provides the functionality to send messages between phone numbers.

### Using statements
```C# Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using System.Collections.Generic;
using Azure.Communication.Sms;
```

### Authenticate the client
SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
SmsClient client = new SmsClient(connectionString);
```

Alternatively, SMS clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication. 

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
```

## Examples
### Send a SMS Message
To send a SMS message, call the `Send` or `SendAsync` function from the `SmsClient`.
```C# Snippet:Azure_Communication_Sms_Tests_SendAsync
SmsSendResult result = await client.SendAsync(
   from: "+18001230000" // Phone number acquired on your Azure Communication resource
   to: "+18005670000",
   message: "Hi");
Console.WriteLine($"Sms id: {result.MessageId}");
```
### Send a Group SMS Message
To send a SMS message to a list of recipients, call the `Send` or `SendAsync` function from the `SmsClient` with a list of recipient's phone numbers.
You may also add pass in an options object to specify whether the delivery report should be enabled and set custom tags.
```C# Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
Response<IEnumerable<SmsSendResult>> response = await client.SendAsync(
   from: "+18001230000" // Phone number acquired on your Azure Communication resource
   to: new string[] {"+18005670000", "+18008900000}",
   message: "Hi",
   options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
   {
       Tag = "marketing", // custom tags
   });
IEnumerable<SmsSendResult> results = response.Value;
foreach (SmsSendResult result in results)
{
    Console.WriteLine($"Sms id: {result.MessageId}");
}
```
## Troubleshooting
All SMS operations will throw a RequestFailedException on failure.

```C# Snippet:Azure_Communication_Sms_Tests_Troubleshooting
try
{
    SmsSendResult result = await client.SendAsync(
       from: "+18001230000" // Phone number acquired on your Azure Communication resource
       to: "+18005670000",
       message: "Hi");
    Console.WriteLine($"Sms id: {result.MessageId}");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps
[Read more about SMS in Azure Communication Services][nextsteps]

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
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[package]: https://www.nuget.org/packages/Azure.Communication.Sms
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nextsteps]:https://docs.microsoft.com/azure/communication-services/quickstarts/telephony-sms/send?pivots=programming-language-csharp
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Sms/src
