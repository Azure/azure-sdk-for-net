# Azure Communication Email client library for .NET

This package contains a C# SDK for Azure Communication Services for Email.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Email client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Email --prerelease
``` 

### Prerequisites
You need an [Azure subscription][azure_sub], a [Communication Service Resource][communication_resource_docs], and an [Email Communication Resource][email_resource_docs] with an active [Domain][domain_overview].

To create these resource, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`EmailClient` provides the functionality to send email messages .

### Using statements
```C# Snippet:Azure_Communication_Email_UsingStatements
using Azure.Communication.Email;
```

### Authenticate the client
Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient client = new EmailClient(connectionString);
```

Alternatively, Email clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication. 

```C# Snippet:Azure_Communication_Email_CreateEmailClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
tokenCredential = new DefaultAzureCredential();
EmailClient client = new EmailClient(new Uri(endpoint), tokenCredential);
```
## Examples
### Send an Email Message
To send an email message, call the `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send
// Create the email content
var emailContent = new EmailContent("This is the subject");
emailContent.PlainText = "This is the body";

// Create the recipient list
var emailRecipients = new EmailRecipients(
    new List<EmailAddress>
    {
        new EmailAddress(
            email: "<recipient email address>"
            displayName: "<recipient displayname>"
    });

// Create the EmailMessage
var emailMessage = new EmailMessage(
    sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    emailContent,
    emailRecipients);

SendEmailResult sendResult = client.Send(emailMessage);

Console.WriteLine($"Email id: {sendResult.MessageId}");
```

### Send an Email Message to Multiple Recipients
To send an email message to multiple recipients, add an `EmailAddress` object for each recipent type to the `EmailRecipient` object.

```C# Snippet:Azure_Communication_Email_Send_Multiple_Recipients
// Create the email content
var emailContent = new EmailContent("This is the subject");
emailContent.PlainText = "This is the body";

// Create the To list
var toRecipients = new List<EmailAddress>
{
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
};

// Create the CC list
var ccRecipients = new List<EmailAddress>
{
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
};

// Create the BCC list
var bccRecipients = new List<EmailAddress>
{
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        email: "<recipient email address>"
        displayName: "<recipient displayname>"
};

var emailRecipients = new EmailRecipients(toRecipients, ccRecipients, bccRecipients);

// Create the EmailMessage
var emailMessage = new EmailMessage(
    sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    emailContent,
    emailRecipients);

SendEmailResult sendResult = client.Send(emailMessage);

Console.WriteLine($"Email id: {sendResult.MessageId}");
```

### Send Email with Attachments
Azure Communication Services support sending email swith attachments. See [EmailAttachmentType][email_attachmentTypes] for a list of supported attachments
```C# Snippet:Azure_Communication_Email_Send_With_Attachments
// Create the EmailMessage
var emailMessage = new EmailMessage(
    sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    emailContent,
    emailRecipients);

var filePath = "<path to your file>";
var attachmentName = "<name of your attachment>";
EmailAttachmentType attachmentType = EmailAttachmentType.Txt;

// Convert the file content into a Base64 string
byte[] bytes = File.ReadAllBytes(filePath);
string attachmentFileInBytes = Convert.ToBase64String(bytes);
var emailAttachment = new EmailAttachment(attachmentName, attachmentType, attachmentFileInBytes);

emailMessage.Attachments.Add(emailAttachment);

SendEmailResult sendResult = client.Send(emailMessage);
```

### Get Email Message Status
The `EmailSendResult` from the `Send` call contains a `MessageId` which can be used to query the status of the email.
```C# Snippet:Azure_Communication_Email_GetSendStatus
SendEmailResult sendResult = client.Send(emailMessage);

SendStatusResult status = client.GetSendStatus(sendResult.MessageId);
```

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps
- [Read more about Email in Azure Communication Services][nextsteps]

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
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[email_resource_docs]: https://aka.ms/acsemail/createemailresource
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[package]: https://www.nuget.org/packages/Azure.Communication.Email
[product_docs]: https://aka.ms/acsemail/overview
[nextsteps]:https://aka.ms/acsemail/qs-sendmail?pivots=programming-language-csharp
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Email/src
[email_attachmentTypes]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/src/Generated/Models/EmailAttachmentType.cs
[domain_overview]: https://aka.ms/acsemail/domainsoverview
