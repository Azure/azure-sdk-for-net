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
 - Send an email message with attachments

 #### You can find samples for each of these functions below.
 - Send Email Messages [synchronously][sample_email] or [asynchronously][sample_email_async]
 
<!-- LINKS -->
[sample_email]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample1_SendEmail.md
[sample_email_async]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Email/samples/Sample1_SendEmailAsync.md
