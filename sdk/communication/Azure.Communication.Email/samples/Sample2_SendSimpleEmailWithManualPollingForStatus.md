# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient emailClient = new EmailClient(connectionString);
```

### Send a simple email message with manual polling for status
To send an email message, call the simple overload of `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send_Simple_ManualPolling
/// Send the email message with WaitUntil.Started
var emailSendOperation = emailClient.Send(
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
        emailSendOperation.UpdateStatus();
        if (emailSendOperation.HasCompleted)
        {
            break;
        }
        Thread.Sleep(100);
    }

    if (emailSendOperation.HasValue)
    {
        Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
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

[README]: https://learn.microsoft.com/azure/communication-services/quickstarts/email/send-email?tabs=windows&pivots=platform-azcli#prerequisites