---
page_type: sample
languages:
- csharp
products:
- azure
- azure-communication
name: Azure Communication SIP routing samples for .NET
description: Samples for the Azure.Communication.SipRouting client library
---

# Azure Communication SIP routing SDK samples

Azure Communication SIP routing is a client library that is used to configure PSTN related settings for ACS resource.
To get started you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create Azure Communication Services resource. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows to do following operations:
 - Setup [SipTrunk][telephony] configuration and routing rules for [Sip interface][sip];

 #### You can find samples for each of these functions below.
 - Manage Sip routing configurations [synchronously][sample_callingconfiguration] and [asynchronously][sample_callingconfiguration_async]

<!-- LINKS -->
[sample_callingconfiguration]: https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/communication-calling_config/sdk/communication/Azure.Communication.SipRouting/samples/Sample1_ManageSipTrunkConfiguration.md
[sample_callingconfiguration_async]: https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/communication-calling_config/sdk/communication/Azure.Communication.SipRouting/samples/Sample1_ManageSipTrunkConfigurationAsync.md
[telephony]: https://docs.microsoft.com/azure/communication-services/concepts/telephony-sms/telephony-concept
[sip]: https://docs.microsoft.com/azure/communication-services/concepts/telephony-sms/sip-interface-infrastructure
