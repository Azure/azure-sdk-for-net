# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient emailClient = new EmailClient(connectionString);
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

[README]: https://learn.microsoft.com/azure/communication-services/quickstarts/email/send-email?tabs=windows&pivots=platform-azcli#prerequisites