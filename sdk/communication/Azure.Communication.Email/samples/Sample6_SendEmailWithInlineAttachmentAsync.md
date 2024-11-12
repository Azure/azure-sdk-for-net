# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, Email clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient emailClient = new EmailClient(connectionString);
```

### Send email with attachments
Azure Communication Services support sending emails with attachments. Adding an optional `contentId` parameter to the `EmailAttachment` constructor will make the attachment an inline attachment.
See [EmailAttachmentType][email_attachmentTypes] for a list of supported attachments.
```C# Snippet:Azure_Communication_Email_Send_With_Inline_Attachments_Async
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
    EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
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

[README]: https://learn.microsoft.com/azure/communication-services/quickstarts/email/send-email?tabs=windows&pivots=platform-azcli#prerequisites
