# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient client = new EmailClient(connectionString);
```

### Send a simple email message with automatic polling for status
To send an email message, call the simple overload of `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send_Simple_AutoPolling_Async
var emailSendOperation = await emailClient.SendAsync(
    wait: WaitUntil.Completed,
    from: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    to: "<recipient email address>"
    subject: "This is the subject",
    htmlContent: "<html><body>This is the html body</body></html>");
Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

### Send a simple email message with manual polling for status
To send an email message, call the simple overload of `Send` or `SendAsync` function from the `EmailClient`.
```C# Snippet:Azure_Communication_Email_Send_Simple_ManualPolling_Async
/// Send the email message with WaitUntil.Started
var emailSendOperation = await emailClient.SendAsync(
    wait: WaitUntil.Started,
    from: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    to: "<recipient email address>"
    subject: "This is the subject",
    htmlContent: "<html><body>This is the html body</body></html>");

/// Call UpdateStatus on the email send operation to poll for the status
/// manually.
while (true)
{
    await emailSendOperation.UpdateStatusAsync();
    if (emailSendOperation.HasCompleted)
    {
        break;
    }
    await Task.Delay(10);
}

if (emailSendOperation.HasValue)
{
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
}

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

### Send an email message with more options
To send an email message, call the overload of `Send` or `SendAsync` function from the `EmailClient` that takes an `EmailMessage` parameter.
```C# Snippet:Azure_Communication_Email_Send_With_MoreOptions_Async
// Create the email content
var emailContent = new EmailContent("This is the subject")
{
    PlainText = "This is the body",
    Html = "<html><body>This is the html body</body></html>"
};

// Create the EmailMessage
var emailMessage = new EmailMessage(
    fromAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
    toAddress: "<recipient email address>"
    content: emailContent);

var emailSendOperation = await client.SendAsync(
    wait: WaitUntil.Completed,
    message: emailMessage);
Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

### Send an email message to multiple recipients
To send an email message to multiple recipients, add an `EmailAddress` object for each recipent type to the `EmailRecipient` object.

```C# Snippet:Azure_Communication_Email_Send_Multiple_Recipients_Async
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

EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

### Send email with attachments
Azure Communication Services support sending emails with attachments. See [EmailAttachmentType][email_attachmentTypes] for a list of supported attachments
```C# Snippet:Azure_Communication_Email_Send_With_Attachments_Async
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

EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

/// Get the OperationId so that it can be used for tracking the message for troubleshooting
string operationId = emailSendOperation.Id;
Console.WriteLine($"Email operation id = {operationId}");
```

[README]: https://www.bing.com
