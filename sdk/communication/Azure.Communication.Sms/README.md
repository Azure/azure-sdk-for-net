# Azure Communication SMS client library for .NET

This package contains a C# SDK for Azure Communication Services for SMS and Telephony.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication SMS client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Sms
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`SmsClient` provides the functionality to send messages between phone numbers.

### Using statements
```C# Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using System.IO;
using Azure.Communication.Sms;
```

### Authenticate the client
SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
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
### Send a 1:1 SMS Message
To send a SMS message, call the `Send` or `SendAsync` function from the `SmsClient`.
```C# Snippet:Azure_Communication_Sms_Tests_SendAsync
SmsSendResult sendResult = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: "<to-phone-number>", // E.164 formatted recipient phone number
    message: "Hi");
Console.WriteLine($"Sms id: {sendResult.MessageId}");
```
### Send a 1:N SMS Message
To send a SMS message to a list of recipients, call the `Send` or `SendAsync` function from the `SmsClient` with a list of recipient's phone numbers.
You may also add pass in an options object to specify whether the delivery report should be enabled and set custom tags.
```C# Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptionsAsync
var response = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
    message: "Weekly Promotion!",
    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
    {
        Tag = "marketing", // custom tags
    });
foreach (SmsSendResult result in response.Value)
{
    Console.WriteLine($"Sms id: {result.MessageId}");
    Console.WriteLine($"Send Result Successful: {result.Successful}");
}
```
## Troubleshooting
SMS operations will throw an exception if the request to the server fails.
Exceptions will not be thrown if the error is caused by an individual message, only if something fails with the overall request.
Please use the `Successful` flag to validate each individual result to verify if the message was sent.

```C# Snippet:Azure_Communication_Sms_Tests_Troubleshooting
try
{
    var response = await smsClient.SendAsync(
        from: "<from-phone-number>" // Your E.164 formatted phone number used to send SMS
        to: new string [] {"<to-phone-number-1>", "<to-phone-number-2>"}, // E.164 formatted recipient phone number
        message: "Weekly Promotion!",
        options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
        {
            Tag = "marketing", // custom tags
        });
    foreach (SmsSendResult result in response.Value)
    {
        if (result.Successful)
        {
            Console.WriteLine($"Successfully sent this message: {result.MessageId} to {result.To}.");
        }
        else
        {
            Console.WriteLine($"Something went wrong when trying to send this message {result.MessageId} to {result.To}.");
            Console.WriteLine($"Status code {result.HttpStatusCode} and error message {result.ErrorMessage}.");
        }
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps
- [Read more about SMS in Azure Communication Services][nextsteps]
- For a basic guide on how to configure Delivery Reporting for your SMS messages please refer to the [Handle SMS Events quickstart][handle_sms_events].

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[handle_sms_events]: https://learn.microsoft.com/azure/communication-services/quickstarts/telephony-sms/handle-sms-events
[package]: https://www.nuget.org/packages/Azure.Communication.Sms
[product_docs]: https://learn.microsoft.com/azure/communication-services/overview
[nextsteps]:https://learn.microsoft.com/azure/communication-services/quickstarts/telephony-sms/send?pivots=programming-language-csharp
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Sms/src
