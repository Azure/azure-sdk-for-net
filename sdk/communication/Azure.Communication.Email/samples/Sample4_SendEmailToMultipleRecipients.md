# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient emailClient = new EmailClient(connectionString);
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

[README]: https://learn.microsoft.com/azure/communication-services/quickstarts/email/send-email?tabs=windows&pivots=platform-azcli#prerequisites