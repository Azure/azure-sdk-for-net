# Azure Communication Messages client library for .NET

This package contains a C# SDK for Azure Communication Messages Services.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]


## Getting started

### Install the package
Install the Azure Communication Messages client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Messages --prerelease
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`NotificationMessagesClient` provides the functionality to send notification messages .

### Using statements
```C#
using Azure.Communication.Messages;
```

### Authenticate the client
#### Connection String
Messages clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C#
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
NotificationMessagesClient notificationMessagesClient = new NotificationMessagesClient(connectionString);
MessageTemplateClient messageTemplateClient = new MessageTemplateClient(connectionString);
```

## Examples
### Send an Notification Message
To send a notification message, call the `Send` or `SendAsync` function from the `NotificationMessagesClient`.

#### Send a text message
```C#
// Create the recipient list, currently only one recipient is supported 
var recipient = new List<string> { "<to-phone-number>" };
var textContent = new = new TextNotificationContent(new Guid("<channel-registration-id>"), recipient, "Come on everyone, let's go for lunch together.");
SendMessageResult result = await notificationMessagesClient.SendAsync(textContent);
Console.WriteLine($"Message id: {result.Receipts[0].MessageId}");
```

#### Send a template message
```C#
// Create the recipient list, currently only one recipient is supported 
var recipient = new List<string> { "<to-phone-number>" };
string templateName = "sample_template";
string templateLanguage = "en_us";
var messageTemplate = new MessageTemplate(templateName, templateLanguage);
var templateContent = new TemplateNotificationContent(channelRegistrationId, recipientList, messageTemplate);
SendMessageResult result = await notificationMessagesClient.SendAsync(templateContent);
Console.WriteLine($"Message id: {result.Receipts[0].MessageId}");
```

#### Send a media message
```C#
// Create the recipient list, currently only one recipient is supported 
var recipient = new List<string> { "<to-phone-number>" };
var uri = new Uri("https://aka.ms/acsicon1");
var mediaContent = new MediaNotificationContent(channelRegistrationId, recipientList, uri);
SendMessageResult result = await notificationMessagesClient.SendAsync(mediaContent);
Console.WriteLine($"Message id: {result.Receipts[0].MessageId}");
```

### Retrieve templates
To retrieve templates, call the `GetMessages` or `GetMessagesAsync` function from the `MessageTemplateClient`.


```C#
AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelId);
await foreach (MessageTemplateItem template in templates)
{
    Console.WriteLine($"{template.Name}");
}
```

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps
- Read more about Messages in Azure Communication Services (Link to be added).
- Read more about how to set up Event Grid subscription for new message and message delivery status (Link to be added).


## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Messages/src
[package]: https://www.nuget.org/packages/Azure.Communication.Messages
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq
[coc_contact]: mailto:opencode@microsoft.com
