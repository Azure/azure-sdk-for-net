# Azure Communication SMS client library for .NET

This package contains a C# SDK for Azure Communication Services for SMS and Telephony.

> **Important**: The `SmsClient` class will be deprecated soon and removed in a future version. Please migrate to the new `TelcoMessagingClient` for all new development, which provides better organization through sub-clients and access to delivery reports functionality.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication SMS client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Sms
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts

**Recommended**: `TelcoMessagingClient` provides the functionality to send messages between phone numbers through organized sub-clients:
- `TelcoMessagingClient.Sms` - for sending SMS messages
- `TelcoMessagingClient.OptOuts` - for managing opt-out preferences
- `TelcoMessagingClient.DeliveryReports` - for retrieving message delivery status

**Will be deprecated soon**: `SmsClient` provides the functionality to send messages between phone numbers. This class will be deprecated in an upcoming release and removed in a future version. Please migrate to `TelcoMessagingClient` for all new development.

### Using statements
```C# Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using Azure.Communication.Sms;
```

### Authenticate the client

SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

**Recommended - TelcoMessagingClient:**
```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateTelcoMessagingClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
TelcoMessagingClient client = new TelcoMessagingClient(connectionString);
```

**Will be deprecated soon - SmsClient:**
```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
SmsClient client = new SmsClient(connectionString);
```

Alternatively, SMS clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication.

**Recommended - TelcoMessagingClient:**
```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateTelcoMessagingClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
TelcoMessagingClient client = new TelcoMessagingClient(new Uri(endpoint), tokenCredential);
```

**Will be deprecated soon - SmsClient:**
```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
```

## Examples

### SMS

#### Send a 1:1 SMS Message

**Recommended - Using TelcoMessagingClient:**
To send a SMS message, call the `Send` or `SendAsync` function from the `TelcoMessagingClient.Sms` sub-client.
```C# Snippet:Azure_Communication_Sms_Tests_TelcoMessaging_SendAsync
SmsSendResult sendResult = await telcoMessagingClient.Sms.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: "<to-phone-number>", // E.164 formatted recipient phone number
    message: "Hi");
Console.WriteLine($"Sms id: {sendResult.MessageId}");
```

**Will be deprecated soon - Using SmsClient:**
To send a SMS message, call the `Send` or `SendAsync` function from the `SmsClient`.
```C# Snippet:Azure_Communication_Sms_Tests_SendAsync
SmsSendResult sendResult = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: "<to-phone-number>", // E.164 formatted recipient phone number
    message: "Hi");
Console.WriteLine($"Sms id: {sendResult.MessageId}");
```

#### Send a 1:N SMS Message

**Recommended - Using TelcoMessagingClient:**
To send a SMS message to a list of recipients, call the `Send` or `SendAsync` function from the `TelcoMessagingClient.Sms` sub-client with a list of recipient's phone numbers.
```C# Snippet:Azure_Communication_TelcoMessagingClient_Send_GroupSmsWithOptionsAsync
var response = await telcoMessagingClient.Sms.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
    message: "Weekly Promotion!",
    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
    {
        Tag = "marketing", // custom tags
        DeliveryReportTimeoutInSeconds = 90
    });
foreach (SmsSendResult result in response.Value)
{
    Console.WriteLine($"Sms id: {result.MessageId}");
    Console.WriteLine($"Send Result Successful: {result.Successful}");
}
```

**Will be deprecated soon - Using SmsClient:**
To send a SMS message to a list of recipients, call the `Send` or `SendAsync` function from the `SmsClient` with a list of recipient's phone numbers.
You can also provide an options object to configure various settings, such as enabling the delivery report, adding custom tags, or specifying parameters for connecting with the Messaging Connect Partner to deliver SMS.
```C# Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptionsAsync
var response = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
    message: "Weekly Promotion!",
    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
    {
        Tag = "marketing", // custom tags
        DeliveryReportTimeoutInSeconds = 90
    });
foreach (SmsSendResult result in response.Value)
{
    Console.WriteLine($"Sms id: {result.MessageId}");
    Console.WriteLine($"Send Result Successful: {result.Successful}");
}
```

