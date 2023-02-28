# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient emailClient = new EmailClient(connectionString);
```

### Send email with attachments
Azure Communication Services support sending emails with attachments. See [EmailAttachmentType][email_attachmentTypes] for a list of supported attachments
```C# Snippet:Azure_Communication_Email_Send_With_Attachments
// Create the EmailMessage
var emailMessage = new EmailMessage(
    fromAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    toAddress: "<recipient email address>"
    content: emailContent);

var filePath = "<path to your file>";
var attachmentName = "<name of your attachment>";
var contentType = MediaTypeNames.Text.Plain;

string content = new BinaryData(File.ReadAllBytes(filePath));
var emailAttachment = new EmailAttachment(attachmentName, contentType, content);

emailMessage.Attachments.Add(emailAttachment);

EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

[README]: https://learn.microsoft.com/azure/communication-services/quickstarts/email/send-email?tabs=windows&pivots=platform-azcli#prerequisites
