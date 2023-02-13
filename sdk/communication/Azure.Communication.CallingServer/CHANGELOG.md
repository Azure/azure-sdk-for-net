# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added
- concept of in-call and out-call removed 
- Optimized the logic for deserializing types derived from the `CommunicationIdentifier`.

### Breaking Changes
- CallConnection object removed due to everything now being out-call

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2021-10-05)

### Features Added
- Support for Audio Only Recording. User can provide with content Type e.g Audio/AudioVideo, user can also provide with channel type e.g Mixed/UnMixed, and user can also provide format type e.g mp4, mp3.

## 1.0.0-beta.2 (2021-07-23)

### Key Bugs Fixed
- Downloading a recording from a different region no longer fails authentication

## 1.0.0-beta.1 (2021-06-24)
This is the first release of Azure Communication Service Call Automation. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Features Added
- Create outbound call to an Azure Communication Service user or a phone number.
- Hangup and delete the existing call.
- Play audio in the call.
- Out-call apis for call recording including start, pause, resume stop and get state.
- Subscribe to and receive [DTMF][DTMF] tones via events.
- Add and remove participants from the call.
- Recording download apis.

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.CallingServer/README.md
[DTMF]: https://en.wikipedia.org/wiki/Dual-tone_multi-frequency_signaling

