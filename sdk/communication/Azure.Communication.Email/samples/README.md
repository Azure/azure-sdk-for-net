---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication-services
name: Azure Communication Email samples for .NET
description: Samples for the Azure.Communication.Email client library
---

# Azure Communication Email SDK samples

Azure Communication Email is a client library that provides the functionality to send emails.
To get started you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create an Azure Communication Services resource, an Azure Communication Email resource with a domain. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows to do following operations:
 - Send a simple email message with automatic polling for status
 - Send a simple email message with manual polling for status
 - Specify optional paramters while sending Emails
 - Send an email message to multiple recipients
 - Send an email message with attachments and inline attachments

 #### You can find samples for each of these functions below.
 - Send simple email message with automatic polling for status [synchronously][sample_simpleemail_autopolling] or [asynchronously][sample_simpleemail_autopolling_async]
 - Send simple email message with manual polling for status [asynchronously][sample_simpleemail_manualpolling_async]
 - Specify optional paramters while sending Emails [synchronously][sample_emailwithoptions] or [asynchronously][sample_emailwithoptions_async]
 - Send an email message to multiple recipients [synchronously][sample_email_multiplerecipients] or [asynchronously][sample_email_multiplerecipients_async]
 - Send an email message with attachments and inline attachments [synchronously][sample_email_attachments] or [asynchronously][sample_email_attachments_async]

<!-- LINKS -->
[sample_simpleemail_autopolling]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample1_SendSimpleEmailWithAutomaticPollingForStatus.md
[sample_simpleemail_autopolling_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample1_SendSimpleEmailWithAutomaticPollingForStatusAsync.md
[sample_simpleemail_manualpolling_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample2_SendSimpleEmailWithManualPollingForStatusAsync.md
[sample_emailwithoptions]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample3_SendEmailWithMoreOptions.md
[sample_emailwithoptions_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample3_SendEmailWithMoreOptionsAsync.md
[sample_email_multiplerecipients]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample4_SendEmailToMultipleRecipients.md
[sample_email_multiplerecipients_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample4_SendEmailToMultipleRecipientsAsync.md
[sample_email_attachments]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample5_SendEmailWithAttachment.md
[sample_email_attachments_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample5_SendEmailWithAttachmentAsync.md
