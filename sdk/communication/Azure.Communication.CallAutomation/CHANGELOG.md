# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added
- StartRecording now accepts PauseOnStart.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2023-11-23)

### Features Added
- Mid-Call actions support overriding callback uri 
- Cancel Add Participant Invitation 
- Support transfer a participant in a group call to another participant
- Add Custom Calling Context payload to Transfer and AddParticipant API

## 1.1.0-beta.1 (2023-08-17)

### Features Added
- Play and recognize supports TTS and SSML source prompts.
- Recognize supports choices and freeform speech.
- Start/Stop continuous DTMF recognition by subscribing/unsubscribing to tones.
- Send DTMF tones to a participant in the call.
- Mute participants in the call.

## 1.0.0 (2023-06-14)

### Features Added
- Outbound calls can now be created without providing a User Identifier. This value can be specified in the CallAutomationClientOption if desired.
- AnswerCall now accepts OperationContext.
- Calls can be answered by a specific communication identifier user.
- RemoveParticipant now sends success and failure events with the request.
- ParticipantsUpdated event now includes a sequence number to distinguish the ordering of events.
- CallConnectionProperties now includes CorrelationId.
- StartRecording now accepts ChannelAffinity.
- Added EventProcessor, an easy and powerful way to handle Call Automation events. See README for details.

### Breaking Changes
- AddParticipant and RemoveParticipant now only accept one participant at a time.
- CallSource has been flattened out.
- CallInvite model replaces previous models for handling outbound calls.

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
