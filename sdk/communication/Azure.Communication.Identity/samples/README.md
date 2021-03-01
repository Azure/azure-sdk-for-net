---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication
name: Azure Communication Identity samples for .NET
description: Samples for the Azure.Communication.Identity client library
---

# Azure Communication Identity SDK samples

Azure Communication Identity is a client library that is used to do operations necessary for identities and tokens.
To get started you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create Azure Communication Services resource. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows for the following operations:
 - Generate user tokens that allow the bearers to access Azure Communication Services.
 - Generate TURN server credentials that allow the bearers to access a TURN server for media relay.

 You can find samples for each of these functions below.
 - Generate user tokens and TURN credentials [synchronously][sample_identity] or [asynchronously][sample_identity_async]
 
<!-- LINKS -->
[sample_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Identity/samples/Sample1_CommunicationIdentityClient.md
[sample_identity_async]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Identity/samples/Sample1_CommunicationIdentityClientAsync.md
