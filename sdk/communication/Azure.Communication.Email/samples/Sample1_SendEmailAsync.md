# Send Email Message

This sample demonstrates how to send an email message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `EmailClient`

Email clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Email_CreateEmailClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
EmailClient client = new EmailClient(connectionString);
```

## Send Email to a single recipient

To send a email message, call the `Send` or `SendAsync` function from the `EmailClient`. `Send` expects an `EmailMessage` with the details of the email. The returned value is `EmailSendResult` objects that contains the ID of the send operation.

```C# Snippet:Azure_Communication_Email_SendAsync
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

SendEmailResult sendResult = await client.SendAsync(emailMessage);

Console.WriteLine($"Email id: {sendResult.MessageId}");
```

## Send Email to multiple recipients

To send a Email message to a list of recipients, call the `Send` or `SendAsync` function from the `EmailClient` with an `EmailMessage` object that has a list of recipient.

```C# Snippet:Azure_Communication_Email_Send_Multiple_RecipientsAsync
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

SendEmailResult sendResult = await client.SendAsync(emailMessage);

Console.WriteLine($"Email id: {sendResult.MessageId}");
```

## Send Email with Attachments
To send a Email message with attachments, call the `Send` or `SendAsync` function from the `EmailClient` with an `EmailMessage` object which has `EmailAttachment` objects added to the `Attachments` list.

```C# Snippet:Azure_Communication_Email_Send_With_AttachmentsAsync
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

SendEmailResult sendResult = await client.SendAsync(emailMessage);
```

## Get the status of a call to `Send`
When `Send` or `SendAsync` is called, the Azure Communication Service has accepted the email that you want to send. The actual sending opration is an asynchronous process. You can get the status of the email throughout this process by calling `GetSendStatus` or `GetSendStatusAsync` using the `SendEmailResult.MessageId` returned from a previous call to `Send` or `SendAsync`
```C# Snippet:Azure_Communication_Email_GetSendStatusAsync
SendEmailResult sendResult = await client.SendAsync(emailMessage);

SendStatusResult status = await client.GetSendStatusAsync(sendResult.MessageId);
```

[README]: https://www.bing.com