### Delivery Reports

#### Get Delivery Report for a Message
To get delivery report for a specific outgoing message, call the `Get` or `GetAsync` function from the `TelcoMessagingClient.DeliveryReports` sub-client.
```C# Snippet:Azure_Communication_Sms_Tests_DeliveryReports_GetAsync
var deliveryReport = await telcoMessagingClient.DeliveryReports.GetAsync("<message-id>");
Console.WriteLine($"Message {deliveryReport.MessageId} delivery status: {deliveryReport.DeliveryStatus}");
if (deliveryReport.DeliveryAttempts != null)
{
    foreach (var attempt in deliveryReport.DeliveryAttempts)
    {
        Console.WriteLine($"Attempt at {attempt.Timestamp}: {attempt.SegmentsSucceeded} succeeded, {attempt.SegmentsFailed} failed");
    }
}
```
### Opt Out Management

#### Check if a list of recipients is in the Opt Out list

**Recommended - Using TelcoMessagingClient:**
To check if the recipients are in the Opt Out list, call the function from the `TelcoMessagingClient.OptOuts.Check` or `TelcoMessagingClient.OptOuts.CheckAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_CheckAsync
var optOutCheckResults = await telcoMessagingClient.OptOuts.CheckAsync(
   from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
   to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutCheckResults.Value)
{
    Console.WriteLine($"{result.To}: {result.IsOptedOut}");
}
```

**Will be deprecated soon - Using SmsClient:**
To check if the recipients are in the Opt Out list, call the function from the `SmsClient.OptOuts.Check` or  `SmsClient.OptOuts.CheckAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_CheckAsync
var optOutCheckResults = await smsClient.OptOuts.CheckAsync(
   from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
   to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutCheckResults.Value)
{
    Console.WriteLine($"{result.To}: {result.IsOptedOut}");
}
```

#### Add a list of recipients to Opt Out list

**Recommended - Using TelcoMessagingClient:**
To add the list of recipients to Opt Out list, call the function from the `TelcoMessagingClient.OptOuts.Add` or `TelcoMessagingClient.OptOuts.AddAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_AddAsync
var optOutAddResults = await telcoMessagingClient.OptOuts.AddAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutAddResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```

**Will be deprecated soon - Using SmsClient:**
To add the list of recipients to Opt Out list, call the function from the `SmsClient.OptOuts.Add` or `SmsClient.OptOuts.AddAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_AddAsync
var optOutAddResults = await smsClient.OptOuts.AddAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutAddResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```

#### Remove a list of recipients from Opt Out list

**Recommended - Using TelcoMessagingClient:**
To remove the list of recipients from Opt Out list, call the function from the `TelcoMessagingClient.OptOuts.Remove` or `TelcoMessagingClient.OptOuts.RemoveAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_RemoveAsync
var optOutRemoveResults = await telcoMessagingClient.OptOuts.RemoveAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers

foreach (var result in optOutRemoveResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```

**Will be deprecated soon - Using SmsClient:**
To remove the list of recipients to Opt Out list, call the function from the `SmsClient.OptOuts.Remove` or `SmsClient.OptOuts.RemoveAsync` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_RemoveAsync
var optOutRemoveResults = await smsClient.OptOuts.RemoveAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers

foreach (var result in optOutRemoveResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```



## Troubleshooting

### Migration from SmsClient to TelcoMessagingClient

If you're migrating from the `SmsClient` (which will be deprecated soon) to the new `TelcoMessagingClient`, here are the key changes:

```csharp
// OLD - SmsClient (will be deprecated soon)
var smsClient = new SmsClient(connectionString);
await smsClient.SendAsync(from, to, message);
await smsClient.OptOuts.CheckAsync(from, to);

// NEW - TelcoMessagingClient (recommended)
var telcoClient = new TelcoMessagingClient(connectionString);
await telcoClient.Sms.SendAsync(from, to, message);
await telcoClient.OptOuts.CheckAsync(from, to);
await telcoClient.DeliveryReports.GetAsync(messageId); // New functionality
```

### Error Handling

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
