﻿---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication-services
name: Azure Communication Server Calling samples for .NET
description: Samples for the Azure.Communication.Calling.Server client library
---

# Azure Communication Server Calling SDK samples

Azure Communication Server Calling is a client library that provides the functionality to make call between user identities.
To get started you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create Azure Communication Services resource. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows to do following operations:
 - Create a Call from a Azure Communication Resource identity to a phone number
 - Specify request payload for the created call.

 #### You can find samples for each of these functions below.
 - CreateCall [synchronously][sample_servercalling] or [asynchronously][sample_servercalling_async]

<!-- LINKS -->
[sample_servercalling]: https://github.com/Azure/azure-sdk-for-net/blob/9e82a99869d0f47c73b66191e04530537259db60/sdk/communication/Azure.Communication.Calling.Server/tests/samples/Sample1_CreateCall.md
[sample_servercalling_async]: https://github.com/Azure/azure-sdk-for-net/blob/9e82a99869d0f47c73b66191e04530537259db60/sdk/communication/Azure.Communication.Calling.Server/tests/samples/Sample1_CreateCallAsync.md
