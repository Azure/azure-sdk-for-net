# Azure Communication Email client library for .NET

This package contains a C# SDK for Azure Communication Services for Email.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Email client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Email
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
EmailClient emailClient = new EmailClient(connectionString);
```

Alternatively, Email clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication. 

```C# Snippet:Azure_Communication_Email_CreateEmailClientWithToken
string endpoint = "<endpoint_url>";
var tokenCredential = new DefaultAzureCredential();
EmailClient emailClient = new EmailClient(new Uri(endpoint), tokenCredential);
```
## Examples
### Send a simple email message with automatic polling for status
To send an email message, call the simple overload of `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send_Simple_AutoPolling
try
{
    var emailSendOperation = emailClient.Send(
        wait: WaitUntil.Completed,
        senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
        recipientAddress: "<recipient email address>"
        subject: "This is the subject",
        htmlContent: "<html><body>This is the html body</body></html>");
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch ( RequestFailedException ex )
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}
```

### Send a simple email message with manual polling for status
To send an email message, call the simple overload of `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send_Simple_ManualPolling_Async
/// Send the email message with WaitUntil.Started
var emailSendOperation = await emailClient.SendAsync(
    wait: WaitUntil.Started,
    senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    recipientAddress: "<recipient email address>"
    subject: "This is the subject",
    htmlContent: "<html><body>This is the html body</body></html>");

/// Call UpdateStatus on the email send operation to poll for the status
/// manually.
try
{
    while (true)
    {
        await emailSendOperation.UpdateStatusAsync();
        if (emailSendOperation.HasCompleted)
        {
            break;
        }
        await Task.Delay(100);
    }

    if (emailSendOperation.HasValue)
    {
        Console.WriteLine($"Email queued for delivery. Status = {emailSendOperation.Value.Status}");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Email send failed with Code = {ex.ErrorCode} and Message = {ex.Message}");
}

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

### Send an email message with more options
To send an email message, call the overload of `Send` or `SendAsync` function from the `EmailClient` that takes an `EmailMessage` parameter.
```C# Snippet:Azure_Communication_Email_Send_With_MoreOptions
// Create the email content
var emailContent = new EmailContent("This is the subject")
{
    PlainText = "This is the body",
    Html = "<html><body>This is the html body</body></html>"
};

// Create the EmailMessage
var emailMessage = new EmailMessage(
    senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    recipientAddress: "<recipient email address>"
    content: emailContent);

try
{
    var emailSendOperation = emailClient.Send(
        wait: WaitUntil.Completed,
        message: emailMessage);
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch ( RequestFailedException ex )
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}
```

### Send an email message to multiple recipients
To send an email message to multiple recipients, add an `EmailAddress` object for each recipent type to the `EmailRecipient` object.

```C# Snippet:Azure_Communication_Email_Send_Multiple_Recipients
// Create the email content
var emailContent = new EmailContent("This is the subject")
{
    PlainText = "This is the body",
    Html = "<html><body>This is the html body</body></html>"
};

// Create the To list
var toRecipients = new List<EmailAddress>
{
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
};

// Create the CC list
var ccRecipients = new List<EmailAddress>
{
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
};

// Create the BCC list
var bccRecipients = new List<EmailAddress>
{
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
    new EmailAddress(
        address: "<recipient email address>"
        displayName: "<recipient displayname>"
};

var emailRecipients = new EmailRecipients(toRecipients, ccRecipients, bccRecipients);

// Create the EmailMessage
var emailMessage = new EmailMessage(
    senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    emailRecipients,
    emailContent);

try
{
    EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch ( RequestFailedException ex )
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}
```

### Send email with attachments
Azure Communication Services support sending emails with attachments.
```C# Snippet:Azure_Communication_Email_Send_With_Attachments
// Create the EmailMessage
var emailMessage = new EmailMessage(
    senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    recipientAddress: "<recipient email address>"
    content: emailContent);

var filePath = "<path to your file>";
var attachmentName = "<name of your attachment>";
var contentType = MediaTypeNames.Text.Plain;

var content = new BinaryData(System.IO.File.ReadAllBytes(filePath));
var emailAttachment = new EmailAttachment(attachmentName, contentType, content);

emailMessage.Attachments.Add(emailAttachment);

try
{
    EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch ( RequestFailedException ex )
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}
```

### Send email with inline attachments
Azure Communication Services support sending inline attachments.
Adding an optional `contentId` parameter to the `EmailAttachment` constructor will make the attachment an inline attachment.
```C# Snippet:Azure_Communication_Email_Send_With_Inline_Attachments
// Create the email content and reference any inline attachments.
var emailContent = new EmailContent("This is the subject")
{
    PlainText = "This is the body",
    Html = "<html><body>This is the html body<img src=\"cid:myInlineAttachmentContentId\"></body></html>"
};

// Create the EmailMessage
var emailMessage = new EmailMessage(
    senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    recipientAddress: "<recipient email address>"
    content: emailContent);

var filePath = "<path to your file>";
var attachmentName = "<name of your attachment>";
var contentType = MediaTypeNames.Text.Plain;
var contentId = "myInlineAttachmentContentId";

var content = new BinaryData(System.IO.File.ReadAllBytes(filePath));
var emailAttachment = new EmailAttachment(attachmentName, contentType, content);
emailAttachment.ContentId = contentId;

emailMessage.Attachments.Add(emailAttachment);

try
{
    EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch ( RequestFailedException ex )
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}
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
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[email_resource_docs]: https://aka.ms/acsemail/createemailresource
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[package]: https://www.nuget.org/packages/Azure.Communication.Email
[product_docs]: https://aka.ms/acsemail/overview
[nextsteps]:https://aka.ms/acsemail/qs-sendmail?pivots=programming-language-csharp
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Email/src
[domain_overview]: https://aka.ms/acsemail/domainsoverview
