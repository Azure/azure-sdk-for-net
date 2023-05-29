# Release History

## 1.0.9-beta.2 (Unreleased)
- Fix CallDialog creation
- Fix Dialog event parsing

## 1.0.4-alpha.8 (Unreleased)
 - DialogId is now a string and added to all event classes
 - code is updated to snapshot from 2023-05-25

## 1.0.3-alpha.7 (Unreleased)
 - change botId to botAppId, change type from Guid to string

## 1.0.1-alpha.7 (Unreleased)
 - DialogContext in StartDialogOption is now of type IDictionary<string, object>
 - StatDialog now takes dialogId of type Guid
 - Remove TargetParticipant from StartDialogOptions

## 1.0.1-alpha.6 (Unreleased)
- Added Conversation Conductor events

## 1.0.1-alpha.3 (Unreleased)
- Added DialogInputType to all events

## 1.0.1-alpha.2 (Unreleased)
- Replaced pVA with DLGaaS
- Removed DialogSessionId
- StopDialog no longer needs any parameters to run

## 1.0.1-alpha.1 (Unreleased)

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2022-11-07)
This is a refresh of Azure Communication Service's Calling-Server library. It is now called Call Automation. Call Automation enables developers to build call workflows. Personalise customer interactions by listening to call events and take actions based on your business logic. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Features Added
- Create outbound calls to an Azure Communication Service user or a phone number.
- Answer/Redirect/Reject incoming call from an Azure Communication Service user or a phone number.
- Transfer the call to another participant.
- List, add or remove participants from the call.
- Hangup or terminate the call.
- Play audio files to one or more participants in the call.
- Recognize incoming DTMF in the call.
- Record calls with option to start/resume/stop.
- Record mixed and unmixed audio recordings.
- Download recordings.
- Parse various events happening in the call, such as CallConnected and PlayCompleted event.

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.CallAutomation/README.md
[Overview]: https://learn.microsoft.com/azure/communication-services/concepts/voice-video-calling/call-automation
[Demo Video]: https://ignite.microsoft.com/sessions/14a36f87-d1a2-4882-92a7-70f2c16a306a
[Incoming Call Concept]: https://learn.microsoft.com/azure/communication-services/concepts/voice-video-calling/incoming-call-notification
[Build a customer interaction workflow using Call Automation]: https://learn.microsoft.com/azure/communication-services/quickstarts/voice-video-calling/callflows-for-customer-interactions
