---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication
name: Azure Communication Administration samples for .NET
description: Samples for the Azure.Communication.Administration client library
---

# Azure Communication Administration SDK samples

Azure Communication Administration is a client library that is used to do operations necessary for using different services offered by Azure Communication Services, such as calling, chat, SMS, PSTN etc.
To get started you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create Azure Communication Services resource. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows to do following operations:
 - Generate user tokens that allows the holders to access Azure Communication Services.
 - Purchase, configure and release phone numbers.

 #### You can find samples for each of these functions below.
 - Generate user tokens [synchronously][sample_identity] or [asynchronously][sample_identity_async]
 - Manage phone numbers [synchronously][sample_admin] or [asynchronously][sample_admin_async]

<!-- LINKS -->
[sample_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Administration/samples/Sample1_CommunicationIdentityClient.md
[sample_identity_async]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Administration/samples/Sample1_CommunicationIdentityClientAsync.md
[sample_admin]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/samples/Sample2_PhoneNumberAdministrationClient.md
[sample_admin_async]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/samples/Sample2_PhoneNumberAdministrationClientAsync.md
